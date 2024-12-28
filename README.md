# Command Downloader - C# Console Application

## Project Description

The **Command Downloader** is a simple command-line tool built using C# that allows users to download files from a given URL directly in the console. The application lets users specify:

1. A **download URL** where the file is located.
2. The **time limit** (in seconds) for how long the download should proceed.
3. The **path and name of the file** where the downloaded content will be saved.

If the user does not provide a file name, the download will not proceed. If the download is incomplete by the time the time limit is reached, the download will be paused. Users can provide a new time limit to resume the download from where it left off.

## Features

- **Download files via URL**: The app allows users to specify the URL of the file they want to download.
- **Set a download time limit**: Users can set a specific time limit (in seconds) for the download.
- **Save downloaded file**: Users can specify the local file path, including the name, where the downloaded content will be saved.
- **Pause and resume functionality**: If the download is not completed within the given time limit, the download pauses and users can continue by providing a new time limit.

## Prerequisites

- **C#**: The app is written in C# and requires .NET to run.
- **HttpClient**: This application uses the `HttpClient` class to fetch files from the provided URL.

## Installation

1. **Clone the Repository**:  
   Clone this project to your local machine.

   ```bash
   git clone https://github.com/yourusername/command-downloader.git


2. **Build the Project**:  
   Open the project in Visual Studio or any other C# IDE, then build the project.


3. **Run the Application**:  
   Execute the application in the console.




## Usage

### Steps to Download a File:

1. **Start the Application**:  
   Run the application in your console.

2. **Provide the Download URL**:  
   When prompted, enter the **URL** of the file you want to download.

   Example:  
   `https://example.com/file.zip`

3. **Specify the File Path**:  
   Enter the **file path** and **name** where you want to save the downloaded file. Make sure to include the full path and file name (e.g., `C:\Downloads\file.zip` or `/home/user/downloads/file.zip`).

   Example:  
   `C:\Downloads\file.zip`

4. **Set the Download Time Limit**:  
   Enter the **download time** in seconds. This is the amount of time the application will attempt to download the file. Once the time limit is reached, the download will pause if it is not finished.

   Example:  
   `30` (for 30 seconds)

5. **Pause and Resume**:  
   If the download is not completed in the given time limit, the application will pause the download and allow you to specify another time limit to resume.  
   
   - If the download completes within the time limit, the application will print `"Download complete."`
   - If the download is incomplete and the time runs out, it will print `"Time is up! Download paused."`

6. **Repeat Step 4 if Needed**:  
   You can continue the download by entering a new time limit. This allows you to resume the download from where it left off.

### Example:

```bash
Enter the download URL: https://example.com/file.zip
Enter the file path to save the download (include file name, e.g., downloadedFile.exe): C:\Downloads\file.zip
Enter download time in seconds: 30
