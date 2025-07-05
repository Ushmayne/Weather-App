namespace Weather_App;
using System;
using System.Drawing;
using System.Windows.Forms;
partial class Form1
{

    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }



    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        //this.BackColor = System.Drawing.Color.LightBlue; was initially set, but now a background image is used
        this.BackgroundImage = System.Drawing.Image.FromFile("C:\\Users\\usman\\Videos\\New Projects Git\\Weather app\\Weather-App\\weather.jpg");//insert file path to your image
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.Text = "Weather App";
        this.Paint += ScreenText_Paint;
        this.DoubleBuffered = true; // Enable double buffering to reduce flickering
        

    }

    private void ScreenText_Paint(object sender, PaintEventArgs e)
    {
        // Set up font and brush
        Font font = new Font("Arial", 12, FontStyle.Regular);
        Brush brush = Brushes.Black; // Use a contrasting color for visibility
        PointF point = new PointF(70, 70);

        // Draw the text on the form
        e.Graphics.DrawString("City: ", font, brush, point);
        point = new PointF(70, 130);
        e.Graphics.DrawString("Condition: ", font, brush, point);
        point = new PointF(70, 160);
        e.Graphics.DrawString("Detail: ", font, brush, point);
        point = new PointF(70, 240);
        e.Graphics.DrawString("Sunrise: ", font, brush, point);
        point = new PointF(70, 280);
        e.Graphics.DrawString("Sunset: ", font, brush, point);
        point = new PointF(310, 130);
        e.Graphics.DrawString("Wind Speed: ", font, brush, point);
        point = new PointF(310, 160);
        e.Graphics.DrawString("Pressure: ", font, brush, point);

        TextBox cityTextBox = new TextBox();
        cityTextBox.Location = new Point(110, 70);
        cityTextBox.Size = new Size(200, 80);
        cityTextBox.PlaceholderText = "Enter city name";

        Button checkWeatherButton = new Button();
        checkWeatherButton.Text = "Search";
        checkWeatherButton.Location = new Point(320, 70);
        //checkWeatherButton.Click += CheckWeatherButton_Click;
        this.Controls.Add(cityTextBox);
        this.Controls.Add(checkWeatherButton);

    }

    #endregion
}
