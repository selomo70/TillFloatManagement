using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Item
{
    public Item()
    {
        lines =new List<string>();
        result = new List<string>();
    }
  public  List<string> lines ;
  public  List<string> result;
    public int TransAmt { get; set; } = 0;
    public int  total  { get; set; }= 500;
    public int paidAmount { get; set; } = 0;
    public int tillStart { get; set; } = 0;
    public int Change { get; set; } = 0;
    public string ChangeBreakdown { get; set; } = "";
    public void ReWriteFile(string filePath)
    {

         lines = File.ReadAllLines(filePath).ToList();
         result = new List<string>();
        string newFile = @"C:\Users\confidences\source\repos\TillFloatManagement\TillFloatManagement\result.txt";

        foreach (var ln in lines)
        {
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
    }
    public void ReadFile(string newFile)
    {

       lines = File.ReadAllLines(newFile).ToList();
       
  
        // Get the output
        
        foreach (var ln in lines)
        {
            string[] parts, paid;
            var i = ln.Length - ln.IndexOf(" R");
            var sub = ln.Substring(ln.IndexOf(" R"), i);
            //To find the amount Paid  

            if (sub.Contains(","))
            {
                TransAmt = Int32.Parse(sub.Split(",")[0].Replace("R", ""));
                tillStart = total + TransAmt;

                //To find the Change Breakdown
                ChangeBreakdown = sub.Split(",")[1];
                paid = ChangeBreakdown.Split("-");
                paidAmount = Int32.Parse(paid[0].Replace("R", ""));
                 Change = paidAmount - TransAmt;
            }
            else
            {
                TransAmt = Int32.Parse(sub.Replace("R", ""));
                tillStart = total + TransAmt;
                paidAmount = Int32.Parse(sub.Replace("R", ""));
                ChangeBreakdown = sub;
                Change = paidAmount - TransAmt;
            }
            //Total left in the till
            total += TransAmt;
            Console.WriteLine("R" + tillStart + ", R" + TransAmt + ", R" + paidAmount + ", R" + Change + ", " + ChangeBreakdown);
           
        }
        
        Console.WriteLine("Amount left in the till is R" + total);
    }
   
}

