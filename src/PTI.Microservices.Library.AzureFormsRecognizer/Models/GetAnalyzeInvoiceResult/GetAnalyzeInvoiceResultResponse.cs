using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTI.Microservices.Library.AzureFormsRecognizer.Models.GetAnalyzeInvoiceResult
{

    public class GetAnalyzeInvoiceResultResponse
    {
        public string status { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime lastUpdatedDateTime { get; set; }
        public GetAnalyzeInvoiceResultResponseAnalyzeresult analyzeResult { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseAnalyzeresult
    {
        public string version { get; set; }
        public GetAnalyzeInvoiceResultResponseReadresult[] readResults { get; set; }
        public GetAnalyzeInvoiceResultResponsePageresult[] pageResults { get; set; }
        public GetAnalyzeInvoiceResultResponseDocumentresult[] documentResults { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseReadresult
    {
        public int page { get; set; }
        public float angle { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string unit { get; set; }
        public GetAnalyzeInvoiceResultResponseLine[] lines { get; set; }
        public GetAnalyzeInvoiceResultResponseSelectionmark[] selectionMarks { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseLine
    {
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public GetAnalyzeInvoiceResultResponseWord[] words { get; set; }
        public GetAnalyzeInvoiceResultResponseAppearance appearance { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseAppearance
    {
        public GetAnalyzeInvoiceResultResponseStyle style { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseStyle
    {
        public string name { get; set; }
        public float confidence { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseWord
    {
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public float confidence { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseSelectionmark
    {
        public int[] boundingBox { get; set; }
        public float confidence { get; set; }
        public string state { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponsePageresult
    {
        public int page { get; set; }
        public object[] tables { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseDocumentresult
    {
        public string docType { get; set; }
        public int[] pageRange { get; set; }
        public GetAnalyzeInvoiceResultResponseFields fields { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseFields
    {
        public GetAnalyzeInvoiceResultResponseInvoicedate InvoiceDate { get; set; }
        public GetAnalyzeInvoiceResultResponseInvoicetotal InvoiceTotal { get; set; }
        public GetAnalyzeInvoiceResultResponseItems Items { get; set; }
        public GetAnalyzeInvoiceResultResponseSubtotal SubTotal { get; set; }
        public GetAnalyzeInvoiceResultResponseTotaltax TotalTax { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseInvoicedate
    {
        public string type { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseInvoicetotal
    {
        public string type { get; set; }
        public float valueNumber { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseItems
    {
        public string type { get; set; }
        public GetAnalyzeInvoiceResultResponseValuearray[] valueArray { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseValuearray
    {
        public string type { get; set; }
        public GetAnalyzeInvoiceResultResponseValueobject valueObject { get; set; }
        public string text { get; set; }
        public float[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseValueobject
    {
        public GetAnalyzeInvoiceResultResponseAmount Amount { get; set; }
        public GetAnalyzeInvoiceResultResponseDescription Description { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseAmount
    {
        public string type { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
        public float valueNumber { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseDescription
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string text { get; set; }
        public float[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseSubtotal
    {
        public string type { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class GetAnalyzeInvoiceResultResponseTotaltax
    {
        public string type { get; set; }
        public float valueNumber { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

}
