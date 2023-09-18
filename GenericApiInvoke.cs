using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Brayns.BCT
{
    public partial class GenericApiInvoke : Form
    {
        public GenericApiInvoke()
        {
            InitializeComponent();
        }

        private void btInvoke_Click(object sender, EventArgs e)
        {
            try
            {
                var url = MainForm.Current!.ProfileData.ApiBaseUrl;
                if (!url.EndsWith("/")) url += "/";
                url += "api/brayns/generic/v2.0/companies(" + tbCompID.Text + ")/api";

                var handler = new HttpClientHandler();
                handler.Credentials = new NetworkCredential(MainForm.Current!.ProfileData.ApiLogin, MainForm.Current!.ProfileData.ApiPassword);

                var client = new HttpClient(handler);
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(url);

                var jReq = new JObject();
                jReq["subsystem"] = tbSubsys.Text;
                jReq["procedureName"] = tbProcedure.Text;
                jReq["body"] = Convert.ToBase64String(Encoding.UTF8.GetBytes(tbRequest.Text));

                var reqContent = new StringContent(jReq.ToString(), Encoding.UTF8, "application/json");
                request.Content = reqContent;

                var response = client.Send(request);

                StreamReader sr = new StreamReader(response.Content.ReadAsStream());
                string resTxt = sr.ReadToEnd();
                sr.Close();

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    var jRes = JObject.Parse(resTxt);
                    var jRes2 = JObject.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(jRes["body"]!.ToString())));
                    tbResponse.Text = jRes2.ToString(Newtonsoft.Json.Formatting.Indented);
                }
                else
                {
                    tbResponse.Text = resTxt;
                }
            }
            catch (Exception ex)
            {
                tbResponse.Text = ex.Message;
            }
        }

        private void GenericApiInvoke_Load(object sender, EventArgs e)
        {
            tbSubsys.Text = MainForm.Current!.ProfileData.LastApiSubsystem;
            tbProcedure.Text = MainForm.Current!.ProfileData.LastApiProcedure;
            tbCompID.Text = MainForm.Current!.ProfileData.LastApiCompanyID;
            tbRequest.Text = MainForm.Current!.ProfileData.LastApiBody;
        }

        private void GenericApiInvoke_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Current!.ProfileData.LastApiSubsystem = tbSubsys.Text;
            MainForm.Current!.ProfileData.LastApiProcedure = tbProcedure.Text;
            MainForm.Current!.ProfileData.LastApiCompanyID = tbCompID.Text;
            MainForm.Current!.ProfileData.LastApiBody = tbRequest.Text;
        }

        private void tbRequest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                tbRequest.Paste("    ");
                e.SuppressKeyPress = true;
            }
        }
    }
}
