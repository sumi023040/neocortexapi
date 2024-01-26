# Video Learning With NeoCortexApi
## Introduction
This work "Video Learning with HTM CLA" introduces videos data into the Cortical Learning Algorithm in NeoCortex Api.
Experiment in current work involves using Temporal Memory to learn binary representation of videos (sequence of bitarrays - each bitarray represents 1 frame).
Afterwards the result of the learning is tested by giving the trained model an abitrary image, the model then tries to recreate a video with proceeding frame after the input frame. I implemented this projects test part in Azure cloud storage. Moreover, running this project on Azure Cloud, I explored and got to use very useful features of Azure Cloud services.
## Recap (Software Engineering Project)
If you need to obtain a copy of our project on your own system, use these links in order to carry out development and testing. Look at the notes on how to deploy the project and experiment with it on a live system. These are the relevant links:

- Project Documentation: [Documentation](https://github.com/ddobric/neocortexapi/tree/SequenceLearning_ToanTruong/Project12_HTMCLAVideoLearning/HTMVideoLearning#readme) 

- Unit Test Cases: [here](https://github.com/ddobric/neocortexapi/blob/SequenceLearning_ToanTruong/Project12_HTMCLAVideoLearning/HTMVideoLearning/VideoLibraryTest/VideoLibraryTest.cs)

 
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
