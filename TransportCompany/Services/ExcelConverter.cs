using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
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
            sheet.Cells[3, 1].Value = "Общее число заказов:";
            sheet.Cells[4, 1].Value = "Суммарный доход:";
            sheet.Cells[5, 1].Value = "Суммарный расход:";
            sheet.Cells[6, 1].Value = "Суммарная прибыль:";
            sheet.Cells[7, 1].Value = "Период:";
            sheet.Cells[8, 1].Value = "Доходы:";
            sheet.Cells[9, 1].Value = "Расходы:";
            sheet.Cells[10, 1].Value = "Прибыль:";


            sheet.Cells[1, 2].Value = reportData.Efficiency;
            sheet.Cells[2, 2].Value = reportData.MidSell;
            sheet.Cells[3, 2].Value = reportData.TotalCount;
            sheet.Cells[4, 2].Value = reportData.IncomeTotal;
            sheet.Cells[5, 2].Value = reportData.OutcomeTotal;
            sheet.Cells[6, 2].Value = reportData.ProftTotal;
            sheet.Cells[1, 2].Style.Numberformat.Format = "# ##0,00 ₽";
            sheet.Cells[2, 2].Style.Numberformat.Format = "0,00%";

            int i = 0;

            for (i = 0; i < reportData.Labels.Length; i++)
                sheet.Cells[7, i+2].Value = reportData.Labels[i];

            for (i = 0; i < reportData.Incomes.Length; i++)
                sheet.Cells[8, i+2].Value = reportData.Incomes[i];

            for (i = 0; i < reportData.Outcomes.Length; i++)
                sheet.Cells[9, i+2].Value = reportData.Outcomes[i];

            for (i = 0; i < reportData.Profits.Length; i++)
                sheet.Cells[10, i+2].Value = reportData.Profits[i];

            sheet.Column(1).Width = 20;
            sheet.Column(1).Style.Font.Bold = true;
            sheet.Row(4).Style.Font.Bold = true;

            sheet.Cells[7, 1, 10, reportData.Labels.Length + 1].Style.Border.BorderAround(ExcelBorderStyle.Dashed);
            //sheet.Cells[5, 2, 7, reportData.Labels.Length].Style.Numberformat.Format = "# ##0,00 ₽";

            var chart = sheet.Drawings.AddChart("FindingsChart", OfficeOpenXml.Drawing.Chart.eChartType.Line);
            chart.Title.Text = "График";
            chart.SetPosition(13, 0, 0, 0);
            chart.SetSize(800, 400);
            //chart.Series.Add(sheet.Cells[7, 2, 7, reportData.Labels.Length]);
            chart.Series.Add(sheet.Cells[8, 2, 8, reportData.Labels.Length + 1], sheet.Cells[7, 2, 7, reportData.Labels.Length + 1]).Header = "Доход";
            
            chart.Series.Add(sheet.Cells[9, 2, 9, reportData.Labels.Length + 1], sheet.Cells[7, 2, 7, reportData.Labels.Length + 1]).Header = "Расход";
            chart.Series.Add(sheet.Cells[10, 2, 10, reportData.Labels.Length + 1], sheet.Cells[7, 2, 7, reportData.Labels.Length + 1]).Header = "Прибыль";
            //chart.Series.Add();

            return package.GetAsByteArray();
        }
    }
}
