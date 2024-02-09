# Visual Studio Code Snippet Generator
## Description
This is a program for the users of the VSCode extension: snippet, this program does the json formating of your code for you to simply copy-paste the output into your cpp.json file.

## Features
* Have your code in json foramt while not having to do it line by line.
* Has an option to get the output in a text file.
* handles inputs in the form: s = "anas", output: "s = \\"anas\\""
* Handles multi-line blocks (like some function).

## Getting started
Only download .NET 7.0 SDK x64: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.405-windows-x64-installer

## Usage
1. Make a text file, put your code in the file, seperate each block of code with a unique word/sequence of symbols (ex: @@@@@@).
   example:

   fun f(int x) {
   
     return x;
   
   }
   
   @@@@@@
   
   string alphabet = "abcdefg"

   @@@@@@

   and so on...
3. run the program.

## Screenshots
![image](https://github.com/anasmaher/VSCode_Snippet_Generator/assets/91443394/adb5db7f-2547-438e-a148-19a3311438e6)
![image](https://github.com/anasmaher/VSCode_Snippet_Generator/assets/91443394/be58940a-efcf-4c6d-b11d-18d403a3357c)
![image](https://github.com/anasmaher/VSCode_Snippet_Generator/assets/91443394/a6d6fc21-bf56-4832-9f1b-3baf1451a47a)
![image](https://github.com/anasmaher/VSCode_Snippet_Generator/assets/91443394/ccad9941-3574-4835-be3e-92e4a1f5a3b4)
![image](https://github.com/anasmaher/VSCode_Snippet_Generator/assets/91443394/a7baa2ce-b8ea-408a-83a6-327894e70a87)




