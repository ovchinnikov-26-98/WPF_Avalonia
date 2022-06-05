using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace TSvsGTD_Avalonia.Models
{
    public class ExportExcel
    {
        /// <summary>
        ///  Создание и заполнения эксель файла
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        public static void WriteExcel(DateTimeOffset beginDate, DateTimeOffset endDate)
        {
            DateTime BeginDate = beginDate.DateTime;
            DateTime EndDate = endDate.DateTime;

            var messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Начало метода", ButtonEnum.Ok);
            messageBoxStandardWindow.Show();
            
            //List<Mistakes> mistakesInSklad = GetAndCompareEntities.CompareAltaInSkladWithArm(BeginDate, EndDate);
            //List<Mistakes> mistakesOutSklad = GetAndCompareEntities.CompareAltaOutSkladaWithArm(BeginDate, EndDate);
            //var dir = ("xlsx");
            //if (!Directory.Exists(dir))
            //    Directory.CreateDirectory(dir);
            var filename = ("TSvsGTD" + DateTime.Now.ToString("ddMMyyHHmmss") + ".xlsx");

            messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Создание файла", ButtonEnum.Ok);
            messageBoxStandardWindow.Show();
            IWorkbook workbook = new XSSFWorkbook();
            messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Создание приема", ButtonEnum.Ok);
            messageBoxStandardWindow.Show();
            ISheet sheet = workbook.CreateSheet($"Прием");
            messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Создание выдачи", ButtonEnum.Ok);
            messageBoxStandardWindow.Show();

            messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Заполенение приема", ButtonEnum.Ok);
            messageBoxStandardWindow.Show();

            messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Заполенение шаблона", ButtonEnum.Ok);
            messageBoxStandardWindow.Show();


            IFont font = workbook.CreateFont();
            font.IsBold = true;
            font.FontHeightInPoints = 16;
            ICellStyle boldStyle = workbook.CreateCellStyle();
            boldStyle.SetFont(font);

            IRow row = sheet.CreateRow(0);
            ICell cell = row.CreateCell(0);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("№ ДО");
            cell = row.CreateCell(1);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("Дата ДО");
            cell = row.CreateCell(2);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("№ ГТД");
            cell = row.CreateCell(3);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("Дата ГТД");
            cell = row.CreateCell(4);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("Место ошибки");
            cell = row.CreateCell(5);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("Ошибка");
            cell = row.CreateCell(6);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("В ДО");
            cell = row.CreateCell(7);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("В ГТД");
            cell = row.CreateCell(8);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("Получатель");

            //int numberRow = 1;
            //foreach (var aa in mistakes)
            //{

            //    row = sheet.CreateRow(numberRow);
            //    cell = row.CreateCell(0);
            //    cell.SetCellValue($"{aa.Number}");
            //    cell = row.CreateCell(1);
            //    cell.SetCellValue($"{aa.DateTimeDoc}");
            //    cell = row.CreateCell(2);
            //    cell.SetCellValue($"{aa.GTD}");
            //    cell = row.CreateCell(3);
            //    cell.SetCellValue($"{aa.GtdDate}");
            //    cell = row.CreateCell(4);
            //    cell.SetCellValue($"{aa.PlaceOfError}");
            //    cell = row.CreateCell(5);
            //    cell.SetCellValue($"{aa.Error}");
            //    cell = row.CreateCell(6);
            //    cell.SetCellValue($"{aa.ValueInAlta}");
            //    cell = row.CreateCell(7);
            //    cell.SetCellValue($"{aa.ValueInArm}");
            //    cell = row.CreateCell(8);
            //    cell.SetCellValue($"{aa.NameOfCompany}");
            //    numberRow++;

            //}
            int lastColumn = sheet.GetRow(0).LastCellNum;
            for (int i = 0; i < lastColumn; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Конец шаблона", ButtonEnum.Ok);
            messageBoxStandardWindow.Show();


            //messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Создание выдачи", ButtonEnum.Ok);
            //messageBoxStandardWindow.Show();

            //ISheet sheet_2 = workbook.CreateSheet($"Выдача");

            //messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Заполнение приема", ButtonEnum.Ok);
            //messageBoxStandardWindow.Show();

            //FillSheet(sheet_1, workbook/*, mistakesInSklad*/);
            //messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Заполнение выдачи", ButtonEnum.Ok);
            //messageBoxStandardWindow.Show();
            //FillSheet(sheet_2, workbook/*, mistakesOutSklad*/);


            messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Запись файла", ButtonEnum.Ok);
            messageBoxStandardWindow.Show();
            using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
            }
            messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Запись окончена", ButtonEnum.Ok);
            messageBoxStandardWindow.Show();


        }

        /// <summary>
        /// Шаблон заполнения страниц
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="workbook"></param>
        /// <param name="mistakes"></param>
        private static void FillSheet(ISheet sheet, IWorkbook workbook/*, List<Mistakes> mistakes*/)
        {
            var messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Заполенение шаблона", ButtonEnum.Ok);
            messageBoxStandardWindow.Show();


            IFont font = workbook.CreateFont();
            font.IsBold = true;
            font.FontHeightInPoints = 16;
            ICellStyle boldStyle = workbook.CreateCellStyle();
            boldStyle.SetFont(font);

            IRow row = sheet.CreateRow(0);
            ICell cell = row.CreateCell(0);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("№ ДО");
            cell = row.CreateCell(1);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("Дата ДО");
            cell = row.CreateCell(2);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("№ ГТД");
            cell = row.CreateCell(3);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("Дата ГТД");
            cell = row.CreateCell(4);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("Место ошибки");
            cell = row.CreateCell(5);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("Ошибка");
            cell = row.CreateCell(6);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("В ДО");
            cell = row.CreateCell(7);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("В ГТД");
            cell = row.CreateCell(8);
            //cell.CellStyle = boldStyle;
            cell.SetCellValue("Получатель");

            //int numberRow = 1;
            //foreach (var aa in mistakes)
            //{

            //    row = sheet.CreateRow(numberRow);
            //    cell = row.CreateCell(0);
            //    cell.SetCellValue($"{aa.Number}");
            //    cell = row.CreateCell(1);
            //    cell.SetCellValue($"{aa.DateTimeDoc}");
            //    cell = row.CreateCell(2);
            //    cell.SetCellValue($"{aa.GTD}");
            //    cell = row.CreateCell(3);
            //    cell.SetCellValue($"{aa.GtdDate}");
            //    cell = row.CreateCell(4);
            //    cell.SetCellValue($"{aa.PlaceOfError}");
            //    cell = row.CreateCell(5);
            //    cell.SetCellValue($"{aa.Error}");
            //    cell = row.CreateCell(6);
            //    cell.SetCellValue($"{aa.ValueInAlta}");
            //    cell = row.CreateCell(7);
            //    cell.SetCellValue($"{aa.ValueInArm}");
            //    cell = row.CreateCell(8);
            //    cell.SetCellValue($"{aa.NameOfCompany}");
            //    numberRow++;

            //}
            int lastColumn = sheet.GetRow(0).LastCellNum;
            for (int i = 0; i < lastColumn; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", "Конец шаблона", ButtonEnum.Ok);
            messageBoxStandardWindow.Show();
        }



    }
}
