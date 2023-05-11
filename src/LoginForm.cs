using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagmaMc.UAS
{
    internal partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allows Hiding Or Showing The Input Boxes
        /// </summary>
        /// <param name="Hide"></param>
        /// <param name="ReadOnly"></param>
        public void Inputs(bool Hide, bool ReadOnly)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    Inputs(Hide, ReadOnly);
                }));
                return;
            }
            Username_Input.Visible = !Hide;
            Username_Input.ReadOnly = ReadOnly;
            Password_Input.Visible = !Hide;
            Password_Input.ReadOnly = ReadOnly;
        }

        /// <summary>
        /// Enables Or Disables ConnectionHandler (Checks If Can Contact The Remote Servers)
        /// </summary>
        /// <param name="enable"></param>
        public void EnableConnectionHandler(bool enable)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    EnableConnectionHandler(enable);
                }));
                return;
            }

            ConnectionHandler.Enabled = enable;
            ConnectionGIF.Visible = enable;
            Refresh();

        }

        public void SetProgressBar(byte progress)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    SetProgressBar(progress);
                }));
                return;
            }
            Login_Progress.Value = progress;
        }

        private void betterPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        bool Tasking = false;
        int Failed = 0;
        private void Connection_Update(object sender, EventArgs e)
        {
            if (Failed == 0)
            {
                Inputs(true, false);
                Failed++;
            }
            if (!Tasking)
            {
                Tasking = true;
                new Thread(() =>
                {
                    try
                    {
                        bool Allow = (UDUtils.CallAPI(APIEndPoints.APIPathProxy, null).Success);
                        if (Failed > 15)
                            if (DialogResult.Cancel == MessageBox.Show("Failed To Connect To Remote UserData Servers", "https://accounts.magma-mc.net/API/", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)) Environment.Exit(0); else Failed = 0;
                        if (!Allow)
                            Failed++;
                        else 
                            Failed = 0;
                        if (Allow)
                        {
                            Inputs(false, false);
                            Invoke(new Action(() =>
                            {
                                ConnectionGIF.Visible = false;
                                ConnectionHandler.Enabled = false;
                            }));
                        }
                    } catch { }
                    Tasking = false;
                }).Start();
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadingGIF.Visible = true;
            new Thread(() =>
            {
                UserData UD = UserData.Read();
                if (UD != null)
                {
                    UD = UserData.GetUserData(UD.Authorisation);
                    Bitmap icon = UDUtils.DownloadBitmap("https://" + UD.Icon);
                    BeginInvoke(new Action(() =>
                    {
                        UD_Email.Text = UD.Email;
                        UD_Icon.Image = icon;
                        LoginButton.Text = "Logout";
                        LoadingGIF.Visible = false;
                    }));
                }
                else
                {

                    BeginInvoke(new Action(() =>
                    {
                        LoadingGIF.Visible = false;
                    }));
                }
            }).Start();
        }

        private void CreateAcccount_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.UseShellExecute = true;
            processStartInfo.FileName = "https://accounts.magma-mc.net/Account.php";
            Process.Start(processStartInfo);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoadingGIF.Visible = true;
            if (LoginButton.Text == "Logout" )
            {
                UD_Email.Text = "";
                UD_Icon.Image = null;
                File.Delete(UserData.Filename);
                LoginButton.Text = "Login";
                LoadingGIF.Visible = false;
                Refresh();
                return;
            } 
            new Thread(() =>
            {
                UserData UD = new UserData();
                UD.Username = Username_Input.Text;
                UD.Password = Password_Input.Text;
                bool vaild = UD.ValidLogin();
                BeginInvoke(new Action(() =>
                {
                    LoadingGIF.Visible = false;
                    if (vaild)
                    {
                        UserData.GetUserData((APIData)UD).Save();
                        Hide();
                        Dispose();
                        Close();
                    }
                    else
                        MessageBox.Show("Username Or Password Is Incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }).Start();
        }
    }
}
