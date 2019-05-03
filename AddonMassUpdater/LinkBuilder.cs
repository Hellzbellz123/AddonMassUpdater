using HtmlAgilityPack;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

#pragma warning disable ET001 // Type name does not match file name

public class LinkBuilder
#pragma warning restore ET001 // Type name does not match file name
{
    public static string downloadlink = string.Empty;
    public static string WorkingLinkInTextFile = string.Empty;
    public static string workingdirectory = Directory.GetCurrentDirectory();

    public void GetLinks()
    {
        WorkingLinkInTextFile = ("https://www.curseforge.com/wow/addons/deadly-boss-mods");
    }

    public void Makeuseablelink()
    {
        string WorkingLink = WorkingLinkInTextFile + "/download";
        HtmlWeb web = new HtmlWeb();
        var htmlDoc = web.Load(WorkingLink);
        foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//p/a"))
        {
            var hrefValue = node.Attributes["href"]?.Value;
            downloadlink = "https://www.curseforge.com" + hrefValue;
        }
    }

    public void Downloader()
    {
        workingdirectory = $"{workingdirectory}/download/";
        using (WebClient wc = new WebClient())
        {
            wc.DownloadProgressChanged += ProgressBar_ValueChanged_1;
            wc.DownloadFileAsync(new Uri(downloadlink), workingdirectory);
        }
        Console.WriteLine(downloadlink);
    }

    private void ProgressBar_ValueChanged_1(object sender, DownloadProgressChangedEventArgs e)
    {
        //ProgressBar.ValueChangedEvent = e.ProgressPercentage;
    }
}