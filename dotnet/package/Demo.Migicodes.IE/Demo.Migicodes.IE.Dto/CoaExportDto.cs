using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Pdf;
using System.Collections.Generic;

namespace Demo.Migicodes.IE.Dto
{
    [Exporter(Name = "COA报告单")]
    public class CoaExportDto
    {
        /// <summary>
        /// 基地名称
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// COA报告标题
        /// </summary>
        public string CoaTitle { get; set; }
        /// <summary>
        /// 检品名称
        /// </summary>
        public string SampleName { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Guige { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public string Ct_Smp_Man_Date { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Ct_Smp_Db_Quantity { get; set; }
        /// <summary>
        /// 有效期至
        /// </summary>
        public string Expiry_Date { get; set; }
        /// <summary>
        /// 包装规格
        /// </summary>
        public string BaoZhuangGuiGe { get; set; }
        /// <summary>
        /// 检验日期
        /// </summary>
        public string JianYan_Date { get; set; }
        /// <summary>
        /// 分析号
        /// </summary>
        public string FenXiHao { get; set; }
        /// <summary>
        /// 报告日期
        /// </summary>
        public string BaoGao_Date { get; set; }
        /// <summary>
        /// 检验依据
        /// </summary>
        public string TestAccording { get; set; }
        
        

        public string SmpApplyDept { get; set; }

        public string SmpApplyDate { get; set; }

        public string JieLun { get; set; }

        public string CoaDeptName { get; set; }


        public string OrderNum { get; set; }


        public string IdNumeric { get; set; }

        public string Id { get; set; }

        

        public string CtNumbersCase { get; set; }

        public string ProductCode { get; set; }

        public string Remark { get; set; }

        public string ReportBy { get; set; }

        public string CheckBy { get; set; }

        public string ApproveBy { get; set; }

        public List<CoaResult> CoaResults { get; set; }
    }

    public class CoaResult
    {
        public string TestNumber { get; set; }

        public string Result { get; set; }

        public string Guifan { get; set; }

        public string AnalysisType { get; set; }

        public string Item { get; set; }

        public string Data { get; set; }
        /// <summary>
        /// 结论
        /// </summary>
        public string JieLun { get; set; }
    }
}
