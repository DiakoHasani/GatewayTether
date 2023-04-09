using GatewayTether.Schedules;
using GatewayTether.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatewayTether.Forms
{
    public partial class HomeForm : Form, IScheduledTaskMessage
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        public async Task ClearMessage()
        {
            await Task.Run(() =>
            {
                txt_log.Text = "";
                txt_log.SelectionStart = txt_log.Text.Length;
                txt_log.ScrollToCaret();
            });
            
        }

        public async Task ShowMessage(string message)
        {
            await Task.Run(() =>
            {
                if (message.Length <= 32767)
                {
                    if ((txt_log.Text.Length + message.Length) < 32767)
                    {
                        txt_log.Text += message;
                        txt_log.Text += Environment.NewLine;
                    }
                    else
                    {
                        txt_log.Text = message;
                    }
                    txt_log.SelectionStart = txt_log.Text.Length;
                    txt_log.ScrollToCaret();
                }
            });
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            ScheduledTasksRegistry.Init(this);
        }

        private void btn_AddWallet_Click(object sender, EventArgs e)
        {
            new AddWalletForm().ShowDialog();
        }

        private void btn_ShowWallets_Click(object sender, EventArgs e)
        {
            new WalletsForm().ShowDialog();
        }
    }
}
