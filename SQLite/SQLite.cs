using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System.IO;
using System.Globalization;
using StatsOutcast.Models;

namespace StatsOutcast
{
    public class SQLite
    {
        static ScrapingBrowser _browser = new ScrapingBrowser();

        internal static List<LootModel> BuscarLootsPorBoss(string nomeBoss)
        {
            try
            {


                List<LootModel> loots = new List<LootModel>();

                sqlite_conn = CreateConnection();

                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT Item, Boss, Data, Count(Item) qtd FROM LootLog2 where Boss=@BOSS AND Ativo=1 group by Item";

                sqlite_conn.Open();
                sqlite_cmd.Parameters.AddWithValue("BOSS", nomeBoss);

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    LootModel loot = new LootModel();

                    loot.Item = sqlite_datareader["Item"].ToString();
                    loot.Data = DateTime.Parse(sqlite_datareader["data"].ToString());
                    loot.Boss = sqlite_datareader["boss"].ToString();
                    loot.Quantidade = Int32.Parse(sqlite_datareader["qtd"].ToString());
                    loots.Add(loot);
                }
                sqlite_conn.Close();
                loots = loots.OrderByDescending(a => a.Data).ToList();
                return loots;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }
        }

        internal static List<BossModel> BuscarBossesEQuantidade()
        {
            try
            {


                List<BossModel> bosses = new List<BossModel>();

                sqlite_conn = CreateConnection();

                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT Boss, COUNT(Boss) as QTD FROM LootLog2 WHERE Ativo=1 GROUP BY Boss ORDER BY QTD";

                sqlite_conn.Open();

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    BossModel bossModel = new BossModel();

                    bossModel.NomeBoss = sqlite_datareader["Boss"].ToString();
                    bossModel.QuantidadeLoots = Int32.Parse(sqlite_datareader["QTD"].ToString());
                    bosses.Add(bossModel);
                }
                sqlite_conn.Close();
                return bosses;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }
        }

        private static SQLiteConnection sqlite_conn;
        public static void Configurar()
        {
            try
            {

                sqlite_conn = CreateConnection();
                //CreateTable(sqlite_conn);
                //int teste =BuscarQuantidadePorItem("The Roc Head");
                ProcessarLootPage("https://outcastserver.com/loot.php");

            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }

            //ReadData(sqlite_conn);
        }
        public static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection($"Data Source={Directory.GetCurrentDirectory()}/database.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        static void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;

            string Createsql1 = "CREATE  TABLE IF NOT EXISTS LootLog            (Data VARCHAR(40), Boss VARCHAR(100), Item VARCHAR(255))";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql1;
            sqlite_conn.Open();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
            //  sqlite_cmd = new SQLiteCommand("DELETE FROM LootLog", conn);
            // sqlite_cmd.ExecuteNonQuery();
        }

        static int InsertData(SQLiteConnection conn, string data, string boss, string item, string lootCompleto)
        {
            int result = 0;
            SQLiteCommand sqlite_cmd = new SQLiteCommand(@"INSERT INTO LootLog2 (Data, Boss,Item,LootCompleto,Ativo) 
                                                            SELECT @DATA, @BOSS,@ITEM,@Loot,1
                                                            WHERE NOT EXISTS(SELECT 1 FROM LootLog2 WHERE LootCompleto = @Loot)", conn);

            sqlite_cmd.CommandType = System.Data.CommandType.Text;
            sqlite_cmd.Parameters.AddWithValue("DATA", data);
            sqlite_cmd.Parameters.AddWithValue("BOSS", boss);
            sqlite_cmd.Parameters.AddWithValue("ITEM", item);
            sqlite_cmd.Parameters.AddWithValue("Loot", lootCompleto);
            sqlite_conn.Open();
            result = sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
            return result;
        }

        public static string ReadData()
        {
            List<LootModel> listaLoot = new List<LootModel>();
            sqlite_conn = CreateConnection();
            string myreader = string.Empty;
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM LootLog2";
            sqlite_conn.Open();

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                LootModel loot = new LootModel();
                loot.Data = DateTime.ParseExact(sqlite_datareader["Data"].ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                loot.Boss = sqlite_datareader["Boss"].ToString();
                loot.Item = sqlite_datareader["Item"].ToString();
                loot.LootCompleto = sqlite_datareader["LootCompleto"].ToString();

                myreader = $"{sqlite_datareader["Data"]} {sqlite_datareader["Boss"]} {sqlite_datareader["Item"]}";

                listaLoot.Add(loot);
            }
            sqlite_conn.Close();
            return myreader;
        }

        private static void ProcessarLootPage(string pagina)
        {
            var lootPage = GetHtml(pagina);
            string divContent = lootPage.SelectSingleNode("//div[@class='content_txt']").InnerText;
            string data;
            string loot;
            string lootCompleto;
            string boss;
            string linhaFormatada;
            int result = 0;


            divContent = divContent.Replace("Latest Rare Item Drops by Boss Monsters", "");
            divContent = divContent.Replace("Loot Log Page 1", "");
            divContent = divContent.Replace("Loot Log Page 2", "");
            divContent = divContent.Replace("Loot Log Page 3", "");
            divContent = divContent.Replace("It is brand new.", "");
            divContent = divContent.Replace("It's an \"Rune of Homestead\" spell (1x)", "Rune of Homestead");
            divContent = divContent.Replace("It has 50 charges left.", "");
            divContent = divContent.Replace("It has 5 charges left.", "");
            divContent = divContent.Replace("\r", " ");
            divContent = divContent.Replace("\n", " ");
            divContent = Regex.Replace(divContent, @"\s+", " ").Trim();

            var linhas = divContent.Split("Date:");
            List<String> listaLinhas = linhas.ToList();
            listaLinhas.RemoveAt(0);
            int contadorRetornoZero = 0;
            foreach (var item in listaLinhas)
            {
                linhaFormatada = item.Trim();
                data = linhaFormatada.Substring(0, 16).Trim();
                boss = linhaFormatada.Substring(17, linhaFormatada.IndexOf("'s") - 17);
                loot = linhaFormatada.Substring(linhaFormatada.IndexOf("Loot:"));

                loot = loot.Replace("Loot: an ", "");
                loot = loot.Replace("Loot: a ", "");
                loot = loot.Replace("Loot: ", "");
                loot = loot.Replace(loot.Substring(loot.IndexOf(".")), "");
                lootCompleto = $"{data} {boss} {loot}";
                result = InsertData(sqlite_conn, data, boss, loot, lootCompleto);
                if (result == 0)
                    contadorRetornoZero++;

                if (result == 0 && contadorRetornoZero > 1000)
                    break;
            }
        }

        static HtmlNode GetHtml(string url)
        {
            WebPage webpage = _browser.NavigateToPage(new Uri(url));
            return webpage.Html;
        }
        public static List<LootModel> BuscarLoots()
        {
            try
            {


                List<LootModel> loots = new List<LootModel>();

                sqlite_conn = CreateConnection();

                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT Item, Boss,Data FROM LootLog2 WHERE Ativo=1";

                sqlite_conn.Open();

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    LootModel loot = new LootModel();

                    loot.Item = sqlite_datareader["Item"].ToString();
                    loot.Data = DateTime.Parse(sqlite_datareader["data"].ToString());
                    loot.Boss = sqlite_datareader["boss"].ToString();
                    loots.Add(loot);
                }
                sqlite_conn.Close();
                loots = loots.OrderByDescending(a => a.Data).ToList();
                return loots;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }
        }
        public static int BuscarQuantidadePorItem(string nomeItem)
        {
            try
            {


                LootModel loot = new LootModel();

                sqlite_conn = CreateConnection();

                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT Item, COUNT(Item) as QTD FROM LootLog2 WHERE Item = @ITEM AND Ativo=1 GROUP BY Item";
                sqlite_cmd.Parameters.AddWithValue("ITEM", nomeItem);
                sqlite_conn.Open();

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    loot = new LootModel();

                    loot.Item = sqlite_datareader["Item"].ToString();
                    loot.Quantidade = Int32.Parse(sqlite_datareader["QTD"].ToString());
                }
                sqlite_conn.Close();
                return loot.Quantidade;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }
        }
        public static List<LootModel> BuscarItemEQuantidade()
        {
            try
            {


                List<LootModel> loots = new List<LootModel>();

                sqlite_conn = CreateConnection();

                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT Item, COUNT(Item) as QTD FROM LootLog2 WHERE Ativo=1 GROUP BY Item ORDER BY QTD";
             
                sqlite_conn.Open();

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    LootModel loot = new LootModel();

                    loot.Item = sqlite_datareader["Item"].ToString();
                    loot.Quantidade = Int32.Parse(sqlite_datareader["QTD"].ToString());
                    loots.Add(loot);
                }
                sqlite_conn.Close();
                return loots;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }
        }
    }
}
