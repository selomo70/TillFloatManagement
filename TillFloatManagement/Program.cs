using System;
using System.IO;





string filePath = @"C:\Users\confidences\source\repos\TillFloatManagement\TillFloatManagement\input.txt";

if (File.Exists(filePath))
            {
/*
 *
 *
 */
    List<string> lines = File.ReadAllLines(filePath).ToList();        
    List<string> result = new List<string>();
    string newFile= @"C:\Users\confidences\source\repos\TillFloatManagement\TillFloatManagement\result.txt";
    
    foreach (var ln in lines) {
        string[] part = ln.Split(';');
        if (part.Length > 2)
        {
            result.Add(part[0]);
            result.Add(part[1]);
            result.Add(part[2]);
        }
        else if (part.Length > 1)
        {
            result.Add(part[0]);
            result.Add(part[1]);
        }
        else
        {
            result.Add(part[0]);
        }
   
    }
    File.WriteAllLines(newFile, result);

    
    List<string> newLines = File.ReadAllLines(newFile).ToList();
    int TransAmt = 0;
    var ChangeBreakdown = "";
    var paidAmount = 0;
    var change = 0;
    var total = 500;
    var tillStart = 0;
    // Get the output
    Console.WriteLine("Till Start, Transaction Total, Paid, Change Total, Change Breakdown");
    foreach (var ln in newLines)
    {
        string[] parts, paid;
        var i = ln.Length- ln.IndexOf(" R");
        var sub = ln.Substring(ln.IndexOf(" R"), i);
        //To find the amount Paid  

        if (sub.Contains(",")) { 
         TransAmt = Int32.Parse(sub.Split(",")[0].Replace("R", ""));
          tillStart=  total + TransAmt;
              //To find the Change Breakdown
              parts = sub.Split(',');
            ChangeBreakdown=parts[1];
            paid = ChangeBreakdown.Split('-');
            paidAmount = Int32.Parse(paid[0].Replace("R", ""));
            change = paidAmount - TransAmt;
        }
        else
        {
            TransAmt = Int32.Parse(sub.Replace("R", ""));
            tillStart = total + TransAmt;
            paidAmount = Int32.Parse(sub.Replace("R", "0"));
            ChangeBreakdown = sub.Replace("R", "R");
            change =paidAmount - TransAmt;
           


        }
//Total left in the till
        total += TransAmt;
        Console.WriteLine("R"+tillStart + ", R"+ TransAmt+ ", R"+ paidAmount+ ", R"+change+", "+ ChangeBreakdown);
    }
    Console.WriteLine("Amount left in the till is R" + total);
    Console.ReadLine();
   
}

Console.ReadKey();
  