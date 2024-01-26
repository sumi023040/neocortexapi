using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyCloudProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoLibraryTest1;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MyExperiment
{
    /// <summary>
    /// This class implements the ML experiment that will run in the cloud. This is refactored code from my SE project.
    /// </summary>
    public class Experiment : IExperiment
    {
        private IStorageProvider storageProvider;

        private ILogger logger;

        private MyConfig config;

        private string expectedProjectName;
        /// <summary>
        /// construct the class
        /// </summary>
        /// <param name="configSection"></param>
        /// <param name="storageProvider"></param>
        /// <param name="expectedPrjName"></param>
        /// <param name="log"></param>
        public Experiment(IConfigurationSection configSection, IStorageProvider storageProvider, string expectedPrjName, ILogger log)
        {
            this.storageProvider = storageProvider;
            this.logger = log;
            this.expectedProjectName = expectedPrjName;
            config = new MyConfig();
            configSection.Bind(config);
        }

        /// <summary>
        /// Run Software Engineering project method
        /// </summary>
        /// <param name="inputFile">The input file.</param>
        /// <returns>experiment result object</returns>
        public Task<IExperimentResult> Run(string inputFile)
        {
            Random rnd = new Random();
            int rowKeyNumber = rnd.Next(0, 1000);
            string rowKey = "sumicloud-" + rowKeyNumber.ToString();

            ExperimentResult res = new ExperimentResult(this.config.GroupId, rowKey);

            res.StartTimeUtc = DateTime.UtcNow;
            res.ExperimentId = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            res.RowKey = rowKey;
            res.PartitionKey = "nusrat-proj-" + rowKey;

            if (inputFile == "sumi_project")
            {
                res.TestName = "Video Learning With NeoCortexApi tests";
                List<TestInfo> testResults = RunTests();

                float totalTests = testResults.Count;
                float passingTests = testResults.Count(info => info.IsPassing);
                float accuracy = (passingTests / totalTests) * 100;

                // Serialize the test results to JSON
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(testResults, Newtonsoft.Json.Formatting.Indented);
                res.Description = json;
                this.logger?.LogInformation($"The file result we got {json}");
                res.TestData = string.IsNullOrEmpty(json) ? null : Encoding.UTF8.GetBytes(json);
                res.Accuracy = accuracy;
            }
            res.EndTimeUtc = DateTime.UtcNow;

            this.logger?.LogInformation("The process successfully completed");
            return Task.FromResult<IExperimentResult>(res);
        }



        /// <inheritdoc/>
        public async Task RunQueueListener(CancellationToken cancelToken)
        {

            //ExperimentResult res = new ExperimentResult("damir", "123");
            //{
            //    //Timestamp = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),

            //    Accuracy = (float)0.5,
            //};

            //await storageProvider.UploadExperimentResult(res);


            QueueClient queueClient = new QueueClient(this.config.StorageConnectionString, this.config.Queue);

            //
            // Implements the step 3 in the architecture picture.
            while (cancelToken.IsCancellationRequested == false)
            {
                QueueMessage message = await queueClient.ReceiveMessageAsync();

                if (message != null)
                {
                    try
                    {
                        string msgTxt = Encoding.UTF8.GetString(message.Body.ToArray());

                        this.logger?.LogInformation($"Received the message {msgTxt}");

                        // The message in the step 3 on architecture picture.
                        ExerimentRequestMessage request = JsonSerializer.Deserialize<ExerimentRequestMessage>(msgTxt);

                        // Step 4.
                        //var inputFile = await this.storageProvider.DownloadInputFile(request.InputFile);
                        var inputFile = request.InputFile;

                        // Here is your SE Project code started.(Between steps 4 and 5).
                        IExperimentResult result = await this.Run(inputFile);

                        // Step 4 (oposite direction)
                        //TODO. do serialization of the result.
                        //await storageProvider.UploadResultFile("outputfile.txt", null);

                        // Step 5.
                        this.logger?.LogInformation($"{DateTime.Now} -  UploadExperimentResultFile...");
                        await storageProvider.UploadResultFile($"Test_data_{DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")}.txt", result.TestData);


                        this.logger?.LogInformation($"{DateTime.Now} -  UploadExperimentResult...");
                        await storageProvider.UploadExperimentResult(result);
                        this.logger?.LogInformation($"{DateTime.Now} -  Experiment Completed Successfully...");

                        await queueClient.DeleteMessageAsync(message.MessageId, message.PopReceipt);
                    }
                    catch (Exception ex)
                    {
                        this.logger?.LogError(ex, "TODO...");
                    }
                }
                else
                {
                    await Task.Delay(500);
                    logger?.LogTrace("Queue empty...");
                }
            }

            this.logger?.LogInformation("Cancel pressed. Exiting the listener loop.");
        }


        public List<TestInfo> RunTests()
        {
            VideoLibraryTest videoLibraryTest = new VideoLibraryTest();
            List<TestInfo> testResults = new List<TestInfo>();

            //// Run each test and accumulate the results
            testResults.Add(videoLibraryTest.SubArrayTest());
            testResults.Add(videoLibraryTest.WriteFile());
            testResults.Add(videoLibraryTest.BitmapConvert());
            testResults.Add(videoLibraryTest.BitmapResize());
            testResults.Add(videoLibraryTest.ColorChannelConvert());
            testResults.Add(videoLibraryTest.ReadVideo());
            return testResults;
        }
        #region Private Methods


        #endregion
    }
}
