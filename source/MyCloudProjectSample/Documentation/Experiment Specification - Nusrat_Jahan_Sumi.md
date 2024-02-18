# Video Learning With NeoCortexApi
## Introduction
This work "Video Learning with HTM CLA" introduces videos data into the Cortical Learning Algorithm in NeoCortex Api.
Experiment in current work involves using Temporal Memory to learn binary representation of videos (sequence of bitarrays - each bitarray represents 1 frame).
Afterwards the result of the learning is tested by giving the trained model an abitrary image, the model then tries to recreate a video with proceeding frame after the input frame. I implemented this projects test part in Azure cloud storage. Moreover, running this project on Azure Cloud, I explored and got to use very useful features of Azure Cloud services.
## Recap (Software Engineering Project)
If you need to obtain a copy of our project on your own system, use these links in order to carry out development and testing. Look at the notes on how to deploy the project and experiment with it on a live system. These are the relevant links:

- Project Documentation: [Documentation](https://github.com/ddobric/neocortexapi/tree/SequenceLearning_ToanTruong/Project12_HTMCLAVideoLearning/HTMVideoLearning#readme) 

- Unit Test Cases: [here](https://github.com/ddobric/neocortexapi/blob/SequenceLearning_ToanTruong/Project12_HTMCLAVideoLearning/HTMVideoLearning/VideoLibraryTest/VideoLibraryTest.cs)

## What is "Video Learning With NeoCortexApi in Microsoft Azure Cloud computing"
Cloud computing, the future of the IT industry, is revolutionizing how applications are developed and deployed, offering benefits like accessibility, agility, scalability, and reliability, all while being cost-effective. Accordingly, the video learning project has been migrated to Microsoft Azure, a leading cloud computing platform.

Utilizing Docker for app containerization proves to be economical as it negates the need for specific hardware configurations and software installations for hosting. Docker enables running multiple applications on a single hardware setup in separate containers, thus ensuring they do not interfere with each other’s files, memory, or resources.

This project leverages six key features of the Microsoft Azure platform:

 1. Azure Storage: A highly secure, scalable, and accessible cloud storage solution. It encompasses various storage types such as Blob Storage, File Storage, and Queue Storage.

 2. Azure Blob Storage: This caters to unstructured data storage in the cloud, facilitating direct browser access for images and documents, distributed file access, and the creation of log files with backup and recovery capabilities.

 3. Azure Queue Storage: A cloud messaging service that aids in task and workflow management among application components. It allows access through HTTP or HTTPS, enabling stacking and sequential processing of multiple queue messages for more efficient task completion.

 4. Azure Table Storage (formerly Cosmos DB Table API): A flexible, schema-less storage solution for structured data, ideal for quickly accessing project overviews through metadata parsing as required.

 5. Azure Container Registry: A repository for storing private Docker container images, making them publicly accessible and usable from anywhere.

 6. Azure Container Instances: A service that simplifies the deployment and running of containers without the need for local Docker image management or virtual machine provisioning.

## Video Learning Project:
The Hierarchical Temporal Memory (HTM) model, based on the "Thousand Brains Theory," replicates high-level concepts and object behaviors across cortical columns, not just on the top layer but distributed throughout the neocortex. The HTM’s Spatial Pooler, incorporating various cortical computational principles, focuses on aspects like competitive Hebbian learning, homeostatic excitability control, and structural plasticity. It aims to preserve the topology of input space, adapt to changing input statistics, maintain fixed sparsity in representations, and ensure robustness against noise and faults, thereby supporting Sparse Distributed Representations (SDRs).

HTM’s integral component, the Spatial Pooler, produces outputs that are easily recognized by downstream neurons, enhancing the overall HTM system performance. The model also encompasses sequence learning, such as generation, prediction, or recognition, based on trained legitimate sequence models. The Cortical Learning Algorithms (CLA), inspired by the neocortex, offer insights into brain functionality. These algorithms emulate the brain's pattern recognition and predictive intelligence, processing information streams, classifying them, and learning to distinguish differences using time-based patterns. Significantly, the temporal sequence in HTM is derived from input data streams, and the learning outcomes are tested by feeding an arbitrary image to the trained model, which then attempts to generate a subsequent video frame, demonstrating the model's predictive capability.

![sumi_project_diagram drawio](https://github.com/sumi023040/neocortexapi/assets/74204965/275f3a6f-3669-4e5d-b7e9-bda870f331af) 
<p>Figure 1: Implementation of the Project</p>

### How the Video Learning with NeoCortexApi works:
In this experiment, Videos are learned as sequences of Frames. The link to the project code can be found in [VideoLearning.cs](https://github.com/ddobric/neocortexapi/blob/SequenceLearning_ToanTruong/Project12_HTMCLAVideoLearning/HTMVideoLearning/HTMVideoLearning/VideoLearning.cs). An overall view of the experiment can be found in the [Projet Folder](https://github.com/sumi023040/neocortexapi/tree/master/Project12_HTMCLAVideoLearning/HTMVideoLearning).  

This project references Sequence Learning sample, see [SequenceLearning.cs](https://github.com/ddobric/neocortexapi/tree/master/source/Samples/NeoCortexApiSample).  

Input Videos are currently generated from python scripts, using OpenCV2. See [DataGeneration](https://github.com/ddobric/neocortexapi/tree/SequenceLearning_ToanTruong/DataGeneration) for manual on usage and modification.  

The Reading of Videos are enabled by [VideoLibrary](https://github.com/ddobric/neocortexapi/tree/SequenceLearning_ToanTruong/Project12_HTMCLAVideoLearning/HTMVideoLearning/VideoLibrary), written for this project using OpenCV2. This library requires nuget package [Emgu.CV](https://www.nuget.org/packages/Emgu.CV/), [Emgu.CV.Bitmap](https://www.nuget.org/packages/Emgu.CV.Bitmap/), [Emgu.CV.runtimes.windows](https://www.nuget.org/packages/Emgu.CV.runtime.windows/) version > 4.5.3.  
Learning process include: 
1. reading videos.
2. convert videos to Lists of bitarrays.
3. Spatial Pooler Learning with Homeostatic Plasticity Controller until reaching stable state.
4. Learning with Spatial pooler and Temporal memory, conditional exit.
5. Interactive testing section, output video from frame input.
### Data Generation:
The current encoding mechanism of the frame employs the convert of each pixels into an part in the input bit array. This input bit array is used by the model for training.  
There are currently 3 training set:
- SmallTrainingSet: has 3 video, 1 foreach label in {circle rectangle triangle}.    
- TrainingVideos: has more video, intended for training in `PURE` colorMode
- oneVideoTrainingSet
The current most used set for training and debugging is SmallTrainingSet.  

## Cloud Project Implementation

One of the crucial part of the Video learning with neocortexapi was implement the unit tests to make sure the functionality works alright to the core. So I made sure all of the unit tests from my Software Engineering project ran on Cloud. For this I imported two Projects From the Softare Engineering project which is "VideoLibrary" and "VideoLibraryTest" to the solution "MyCloudProjectSample". Inside the Experiment project the implementation of the Azure Cloud project happens. The "VideoLibraryTest" and "VideoLibrary" folder is the Software Engineering projects test folder and Library implementation folder responsible for video reading and writing. Then we import the tests in Experiment project and run them from inside the Experiment.cs file in order to run this project on the cloud.
![project_cc_12](https://github.com/sumi023040/neocortexapi/assets/74204965/90ffa5c8-d2b5-4396-8187-be9250592d33)
<p>Figure 2: Project Structure</p>

In MyCloudProjectSample->MyExperiment->Experiment.cs, This code snippet is responsible for listening the queue message from the Azure Cloud's Queue Storage. 

``` 

    public async Task RunQueueListener(CancellationToken cancelToken)
        {

            QueueClient queueClient = new QueueClient(this.config.StorageConnectionString, this.config.Queue);

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
        
```

This below code snippet is responsible for Uploading the results in Azure Cloud Table and Azure Cloud Blob container respectevely.

```

    public async Task UploadExperimentResult(IExperimentResult result)
        {
            Random rnd = new Random();
            int rowKeyNumber = rnd.Next(0, 1000);
            string rowKey = "sumicloud-" + rowKeyNumber.ToString();
            string partitionKey = "nusrat-proj-" + rowKey;

            var testResult = new ExperimentResult(partitionKey, rowKey)
            {

                ExperimentId = result.ExperimentId,
                Name = result.Name,
                Description = result.Description,
                StartTimeUtc = result.StartTimeUtc,
                EndTimeUtc = result.EndTimeUtc,
                TestData = result.TestData,
            };
            Console.WriteLine($"Upload ExperimentResult to table: {this.config.ResultTable}");
            var client = new TableClient(this.config.StorageConnectionString, this.config.ResultTable);

            await client.CreateIfNotExistsAsync();
            try
            {
                await client.AddEntityAsync<ExperimentResult>(testResult);
                //await client.UpsertEntityAsync<ExperimentResult>(minimalResult);
                Console.WriteLine("Uploaded to Table Storage completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to upload to Table Storage: {ex.ToString()}");
            }

        }

        public async Task UploadResultFile(string fileName, byte[] data)
        {
            var experimentLabel = fileName;

            BlobServiceClient blobServiceClient = new BlobServiceClient(this.config.StorageConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(this.config.ResultContainer);

            // Write encoded data to text file
            byte[] testData = data;

            string blobName = experimentLabel;

            // Upload the text data to the blob container
            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            using (MemoryStream memoryStream = new MemoryStream(testData))
            {
                await blobClient.UploadAsync(memoryStream);
            }

        }

    }
```


Then in the Expeiment.cs in the method ``` List<TestInfo> RunTests() ``` I imported all Unit tests and run them and get the results, and put the results in the Azure Cloud blob storage, Azure Cloud Table storage.

The next steps would be Containerize the application with Docker, Upload it in Azure Container Registry, Create an Instance of that Container and Run them.

## Benefits of Implementing this project in the Cloud

This section details the specific advantages this method offers over traditional local testing practices, emphasizing the benefits directly related to my project's context.

 1. Enhanced Testing Efficiency

 2. On-Demand Scalability: The cloud provides on-demand scalability, allowing us to adjust computing resources based on our testing needs. This flexibility is crucial for video processing tests, which can be resource-intensive due to the large file sizes and the computational power required for video analysis and manipulation.

 3. Parallel Test Execution: Cloud environments enable us to run multiple tests simultaneously, drastically reducing the time needed to complete the testing cycle. This capability allows for rapid feedback and faster iterations, which is especially valuable in agile development environments.

 4. Cost and Resource Optimization

 5. Reduced Infrastructure Costs: By leveraging cloud services, we avoid the significant upfront costs associated with purchasing and maintaining dedicated hardware for testing. The cloud's pay-as-you-go pricing model means we only pay for the compute and storage resources we use, optimizing our project's budget.

 6. Efficient Resource Utilization: Running tests in the cloud eliminates the idle time of local resources, ensuring that we're using our allocated resources efficiently. This optimization can lead to cost savings and a greener footprint by reducing unnecessary energy consumption.

 7. Improved Collaboration and Accessibility

 8. Accessibility from Anywhere: Cloud-based testing environments are accessible from anywhere with an internet connection, enabling any team members to run tests, access results, and collaborate on improvements without being tied to a specific location. This flexibility is particularly beneficial for remote or distributed teams.

 9.  Centralized Results and Reporting: Test results and logs are automatically stored in the cloud, providing a single source of truth for all team members. This centralized storage simplifies result analysis, bug tracking, and historical data comparison, fostering a data-driven approach to software quality.

 10. Reliability and Consistency

 11. High Availability: Cloud providers typically offer high availability for their services, ensuring that our testing environment is always accessible. This reliability is critical for maintaining continuous integration and delivery pipelines.

 12.Consistent Testing Environment: Running our tests in a cloud environment ensures a consistent and controlled setting across all test executions. This consistency helps to eliminate the "works on my machine" problem, leading to more reliable and reproducible test outcomes.

## Information about my Azure accounts and their components

|  |  |  |
| --- | --- | --- |
| Resource Group | ```RG-nusrat.sumi``` | --- |
| Container Registry | ```sumicloud``` | --- |
| Container Registry server | ```sumicloud.azurecr.io``` | --- |
| Container Instance | ```sumiccinstance``` | --- |
| Storage account | ```nusratjahan``` | --- |
| Queue storage | ```sumisqueue``` | Queue which containes trigger message |
| Blob container | ```sumisresultcontainer``` | Container used to store results|
| Table storage | ```sumistable``` | Container used to store learning accuracy logs |



The experiment Docker image can be pulled from the Azure Container Registry using the instructions below.
~~~
docker pull sumicloud.azurecr.io/sumicloudproject:v6
~~~

## How to run the experiment

## Step1: Message input from Azure portal
Add a message to queues inside the Azure storage account.
p.s Put off the tik from "Encode the message body in Base64"

**How to add a message:** 

Azure portal > Home > nusratjahan | Queues > sumisqueue> Add message

![sumi-project-7](https://github.com/sumi023040/neocortexapi/assets/74204965/1a2dcce4-f9f6-4485-b7a7-76c715824487)

**Messages added to the queue:**

![sumi-project-3](https://github.com/sumi023040/neocortexapi/assets/74204965/9ba41f9a-0d68-40c0-962b-2e323db194fa)


### Queue Message that will trigger the experiment:
~~~json
{
  "ExperimentId": "1",
  "InputFile": "sumi_project",
  "Description": "Video Leraning implementation",
  "ProjectName": "Video Learning With NeoCortexApi",
  "GroupName": "nusrat-jahan-cloud-project",
  "Students": [ "Nusrat Jahan" ]
}
~~~
Go to "sumiccinstance," "Containers," and "logs" to make sure the experiment is being run from a container instance.

![sumi-project-2](https://github.com/sumi023040/neocortexapi/assets/74204965/b61097f5-ad96-4072-a396-27ceb9a53eff)


When the experiment  is successful bellow message(Experiment complete successfully) will be shown. Experiment successfully

![sumi-project-4](https://github.com/sumi023040/neocortexapi/assets/74204965/a64c6ea4-47aa-42ab-9483-866df7c5b8db)

## Step2: Describe the Experiment Result Output Container

After the experiments are completed, the result file is stored in Azure storage blob containers. 


![sumi-project-5](https://github.com/sumi023040/neocortexapi/assets/74204965/5b3daf33-0937-45ab-8b5b-d2ec8f0c744b)

The result data are also subsequently uploaded into a database table named "variable-i-table"


![sumi-project-6](https://github.com/sumi023040/neocortexapi/assets/74204965/0d2dabb8-c4c8-4058-bfc4-98093d80c0b4)
