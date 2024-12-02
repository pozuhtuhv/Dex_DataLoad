using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Timers; 

namespace WinFormsApp
{
    public partial class Main : Form
    {
        private bool isOn = false;
        private System.Timers.Timer timer;

        public Main()
        {
            InitializeComponent();

            // KeyPreview 활성화: 폼에서 키 이벤트 처리
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            Button0.Click += async (s, e) => await ToggleTrackingAsync(); // 버튼 클릭 이벤트
            TextBox1.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    await TrackDataAsync();
                    e.Handled = true;
                    e.SuppressKeyPress = true; // 엔터 입력 시 "띵" 소리 방지
                }
            };

            // 타이머 초기화
            timer = new System.Timers.Timer(1000); // 5초 간격 1000 = 1초
            timer.Elapsed += async (s, e) => await TrackDataAsync(); // 반복적으로 데이터 가져오기
            timer.AutoReset = true;
        }
        
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                this.Close(); // 프로그램 종료
            }
        }

        // 추적 시작/중단 상태 전환
        private async Task ToggleTrackingAsync()
        {
            isOn = !isOn;

            if (isOn)
            {
                Label8.Text = "Tracking Started";
                await TrackDataAsync(); // 즉시 한 번 데이터 가져오기
                timer.Start(); // 간격 타이머 시작
            }
            else
            {
                Label8.Text = "Tracking Stopped";
                timer.Stop(); // 타이머 중지
            }
        }

        // 추적 시작
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
                        isOn = false; // 예외 발생 시 isOn 상태 복원
                        timer.Stop(); // 타이머 중지
                        return;
                    }

                    try
                    {
                        JObject data = JObject.Parse(json);

                        var pairsToken = data["pairs"];
                        if (pairsToken is JArray pairs && pairs.Count > 0)
                        {
                            var firstPair = pairs[0];

                            string? pairAddress = firstPair["pairAddress"]?.ToString();
                            string? baseTokenAddress = firstPair["baseToken"]?["address"]?.ToString();
                            string? price = firstPair["priceUsd"]?.ToString();

                            Label4.Text = $"{pairAddress}";
                            Label5.Text = $"{baseTokenAddress}";
                            Label6.Text = $"${price}";
                        }
                        else
                        {
                            Label8.Text = "No pairAddress found!";
                            Label4.Text = "";
                            Label5.Text = "";
                            Label6.Text = "";
                            isOn = false; // 예외 발생 시 isOn 상태 복원
                            timer.Stop(); // 타이머 중지
                        }
                    }
                    catch (JsonReaderException jsonEx)
                    {
                        Label8.Text = $"Failed to parse JSON response! : {jsonEx.Message}";
                        Label4.Text = "";
                        Label5.Text = "";
                        Label6.Text = "";
                        isOn = false; // 예외 발생 시 isOn 상태 복원
                        timer.Stop(); // 타이머 중지
                    }
                }
                catch (Exception ex)
                {
                    Label8.Text = $"Error: {ex.Message}";
                    Label4.Text = "";
                    Label5.Text = "";
                    Label6.Text = "";
                    isOn = false; // 예외 발생 시 isOn 상태 복원
                    timer.Stop(); // 타이머 중지
                }
            }
        }

    }
}