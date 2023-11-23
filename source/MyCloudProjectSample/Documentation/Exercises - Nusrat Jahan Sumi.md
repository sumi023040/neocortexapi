# My Exercises
RENAME THIS FILE TO "Exercises - Firsname Lastname.md" and put the content of this file into it.
FILES WITH OTHER NAMES WILL BE REJECTED!

#### Exercise I 

Provide script samples used in this exercise. What did you do , why, how, what was the result.
If you have your scrips somwhere on the git, provide us als the URL here to them.

Solution: 
az --version This command is used to check if azure desktop is installed in the pc and for current version information
az login This command is used to login to the azure account https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercise%231%20Pictures/azure%20login.PNG

az group create --location Japaneast --resource-group Demo This command is used to create resource group in a location server which can also be done by web dashboard

az group list This command is used to show the list of current groups in the account https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercise%231%20Pictures/azure%20group%20list.PNG

az group list --tag key1=America This command is used to show the groups containing key1 value America az group list --tag key1=America This command is used to show the groups containing key1 value America https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercise%231%20Pictures/azure%20grouplist%20using%20key.PNG

az group export --n Demo This will print the group information as a jason format  

az group delete --name Demo This will delete the group from resource groups

az account list-locations --query "[*].name" This command is used to show the name property of each location https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercise%231%20Pictures/azure%20account%20list%20location.PNG

az group exists -n Demo This command is used to check the existance of the group https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercise%231%20Pictures/azure%20group%20existing.PNG  

#### Exercise 2 - Docker in Azure

<<<<<<< HEAD
Provide URL to the docker file. I.e.: %giturl%\Source\MyCloudProjectSample\MyCloudProject\Dockerfile Ans: #See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build WORKDIR /src COPY ["ConsoleApp2/ConsoleApp2.csproj", "ConsoleApp2/"] RUN dotnet restore "ConsoleApp2/ConsoleApp2.csproj" COPY . . WORKDIR "/src/ConsoleApp2" RUN dotnet build "ConsoleApp2.csproj" -c Release -o /app/build

FROM build AS publish RUN dotnet publish "ConsoleApp2.csproj" -c Release -o /app/publish

FROM base AS final WORKDIR /app COPY --from=publish /app/publish . ENTRYPOINT ["dotnet", "ConsoleApp2.dll"]

Provide the URL to the publich image in the Docker Hub. Ans: https://hub.docker.com/layers/209350656/nusrat023040/cloudtut/first/images/sha256-5b2b6b002af448a992df18b160fdd9c98ef3449e8c33a9e460317e039923a7f0?context=repo

Provide the URL to the private(public??) image in the Azure Registry. Ans: https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercise%231%20Pictures/azure_Container_Image.JPG
=======
1. Provide URL to the docker file. I.e.: %giturl%\Source\MyCloudProjectSample\MyCloudProject\Dockerfile
Ans:
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ConsoleApp2/ConsoleApp2.csproj", "ConsoleApp2/"]
RUN dotnet restore "ConsoleApp2/ConsoleApp2.csproj"
COPY . .
WORKDIR "/src/ConsoleApp2"
RUN dotnet build "ConsoleApp2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleApp2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleApp2.dll"]

2. Provide the URL to the publich image in the Docker Hub.
Ans: https://hub.docker.com/layers/209350656/nusrat023040/cloudtut/first/images/sha256-5b2b6b002af448a992df18b160fdd9c98ef3449e8c33a9e460317e039923a7f0?context=repo

3. Provide the URL to the private(public??) image in the Azure Registry.
Ans: 
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercise%231%20Pictures/azure_Container_Image.JPG
>>>>>>> cd7b6e58a89e4a31b15a5347672e36b8f7ea7a8e

#### Exercise 3 - Host a web application with Azure App service

1. Provide the public URL of the webapplication.
Ans: https://bikeapp.azurewebsites.net/
2. Provide the URL to the source code of the hosted application. (Source code somwhere or the the docker image, or ??)
Ans: Images added:
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercises%20Pictures/bestbikeapp_in_containerRegistry.jpeg
3. Provide AZ scripts used to bublish the application.
Ans:az acr build –file Dockerfile –registry bikeapparc –image bikeapp:v3 .

#### Exercise 4 - Deploy and run the containerized app in AppService

1. Provide URL to the docker image of your application (Docker Hub / Azure Registry)
Ans:https://portal.azure.com/#blade/Microsoft_Azure_ContainerRegistries/TagMetadataBlade/id/%2Fsubscriptions%2Fb3476203-a0f0-4756-8093-77d2cf40cad3%2Fresourcegroups%2FBikeApp%2Fproviders%2FMicrosoft.ContainerRegistry%2Fregistries%2Fbikeappacr/repository/bestbikeappacr/tag/v4/loginServer/bikeappacr.azurecr.io

2. Provide the public URL to the running application. 
Ans:https://bestbikeappacr.azurewebsites.net/

#### Exercise 5 - Blob Storage

Provide the URL to to blob storage container under your account.
We should find some containers and blobs in there.
Following are mandatory:
- Input
Contains training files
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercises%20Pictures/BlobContainerTestFile.PNG
- Output
Contains output of the traned models
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercises%20Pictures/BlobContainerTestFile.PNG
- 'Test' for playing and testing.
you should provide here SAS Url to 2-3 files in this container with time expire 1 year.
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercises%20Pictures/BlobTestFileDeletedInContainer.PNG

#### Exercise 6 - Table Storage

Provide us access to the account which you have used for table exersises.
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercises%20Pictures/Table%20storage%20updating.PNG
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercises%20Pictures/Table%20storage%20table%20created.PNG
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercises%20Pictures/Table%20storage%20query.PNG
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercises%20Pictures/Table%20Storage%20table%20created%20wiht%20data.PNG

#### Exercise 7 - Queue Storage

Provide us access to the account which you have used for queue exersises.

https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercises%20Pictures/Receiving%20Msg.PNG
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercises%20Pictures/Received%20Queue%20Msg%202.PNG
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/Nusrat-Jahan-Sumi/Source/MyCloudProjectSample/Documentation/Exercises%20Pictures/Receive%20many%20msg%201.PNG