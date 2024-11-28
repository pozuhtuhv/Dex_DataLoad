using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Button0.Click += async (s, e) => await TrackDataAsync();
            TextBox1.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    await TrackDataAsync();
                    e.Handled = true;
                    e.SuppressKeyPress = true; // 엔터 입력 시 "띵" 소리 방지
                }
            };
        }

        private async Task TrackDataAsync()
        {
            string input = TextBox1.Text.Trim();
            string chainId = ComboBox1.Text.Trim();
            if (string.IsNullOrEmpty(input)) // Empty 확인
            {
                Label8.Text = "Input cannot be empty! Token ";
                Label4.Text = "";
                Label5.Text = "";
                Label6.Text = "";
                return;
            }
            
            string url = $"https://api.dexscreener.com/latest/dex/pairs/{chainId}/{input}";
            
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // HTTP 에러 코드 발생 시 예외 발생
                    string json = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(json))
                    {
                        Label8.Text = "API response is empty!";
                        Label4.Text = "";
                        Label5.Text = "";
                        Label6.Text = "";
                        return;
                    }

                    try
                    {
                        JObject data = JObject.Parse(json);

                        var pairsToken = data["pairs"];
                        if (pairsToken is JArray pairs && pairs.Count > 0)
                        {
                            var firstPair = pairs[0];

                            string pairAddress = firstPair["pairAddress"]?.ToString();
                            string baseTokenAddress = firstPair["baseToken"]?["address"]?.ToString();
                            string price = firstPair["priceUsd"]?.ToString();

                            Label4.Text = $"{pairAddress}";
                            Label5.Text = $"{baseTokenAddress}";
                            Label6.Text = $"${price}";
                            Label8.Text = "Nomal";

                        }
                        else
                        {
                            Label8.Text = "No pairs found in JSON!";
                            Label4.Text = "";
                            Label5.Text = "";
                            Label6.Text = "";
                        }
                    }
                    catch (JsonReaderException jsonEx)
                    {
                        Label8.Text = $"Failed to parse JSON response! : {jsonEx.Message}";
                        Label4.Text = "";
                        Label5.Text = "";
                        Label6.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    Label8.Text = $"Error: {ex.Message}";
                    Label4.Text = "";
                    Label5.Text = "";
                    Label6.Text = "";
                }
            }
        }

    }
}