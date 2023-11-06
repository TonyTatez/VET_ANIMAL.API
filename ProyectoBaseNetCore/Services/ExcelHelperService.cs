using NPOI.SS.UserModel;
using System.Text;

namespace ProyectoBaseNetCore.Services
{
    public class ExcelHelperService
    {
        public async Task<Dictionary<string, object>> ValidarFormatoArchivo(ISheet sheet, string[] expectedHeaders)
        {
            var messageError = new StringBuilder();
            bool hasError = false;

            for (int columnIndex = 0; columnIndex < expectedHeaders.Length; columnIndex++)
            {
                var cellValue = sheet.GetRow(0)?.GetCell(columnIndex)?.ToString();
                if (cellValue == null || cellValue.Trim().ToUpper() != expectedHeaders[columnIndex].Trim().ToUpper())
                {
                    hasError = true;
                    messageError.AppendLine($"La columna {columnIndex + 1} no cumple con el formato.");
                }
            }

            return await Task.Run(() => new Dictionary<string, object>
                {
                    { "hasError", hasError },
                    { "messageError", messageError.ToString() }
                });
        }
    }
}
