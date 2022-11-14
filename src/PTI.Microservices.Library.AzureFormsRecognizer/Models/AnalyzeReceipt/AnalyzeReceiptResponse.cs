using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTI.Microservices.Library.Models.AzureFormsRecognizer.AnalyzeReceipt
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public class AnalyzeReceiptResponse
    {
        public string status { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime lastUpdatedDateTime { get; set; }
        public AnalyzeReceiptResponseAnalyzeresult analyzeResult { get; set; }
    }

    public class AnalyzeReceiptResponseAnalyzeresult
    {
        public string version { get; set; }
        public AnalyzeReceiptResponseReadresult[] readResults { get; set; }
        public AnalyzeReceiptResponseDocumentresult[] documentResults { get; set; }
    }

    public class AnalyzeReceiptResponseReadresult
    {
        public int page { get; set; }
        public float angle { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string unit { get; set; }
        public AnalyzeReceiptResponseLine[] lines { get; set; }
    }

    public class AnalyzeReceiptResponseLine
    {
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public AnalyzeReceiptResponseWord[] words { get; set; }
        public AnalyzeReceiptResponseAppearance appearance { get; set; }
    }

    public class AnalyzeReceiptResponseAppearance
    {
        public AnalyzeReceiptResponseStyle style { get; set; }
    }

    public class AnalyzeReceiptResponseStyle
    {
        public string name { get; set; }
        public float confidence { get; set; }
    }

    public class AnalyzeReceiptResponseWord
    {
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public float confidence { get; set; }
    }

    public class AnalyzeReceiptResponseDocumentresult
    {
        public string docType { get; set; }
        public int[] pageRange { get; set; }
        public AnalyzeReceiptResponseFields fields { get; set; }
    }

    public class AnalyzeReceiptResponseFields
    {
        public AnalyzeReceiptResponseItems Items { get; set; }
        public AnalyzeReceiptResponseMerchantname MerchantName { get; set; }
        public AnalyzeReceiptResponseMerchantphonenumber MerchantPhoneNumber { get; set; }
        public AnalyzeReceiptResponseReceipttype ReceiptType { get; set; }
        public AnalyzeReceiptResponseSubtotal Subtotal { get; set; }
        public AnalyzeReceiptResponseTax Tax { get; set; }
        public AnalyzeReceiptResponseTotal Total { get; set; }
        public AnalyzeReceiptResponseTransactiondate TransactionDate { get; set; }
        public AnalyzeReceiptResponseTransactiontime TransactionTime { get; set; }
    }

    public class AnalyzeReceiptResponseItems
    {
        public string type { get; set; }
        public AnalyzeReceiptResponseValuearray[] valueArray { get; set; }
    }

    public class AnalyzeReceiptResponseValuearray
    {
        public string type { get; set; }
        public AnalyzeReceiptResponseValueobject valueObject { get; set; }
    }

    public class AnalyzeReceiptResponseValueobject
    {
        public AnalyzeReceiptResponseName Name { get; set; }
        public AnalyzeReceiptResponseQuantity Quantity { get; set; }
        public AnalyzeReceiptResponseTotalprice TotalPrice { get; set; }
    }

    public class AnalyzeReceiptResponseName
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string text { get; set; }
        public float[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class AnalyzeReceiptResponseQuantity
    {
        public string type { get; set; }
        public int valueNumber { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class AnalyzeReceiptResponseTotalprice
    {
        public string type { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class AnalyzeReceiptResponseMerchantname
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public string text { get; set; }
        public float[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class AnalyzeReceiptResponseMerchantphonenumber
    {
        public string type { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class AnalyzeReceiptResponseReceipttype
    {
        public string type { get; set; }
        public string valueString { get; set; }
        public float confidence { get; set; }
    }

    public class AnalyzeReceiptResponseSubtotal
    {
        public string type { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class AnalyzeReceiptResponseTax
    {
        public string type { get; set; }
        public int valueNumber { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class AnalyzeReceiptResponseTotal
    {
        public string type { get; set; }
        public int valueNumber { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class AnalyzeReceiptResponseTransactiondate
    {
        public string type { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

    public class AnalyzeReceiptResponseTransactiontime
    {
        public string type { get; set; }
        public string valueTime { get; set; }
        public string text { get; set; }
        public int[] boundingBox { get; set; }
        public int page { get; set; }
        public float confidence { get; set; }
        public string[] elements { get; set; }
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
