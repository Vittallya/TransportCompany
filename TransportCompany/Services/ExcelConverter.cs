using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportCompany.ViewModels;

namespace TransportCompany.Services
{
    public class ExcelConverter
    {

        public byte[] Convert(ReportData reportData)
        {
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Main");


            sheet.Cells[1, 1].Value = "Рентабельность:";
            sheet.Cells[2, 1].Value = "Средний чек:";
            sheet.Cells[4, 1].Value = "Период:";
            sheet.Cells[5, 1].Value = "Доходы:";
            sheet.Cells[6, 1].Value = "Расходы:";
            sheet.Cells[7, 1].Value = "Прибыль:";


            sheet.Cells[1, 2].Value = reportData.Efficiency;
            sheet.Cells[1, 2].Style.Numberformat.Format = "# ##0,00 ₽";
            sheet.Cells[2, 2].Value = reportData.MidSell;
            sheet.Cells[2, 2].Style.Numberformat.Format = "0,00%";

            int i = 0;

            for (i = 0; i < reportData.Labels.Length; i++)
                sheet.Cells[4, i+2].Value = reportData.Labels[i];

            for (i = 0; i < reportData.Incomes.Length; i++)
                sheet.Cells[5, i+2].Value = reportData.Incomes[i];

            for (i = 0; i < reportData.Outcomes.Length; i++)
                sheet.Cells[6, i+2].Value = reportData.Outcomes[i];

            for (i = 0; i < reportData.Profits.Length; i++)
                sheet.Cells[7, i+2].Value = reportData.Profits[i];

            sheet.Column(1).Width = 20;
            sheet.Column(1).Style.Font.Bold = true;
            sheet.Row(4).Style.Font.Bold = true;

            sheet.Cells[4, 1, 7, reportData.Labels.Length + 1].Style.Border.BorderAround(ExcelBorderStyle.Double);
            //sheet.Cells[5, 2, 7, reportData.Labels.Length].Style.Numberformat.Format = "# ##0,00 ₽";

            return package.GetAsByteArray();
        }
    }
}
