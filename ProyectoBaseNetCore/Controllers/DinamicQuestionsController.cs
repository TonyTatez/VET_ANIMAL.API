using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.DTOs.DinamicQuestionsDTOs;
using ProyectoBaseNetCore.Entities.DinamicQuestionEntities;
using ProyectoBaseNetCore.Utilidades;
using ProyectoBaseNetCore.Utilities;
using System.Data;
using static ProyectoBaseNetCore.DTOs.DinamicQuestionsDTOs.DinamicQuestionsDTO;
using static ProyectoBaseNetCore.Utilidades.QuestionTypes;

namespace ProyectoBaseNetCore.Controllers
{
    [ApiController]
    [Route("api/DinamicQuestions")]
    public class DinamicQuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IAuthorizationService authorizationService;

        private DinamicQuestionsController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration, IAuthorizationService authorizationService)
        {
            this.context = context;
            this.mapper = mapper;
            this.configuration = configuration;
            this.authorizationService = authorizationService;
        }

        [HttpPost("AddForm")]
        private async Task<ActionResult> AddForm(Form form)
        {
            var checkForm = await context.Forms.Where(x => x.FormName.ToUpper().Trim().Contains(form.FormName.ToUpper().Trim())).FirstOrDefaultAsync();
            if (checkForm is null)
            {
                await context.Forms.AddAsync(form);
                await context.SaveChangesAsync();
                return HTTPHelper.CustomHTTPResponse(HttpCode.Created, "Formulario agregado exitosamente");
            }
            else
            {
                return BadRequest("El formulario ya existe");
            }
        }

        [HttpPost("AddSection")]
        private async Task<ActionResult> AddSection(Section section)
        {
            var checkSection = await context.Sections.Where(x => x.SectionName.ToUpper().Trim().Contains(section.SectionName.ToUpper().Trim())).FirstOrDefaultAsync();
            if (checkSection is null)
            {
                await context.Sections.AddAsync(section);
                await context.SaveChangesAsync();
                return HTTPHelper.CustomHTTPResponse(HttpCode.Created, "La sección se guardo correctamente");
            }
            else
            {
                return BadRequest("La sección ya existe");
            }
        }

        [HttpPost("AddQuestion")]
        private async Task<ActionResult> AddQuestion(Question question)
        {
            var questionTypes = await context.QuestionTypes.ToListAsync();
            var checkQuestion = await context.Questions.Where(x => x.QuestionDesc.ToUpper().Trim().Equals(question.QuestionDesc.ToUpper().Trim())).FirstOrDefaultAsync();
            var catalogQuestionTypeListIds = questionTypes
                .Where(x => CatalogQuestionTypeList.Contains(x.QuestionTypeName))
                .Select(x => x.IdQuestionType)
                .ToList();
            if (checkQuestion is null)
            {
                var checkQuestionType = questionTypes.FirstOrDefault(x => x.QuestionTypeName.ToUpper().Trim().Contains(question.QuestionTypeName.ToUpper().Trim()) || x.IdQuestionType == question.IdQuestionType);
                if (checkQuestionType is null) return BadRequest("El tipo de pregunta no existe en el catalogo pregunta");

                if (CatalogQuestionTypeList.Any(x => x == question.QuestionTypeName.Trim().ToUpper()) ||
                    MultiAnswerList.Any(x => x == question.QuestionTypeName.Trim().ToUpper()) ||
                    catalogQuestionTypeListIds.Any(x => x == question.IdQuestionType))
                {
                    var checkCatalalog = await context.Catalogs.FirstOrDefaultAsync(x => x.IdCatalog == question.IdCatalog);
                    if (checkCatalalog is null)
                        return BadRequest("El id de catalogo no existe");
                    question.IdCatalog = checkCatalalog.IdCatalog;
                }
                else
                {
                    question.IdCatalog = null;
                }
                question.IdQuestionType = checkQuestionType.IdQuestionType;
                question.QuestionTypeName = checkQuestionType.QuestionTypeName;
                question.MinRequiredAnswersCount = question.MinRequiredAnswersCount <= 0 ? 1 : question.MinRequiredAnswersCount;
                question.MinAnswersCount = question.MinRequiredAnswersCount <= 0 ? 1 : question.MinRequiredAnswersCount;
                question.MaxAnswersCount = question.MaxAnswersCount <= question.MinRequiredAnswersCount ? question.MinRequiredAnswersCount : question.MaxAnswersCount;
                question.IsMultiAnswer = question.MinRequiredAnswersCount > 1;
                await context.Questions.AddAsync(question);
                await context.SaveChangesAsync();
                return HTTPHelper.CustomHTTPResponse(HttpCode.Created, "La pregunta se guardo correctamente");
            }
            else
            {
                return BadRequest("La pregunta ya existe");
            }
        }

        [HttpPost("AddQuestionType")]
        private async Task<ActionResult> AddQuestionType()
        {
            var dbQuestionTypes = await context.QuestionTypes.ToListAsync();
            var allQuestionTypes = new List<string>();
            allQuestionTypes.AddRange(DinamicQuestionsHelper.AddQuestionTypes(typeof(SingleQuestionTypes)));
            allQuestionTypes.AddRange(DinamicQuestionsHelper.AddQuestionTypes(typeof(MultiQuestionTypes)));
            allQuestionTypes.AddRange(DinamicQuestionsHelper.AddQuestionTypes(typeof(OtherQuestionTypes)));
            var questionTypesToAdd = allQuestionTypes.Where(type => !dbQuestionTypes.Any(dbType => dbType.QuestionTypeName == type))
                                                     .Select(qtype => new QuestionType { QuestionTypeName = qtype })
                                                     .ToList();
            await context.QuestionTypes.AddRangeAsync(questionTypesToAdd);
            await context.SaveChangesAsync();
            return HTTPHelper.CustomHTTPResponse(HttpCode.Created, $"Se han agregado {questionTypesToAdd.Count} tipos de pregunta");
        }

        [HttpPost("AddCatalog")]
        private async Task<ActionResult> AddCatalog(Catalog catalog)
        {
            var checkCatalog = await context.Catalogs.Where(x => x.CatalogName.ToUpper().Trim().Contains(catalog.CatalogName.ToUpper().Trim())).FirstOrDefaultAsync();
            if (checkCatalog is null)
            {
                catalog.CatalogName.ToUpper().Trim();
                context.Catalogs.Add(catalog);
                await context.SaveChangesAsync();
                return HTTPHelper.CustomHTTPResponse(HttpCode.Created, "El catálogo se guardo correctamente");
            }
            else
            {
                return BadRequest("El catálogo ya existe");
            }
        }

        [HttpPost("AddItem")]
        private async Task<ActionResult> AddItem(Item item)
        {
            var checkItem = context.Items.Where(x => x.ItemName.ToUpper().Trim().Equals(item.ItemName.ToUpper().Trim())).FirstOrDefault();
            if (checkItem is null)
            {
                await context.Items.AddAsync(item);
                await context.SaveChangesAsync();
                return HTTPHelper.CustomHTTPResponse(HttpCode.Created, "El item se guardo correctamente");
            }
            else
            {
                return BadRequest("El item ya existe");
            }
        }

        [HttpPost("AddItemsToCatalog")]
        private async Task<ActionResult> AddItemsToCatalog(ItemsHelper itemsToCatalog)
        {
            var dbCatalogsItems = await context.CatalogItems
                .OrderByDescending(x => x.CatalogOrder)
                .ToListAsync();

            var maxCatalogOrder = dbCatalogsItems.FirstOrDefault(x => x.IdCatalog == itemsToCatalog.IdCatalog)?.CatalogOrder ?? dbCatalogsItems.FirstOrDefault()?.CatalogOrder + 1 ?? 1;

            var maxItemOrder = await context.CatalogItems
                .Where(x => x.IdCatalog == itemsToCatalog.IdCatalog)
                .MaxAsync(x => (int?)x.ItemOrder) ?? 0;

            itemsToCatalog.IdItems.ForEach(async (idItem) =>
            {
                var newCatalogItem = new CatalogItem()
                {
                    IdCatalog = itemsToCatalog.IdCatalog,
                    IdItem = idItem,
                    CatalogOrder = maxCatalogOrder,
                    ItemOrder = maxItemOrder = ++maxItemOrder
                };
                await context.AddAsync(newCatalogItem);
            });

            await context.SaveChangesAsync();

            return HTTPHelper.CustomHTTPResponse(HttpCode.Created, "Se ha guardado correctamente los items");
        }

        [HttpPost("AddFormSectionQuestions")]
        private async Task<ActionResult> AddFormSectionQuestions(QuestionsHelper formSectionQuestions)
        {
            var forms = await context.Forms.ToListAsync();
            var sections = await context.Sections.ToListAsync();
            var questions = await context.Questions.ToListAsync();

            if (!(forms.Any(x => x.IdForm == formSectionQuestions.IdForm) &&
                  sections.Any(x => x.IdSection == formSectionQuestions.IdSection) &&
                  formSectionQuestions.IdQuestions.All(idPregunta => questions.Any(x => x.IdQuestion == idPregunta))
               ))
            {
                return BadRequest("El idGrupo, idSeccion o idPreguntas no existen");
            }

            var dbexistingFSQ = await context.FormSectionQuestions.ToListAsync();

            // Obtener el último FormOrder para cualquier sección en el formulario actual
            int maxFormOrder = dbexistingFSQ
                .Where(x => x.IdForm == formSectionQuestions.IdForm)
                .Max(x => (int?)x.FormOrder) ?? 0;

            // Obtener el último SectionOrder para la sección actual
            int maxSectionOrder = dbexistingFSQ
                .Where(x => x.IdForm == formSectionQuestions.IdForm && x.IdSection == formSectionQuestions.IdSection)
                .Max(x => (int?)x.SectionOrder) ?? 0;

            // Reiniciar el contador de SectionOrder si la sección pertenece a un nuevo IdForm
            if (dbexistingFSQ.Any(x => x.IdForm != formSectionQuestions.IdForm && x.IdSection == formSectionQuestions.IdSection))
            {
                maxSectionOrder = 0;
            }

            // Obtener el último QuestionOrder para la sección actual
            int maxQuestionOrder = dbexistingFSQ
                .Where(x => x.IdForm == formSectionQuestions.IdForm && x.IdSection == formSectionQuestions.IdSection)
                .Max(x => (int?)x.QuestionOrder) ?? 0;

            // Obtener el último FormOrder para cualquier formulario en la base de datos
            int maxGlobalFormOrder = dbexistingFSQ.Max(x => (int?)x.FormOrder) ?? 0;

            // Obtener el último SectionOrder para cualquier formulario y sección en la base de datos
            int maxGlobalSectionOrder = dbexistingFSQ
                .Where(x => x.IdForm == formSectionQuestions.IdForm)
                .Max(x => (int?)x.SectionOrder) ?? 0;

            var newRegister = formSectionQuestions.IdQuestions
                .Where(x => !dbexistingFSQ.Any(d => d.IdForm == formSectionQuestions.IdForm && d.IdSection == formSectionQuestions.IdSection && d.IdQuestion == x))
                .Select((x, index) => new FormSectionQuestion
                {
                    IdForm = formSectionQuestions.IdForm,
                    IdSection = formSectionQuestions.IdSection,
                    IdQuestion = x,
                    FormOrder = maxFormOrder != 0 ? maxFormOrder : maxGlobalFormOrder + 1,
                    SectionOrder = maxSectionOrder != 0 ? maxSectionOrder : maxGlobalSectionOrder + 1,
                    QuestionOrder = maxQuestionOrder + index + 1,
                })
                .ToList();

            // Incrementar los contadores de FormOrder y SectionOrder si se ha añadido una pregunta a la sección actual
            if (newRegister.Any(x => x.IdSection == formSectionQuestions.IdSection))
            {
                maxFormOrder++;
                maxSectionOrder++;
            }

            if (newRegister.Count > 0)
            {
                await context.FormSectionQuestions.AddRangeAsync(newRegister);
                await context.SaveChangesAsync();
            }
            return HTTPHelper.CustomHTTPResponse(HttpCode.Created, "Se registraron las preguntas correctamente");
        }

        [HttpPost("SendAnswers")]
        private async Task<ActionResult> SendAnswers(FormDTO form) => Ok(
        await Task.Run(() =>
        {
            List<object> allAnswers = new List<object>();
            form.Sections.ForEach(section =>
                section.Questions.ForEach(question =>
                {
                    dynamic answerValue = question.Answer;
                    answerValue = DinamicQuestionsHelper.CleanAnswerValue(answerValue); // Limpia la respuesta
                    if (DinamicQuestionsHelper.IsSingleItemAnswer(question.QuestionTypeName))
                        allAnswers.Add(DinamicQuestionsHelper.CreateAnswerObject(form, section, question, (answerValue as ItemDTO), (answerValue as ItemDTO).Answer));
                    else if (DinamicQuestionsHelper.IsMultiItemAnswer(question.QuestionTypeName))
                        (answerValue as List<ItemDTO>).ForEach(answer => allAnswers.Add(DinamicQuestionsHelper.CreateAnswerObject(form, section, question, answer, answer.Answer)));
                    else
                        allAnswers.Add(DinamicQuestionsHelper.CreateAnswerObject(form, section, question, null, answerValue));
                }));
            return allAnswers;
        }));

        [HttpGet("DinamicQuestions")]
        private async Task<ActionResult> DinamicQuestions() => Ok(
        await Task.Run(async () =>
        {
            var forms = await context.Forms.AsNoTracking().ToListAsync();
            var formSectionQuestions = await context.FormSectionQuestions.AsNoTracking().ToListAsync();
            var questions = await context.Questions.AsNoTracking().ToListAsync();
            var catalogItem = await context.CatalogItems.AsNoTracking().ToListAsync();
            var items = await context.Items.AsNoTracking().ToListAsync();
            var dinamicQuestions = new List<FormDTO>();
            forms.ForEach(form =>
            {
                var sectionList = new List<SectionDTO>();
                var formSectionQuestion = formSectionQuestions
                    .Where(gp => gp.IdForm == form.IdForm)
                    .GroupBy(gp => gp.IdSection).ToList();
                formSectionQuestion.ForEach(sectionQuestion =>
                {
                    var section = context.Sections.FirstOrDefault(s => s.IdSection == sectionQuestion.Key);
                    if (section != null)
                    {
                        var questionDTOs = new List<QuestionDTO>();
                        sectionQuestion.Select(sp => sp.IdQuestion).ToList().ForEach(idQuestion =>
                        {
                            var question = questions.FirstOrDefault(p => p.IdQuestion == idQuestion);
                            if (question != null)
                            {
                                var questionDTO = new QuestionDTO
                                {
                                    IdQuestion = question.IdQuestion,
                                    QuestionDesc = question.QuestionDesc,
                                    IdCatalog = question.IdCatalog ?? 0,
                                    Placeholder = question.Placeholder ?? "",
                                    QuestionTypeName = question.QuestionTypeName,
                                    IdQuestionType = question.IdQuestionType,
                                    IsVisible = question.IsVisible,
                                    IsEnable = question.IsEnable,
                                    IsRequired = question.IsRequired,
                                    IsMultiAnswer = question.IsMultiAnswer,
                                    Answer = DinamicQuestionsHelper.IsMultiItemAnswer(question.QuestionTypeName) ? catalogItem
                                            .Where(ci => ci.IdCatalog == question.IdCatalog.Value)
                                            .Join(items, ci => ci.IdItem, i => i.IdItem, (ci, i) => new ItemDTO
                                            {
                                                IdItem = i.IdItem,
                                                ItemName = i.ItemName,
                                                Answer = DinamicQuestionsHelper.GetInitialItemAnswerBasedOnType(question.QuestionTypeName)
                                            })
                                            .ToList() : DinamicQuestionsHelper.GetInitialAnswerBasedOnType(question.QuestionTypeName),
                                    Catalog = DinamicQuestionsHelper.IsMultiItemAnswer(question.QuestionTypeName) ? new List<ItemDTO>() : question.IdCatalog.HasValue
                                        ? catalogItem
                                            .Where(ci => ci.IdCatalog == question.IdCatalog.Value)
                                            .Join(items, ci => ci.IdItem, i => i.IdItem, (ci, i) => new ItemDTO
                                            {
                                                IdItem = i.IdItem,
                                                ItemName = i.ItemName,
                                                Answer = ""
                                            })
                                            .ToList()
                                        : new List<ItemDTO>()
                                };
                                int repeatCount = Math.Max(1, question.MinRequiredAnswersCount);
                                for (int i = 0; i < repeatCount; i++)
                                {
                                    questionDTOs.Add(questionDTO);
                                }
                            }
                        }
                        );
                        var sectionDTO = new SectionDTO
                        {
                            IdSection = section.IdSection,
                            SectionName = section.SectionName,
                            IsVisible = section.IsVisible,
                            IsEnable = section.IsEnable,
                            Questions = questionDTOs
                        };
                        sectionList.Add(sectionDTO);
                    }
                }
                );
                var FormDTO = new FormDTO
                {
                    IdForm = form.IdForm,
                    SyncIdForm = Guid.NewGuid(), // Cambia esto por el valor correcto
                    FormName = form.FormName,
                    Sections = sectionList
                };
                dinamicQuestions.Add(FormDTO);
            });
            return dinamicQuestions;
        }));

        [HttpPost("AddTestQuestions")]
        private async Task<ActionResult> AddTestQuestions()
        {
            await AddQuestionType();
            await AddForm(new Form { FormName = "Form 1" });
            await AddSection(new Section { SectionName = "Section 1" , IsEnable= true, IsVisible = true });
            await AddCatalog(new Catalog { CatalogName = "Catalog 1" });
            await AddItem(new Item { ItemName = "Item 1" });
            await AddItem(new Item { ItemName = "Item 2" });
            await AddItem(new Item { ItemName = "Item 3" });
            await AddItemsToCatalog(new ItemsHelper { IdCatalog = 1, IdItems = new List<long> { 1, 2, 3 } });
            long i = 1;
            var qTypes = new List<string>();
            qTypes.AddRange(DinamicQuestionsHelper.AddQuestionTypes(typeof(SingleQuestionTypes)));
            qTypes.AddRange(DinamicQuestionsHelper.AddQuestionTypes(typeof(MultiQuestionTypes)));
            qTypes.AddRange(DinamicQuestionsHelper.AddQuestionTypes(typeof(OtherQuestionTypes)));
            foreach (var qType in qTypes)
            {
                await AddQuestion(new Question
                {
                    QuestionDesc = $"Question {i}",
                    QuestionTypeName = qType,
                    IdCatalog = 1,
                    IsEnable = true,
                    IsVisible = true,
                }).ConfigureAwait(false);
                i++;
            }
            List<long> GetIds() => Enumerable.Range(1, (int)i - 1).Select(x => (long)x).ToList();
            var questionsIds = (await context.Questions.ToListAsync()).Select(x => x.IdCatalog ?? 0).ToList();
            await AddFormSectionQuestions(new QuestionsHelper { IdForm = 1, IdSection = 1, IdQuestions = GetIds() });
            return Ok("Preguntas de prueba agregadas");
        }
    }
}