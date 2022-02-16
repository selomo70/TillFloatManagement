using System;
using System.IO;
string filePath = @"C:\Users\confidences\source\repos\TillFloatManagement\TillFloatManagement\input.txt";
string newFile= @"C:\Users\confidences\source\repos\TillFloatManagement\TillFloatManagement\result.txt";
if (File.Exists(filePath))
            {
    //Creating the object to call my methods
    Item item = new Item();
    item.ReWriteFile(filePath);
    item.ReadFile(newFile);
    Console.ReadLine();
   
}

Console.ReadKey();
  