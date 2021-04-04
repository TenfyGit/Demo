using Autofac;
using Demo.Migicodes.IE.Dto;
using DinkToPdf;
using Magicodes.ExporterAndImporter.Excel;
using Magicodes.ExporterAndImporter.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Demo.Migicodes.IE.Test.MagicodesTest
{
    public class ExportTest:BaseTest
    {
        private readonly IExcelExporter _excelExporter;
        private readonly IPdfExporter _pdfExporter;
        private string _currentDirectory = Directory.GetCurrentDirectory();
        public ExportTest():base()
        {
            _excelExporter = IocContainer.container.Resolve<IExcelExporter>();
            _pdfExporter = IocContainer.container.Resolve<IPdfExporter>();
        }
        /// <summary>
        /// 根据模板导出PDF
        /// </summary>
        [Fact(DisplayName = "根据模板导出PDF")]
        public async void ExportByTemplateTest_True()
        {
            string templatePath = Path.Combine(_currentDirectory, "File","Templates", "CoaReportTemplate.cshtml");
            string toPath = Path.Combine(_currentDirectory, "File", "DownLoad",$"CoaExport_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.pdf");
            var dto = new CoaExportDto
            {
                DeptName = "石家庄四药有限公司",
                CoaTitle = "成 品 检 验 报 告 书",
                SampleName = "0.9%氯化钠注射液",
                BatchName = "2007033502",
                Guige = "250ml：2.25g",
                Ct_Smp_Man_Date = "2020年07月03日",
                Ct_Smp_Db_Quantity = "1930件",
                Expiry_Date = "2022年07月02日",
                BaoZhuangGuiGe = "50袋/件（直立式聚丙烯输液袋）",
                JianYan_Date = "2020年07月05日",
                FenXiHao = "CS200704016",
                BaoGao_Date = "2020年07月19日",
                TestAccording = "中国药典2015版二部",



                ApproveBy = "张三/2021-03-18",
                
                CheckBy = "张三/2021-03-18",
                CoaDeptName = "兴盟",
                CoaResults = new List<CoaResult>
                {
                    new CoaResult
                    {
                        AnalysisType="性状",
                        Item="性状",
                        Guifan="本品应为无色的澄明液体",
                        Data="本品为无色的澄明液体",
                        JieLun = "符合规定"
                    },
                    new CoaResult
                    {
                        AnalysisType="鉴别",
                        Item="钠盐鉴别1",
                        Guifan="应呈正反应",
                        Data="呈正反应",
                        JieLun = "符合规定"
                    },
                    new CoaResult
                    {
                        AnalysisType="鉴别",
                        Item="钠盐鉴别2",
                        Guifan="应呈正反应",
                        Data="呈正反应",
                        JieLun = "符合规定"
                    },
                    new CoaResult
                    {
                        AnalysisType="检查",
                        Item="重金属",
                        Guifan="不得过千万分之三",
                        Data="含重金属未过千万分之三",
                        JieLun = "符合规定"
                    },
                    new CoaResult
                    {
                        AnalysisType="检查",
                        Item="不溶性微粒",
                        Guifan="≥10μm的不得过25粒/ml",
                        Data="未检出",
                        JieLun = "符合规定"
                    },
                    new CoaResult
                    {
                        AnalysisType="检查",
                        Item="不溶性微粒",
                        Guifan="≥25μm的不得过3粒/ml",
                        Data="未检出",
                        JieLun = "符合规定"
                    },
                    new CoaResult
                    {
                        AnalysisType="含量测定",
                        Item="乳酸左氧氟沙星",
                        Guifan="含乳酸左氧氟沙星按左氧氟沙星（C  18H20FN3O4）计，应为标示量的93.0%～107.0%",
                        Data="96.5%",
                        JieLun = "符合规定"
                    },
                },
                
                CtNumbersCase = "1000",
                
                Id = "1",
                IdNumeric = "5543",
                JieLun = "符合规定",
                OrderNum = "22",
                ProductCode = "LC-ZS002901",
                Remark = "备注",
                ReportBy = "李四/2021-02-28",
                
                SmpApplyDate = "2021-01-14",
                SmpApplyDept = "生物组"
                
            };
            string templateText = File.ReadAllText(templatePath);
            PdfExporterAttribute exporterAttribute = new PdfExporterAttribute()
            {
                IsWriteHtml = true,
                FooterSettings = new FooterSettings()
                {
                    FontSize = 9,
                    Center = "第[page]页,共[toPage]页"
                }
            };
            byte[] bytes = await _pdfExporter.ExportBytesByTemplate(dto, exporterAttribute, templateText);
            using (FileStream stream = new FileStream(toPath, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            //var fileInfo = await _pdfExporter.ExportByTemplate(toPath, dto, templateText);
            Assert.True(File.Exists(templatePath));
        }
        
    }
}
