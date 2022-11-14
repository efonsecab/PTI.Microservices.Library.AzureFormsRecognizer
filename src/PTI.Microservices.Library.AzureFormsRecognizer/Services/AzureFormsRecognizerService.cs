using Microsoft.Extensions.Logging;
using PTI.Microservices.Library.AzureFormsRecognizer.Models.GetAnalyzeInvoiceResult;
using PTI.Microservices.Library.Configuration;
using PTI.Microservices.Library.Interceptors;
using PTI.Microservices.Library.Models.AzureFormsRecognizer.AnalyzeReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PTI.Microservices.Library.Services
{
    /// <summary>
    /// Service in charge of exposing access to Azure Forms Recognizer functionality
    /// </summary>
    public sealed class AzureFormsRecognizerService
    {
        public const string VERSION = "v2.1";
        private ILogger<AzureFormsRecognizerService> Logger { get; }
        private AzureFormsRecognizerConfiguration AzureFormsRecognizerConfiguration { get; }
        private CustomHttpClient CustomHttpClient { get; }

        /// <summary>
        /// Creates a new isntnce of <see cref="AzureFormsRecognizerService"/>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="azureFormsRecognizerConfiguration"></param>
        /// <param name="customHttpClient"></param>
        public AzureFormsRecognizerService(ILogger<AzureFormsRecognizerService> logger,
            AzureFormsRecognizerConfiguration azureFormsRecognizerConfiguration,
            CustomHttpClient customHttpClient)
        {
            this.Logger = logger;
            this.AzureFormsRecognizerConfiguration = azureFormsRecognizerConfiguration;
            this.CustomHttpClient = customHttpClient;
            this.CustomHttpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key",
                this.AzureFormsRecognizerConfiguration.Key);
        }

        /// <summary>
        /// Analyzes the specified receipt
        /// </summary>
        /// <param name="receiptUri"></param>
        /// <returns></returns>
        public async Task<AnalyzeReceiptResponseAnalyzeresult> AnalyzeReceiptAsync(Uri receiptUri)
        {
            try
            {
                string requestUrl = $"{this.AzureFormsRecognizerConfiguration.Endpoint}" +
                    $"/formrecognizer/{VERSION}/prebuilt/receipt/analyze" +
                    $"?includeTextDetails={true}";
                //$"[&locale]";
                AnalyzeReceiptRequest model = new AnalyzeReceiptRequest()
                {
                    source = receiptUri.ToString()
                };
                var response = await this.CustomHttpClient
                    .PostAsJsonAsync<AnalyzeReceiptRequest>(requestUrl, model);
                if (response.IsSuccessStatusCode)
                {
                    var operationLocation = response.Headers.GetValues("Operation-Location").Single();
                    bool shouldStop = false;
                    AnalyzeReceiptResponse analyzeReceiptResponse = null;
                    do
                    {
                        analyzeReceiptResponse = await this.CustomHttpClient.GetFromJsonAsync<AnalyzeReceiptResponse>(operationLocation);
                        shouldStop = analyzeReceiptResponse.status == "failed" || analyzeReceiptResponse.status == "succeeded";
                    } while (!shouldStop);
                    return analyzeReceiptResponse.analyzeResult;
                }
                else
                {
                    string reason = response.ReasonPhrase;
                    string detailedError = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Reason: {reason}. Details: {detailedError}");
                }
            }
            catch (Exception ex)
            {
                this.Logger?.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<GetAnalyzeInvoiceResultResponseAnalyzeresult> AnalyzeInvoiceAsync(Uri invoiceUri,TimeSpan timeToWaitBetweendResultStatusRequests, CancellationToken cancellationToken)
        {
            try
            {
                string requestUrl = $"{this.AzureFormsRecognizerConfiguration.Endpoint}" +
                    $"/formrecognizer/v2.1/prebuilt/invoice/analyze" +
                    $"?includeTextDetails={true}";
                //$"[&locale]" +
                //$"[&pages]";
                AnalyzeReceiptRequest model = new AnalyzeReceiptRequest()
                {
                    source = invoiceUri.ToString()
                };
                var response = await this.CustomHttpClient.PostAsJsonAsync<AnalyzeReceiptRequest>(requestUrl, model, cancellationToken: cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    var operationLocation = response.Headers.GetValues("Operation-Location").Single();
                    GetAnalyzeInvoiceResultResponse analysisResult = null;
                    do
                    {
                        analysisResult = await GetAnalyzeInvoiceResultAsync(operationLocation, cancellationToken: cancellationToken);
                        if (analysisResult.status != "failed" && analysisResult.status != "succeeded")
                            await Task.Delay(timeToWaitBetweendResultStatusRequests);
                    }
                    while (analysisResult.status != "failed" && analysisResult.status != "succeeded");
                    return analysisResult.analyzeResult;
                }
                else
                {
                    string reason = response.ReasonPhrase;
                    string detailedError = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken);
                    throw new Exception($"Reason: {reason}. Details: {detailedError}");
                }
            }
            catch (Exception ex)
            {
                this.Logger?.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<GetAnalyzeInvoiceResultResponse> GetAnalyzeInvoiceResultAsync(string operationLocation, CancellationToken cancellationToken)
        {
            try
            {
                var result = await this.CustomHttpClient.GetFromJsonAsync<GetAnalyzeInvoiceResultResponse>(operationLocation);
                return result;
            }
            catch (Exception ex)
            {
                this.Logger?.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
