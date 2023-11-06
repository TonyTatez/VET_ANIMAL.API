using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using static ProyectoBaseNetCore.DTOs.DinamicQuestionsDTOs.DinamicQuestionsDTO;

namespace ProyectoBaseNetCore.Utilidades
{
    public static class QuestionTypes
    {
        public static class SingleQuestionTypes
        {
            public const string TEXT = "TEXT";
            public const string NUMBER = "NUMBER";
            public const string DATE = "DATE";
            public const string TIME = "TIME";
            public const string DATETIME = "DATETIME";
            public const string RADIOBUTTON = "RADIOBUTTON";
            public const string SWITCH = "SWITCH";
            public const string SELECTOR = "SELECTOR";
            public const string CALCULATION = "CALCULATION";
        }

        public static class MultiQuestionTypes
        {
            public const string MULTITEXT = "MULTITEXT";
            public const string MULTINUMBER = "MULTINUMBER";
            public const string MULTIDATE = "MULTIDATE";
            public const string MULTITIME = "MULTITIME";
            public const string MULTIDATETIME = "MULTIDATETIME";
            public const string MULTIRADIOBUTTON = "MULTIRADIOBUTTON";
            public const string MULTIRADIOBUTTONSINGLEANSWER = "MULTIRADIOBUTTONSINGLEANSWER";
            public const string MULTISWITCH = "MULTISWITCH";
            public const string MULTISWITCHSINGLEANSWER = "MULTISWITCHSINGLEANSWER";
        }

        public static class OtherQuestionTypes
        {
        }

        public static readonly List<string> ItemQuestionTypeList = new()
        {
                SingleQuestionTypes.TEXT,
                SingleQuestionTypes.NUMBER,
                SingleQuestionTypes.DATE,
                SingleQuestionTypes.TIME,
                SingleQuestionTypes.DATETIME,
                SingleQuestionTypes.RADIOBUTTON,
                SingleQuestionTypes.SWITCH,
        };

        public static readonly List<string> CatalogQuestionTypeList = new()
        {
                SingleQuestionTypes.SELECTOR,
        };

        public static readonly List<string> MultiAnswerList = new()
        {
                MultiQuestionTypes.MULTITEXT,
                MultiQuestionTypes.MULTINUMBER,
                MultiQuestionTypes.MULTIDATE,
                MultiQuestionTypes.MULTITIME,
                MultiQuestionTypes.MULTIDATETIME,
                MultiQuestionTypes.MULTISWITCH,
                MultiQuestionTypes.MULTISWITCHSINGLEANSWER,
                MultiQuestionTypes.MULTIRADIOBUTTON,
                MultiQuestionTypes.MULTIRADIOBUTTONSINGLEANSWER,
        };
    }

    public static class DinamicQuestionsHelper
    {
        public static bool IsMultiItemAnswer(string questionTypeName) => QuestionTypes.MultiAnswerList.Contains(questionTypeName);

        public static bool IsSingleItemAnswer(string questionTypeName) => QuestionTypes.CatalogQuestionTypeList.Contains(questionTypeName);

        public static IEnumerable<string> AddQuestionTypes(Type typeClass) => typeClass.GetFields(BindingFlags.Public | BindingFlags.Static)
                                                 .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
                                                 .Select(fi => (string)fi.GetRawConstantValue());

        public static Func<string, object> GetInitialAnswerBasedOnType = type =>
        type switch
        {
            //Single Data Types
            //string
            QuestionTypes.SingleQuestionTypes.TEXT or
            QuestionTypes.SingleQuestionTypes.NUMBER or
            QuestionTypes.SingleQuestionTypes.DATE or
            QuestionTypes.SingleQuestionTypes.TIME or
            QuestionTypes.SingleQuestionTypes.DATETIME or
            QuestionTypes.SingleQuestionTypes.CALCULATION => "",
            //bool
            QuestionTypes.SingleQuestionTypes.RADIOBUTTON or
            QuestionTypes.SingleQuestionTypes.SWITCH => false,
            //object
            QuestionTypes.SingleQuestionTypes.SELECTOR => new ItemDTO()
            {
                IdItem = 0,
                Answer = "",
                Description = "",
            },
            //Multi Data Types
            //string list
            QuestionTypes.MultiQuestionTypes.MULTITEXT or
            QuestionTypes.MultiQuestionTypes.MULTINUMBER or
            QuestionTypes.MultiQuestionTypes.MULTIDATE or
            QuestionTypes.MultiQuestionTypes.MULTITIME or
            QuestionTypes.MultiQuestionTypes.MULTIDATETIME => new List<string>(),
            //object list
            QuestionTypes.MultiQuestionTypes.MULTISWITCH or
            QuestionTypes.MultiQuestionTypes.MULTISWITCHSINGLEANSWER or
            QuestionTypes.MultiQuestionTypes.MULTIRADIOBUTTON or
            QuestionTypes.MultiQuestionTypes.MULTIRADIOBUTTONSINGLEANSWER
            => new List<ItemDTO>(),
            _ => new object()
        };

        public static Func<string, object> GetInitialItemAnswerBasedOnType = type =>
       type switch
       {
           //object list
           QuestionTypes.MultiQuestionTypes.MULTISWITCH or
            QuestionTypes.MultiQuestionTypes.MULTISWITCHSINGLEANSWER or
            QuestionTypes.MultiQuestionTypes.MULTIRADIOBUTTON or
            QuestionTypes.MultiQuestionTypes.MULTIRADIOBUTTONSINGLEANSWER => false,
           //Multi Data Types
           //string list
           QuestionTypes.MultiQuestionTypes.MULTITEXT or
           QuestionTypes.MultiQuestionTypes.MULTINUMBER or
           QuestionTypes.MultiQuestionTypes.MULTIDATE or
           QuestionTypes.MultiQuestionTypes.MULTITIME or
           QuestionTypes.MultiQuestionTypes.MULTIDATETIME or
           _ => ""
       };

        #region AnswersHelper

        public static Func<string, object, object> GetAnswer = (type, answer) => type switch
        {
            //string
            QuestionTypes.SingleQuestionTypes.TEXT or
            QuestionTypes.SingleQuestionTypes.NUMBER or
            QuestionTypes.SingleQuestionTypes.DATE or
            QuestionTypes.SingleQuestionTypes.TIME or
            QuestionTypes.SingleQuestionTypes.DATETIME or
            QuestionTypes.SingleQuestionTypes.CALCULATION => answer ?? "",
            //bool
            QuestionTypes.SingleQuestionTypes.RADIOBUTTON or
            QuestionTypes.SingleQuestionTypes.SWITCH => false,
            //object
            QuestionTypes.MultiQuestionTypes.MULTISWITCH or
            QuestionTypes.MultiQuestionTypes.MULTISWITCHSINGLEANSWER or
            QuestionTypes.MultiQuestionTypes.MULTIRADIOBUTTON or
            QuestionTypes.MultiQuestionTypes.MULTIRADIOBUTTONSINGLEANSWER when answer is ItemDTO catalogAnswer => catalogAnswer.ItemName ?? "",
            _ => ""
        };

        public static object GetAnswerValue(QuestionDTO question)
        {
            var answerItem = question.Answer as ItemDTO;
            if (answerItem != null && question.QuestionTypeName == QuestionTypes.SingleQuestionTypes.SELECTOR)
            {
                return answerItem.IdItem != 0
                    ? new
                    {
                        answerItem.IdItem,
                        answerItem.ItemName
                    }
                    : null;
            }
            else
            {
                return GetAnswer(question.QuestionTypeName, question.Answer);
            }
        }

        public static bool ShouldAddCatalog(ItemDTO catalogo) => catalogo.IdItem != 0 && !string.IsNullOrEmpty(catalogo.ItemName);

        public static object CreateAnswerObject(FormDTO form, SectionDTO section, QuestionDTO question, ItemDTO item, string answerValue) => new
        {
            form.SyncIdForm,
            form.IdForm,
            form.FormName,
            section.IdSection,
            section.SectionName,
            question.IdQuestion,
            question.QuestionDesc,
            question.IdQuestionType,
            question.QuestionTypeName,
            IdCatalog = question.IdCatalog ?? null,
            IdItem = item?.IdItem ?? null,
            ItemName = item?.ItemName ?? null,
            Answer = !string.IsNullOrEmpty(answerValue)
            ? (item != null ? item.Answer : answerValue)
            : null
        };

        public static dynamic CleanAnswerValue(dynamic answerValue)
        {
            if (answerValue is not JToken token)
                return answerValue;
            // Convierte el token en una cadena JSON
            string jsonString = token.ToString();
            // Limpia la cadena JSON eliminando las llaves adicionales
            jsonString = CleanJsonString(jsonString);
            if (jsonString.StartsWith("{"))
                return JsonConvert.DeserializeObject<ItemDTO>(jsonString);
            else
                return JsonConvert.DeserializeObject<List<ItemDTO>>(jsonString);
        }

        public static string CleanJsonString(string jsonString)
        {
            // Elimina las llaves adicionales de los extremos del JSON
            jsonString = Regex.Replace(jsonString, @"^\s*\{+", "{");
            jsonString = Regex.Replace(jsonString, @"\}+\s*$", "}");
            return jsonString;
        }

        #endregion AnswersHelper
    }
}