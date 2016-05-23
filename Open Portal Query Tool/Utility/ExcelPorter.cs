using System;
using System.Collections.Generic;
using System.IO;
using NYCECBQueryTool;
using OfficeOpenXml;
using Open_Portal_Query_Tool.Model;

namespace NYCECBQueryTool {
    class ExcelPorter {
        public void PortToExcel(List<Violation> violationList) {
            Random r = new Random();
            var number = r.Next(1, 9999).ToString();
            var fileName = string.Format(@"\Spreadsheet- {0} Records - {1}.xlsx", violationList.Count, number);
            var newFile = new FileInfo(Environment.CurrentDirectory + fileName);
            var package = new ExcelPackage(newFile);
            var worksheet = package.Workbook.Worksheets.Add("OpenPortalDataGeneration");
            worksheet.View.ShowGridLines = false;
            worksheet.Cells["A1"].LoadFromCollection(violationList, true);
            package.Save();
            OpenExcelSheet(newFile);
        }

        public void BatchPortToExcel(string cubsNumber, List<Violation> violationList) {
            var fileName = string.Format(@"\ {0} - Spreadsheet- {1} Records", cubsNumber, violationList.Count); // Create filename String

            //Create the subfolder for this particular cubs case.
            var fileInfo = CreateSubFolder(cubsNumber);

            //Create the file info for this particular cubscase file.
            var newFile = new FileInfo(fileInfo + fileName + ".xlsx");
            //Create the temporary placeholder package for writing to the spreadsheet.
            var package = new ExcelPackage(newFile);
            var worksheet = package.Workbook.Worksheets.Add("OpenPortalDataGeneration");
            worksheet.View.ShowGridLines = false;
            worksheet.Cells["A1"].LoadFromCollection(violationList, true);
            package.Save();
            using (StreamWriter sw = new StreamWriter(fileInfo + fileName + ".txt")) {
                decimal totalBalance = (decimal)0.00;
                foreach (var entry in violationList) {
                    totalBalance += entry.TotalViolationAmount;
                }
                sw.WriteLine("The Total Balance is ${0} based on the sum of balance on the spreadsheet.", totalBalance);
                sw.Flush();
            }
        }

        public void OpenExcelSheet(FileInfo fileInfo) {
            if (File.Exists(fileInfo.FullName)) {
                if (fileInfo.DirectoryName != null) System.Diagnostics.Process.Start(fileInfo.DirectoryName);
            }
        }

        public FileInfo CreateSubFolder(string cubsNumber) {
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\" + cubsNumber);
            var fileInfo = new FileInfo(
                System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) +
                @"\" + cubsNumber);

            return fileInfo;
        }
    }
}
