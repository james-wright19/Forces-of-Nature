using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class TwilioIO
{
    public static string filesPath = Environment.CurrentDirectory;

    public static bool CheckForMessage()
    {
        if (File.Exists(filesPath + @"/output.txt"))
        {
            return true;
        }
        return false;
    }

    public static string ReadMessageFromPhone()
    {
        using (StreamReader sr = File.OpenText(filesPath + @"/output.txt"))
        {
            string thing = sr.ReadLine();
            sr.Close();
            File.Delete(filesPath + @"/output.txt");
            return thing;
        }
    }

    public static void SendMessageToPhones(List<string> numbers, string message)
    {
        string allNumbers = "";
        foreach (string num in numbers)
        {
            allNumbers += num + "\n";
        }
        File.WriteAllText(filesPath + @"/input.txt", message + "\nFORWARDTO\n" + allNumbers);
    }
}