using GatewayTether.Entities;
using GatewayTether.Enums;
using GatewayTether.Repositories;
using GatewayTether.Helpers;
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
using GatewayTether.XmlDocument;

namespace GatewayTether.Forms
{
    public partial class AddWalletForm : Form
    {
        private readonly WalletRepository walletRepository;
        public AddWalletForm()
        {
            InitializeComponent();
            walletRepository = new WalletRepository();
        }

        private void AddWalletForm_Load(object sender, EventArgs e)
        {
            cmb_CoinType.DataSource = Enum.GetValues(typeof(CoinType));
            cmb_TokenType.DataSource = Enum.GetValues(typeof(TokenType));
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrWhiteSpace(txt_WalletAddress.Text) || string.IsNullOrWhiteSpace(txt_WebhookAddress.Text)))
                {
                    var wallet = new TblWallet();
                    wallet.Address = txt_WalletAddress.Text;
                    wallet.WebhookAddress = txt_WebhookAddress.Text;
                    wallet.Enabled = true;
                    wallet.CreateDate = DateTime.Now;
                    wallet.TokenType = (TokenType)cmb_TokenType.SelectedItem;
                    wallet.CoinType = (CoinType)cmb_CoinType.SelectedItem;

                    if (walletRepository.Add(wallet))
                    {
                        MessageBox.Show("Wallet successfully added");
                    }
                    else
                    {
                        MessageBox.Show("An error has occurred");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the values");
                }
            }
            catch (Exception ex)
            {
                WriteXmlDocument.AddException(MethodBase.GetCurrentMethod().DeclaringType.FullName,ex);
                MessageBox.Show("An error has occurred");
            }
        }
    }
}
