using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;

public class LinkBuilder
{
    public static string downloadlink = string.Empty;

    public void GetLinks()
    {
        string workingdirectory = Directory.GetCurrentDirectory();
        int counter = 0;
        string line;

        // Read the file and display it line by line.
        using (StreamReader file =
            new StreamReader($"{workingdirectory}/download/in.txt"))
        {
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }

            file.Close();
        }
        Console.WriteLine("There were {0} lines.", counter);
    }

    public void Makeuseablelink()
    {
        string WorkingLink = @"https://www.curseforge.com/wow/addons/deadly-boss-mods" + "/download";
        HtmlWeb web = new HtmlWeb();
        var htmlDoc = web.Load(WorkingLink);
        foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//p/a"))
        {
            var hrefValue = node.Attributes["href"]?.Value;
            downloadlink = "https://www.curseforge.com" + hrefValue;
        }

        Console.WriteLine("downloading");
    }

    public static string workingdirectory = string.Empty;

    public void Downloader()
    {
        workingdirectory = $"{workingdirectory}/download/DBM-Core-8.1.20.zip";
        using (WebClient wc = new WebClient())
        {
            wc.DownloadProgressChanged += ProgressBar_ValueChanged_1;
            wc.DownloadFileAsync(new Uri(downloadlink), workingdirectory);
        }
        Console.WriteLine(workingdirectory);
    }

    private void ProgressBar_ValueChanged_1(object sender, DownloadProgressChangedEventArgs e)
    {
        //ProgressBar.ValueChangedEvent = e.ProgressPercentage;
    }
}