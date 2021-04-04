using FastReport;
using FastReport.Export.PdfSimple;
using FreeSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using Xunit;

namespace Demo.FastReport.Test
{
    public class PdfExportTest
    {
        private string _currentDirectory = Directory.GetCurrentDirectory();
        [Fact]
        public void ExportCoa_True()
        {
            string reportPath = Path.Combine(_currentDirectory,"File", "Templates", "crystal_chanpin.frx");
            Report report = new Report();
            report.Load(reportPath);
            //IFreeSql freeSql = new FreeSqlBuilder()
            //                .UseConnectionString( DataType.Oracle, "user id=vgsm;password=vgsm; data source=//192.168.23.106:1521/vgsm;Pooling=true;Min Pool Size=1")
            //                .Build();
            //var dataSet = freeSql.Ado.ExecuteDataSet("SELECT * FROM crystal_test_chanpin c where c.id_numeric=2");
            //dataSet.DataSetName = "CoaReport";
            //dataSet.Tables[0].TableName = "CRYSTAL_TEST_CHANPIN_DETAIL";
            //report.RegisterData(dataSet.Tables[0], "CRYSTAL_TEST_CHANPIN");
            //report.RegisterData(dataSet, "CoaReport");
            List<CoaReport> coaReports = new List<CoaReport>();
            coaReports.Add(new CoaReport() { 
                ANALYSIS_TYPE = "性状",
                ITEM = "性状",
                GUIFAN = "本品为淡黄绿色澄明液体",
                DATA = "本品为淡黄绿色的澄明液体",
                JIELUN = "符合规定"
            });
            report.RegisterData(coaReports, "CRYSTAL_TEST_CHANPIN_DETAIL");
            report.Prepare();
            PDFSimpleExport pdfExport = new PDFSimpleExport();
            
            string toPath = Path.Combine(_currentDirectory, "File", "Coa", $"Coa_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.pdf");
            using (FileStream stream = new FileStream(toPath, FileMode.Create))
            {
                pdfExport.Export(report, stream);
            }
            report.Dispose();
            Assert.True(File.Exists(toPath));
        }
        [Fact]
        public void ExportProduct_True()
        {
            string reportPath = Path.Combine(_currentDirectory, "File", "Templates", "Groups.frx");
            Report report = new Report();
            report.Load(reportPath);
            List<Products> list = new List<Products>();
            list.Add(new Products()
            {
                ProductId = 1,
                ProductName = "1232432424",
                SupplierId = 123,
                CategoryId = 123,
                QuantityPerUnit = "1232fdsg",
                UnitPrice =11,
                UnitsInStock = 123,
                UnitsOnOrder = 123,
                ReorderLevel= 123
            });
            report.RegisterData(list, "Products");
            report.Prepare();
            PDFSimpleExport pdfExport = new PDFSimpleExport();

            string toPath = Path.Combine(_currentDirectory, "File", "Coa", $"Groups_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.pdf");
            using (FileStream stream = new FileStream(toPath, FileMode.Create))
            {
                pdfExport.Export(report, stream);
            }
            report.Dispose();
            Assert.True(File.Exists(toPath));
        }
    }
}
