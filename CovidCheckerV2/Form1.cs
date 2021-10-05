using System;
using System.Diagnostics;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CovidCheckerV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
          
        }

        private static string GetCovidStats(string country)
        {
            try
            {
                var client = new RestClient($"https://coronavirus-19-api.herokuapp.com/countries/{country}");
                var request = new RestRequest(Method.GET);
                var result = client.Execute(request);
                return result.Content;
            }
            catch
            {
                return "error.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Credits creds = new Credits();
            creds.Show();
        }

        private void okBtn_Click_1(object sender, EventArgs e)
        {
            /*
           * {
             "country": "Australia",
             "cases": 113411,
             "todayCases": 2019,
             "deaths": 1346,
             "todayDeaths": 12,
             "recovered": 82406,
             "active": 29659,
             "critical": 296,
             "casesPerOneMillion": 4384,
             "deathsPerOneMillion": 52,
             "totalTests": 38591872,
             "testsPerOneMillion": 1491675
             }
           */
            try
            {
                var country = countryComboBox.Text;
                var response = GetCovidStats(country);
                var converted = JsonConvert.DeserializeObject<JToken>(response);
                resultsBox.Text = "Total Cases: " + converted["cases"] + "\r\n" +
                                  "Today's Cases: " + converted["todayCases"] + "\r\n"
                                  + "Total Deaths: " + converted["deaths"] + "\r\n"
                                  + "Today's deaths: " + converted["todayDeaths"] + "\r\n";
            }
            catch
            {
                resultsBox.Text = "Error, try again.";
                Console.WriteLine("Error Occurred");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/xlildumpling",
                UseShellExecute = true
            });
        }
    }
}