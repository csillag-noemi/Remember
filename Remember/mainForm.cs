using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remember
{
    public partial class MainForm : Form
    {
        SqliteConnection Conn = new SqliteConnection();
        private HttpClient _client;
        private Timer _messageTimer;

        public MainForm(SqliteConnection connection)
        {
            Conn = connection;
            InitializeComponent();
            AddVersionNumber();
            InitializeHttpClient();
            SetupMessageTimer();
        }

        SqliteCommand cmd = new SqliteCommand();

        private void AddVersionNumber()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            Text += $"  v.{fileVersionInfo.FileVersion}";
        }

        private void logInMainFormButton_Click(object sender, EventArgs e)
        {
            if (usrMainFormTextBox.Text.Equals("") || pwMainFormTextBox.Text.Equals(""))
            {
                MessageBox.Show("Username or password field is empty", "Registration faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Conn.Open();
                string loginQuery = "Select * from tbl_users where username = '" + usrMainFormTextBox.Text + "' and password = '" + pwMainFormTextBox.Text + "'";
                cmd = new SqliteCommand(loginQuery, Conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    new Dashboard().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again", "Login failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usrMainFormTextBox.Text = "";
                    pwMainFormTextBox.Text = "";
                    usrMainFormTextBox.Focus();
                }

            }
        }

        private void signUpMainFormButton_Click(object sender, EventArgs e)
        {
            new SignUpForm(Conn).Show();
            this.Hide();
        }

        private void showPwMainFormCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPwMainFormCheckBox.Checked)
            {
                pwMainFormTextBox.PasswordChar = '\0';
            }
            else
            {
                pwMainFormTextBox.PasswordChar = '●';
            }
        }

        private void InitializeHttpClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7009/"); // Change to your API's base address
        }

        private void SetupMessageTimer()
        {
            _messageTimer = new Timer();
            _messageTimer.Interval = 5000; // Check every 5 seconds
            _messageTimer.Tick += MessageTimer_Tick;
            _messageTimer.Start();
        }

        private async void MessageTimer_Tick(object sender, EventArgs e)
        {
            var response = await _client.GetAsync("api/messages");
            if (response.IsSuccessStatusCode)
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var messages = JsonConvert.DeserializeObject<List<string>>(json);
                    foreach (var message in messages)
                    {
                        MessageBox.Show(message, "New Message Received");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to fetch messages.");
                }
        }

    }
}