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
                    loot.Data = DateTime.ParseExact(sqlite_datareader["data"].ToString(), "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
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

        internal static List<PlayerModel> BuscarPlayers()
        {
            try
            {
                List<PlayerModel> players = new List<PlayerModel>();

                sqlite_conn = CreateConnection();

                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT nome,level,vocacao,guild,magiclevel,gender,age FROM Players ORDER BY level desc";

                sqlite_conn.Open();

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                int rank = 1;
                while (sqlite_datareader.Read())
                {
                    PlayerModel playerModel = new PlayerModel();

                    playerModel.Nome = sqlite_datareader["nome"].ToString();
                    playerModel.Vocation = sqlite_datareader["vocacao"].ToString();
                    playerModel.Guild = sqlite_datareader["guild"].ToString();
                    playerModel.Gender = sqlite_datareader["gender"].ToString();
                    playerModel.Level = Int32.Parse(sqlite_datareader["level"].ToString());
                    playerModel.Age = Int32.Parse(sqlite_datareader["age"].ToString());
                    playerModel.MagicLevel = Int32.Parse(sqlite_datareader["magiclevel"].ToString());
                    playerModel.LevelPerDayAvg = CalcularLevelPerDay(playerModel);
                    playerModel.Rank = rank;

                    players.Add(playerModel);
                    rank++;
                }
                sqlite_conn.Close();
                return players;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }
        }

        private static decimal CalcularLevelPerDay(PlayerModel player)
        {
            try
            {



                sqlite_conn = CreateConnection();

                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT DISTINCT nome,level, data,id FROM PlayersLevelLog WHERE nome = @Nome order by id desc";
                //sqlite_cmd.CommandText = "SELECT Item, Boss, Data, Count(Item) qtd FROM LootLog2 where Boss=@BOSS AND Ativo=1 group by Item";

                sqlite_conn.Open();
                sqlite_cmd.Parameters.AddWithValue("Nome", player.Nome);
                decimal levelDif = 0;
                decimal dataDif = 0;
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                Dictionary<DateTime, decimal> dic = new Dictionary<DateTime, decimal>();
                while (sqlite_datareader.Read())
                {
                    Decimal levelAntigo = Decimal.Parse(sqlite_datareader["level"].ToString());
                   
                    DateTime dataAntiga = DateTime.ParseExact(sqlite_datareader["data"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                  
                    if(!dic.ContainsKey(dataAntiga))
                    dic.Add(dataAntiga, levelAntigo);
                }
                sqlite_conn.Close();
                var itemDic = dic.Where(a => a.Key < DateTime.Now.AddDays(-7)).FirstOrDefault();
                levelDif = player.Level - itemDic.Value;
                dataDif = (DateTime.Now - itemDic.Key).Days;

                if (levelDif > 0 && dataDif > 0)
                    return levelDif / dataDif;
                else
                    return 0;
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
        public static void ConfigurarLoot()
        {
            try
            {

                sqlite_conn = CreateConnection();
                //CreateTable(sqlite_conn);
                //int teste =BuscarQuantidadePorItem("The Roc Head");
                ProcessarLootPage("https://outcastserver.com/loot.php");

                //ProcessarLevelPage1("https://outcastserver.com/ranks.php?lvl");
                //ProcessarLevelPage2("https://outcastserver.com/ranks.php?lvl&site=1");
                //ProcessarLevelPage2("https://outcastserver.com/ranks.php?lvl&site=2");
                //ProcessarLevelPage2("https://outcastserver.com/ranks.php?lvl&site=3");

            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }

            //ReadData(sqlite_conn);
        }
        public static void ConfigurarPlayers()
        {
            try
            {

                sqlite_conn = CreateConnection();
                //CreateTable(sqlite_conn);
                //int teste =BuscarQuantidadePorItem("The Roc Head");
                //ProcessarLootPage("https://outcastserver.com/loot.php");

                ProcessarLevelPage1("https://outcastserver.com/ranks.php?lvl");
                ProcessarLevelPage2("https://outcastserver.com/ranks.php?lvl&site=1");
                ProcessarLevelPage2("https://outcastserver.com/ranks.php?lvl&site=2");
                ProcessarLevelPage2("https://outcastserver.com/ranks.php?lvl&site=3");

            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }

            //ReadData(sqlite_conn);
        }

        private static void ProcessarLevelPage1(string pagina)
        {
            List<PlayerModel> listaPlayers = new List<PlayerModel>();
            PlayerModel p = new PlayerModel();
            var levelPage = GetHtml(pagina);
            string divContent = levelPage.SelectSingleNode("//table").InnerText;
            divContent = divContent.Replace("RankNameLevel", "");
            divContent = divContent.Replace("\r", "");
            divContent = divContent.Replace("\t", "");
            divContent = divContent.Replace("    ", "");
            //divContent = Regex.Replace(divContent, @"\s+", " ").Trim();
            var linhas = divContent.Split("\n");
            var lista = linhas.ToList();
            for (int i = 0; i < lista.Count; i++)
            {

                if (String.IsNullOrEmpty(lista[i].Trim()))
                {
                    lista.RemoveAt(i);
                    i--;
                }
                else if (String.IsNullOrWhiteSpace(lista[i].Trim()))
                {
                    lista.RemoveAt(i);
                    i--;
                }
                else
                    lista[i] = lista[i].Trim();
            }
            p = new PlayerModel();
            p.Data = DateTime.Now;
            p.Rank = 1;
            p.Nome = lista[0];
            p.Level = Convert.ToInt32(lista[1]);
            ProcessarPlayer($"https://outcastserver.com/characters.php?char={p.Nome}", ref p);
            listaPlayers.Add(p);

            p = new PlayerModel();
            p.Data = DateTime.Now;
            p.Rank = 2;
            p.Nome = lista[2];
            p.Level = Convert.ToInt32(lista[3]);
            ProcessarPlayer($"https://outcastserver.com/characters.php?char={p.Nome}", ref p);
            listaPlayers.Add(p);

            p = new PlayerModel();
            p.Data = DateTime.Now;
            p.Rank = 3;
            p.Nome = lista[4];
            p.Level = Convert.ToInt32(lista[5]);
            ProcessarPlayer($"https://outcastserver.com/characters.php?char={p.Nome}", ref p);
            listaPlayers.Add(p);

            int contadorIndex = 6;
            while (contadorIndex < lista.Count)
            {
                p = new PlayerModel();
                p.Data = DateTime.Now;
                p.Rank = Convert.ToInt32(lista[contadorIndex]);
                contadorIndex++;
                p.Nome = lista[contadorIndex];
                contadorIndex++;
                p.Level = Convert.ToInt32(lista[contadorIndex]);
                contadorIndex++;
                ProcessarPlayer($"https://outcastserver.com/characters.php?char={p.Nome}", ref p);
                listaPlayers.Add(p);
            }
            foreach (var item in listaPlayers)
            {
                int result = InsertPlayer(sqlite_conn, item.Data.ToString("dd/MM/yyyy"), item);
            }

            /*
             insert into Players (nome,level,ativo,dataAtualizacao) VALUES
('Mel',1800,1,'03/05/2022')
             */
        }

        private static void ProcessarLevelPage2(string pagina)
        {
            List<PlayerModel> listaPlayers = new List<PlayerModel>();
            PlayerModel p = new PlayerModel();
            var levelPage = GetHtml(pagina);
            string divContent = levelPage.SelectSingleNode("//table").InnerText;
            divContent = divContent.Replace("RankNameLevel", "");
            divContent = divContent.Replace("\r", "");
            divContent = divContent.Replace("\t", "");
            divContent = divContent.Replace("    ", "");
            //divContent = Regex.Replace(divContent, @"\s+", " ").Trim();
            var linhas = divContent.Split("\n");
            var lista = linhas.ToList();
            for (int i = 0; i < lista.Count; i++)
            {

                if (String.IsNullOrEmpty(lista[i].Trim()))
                {
                    lista.RemoveAt(i);
                    i--;
                }
                else if (String.IsNullOrWhiteSpace(lista[i].Trim()))
                {
                    lista.RemoveAt(i);
                    i--;
                }
                else
                    lista[i] = lista[i].Trim();
            }

            int contadorIndex = 0;
            while (contadorIndex < lista.Count)
            {
                p = new PlayerModel();
                p.Data = DateTime.Now;
                p.Rank = Convert.ToInt32(lista[contadorIndex]);
                contadorIndex++;
                p.Nome = lista[contadorIndex];
                contadorIndex++;
                p.Level = Convert.ToInt32(lista[contadorIndex]);
                contadorIndex++;
                ProcessarPlayer($"https://outcastserver.com/characters.php?char={p.Nome}", ref p);
                listaPlayers.Add(p);
            }
            foreach (var item in listaPlayers)
            {
                int result = InsertPlayer(sqlite_conn, item.Data.ToString("dd/MM/yyyy"), item);
            }

            /*
             insert into Players (nome,level,ativo,dataAtualizacao) VALUES
('Mel',1800,1,'03/05/2022')
             */
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

        static int InsertLoot(SQLiteConnection conn, string data, string boss, string item, string lootCompleto)
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

        static int InsertPlayer(SQLiteConnection conn, string data, PlayerModel player)
        {
            int result = 0;
            result = VerificaPlayer(player);
            if (result == 0)
            {
                //sqlite_conn = CreateConnection();
                SQLiteCommand sqlite_cmd = new SQLiteCommand(@"REPLACE INTO Players (nome,level,ativo,dataAtualizacao,vocacao,guild,magiclevel,gender,age) 
                                                            VALUES( @nome, @level,1,@data,@vocacao,@guild,@magiclevel,@gender,@age)"
                                                               , conn);

                sqlite_cmd.CommandType = System.Data.CommandType.Text;
                sqlite_cmd.Parameters.AddWithValue("data", data);
                sqlite_cmd.Parameters.AddWithValue("level", player.Level);
                sqlite_cmd.Parameters.AddWithValue("nome", player.Nome);
                sqlite_cmd.Parameters.AddWithValue("vocacao", player.Vocation);
                sqlite_cmd.Parameters.AddWithValue("guild", player.Guild);
                sqlite_cmd.Parameters.AddWithValue("magiclevel", player.MagicLevel);
                sqlite_cmd.Parameters.AddWithValue("gender", player.Gender);
                sqlite_cmd.Parameters.AddWithValue("age", player.Age);
                conn.Open();
                result = sqlite_cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
                result = 0;
            return result;
        }

        private static int VerificaPlayer(PlayerModel player)
        {
            try
            {
                int result = 0;
                sqlite_conn = CreateConnection();

                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT nome FROM Players WHERE nome=@nome and level=@level";
                sqlite_cmd.Parameters.AddWithValue("nome", player.Nome);
                sqlite_cmd.Parameters.AddWithValue("level", player.Level);
                sqlite_conn.Open();

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    result++;
                }
                sqlite_conn.Close();

                return result;
            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }
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
        private static void ProcessarPlayer(string pagina, ref PlayerModel player)
        {
            try
            {

                var lootPage = GetHtml(pagina);
                string divContent = lootPage.SelectSingleNode("//div[@class='content_txt']").InnerText;

                string mortes = divContent.Split(new string[] { "Deaths" }, StringSplitOptions.None).Last();
                var linhas = divContent.Split("\n");
                player.MagicLevel = Convert.ToInt32(linhas[2].Split(new string[] { "Magic Level:" }, StringSplitOptions.None).Last());

                if (linhas[7].Contains("Age"))
                {
                    player.Age = Convert.ToInt32(linhas[7].Contains("This player") ? linhas[7].Split("This player")[0].Split(new string[] { "(Age):" }, StringSplitOptions.None).Last() : linhas[7].Split("Current")[0].Split(new string[] { "(Age):" }, StringSplitOptions.None).Last());
                    player.Guild = linhas[6].Contains("None") ? "None" : linhas[6].Split("(")[0].Split(new string[] { "of" }, StringSplitOptions.None).Last().Trim();
                }
                else
                {
                    player.Age = Convert.ToInt32(linhas[6].Contains("This player") ? linhas[6].Split("This player")[0].Split(new string[] { "(Age):" }, StringSplitOptions.None).Last() : linhas[6].Split("Current")[0].Split(new string[] { "(Age):" }, StringSplitOptions.None).Last());
                    player.Guild = linhas[5].Contains("None") ? "None" : linhas[5].Split("(")[0].Split(new string[] { "of" }, StringSplitOptions.None).Last().Trim();

                }

                player.Vocation = linhas[3].Split(new string[] { "Vocation:" }, StringSplitOptions.None).Last().Trim();
                player.Gender = linhas[4].Split(new string[] { "Gender:" }, StringSplitOptions.None).Last().Trim();

                var arrayMortes = mortes.Split("\n");
                if (arrayMortes[1].Contains("Killed"))
                {
                    string data = arrayMortes[1].Split("Killed")[0].Substring(0, 10);
                    DateTime da = new DateTime(Convert.ToInt32(data.Substring(0, 4)), Convert.ToInt32(data.Substring(5, 2)), Convert.ToInt32(data.Substring(8, 2)));
                    int level = Convert.ToInt32(arrayMortes[1].Split(" by ")[0].Split(new string[] { "level" }, StringSplitOptions.None).Last().Trim());
                    //InsertPlayerLog(da.ToString("dd/MM/yyyy"), level, player.Nome);
                }
                InsertPlayerLog(DateTime.Now.ToString("dd/MM/yyyy"), player.Level, player.Nome);

                // divContent = divContent.Replace("\r", " ");
                //  divContent = divContent.Replace("\n", " ");
                // divContent = Regex.Replace(divContent, @"\s+", " ").Trim();

            }
            catch (Exception e)
            {

                throw new Exception($"{e.Message} {player.Nome}");
            }

        }

        private static void InsertPlayerLog(string data, int level, string nome)
        {
            int result = 0;
            SQLiteCommand sqlite_cmd = new SQLiteCommand(@"INSERT INTO PlayersLevelLog (nome, data,level) 
                                                            SELECT @NOME, @DATA,@LEVEL
 
                                                            WHERE NOT EXISTS(SELECT 1 FROM PlayersLevelLog WHERE nome = @NOME AND data = @DATA AND level = @LEVEL)
                                                          ", sqlite_conn);

            sqlite_cmd.CommandType = System.Data.CommandType.Text;
            sqlite_cmd.Parameters.AddWithValue("DATA", data);
            sqlite_cmd.Parameters.AddWithValue("NOME", nome);
            sqlite_cmd.Parameters.AddWithValue("LEVEL", level);
            // sqlite_cmd.Parameters.AddWithValue("Loot", lootCompleto);
            sqlite_conn.Open();
            result = sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();

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
                result = InsertLoot(sqlite_conn, data, boss, loot, lootCompleto);
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
                    loot.Data = DateTime.ParseExact(sqlite_datareader["data"].ToString(),"yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
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
