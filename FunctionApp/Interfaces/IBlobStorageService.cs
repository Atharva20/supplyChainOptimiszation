namespace AzureAutomation.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using Azure.Storage.Blobs;
    using System.Collections.Generic;

    public interface IBlobStorageService
    {
        /// <summary>
        /// Establishes connection with the service using managed identity to the endpointurl.
        /// </summary>
        /// <param name="endpointUrl">target blob-endpoint-url</param>
        /// <returns></returns>
        BlobServiceClient ConnectToTargetStorageAccountUsingManagedIdentity(string endpointUrl);

        /// <summary>
        /// Returns BlobContainerClient for the given containerName.
        /// </summary>
        /// <param name="blobServiceClient">client required to connect to the storage account.</param>
        /// <param name="containerName">Name of the container in storage account</param>
        /// <returns></returns>
        BlobContainerClient GetTargetBlobConatinerFromClientLocation(BlobServiceClient blobServiceClient, string containerName);

        /// <summary>
        /// Appends the content of the blob data and returns that list of string.
        /// </summary>
        /// <param name="blobContainerClient">client required to connect to the storage account.</param>
        /// <returns></returns>
        Task<List<string>> AppendBlobDataToList(BlobContainerClient blobContainerClient);

        /// <summary>
        /// Appends the content as a stream to provided client/blobName
        /// </summary>
        /// <param name="blobContainerClient">client required to connect to the storage account.</param>
        /// <param name="blobName">The name of the blob where we need to append the data to.</param>
        /// <param name="content">The content to append to the client blob.</param>
        void AppendContentToBlob(BlobContainerClient blobContainerClient, string blobName, string content);
    }
}