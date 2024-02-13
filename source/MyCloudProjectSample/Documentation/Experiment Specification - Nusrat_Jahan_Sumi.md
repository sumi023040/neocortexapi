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

![sumi_project_diagram drawio](https://github.com/sumi023040/neocortexapi/assets/74204965/275f3a6f-3669-4e5d-b7e9-bda870f331af) Figure 1: Implementation of the Project</p>


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
