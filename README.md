# Asset Tracking System  
A simple console application to track assets for different offices.  

# Installing and running the application  
## 1. Prerequisites  
.NET SDK or Runtime: Depending on whether you need to compile or just run the application.  
For building: install the .NET SDK.  
For running: install the .NET Runtime.  
Download from https://dotnet.microsoft.com/download.  
## 2. Clone this repository or download zip file  
Either use git clone https://github.com/Himske/AssetTrackingSystem.git or download as a zip file from github.  
## 3. Build the application  
* Navigate to the project directory  
cd path\to\your\project  
* Restore dependencies  
dotnet restore  
* Build the project  
dotnet build -c Release  
## 4. Run the application  
Output executable will usually be in: bin\Release\netX.Y\YourApp.exe  
Double click the exe file to run the application.  

# How the application works
When starting the application it will load any previously saved assets.  
<img width="289" height="110" alt="image" src="https://github.com/user-attachments/assets/c34b58d2-e67c-4690-af8f-25207446a2b6" />  
Then it will show the menu options:  
<img width="302" height="235" alt="image" src="https://github.com/user-attachments/assets/8b23a1df-97e9-4462-b12f-5908730da151" />  

## 1. Add Asset  
This will let you add new assets.  
<img width="394" height="332" alt="image" src="https://github.com/user-attachments/assets/13126828-e649-4f7f-b337-7f0c296f163e" />  
If an asset is successfully added it will automaticly be saved to a JSON file.

## 2. View Assets  
This option will show a list of all the assets currently in the system. Ordered by Office and Purchase Date.  
<img width="911" height="364" alt="image" src="https://github.com/user-attachments/assets/f1a497ad-2bad-4002-b7d8-f652abeefb16" />  
If an asset is more than 3 years old it will be seen as expired and will be displayed in dark grey.  
If it's less than 6 months before an asset is expired it will be displayed in yellow.  
And if it's less than 3 months it will be displayed in red.  

## 3. Search Assets  
Search will look at brand and model. If it finds an asset it will be highlighted in green.  
<img width="911" height="423" alt="image" src="https://github.com/user-attachments/assets/5321c817-1738-4f3f-a6c5-2c9e2f77c9c7" />  

## 4. Remove Asset  
This option lets you remove an asset by entering it's Id. If the entered Id is found the asset is removed and the JSON file that holds all the assets will be updated.  

## 5. Create Asset Report  
This option will create a CSV file in the working directory.  
The filename will have the format "asset_report_YYYY_MM_DD_HH_MI_SS.csv".  
<img width="864" height="294" alt="image" src="https://github.com/user-attachments/assets/7dda3544-d829-4c36-a246-8d28339ee3ee" />  

## 6. Exit  
This option will save the assets currently in the system and exit the program.
