using GatewayTether.Helpers;
using GatewayTether.Models;
using GatewayTether.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatewayTether.Forms
{
    public partial class WalletsForm : Form
    {
        private readonly WalletRepository walletRepository;
        public WalletsForm()
        {
            InitializeComponent();
            walletRepository = new WalletRepository();
        }

        private void WalletsForm_Load(object sender, EventArgs e)
        {

        }

        private void WalletsForm_Activated(object sender, EventArgs e)
        {
            dgv_Wallets.DataSource = walletRepository.GetAll().Select(a => new WalletsModel
            {
                Address = a.Address,
                CoinType = a.CoinType.ToString(),
                CreateDate = a.CreateDate.ToShamsiDate(),
                Enabled = a.Enabled ? "Enabled" : "Disabled",
                Id = a.Id,
                TokenType = a.TokenType.ToString()
            }).ToList();

            if (!dgv_Wallets.Columns.Contains("ChangeEnabled"))
            {
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "Change Enabled";
                col.Name = "ChangeEnabled";
                dgv_Wallets.Columns.Add(col);
            }
        }

        private void dgv_Wallets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Wallets.Columns[e.ColumnIndex].Name == "ChangeEnabled")
            {
                MessageBox.Show(walletRepository.ChangeEnabled(Convert.ToInt32(dgv_Wallets.Rows[e.RowIndex].Cells["Id"].Value.ToString())).Message);
            }
        }
    }
}
