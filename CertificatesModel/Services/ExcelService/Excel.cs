using System;
using System.IO;
using System.Diagnostics;
using OfficeOpenXml;
using CertificatesModel.Components;

namespace CertificatesModel.ExcelService
{
    public static class Excel
    {
        // путь сохранения файла акта
        /// <summary>
        /// Формирование акта према/передачи в формате .xlsx
        /// </summary>
        /// <param name="certs">Перечень свидетельств</param>
        /// <param name="args">Дополнительные параметры</param>
        public static string MakeNewAct(Certificate[] certs, AdditionalData args)
        {
            string clientName = certs[0].ClientName.Replace('\"', '\'');
            string path = Path.Combine(args.AktFolderPath, $"Акт приема-передачи №{args.AktNumber}_{clientName}.xlsx");
            
            // Проверяем указано ли ФИО представителя Инкомсистем
            if (args.Name.Length <= 0)
                args.Name = "_____________________________________";

            string family = FIO.MakeGenitiveCase(args.Name);

            //Creates a blank workbook. Use the using statment, so the package is disposed when we are done.
            using (var p = new ExcelPackage())
            {
                //A workbook must have at least on cell, so lets add one... 
                var ws = p.Workbook.Worksheets.Add("MySheet");

                ws.PrinterSettings.PrintArea = ws.Cells["a1:f28"];
                ws.PrinterSettings.FitToPage = true;
                ws.PrinterSettings.FitToWidth = 1;

                //To set values in the spreadsheet use the Cells indexer.

                // Шапка
                ws.Cells[2, 1].Value = $"АКТ №{args.AktNumber}-{DateTime.Now.ToString("yy")} \r\nПриема/Передачи документов";
                ws.Cells[2, 1].Style.WrapText = true;

                ws.Cells[3, 1].Value = "г.Казань";
                ws.Cells[3, 5].Value = DateTime.Now;
                ws.Cells[3, 5].Style.Numberformat.Format = "dd MMMM yyyy г.";
                ws.Cells[4, 1].Value = $"ЗАО НИЦ «ИНКОМСИСТЕМ» в лице  {family} с одной стороны, передало, а  {clientName}   в лице _____________________________________________ с другой стороны приняло следующие документы:";
                ws.Cells[4, 1, 4, 6].Style.WrapText = true;
                // заголовки
                ws.Cells[5, 1].Value = "№п/п";
                ws.Cells[5, 2].Value = "Наименование";
                ws.Cells[5, 3].Value = "Заводской номер";
                ws.Cells[5, 4].Value = "Кол-во листов";
                ws.Cells[5, 5].Value = "№ Св-ва";
                ws.Cells[5, 6].Value = "Дата св-ва";
                // значения таблицы и формат ячеек
                int j = 0;
                for (int i = 0; i < certs.Length; i++)
                {
                    ws.Cells[6 + i, 1].Value = i + 1;
                    ws.Cells[6 + i, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    ws.Cells[6 + i, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    if (args.Flags[i] == "True")
                        ws.Cells[6 + i, 2].Value = $"Св-во о поверке+протокол на {certs[i].DeviceName}";
                    else
                        ws.Cells[6 + i, 2].Value = $"Св-во о поверке на {certs[i].DeviceName}";
                    ws.Cells[6 + i, 2].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Bottom;
                    ws.Cells[6 + i, 2].Style.WrapText = true;

                    ws.Cells[6 + i, 3].Value = certs[i].SerialNumber;
                    ws.Cells[6 + i, 3].Style.WrapText = true;
                    ws.Cells[6 + i, 3].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    ws.Cells[6 + i, 3].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    ws.Cells[6 + i, 4].Value = args.Pages[i];
                    ws.Cells[6 + i, 4].Style.WrapText = true;
                    ws.Cells[6 + i, 4].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    ws.Cells[6 + i, 4].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    ws.Cells[6 + i, 5].Value = certs[i].CertificateNumber;
                    ws.Cells[6 + i, 5].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    ws.Cells[6 + i, 5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells[6 + i, 3].Style.WrapText = true;

                    ws.Cells[6 + i, 6].Value = certs[i].CalibrationDate;
                    ws.Cells[6 + i, 6].Style.Numberformat.Format = "dd.MM.yyyy";
                    ws.Cells[6 + i, 6].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    ws.Cells[6 + i, 6].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    j = 8 + i;
                }

                // подписи
                ws.Cells[j, 1].Value = "Передал документы";
                ws.Cells[j + 2, 1].Value = "\"______\"  __________________  20_____ г.";
                ws.Cells[j + 4, 1].Value = "Принял документы";
                ws.Cells[j + 6, 1].Value = "\"______\"  __________________  20_____ г.";

                ws.Cells[j + 2, 3].Value = "_______________";
                ws.Cells[j + 6, 3].Value = "_______________";
                ws.Cells[j + 3, 4].Value = "ФИО";
                ws.Cells[j + 7, 4].Value = "ФИО";
                ws.Cells[j + 3, 3].Value = "     Подпись";
                ws.Cells[j + 7, 3].Value = "     Подпись";

                // высота строк
                ws.Row(1).Height = 15;
                ws.Row(2).Height = 90.75;
                ws.Row(3).Height = 23.25;
                ws.Row(4).Height = 55.5;
                ws.Row(5).Height = 15;

                // ширина столбцов
                ws.Column(1).SetTrueColumnWidth(5.43);
                ws.Column(2).SetTrueColumnWidth(43.57);
                ws.Column(3).SetTrueColumnWidth(17.14);
                ws.Column(4).SetTrueColumnWidth(12.71);
                ws.Column(5).SetTrueColumnWidth(11.71);
                ws.Column(6).SetTrueColumnWidth(12.29);


                // Выравнивание текста
                ws.Cells["a4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                ws.Cells["a2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["a3:f3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["e5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["f5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                ws.Cells[j + 2, 4, j + 2, 5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells[j + 3, 4, j + 3, 5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells[j + 6, 4, j + 6, 5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells[j + 7, 4, j + 7, 5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // границы таблицы
                ws.Cells[5, 1, j - 2, 6].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws.Cells[5, 1, j - 2, 6].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws.Cells[5, 1, j - 2, 6].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws.Cells[5, 1, j - 2, 6].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws.Cells[j + 2, 4, j + 2, 5].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws.Cells[j + 6, 4, j + 6, 5].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                // Слияние ячеек
                ws.Cells["A2:F2"].Merge = true;
                ws.Cells["a4:f4"].Merge = true;
                ws.Cells["e3:f3"].Merge = true;
                ws.Cells["A3:b3"].Merge = true;

                ws.Cells[j + 3, 4, j + 3, 5].Merge = true;
                ws.Cells[j + 4, 4, j + 4, 5].Merge = true;

                ws.Cells[j + 6, 4, j + 6, 5].Merge = true;
                ws.Cells[j + 7, 4, j + 7, 5].Merge = true;


                ws.HeaderFooter.EvenFooter.LeftAlignedText = certs[0].ContractNumber;
                ws.HeaderFooter.OddFooter.LeftAlignedText = certs[0].ContractNumber;
                //Save the new workbook. We haven't specified the filename so use the Save as method.
                
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));

                p.SaveAs(new FileInfo(path));
                return path;
            }
        }

        public static void SetTrueColumnWidth(this ExcelColumn column, double width)
        {
            // Deduce what the column width would really get set to.
            var z = width >= (1 + 2 / 3)
                ? Math.Round((Math.Round(7 * (width - 1 / 256), 0) - 5) / 7, 2)
                : Math.Round((Math.Round(12 * (width - 1 / 256), 0) - Math.Round(5 * width, 0)) / 12, 2);

            // How far off? (will be less than 1)
            var errorAmt = width - z;

            // Calculate what amount to tack onto the original amount to result in the closest possible setting.
            var adj = width >= 1 + 2 / 3
                ? Math.Round(7 * errorAmt - 7 / 256, 0) / 7
                : Math.Round(12 * errorAmt - 12 / 256, 0) / 12 + (2 / 12);

            // Set width to a scaled-value that should result in the nearest possible value to the true desired setting.
            if (z > 0)
            {
                column.Width = width + adj;
                return;
            }

            column.Width = 0d;
        }
    }
}
