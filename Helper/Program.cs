using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;


namespace ConsoleApp1
{

    public class Settings
    {
        private bool buildTech;
        private bool buildEnergy;
        private bool buildRobot;
        private int damagePercentage;
        private bool buildSkylab;

        public int DamagePercentage
        {
            get => damagePercentage;
            set => damagePercentage = value;
        }

        public bool BuildTech
        {
            get => buildTech;
            set => buildTech = value;
        }

        public bool BuildEnergy
        {
            get => buildEnergy;
            set => buildEnergy = value;
        }

        public bool BuildRobot
        {
            get => buildRobot;
            set => buildRobot = value;
        }

        public bool BuildSkylab
        {
            get => buildSkylab;
            set => buildSkylab = value;
        }

        public Settings(int damagePercentage, bool buildTech, bool buildSkylab, bool buildEnergy, bool buildRobot)
        {
            DamagePercentage = damagePercentage;
            BuildTech = buildTech;
            BuildEnergy = buildEnergy;
            BuildRobot = buildRobot;
            BuildSkylab = buildSkylab;
        }

    }
    public class Account
    {
        private Settings settings;

        private string rankPoints;
        private string sid = string.Empty;
        private string server = string.Empty;
        private string crediti = string.Empty;
        private string username = string.Empty;
        private string password = string.Empty;

        private int extraEnergy = 0;
        private int c = 0;

        public Account(string apiKey, string server, string sid, string username, string password)
        {
            Server = server;
            Sid = sid;
            Username = username;
            Password = password;
        }

        public void AddSettings(int damagePercentage, bool buildTech, bool buildSkylab, bool buildEnergy, bool buildRobot)
        {
            settings = new Settings(damagePercentage, buildTech, buildSkylab, buildEnergy, buildRobot);
        }


        public void CheckActivity()
        {
            var htmlResult = GetHtmlSource();

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlResult);
            if (htmlResult != "")
            {
                var credits = doc.DocumentNode.SelectSingleNode("(//div[@id=\"header_credits\"])").InnerText;
                var uridium = doc.DocumentNode.SelectSingleNode("(//a[@id=\"header_uri\"])").InnerText;

                credits = credits.Replace(" ", string.Empty);
                credits = Regex.Replace(credits, @"\n", "");

                uridium = uridium.Replace(" ", string.Empty);
                uridium = Regex.Replace(uridium, @"\n", "");

                rankPoints = rankPoints.Replace(" ", string.Empty);
                rankPoints = Regex.Replace(rankPoints, @"\n", "");


                if (C == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(DateTime.Now.ToString("HH:mm:ss ") + Username + " | ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("CRE: " + credits);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("URI: " + uridium);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("EE: " + ExtraEnergy);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("RANK P: " + rankPoints);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(" |#| ");
                    credits = credits.Replace(".", string.Empty);
                    Crediti = credits;
                    C++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(DateTime.Now.ToString("HH:mm:ss ") + Username + " | ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("CRE: " + credits);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("URI: " + uridium);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("EE: " + ExtraEnergy);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("RANK P: " + rankPoints);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(" |#| ");
                    credits = credits.Replace(".", string.Empty);
                    if (string.Compare(Crediti, credits) == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Inactive!!!");
                    }
                    else
                        Crediti = credits;
                }
            }
            else
            {
                Console.WriteLine("Session lost!!!");
            }
        }

        public void CheckActivity(object source, ElapsedEventArgs e)
        {
            var htmlResult = GetHtmlSource();

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlResult);
            if (htmlResult != "")
            {
                var credits = doc.DocumentNode.SelectSingleNode("(//div[@id=\"header_credits\"])").InnerText;
                var uridium = doc.DocumentNode.SelectSingleNode("(//a[@id=\"header_uri\"])").InnerText;

                credits = credits.Replace(" ", string.Empty);
                credits = Regex.Replace(credits, @"\n", "");

                uridium = uridium.Replace(" ", string.Empty);
                uridium = Regex.Replace(uridium, @"\n", "");

                rankPoints = rankPoints.Replace(" ", string.Empty);
                rankPoints = Regex.Replace(rankPoints, @"\n", "");

                if (C == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(DateTime.Now.ToString("HH:mm:ss ") + Username + " | ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("CRE: " + credits);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("URI: " + uridium);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("EE: " + ExtraEnergy);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("RANK P: " + rankPoints);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(" |#| ");
                    credits = credits.Replace(".", string.Empty);
                    Crediti = credits;
                    C++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(DateTime.Now.ToString("HH:mm:ss ") + Username + " | ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("CRE: " + credits);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("URI: " + uridium);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("EE: " + ExtraEnergy);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" |#| ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("RANK P: " + rankPoints);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(" |#| ");
                    credits = credits.Replace(".", string.Empty);
                    if (string.Compare(Crediti, credits) == 0)
                    {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inactive!!!");
                    }
                    else
                        Crediti = credits;
                }
            }
            else
            {
                Console.WriteLine("Session lost!!!");
            }
        }

        private string GetHtmlSource()
        {

            using (var wc = new WebClient())
            {
                var xmlResult = "";
                var htmlResult = "";
                var honorRsl = "";
                try
                {
                    htmlResult += Login(wc);
                    var doc1 = new HtmlAgilityPack.HtmlDocument();
                    doc1.LoadHtml(htmlResult);

                    if (GetBetween(doc1.Text, "html", "header_credits") == "")
                    htmlResult += LoginWhenExpired(wc, doc1);
                    doc1.LoadHtml(htmlResult);

                    if ((C % 72) == 0)                    // Checks at first runtime and every 6 hours
                        htmlResult += DailyLoginBonus(wc);

                    if (settings.BuildSkylab)
                        htmlResult += BuildSkyLab(wc);

                    if (settings.BuildTech)
                        htmlResult += BuildPrecisionTargeter(wc);
                        
                    if (settings.BuildEnergy)
                        htmlResult += BuildEnergyLeech(wc);

                    if (settings.BuildRobot)
                        htmlResult += BuildRobotTech(wc);

                    htmlResult += RepairDrones(wc);

                    var userId = doc1.DocumentNode.SelectSingleNode("//div[contains(@class, 'header_item_wrapper')]//span").InnerText;
                    xmlResult += wc.DownloadString("https://" + Server + ".darkorbit.com/flashinput/galaxyGates.php?userID=" + userId + "&action=init&sid=" + Sid);
                    doc1.LoadHtml(xmlResult);
                    ExtraEnergy = int.Parse(doc1.DocumentNode.SelectSingleNode("//samples").InnerText);

                    honorRsl += wc.DownloadString("https://" + Server + ".darkorbit.com/indexInternal.es?action=internalHallofFame&view=dailyRank");
                    doc1.LoadHtml(honorRsl);
                    rankPoints = doc1.DocumentNode.SelectSingleNode("(//div[@id=\"hof_daily_points_points\"])").InnerText;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + Username + " | " + "Connection not available! Wrong SID or Server!");
                    return "";
                }
                return htmlResult;
            }

        }

        private string DailyLoginBonus(WebClient wc)
        {
            var htmlResult = string.Empty;

            htmlResult += wc.DownloadString("https://" + Server + ".darkorbit.com/flashAPI/dailyLogin.php?doBook");
            if (GetBetween(htmlResult, "{", "true") != "")
                Console.Write(DateTime.Now.ToString("HH:mm:ss ") + Username + " | " + "Received daily login bonus!\n");
            else if (GetBetween(htmlResult, "{", "error") != "")
                Console.Write(DateTime.Now.ToString("HH:mm:ss ") + Username + " | " + "Daily login bonus already received!\n");
            else
                Console.Write(DateTime.Now.ToString("HH:mm:ss ") + Username + " | " + "Unknown error on daily login bonus!\n");

            return htmlResult;
        }

        private string RepairDrones(WebClient wc)
        {
            var htmlResult = string.Empty;

            var activeHangarId = GetActiveHangarId(wc);
            var drones = GetDronesOver90Damage(wc, activeHangarId);

            var length = drones.Count;
            var lootId = string.Empty;
            var repairPrice = string.Empty;
            var itemId = string.Empty;
            var repairCurrency = string.Empty;
            var droneLevel = string.Empty;
            var notificationSent = false;

            Thread.Sleep(4000);

            for (var i = 0; i < drones.Count; i++)
            {

                if (string.Compare(drones[i][0], "2") == 0)
                    lootId = "drone_iris";
                else if (string.Compare(drones[i][0], "3") == 0)
                    lootId = "drone_apis";
                else if (string.Compare(drones[i][0], "4") == 0)
                    lootId = "drone_zeus";
                else if (string.Compare(drones[i][0], "1") == 0)
                    lootId = "drone_flax";


                var encodedString =
                    "{\"action\":\"repairDrone\",\"lootId\":\"" + lootId + "\",\"repairPrice\":" + drones[i][1] +
                    ",\"params\":{\"hi\":" + activeHangarId + "}," +
                    "\"itemId\":\"" + drones[i][2] + "\",\"repairCurrency\":\"" + drones[i][3] +
                    "\",\"quantity\":1,\"droneLevel\":" + drones[i][4] + "}";

                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(encodedString);
                var decodedString = System.Convert.ToBase64String(plainTextBytes);

                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                htmlResult = wc.UploadString("https://" + Server + ".darkorbit.com/flashAPI/inventory.php",
                    "action=repairDrone&params=" + decodedString);

                byte[] data = Convert.FromBase64String(htmlResult);
                decodedString = Encoding.UTF8.GetString(data);
                decodedString = decodedString.Replace("\"", "\'");

                if (GetBetween(decodedString, "'isError':0", "'data'") != "")
                {
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + Username + " | " + "Drone repaired (over " +
                                      settings.DamagePercentage + " damage)");
                }
                else
                {
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + Username + " | " +
                                      "Drone repair error. Check your account's uridium/ " +
                                      "Make sure you haven't set repair percentage at 0 in the .txt");
                    if (notificationSent == false)
                    {
                        Console.WriteLine("Drone repair ERROR!!!");
                        notificationSent = true;
                    }
                }

                Thread.Sleep(5000);
            }

            return htmlResult;
        }

        private List<List<string>> GetDronesOver90Damage(WebClient wc, string activeHangarId)
        {
            var htmlResult = String.Empty;

            var encodedString = "{\"params\":{\"hi\":" + activeHangarId + "}}";
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(encodedString);
            var decodedString = System.Convert.ToBase64String(plainTextBytes);

            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            htmlResult += wc.UploadString("https://" + Server + ".darkorbit.com/flashAPI/inventory.php",
                "action=getHangar&params=" + decodedString);

            byte[] data = Convert.FromBase64String(htmlResult);
            decodedString = Encoding.UTF8.GetString(data);

            decodedString = decodedString.Replace("\"", "\'");

            var result = JsonConvert.DeserializeObject<dynamic>(decodedString);

            var hangar = string.Empty;
            result = result.SelectToken("data.ret.hangars");

            List<List<String>> drones = new List<List<String>>();
            int i = 0;

            if (GetBetween(decodedString, "'hangars':[", "hangarID") != "")
            {
                Console.ReadLine();

                for (i = 0; i < result.Count; i++)
                {
                    if (result[i].hangar_is_active == true)
                    {
                        result = result.SelectToken("[" + i + "].general.drones");
                        Console.WriteLine(i);
                    }
                }
            }
            else
            {

                foreach (JProperty prop in result.Properties())
                {
                    hangar = prop.Name;
                }

                result = result.SelectToken("['" + hangar + "'].general.drones");
            }

            i = 0;
            foreach (JObject item in result)
            {
                var tmp = (string)item.GetValue("HP");
                tmp = tmp.Remove(tmp.Length - 1);
                int tmp2 = Int32.Parse(tmp);
                if (tmp2 >= settings.DamagePercentage)
                {
                    drones.Add(new List<String>());
                    drones[i].Add((string)item.GetValue("L"));
                    drones[i].Add((string)item.GetValue("repair"));
                    drones[i].Add((string)item.GetValue("I"));
                    drones[i].Add((string)item.GetValue("currency"));
                    drones[i].Add((string)item.GetValue("LV"));
                    i++;
                }
            }

            return drones;
        }

        private string GetActiveHangarId(WebClient wc)
        {
            var htmlResult = string.Empty;
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            htmlResult += wc.UploadString("https://" + Server + ".darkorbit.com/flashAPI/inventory.php",
                "action=getHangarList&params=e30%3D");

            byte[] data = Convert.FromBase64String(htmlResult);
            string decodedString = Encoding.UTF8.GetString(data);

            decodedString = decodedString.Replace("\"", "\'");

            dynamic result = JsonConvert.DeserializeObject(decodedString);
            result = result.data.ret.hangars;

            if (GetBetween(decodedString, "'hangars':[", "hangarID") != "")
            {

                for (var i = 0; i < result.Count; i++)
                {
                    if (result[i].hangar_is_active == true)
                    {
                        htmlResult = result[i].hangarID;
                    }
                }

            }
            else
            {

                foreach (var hangars in result)
                {
                    foreach (var hangar in hangars)
                    {
                        var activeHangar = hangar.GetValue("hangar_is_active");
                        if (activeHangar == true)
                            htmlResult = hangar.GetValue("hangarID").ToString();
                    }
                }
            }

            return htmlResult;
        }
        private string Login(WebClient wc)
        {
            var htmlResult = string.Empty;

            wc.Headers.Add(HttpRequestHeader.Cookie, "dosid=" + Sid);
            htmlResult += wc.DownloadString("https://" + Server + ".darkorbit.com/indexInternal.es?action=internalStart");

            return htmlResult;
        }

        private string LoginWhenExpired(WebClient wc, HtmlAgilityPack.HtmlDocument doc)
        {
            var htmlResult = string.Empty;

            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + Username + " | " + "Session expired! Relogging in with the same SID");

            var link2 = doc.DocumentNode.SelectSingleNode("(//form[@action])[1]");
            var a = link2.Attributes["action"].Value;
            a = a.Replace("&amp;", "&");

            htmlResult += wc.UploadString(a, "username=" + Username + "&password=" + Password);
            return htmlResult;
        }

        private string BuildPrecisionTargeter(WebClient wc)
        {
            var htmlResult = string.Empty;

            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var result = wc.UploadString("https://" + Server + ".darkorbit.com/ajax/nanotechFactory.php", "command=nanoTechFactoryShowBuff&key=RPM&level=1");
            var inProduzione = GetBetween(result, "result", "button_build_inactive");
            if (inProduzione == "")
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);

                var link = doc.DocumentNode.SelectSingleNode("(//a[@href])[2]");
                result = link.Attributes["href"].Value;

                result = result.Remove(0, 2);
                result = result.Remove(result.Length - 2);

                htmlResult += wc.DownloadString("https://" + Server + ".darkorbit.com/" + result);
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + Username + " | " + "Precision Targeter tech has been started");
            }


            return htmlResult;
        }

        private string BuildEnergyLeech(WebClient wc)
        {
            var htmlResult = string.Empty;

            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var result = wc.UploadString("https://" + Server + ".darkorbit.com/ajax/nanotechFactory.php", "command=nanoTechFactoryShowBuff&key=ELA&level=1");
            var inProduzione = GetBetween(result, "result", "button_build_inactive");
            if (inProduzione == "")
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);

                var link = doc.DocumentNode.SelectSingleNode("(//a[@href])[2]");
                result = link.Attributes["href"].Value;

                result = result.Remove(0, 2);
                result = result.Remove(result.Length - 2);

                htmlResult += wc.DownloadString("https://" + Server + ".darkorbit.com/" + result);
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + Username + " | " + "Energy Leech tech has been started");
            }


            return htmlResult;
        }

        private string BuildRobotTech(WebClient wc)
        {
            var htmlResult = string.Empty;

            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var result = wc.UploadString("https://" + Server + ".darkorbit.com/ajax/nanotechFactory.php", "command=nanoTechFactoryShowBuff&key=BRB&level=1");
            var inProduzione = GetBetween(result, "result", "button_build_inactive");
            if (inProduzione == "")
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);

                var link = doc.DocumentNode.SelectSingleNode("(//a[@href])[2]");
                result = link.Attributes["href"].Value;

                result = result.Remove(0, 2);
                result = result.Remove(result.Length - 2);

                htmlResult += wc.DownloadString("https://" + Server + ".darkorbit.com/" + result);
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + Username + " | " + "Battle Repair Bot tech has been started");
            }


            return htmlResult;
        }

        private string BuildSkyLab(WebClient wc)
        {
            var htmlResult = string.Empty;

            var result = wc.DownloadString("https://" + Server + ".darkorbit.com/indexInternal.es?action=internalSkylab");

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(result);
            var upgrades = doc.DocumentNode.SelectNodes("//a[contains(@href,\"subaction=upgrade\")]");

            var transport = doc.DocumentNode.SelectSingleNode("//input[@name=\"reloadToken\"]");
            var token = transport.Attributes["value"].Value;

            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            Thread.Sleep(3000);
            //htmlResult+= wc.UploadString("https://" + Server + ".darkorbit.com/indexInternal.es",
            //    "reloadToken="+token+"&reloadToken="+token+"&action=internalSkylab&subaction=startTransport&mode=normal&construction=TRANSPORT_MODULE&count_prometium=0&count_endurium=0&count_terbium=0&count_prometid=0&count_duranium=0&count_xenomit=0&count_promerium="+100+"&count_seprom=0");

            if (upgrades == null)
                return htmlResult;

            foreach (var upgrade in upgrades)
            {
                result = upgrade.Attributes["href"].Value;
                result = result.Replace("&amp;", "&");
                Thread.Sleep(2000);
                wc.DownloadString("https://" + Server + ".darkorbit.com/" + result);
            }



            return htmlResult;
        }

        private static string GetBetween(string strSource, string strStart, string strEnd)
        {

            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        public string Sid { get; set; }
        public string Server { get; set; }
        public int C { get; set; }
        public string Crediti { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ExtraEnergy { get; set; }
    }


    public class Program
    {

        static void Main(string[] args)
        {
            string version = "v1.3 by ";
            Console.Title = "Helper v1.3";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string path = @"settings.txt";
            string[] accounts;
            var lines = 0;
            var i = 0;
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine("x;server;sid;username;password;repairDronePercentage;buildPrecision(true/false);buildSkylab(true/false);buildEnergyLeech(true/false);buildBattleRobot(true/false)");
                }
            }
            Console.Write(version);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("@drink");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + "Logging in...");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            try
            {
                accounts = System.IO.File.ReadAllLines(path);
                // settings.txt must have 1 account per line with this specifications
                // apikey;server;sid;username;password;repairDronePercentage;buildTech;buildSkylab
                //                                         

                lines = accounts.Length;
                string[] settings = new string[lines];
                Account[] a = new Account[lines];

                foreach (string account in accounts)
                {

                    settings = account.Split(';');
                    if (settings.Length == 10)
                    {
                        settings[5] = Regex.Replace(settings[5], "[^0-9]", "");
                        if (settings[2].Length == 32 && int.Parse(settings[5]) >= 0 && int.Parse(settings[5]) <= 99 && int.Parse(settings[5]) >= 1 && (settings[6] == "true" || settings[6] == "false") && (settings[7] == "true" || settings[7] == "false") && (settings[8] == "true" || settings[8] == "false") && (settings[9] == "true" || settings[9] == "false"))
                        {
                            a[i] = new Account(settings[0], settings[1], settings[2], settings[3], settings[4]);

                            a[i].AddSettings(int.Parse(settings[5]), bool.Parse(settings[6]), bool.Parse(settings[7]), bool.Parse(settings[8]), bool.Parse(settings[9]));

                            a[i].CheckActivity();

                            StartTimer(a[i]);
                        }
                        else
                            Console.WriteLine("Incorrect account format at line:" + (i + 1) +
                                              "\tCorrect Format is:\n" +
                                              "x;server;sid;username;password;repairDronePercentage;buildPrecision(true/false);buildSkylab(true/false);buildEnergyLeech(true/false);buildBattleRobot(true/false)");
                    }
                    else
                        Console.WriteLine("Incorrect account format at line:" + (i + 1) +
                                          "\tCorrect Format is:\n" +
                                          "x;server;sid;username;password;repairDronePercentage;buildPrecision(true/false);buildSkylab(true/false);buildEnergyLeech(true/false);buildBattleRobot(true/false)");
                    i++;
                }

                while (true)
                {
                    var sid = Console.ReadLine();
                    var answer = string.Empty;
                    var newSid = string.Empty;
                    var oldSid = string.Empty;

                    if (sid == "sid")
                    {
                        Console.WriteLine("Which account would you like to change? Insert number (starting from 1)");
                        var accountNumber = int.Parse(Console.ReadLine());
                        var accountName = a[accountNumber - 1].Username;

                        do
                        {
                            Console.WriteLine("Do you want to change " + accountName + " sid? y/n");
                            answer = Console.ReadLine();
                        } while (answer != "Y" && answer != "y");

                        do
                        {
                            Console.WriteLine("Write the new sid!");
                            newSid = Console.ReadLine();
                        } while (newSid.Length != 32);

                        oldSid = a[accountNumber - 1].Sid;
                        a[accountNumber - 1].Sid = newSid;

                        accounts[accountNumber - 1] = accounts[accountNumber - 1].Replace(oldSid, newSid);
                        System.IO.File.WriteAllLines(@"settings.txt", accounts);
                        Console.WriteLine(a[accountNumber - 1].Username + " new sid: " + a[accountNumber - 1].Sid);


                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }



            void StartTimer(Account acc)
            {
                System.Timers.Timer t = new System.Timers.Timer(TimeSpan.FromMinutes(3).TotalMilliseconds)
                {
                    AutoReset = true
                }; // Set the time (5 mins in this case)
                t.Elapsed += (acc.CheckActivity);
                t.Start();
            }
        }
    }

    static class DisableConsoleQuickEdit
    {

        const uint ENABLE_QUICK_EDIT = 0x0040;

        const int STD_INPUT_HANDLE = -10;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        internal static bool Go()
        {
            IntPtr consoleHandle = GetStdHandle(STD_INPUT_HANDLE);
            uint consoleMode;
            if (!GetConsoleMode(consoleHandle, out consoleMode))
            {
                return false;
            }

            consoleMode &= ~ENABLE_QUICK_EDIT;

            if (!SetConsoleMode(consoleHandle, consoleMode))
            {
                return false;
            }

            return true;
        }
    }
}