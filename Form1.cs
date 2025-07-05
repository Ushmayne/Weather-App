namespace Weather_App;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;

public partial class Form1 : Form
{
    String apiKey;

    public Form1()
    {

        string filePath = Path.Combine(Application.StartupPath, "..", "..", "..", "keys.txt");//getting the filepath for the keys.txt directory
        filePath = Path.GetFullPath(filePath);//turning it into a full path

        using (System.IO.StreamReader file = new System.IO.StreamReader(filePath))
        {
            string line;
            apiKey = file.ReadLine();  // Read the first line for the API key
        }
        InitializeComponent();
        displayOptions();

    }

    private void displayOptions()
    {
        cityTextBox = new TextBox();
        checkWeatherButton = new Button();
        condition = new Label();
        detail = new Label();
        sunrise = new Label();
        sunset = new Label();
        windSpeed = new Label();
        pressure = new Label();



        Font font = new Font("Arial", 12, FontStyle.Regular);

        //city textbox
        cityTextBox.Location = new Point(110, 70);
        cityTextBox.Size = new Size(200, 80);
        cityTextBox.PlaceholderText = "Enter city name";


        //weather button
        checkWeatherButton.Text = "Search";
        checkWeatherButton.Location = new Point(320, 70);
        checkWeatherButton.Click += CheckWeatherButton_Click;

        //weather condition
        condition.Location = new Point(70, 150);
        condition.Text = "Condition";
        condition.Font = font;
        condition.BackColor = Color.Transparent;

        //detail label
        detail.Location = new Point(70, 180);
        detail.Text = "Detail";
        detail.Font = font;
        detail.BackColor = Color.Transparent;

        //sunrise label
        sunrise.Location = new Point(140, 240);
        sunrise.Text = "N/A";
        sunrise.Font = font;
        sunrise.BackColor = Color.Transparent;
        sunrise.AutoSize = true; // Ensure the label resizes to fit the text

        //sunset label
        sunset.Location = new Point(140, 280);
        sunset.Text = "N/A";
        sunset.Font = font;
        sunset.BackColor = Color.Transparent;
        sunset.AutoSize = true; // Ensure the label resizes to fit the text

        //wind speed label
        windSpeed.Location = new Point(410, 150);
        windSpeed.Text = "N/A";
        windSpeed.Font = font;
        windSpeed.BackColor = Color.Transparent;
        //pressure label
        pressure.Location = new Point(390, 180);
        pressure.Text = "N/A";
        pressure.Font = font;
        pressure.BackColor = Color.Transparent;



        this.Controls.Add(cityTextBox);
        this.Controls.Add(checkWeatherButton);
        this.Controls.Add(condition);
        this.Controls.Add(detail);
        this.Controls.Add(sunrise);
        this.Controls.Add(sunset);
        this.Controls.Add(windSpeed);
        this.Controls.Add(pressure);



        cityTextBox.Enabled = true;//making sure the textbox is enabled and readable
        cityTextBox.ReadOnly = false;




    }

    private void CheckWeatherButton_Click(object sender, EventArgs e)
    {
        // Get the city name from the TextBox
        Console.WriteLine(cityTextBox.Text.ToString());
        string city = cityTextBox.Text.Trim();

        if (string.IsNullOrEmpty(city))
        {
            MessageBox.Show("Please enter a city name.");
            cityTextBox.Text = string.Empty; // Clear the TextBox from any previous input
            return;
        }
        else
        {
            getWeather();
        }

        // Make API call to get weather data
        //string weatherInfo = await GetWeatherDataAsync(city);

        // Display the result
        //resultLabel.Text = weatherInfo;
    }

    void getWeather()
    {
        using (WebClient client = new WebClient())
        {
            string url = String.Format($"http://api.openweathermap.org/data/2.5/weather?q={cityTextBox.Text}&appid={apiKey}&units=metric");

            using (HttpClient client1 = new HttpClient())
            {
                try//to make sure of a succesful connection
                {

                    HttpResponseMessage response = client1.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();

                    string content = response.Content.ReadAsStringAsync().Result;  // Get response content synchronously
                    JObject weatherJson = JObject.Parse(content);
                    if (weatherJson["cod"].ToString() == "200")
                    {
                        var json = client.DownloadString(url);
                        weatherData.root info = JsonConvert.DeserializeObject<weatherData.root>(json);
                        condition.Text = info.weather[0].main;
                        detail.Text = info.weather[0].description;
                        sunset.Text = convertDateTime(info.sys.sunset).ToString();
                        sunrise.Text = convertDateTime(info.sys.sunrise).ToString();
                        windSpeed.Text = info.wind.speed.ToString() + " m/s";
                        pressure.Text = info.main.pressure.ToString() + " hPa";
                    }


                }
                catch (Exception ex)//catch exceptions if they enter the wrong city name
                {
                    Console.WriteLine("Error: " + ex.Message);
                    clearOptions(); // Clear the TextBox from any previous input
                }
            }


        }
    }

    DateTime convertDateTime(long milisec)
    {
        DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
        return (day.AddMilliseconds(milisec).ToLocalTime());

    }

    void clearOptions()//reset all the options to their defaults
    {
        cityTextBox.Text = string.Empty; 
        condition.Text = "Condition"; 
        detail.Text = "Detail"; 
        sunrise.Text = "N/A"; 
        sunset.Text = "N/A"; 
        windSpeed.Text = "N/A"; 
        pressure.Text = "N/A"; 
    }

    
    
}
