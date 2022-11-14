# PTI.Microservices.Library.AzureFormsRecognizer

This is part of PTI.Microservices.Library set of packages

The purpose of this package is to facilitate the calls to Azure Forms Recognizer APIs, while maintaining a consistent usage pattern among the different services in the group

**Examples:**

## Analyze Invoice
    string imageUrl = INVOICE_IMAGE_URL;
    AzureFormsRecognizerService azureFormsRecognizerService =
        new AzureFormsRecognizerService(null,
        base.AzureFormsRecognizerConfiguration,
        new Microservices.Library.Interceptors.CustomHttpClient(new Microservices.Library.Interceptors.CustomHttpClientHandler(null)));
    var result =
        await azureFormsRecognizerService.AnalyzeInvoiceAsync(new Uri(imageUrl),
            TimeSpan.FromSeconds(5),
        cancellationToken:CancellationToken.None);

## Analyze Receipt
    string imageUrl = RECEIPT_IMAGE_URL;
    AzureFormsRecognizerService azureFormsRecognizerService =
        new AzureFormsRecognizerService(null,
        base.AzureFormsRecognizerConfiguration,
        new Microservices.Library.Interceptors.CustomHttpClient(new Microservices.Library.Interceptors.CustomHttpClientHandler(null)));
    var result = 
        await azureFormsRecognizerService.AnalyzeReceiptAsync(new Uri(imageUrl));