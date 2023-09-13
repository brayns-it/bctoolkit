using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;

namespace Brayns.BCT
{
    public enum NavAppStatus
    {
        Unpublished,
        Published,
        Installed,
        Available
    }

    public class NavApp
    {
        public string Publisher { get; set; } = "";
        public string Name { get; set; } = "";
        public NavAppStatus Status { get; set; }
        public Version? Version { get; set; }
        public Guid ID { get; set; }
        public string FileName { get; set; } = "";
        public bool SymbolsOnly { get; set; } = false;
    }

    public class BC
    {
        public ProfileData Profile { get; set; }
        public List<NavApp> Apps { get; set; } = new();

        public BC(ProfileData profile)
        {
            Profile = profile;
        }

        public List<NavApp> GetAppsById(Guid id)
        {
            List<NavApp> res = new();
            foreach (NavApp a in Apps)
                if (a.ID == id) res.Add(a);
            return res;
        }

        public bool AppExists(NavApp app)
        {
            var appList = GetAppsById(app.ID);
            foreach (NavApp a in appList)
                if (a.Version == app.Version)
                    return true;
            return false;
        }

        public bool OlderAppExists(NavApp app)
        {
            var appList = GetAppsById(app.ID);
            foreach (NavApp a in appList)
                if (a.Version >= app.Version)
                    return true;
            return false;
        }

        private bool TableExists(SqlConnection con, string tableName)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM [sysobjects] WHERE [xtype] = 'U' AND [name] = @p0"; 
            cmd.Parameters.Add(new SqlParameter("p0", tableName));
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public void Load()
        {
            string dsn = "Data Source=" + Profile.DatabaseServer + ";Initial Catalog=" + Profile.DatabaseName + ";TrustServerCertificate = true;";
            if (Profile.DatabaseIntegratedSecurity)
                dsn += "Integrated Security=true;";
            else
                dsn += "User ID=" + Profile.DatabaseLogin + ";Password=" + Utility.DecryptString(Profile.DatabasePassword) + ";";

            var con = new SqlConnection(dsn);
            con.Open();

            Apps.Clear();

            // list of installed APPs
            if (TableExists(con, "NAV App Installed App"))
            {
                string sql = @"SELECT [App ID], [Name], [Publisher], [Version Major], [Version Minor], [Version Build], [Version Revision] 
                FROM [NAV App Installed App]";
                var sda = new SqlDataAdapter(sql, con);
                var tab = new DataTable();
                sda.Fill(tab);
                foreach (DataRow rw in tab.Rows)
                {
                    var a = new NavApp();
                    a.Name = rw["Name"].ToString()!;
                    a.Publisher = rw["Publisher"].ToString()!;
                    a.Version = new Version((int)rw["Version Major"], (int)rw["Version Minor"],
                        (int)rw["Version Build"], (int)rw["Version Revision"]);
                    a.ID = Guid.Parse(rw["App ID"].ToString()!);
                    a.Status = NavAppStatus.Installed;
                    Apps.Add(a);
                }
            }

            // list of uninstalled APPs
            if (TableExists(con, "Published Application"))
            {
                string sql = @"SELECT [ID], [Name], [Publisher], [Version Major], [Version Minor], [Version Build], [Version Revision] 
                    FROM [Published Application]";
                var sda = new SqlDataAdapter(sql, con);
                var tab = new DataTable();
                sda.Fill(tab);
                foreach (DataRow rw in tab.Rows)
                {
                    var a = new NavApp();
                    a.Name = rw["Name"].ToString()!;
                    a.Publisher = rw["Publisher"].ToString()!;
                    a.Version = new Version((int)rw["Version Major"], (int)rw["Version Minor"],
                        (int)rw["Version Build"], (int)rw["Version Revision"]);
                    a.ID = Guid.Parse(rw["ID"].ToString()!);
                    a.Status = NavAppStatus.Published;
                    if (!AppExists(a))
                        Apps.Add(a);
                }
            }

            // list of uninstalled APPs
            if (TableExists(con, "$ndo$navappuninstalledapp"))
            {
                string sql = "SELECT * FROM [$ndo$navappuninstalledapp]";
                var sda = new SqlDataAdapter(sql, con);
                var tab = new DataTable();
                sda.Fill(tab);
                foreach (DataRow rw in tab.Rows)
                {
                    var a = new NavApp();
                    a.Name = rw["name"].ToString()!;
                    a.Publisher = rw["publisher"].ToString()!;
                    a.Version = Version.Parse(rw["version"].ToString()!);
                    a.ID = Guid.Parse(rw["appid"].ToString()!);
                    a.Status = NavAppStatus.Unpublished;
                    if (!AppExists(a))
                        Apps.Add(a);
                }
            }

            // list of available APPs
            foreach (string p in Profile.DevelopmentPaths)
            {
                try
                {
                    FileInfo fi = new(p + "\\app.json");
                    if (fi.Exists)
                    {
                        StreamReader sr = new StreamReader(fi.FullName);
                        JObject jo = JObject.Parse(sr.ReadToEnd());
                        sr.Close();

                        fi = new FileInfo(p + "\\" + jo["publisher"] + "_" + jo["name"] + "_" + jo["version"] + ".app");
                        if (fi.Exists)
                        {
                            var a = new NavApp();
                            a.Name = jo["name"]!.ToString();
                            a.Publisher = jo["publisher"]!.ToString();
                            a.Version = Version.Parse(jo["version"]!.ToString());
                            a.ID = Guid.Parse(jo["id"]!.ToString());
                            a.FileName = fi.FullName;
                            a.Status = NavAppStatus.Available;
                            if (!OlderAppExists(a))
                                Apps.Add(a);
                        }
                    }
                }
                catch
                {
                }
            }

            con.Close();
        }
    }
}
