namespace GatewayTether.Forms
{
    partial class WalletsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_Wallets = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Wallets)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Wallets
            // 
            this.dgv_Wallets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Wallets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Wallets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Wallets.Location = new System.Drawing.Point(12, 12);
            this.dgv_Wallets.Name = "dgv_Wallets";
            this.dgv_Wallets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Wallets.Size = new System.Drawing.Size(945, 612);
            this.dgv_Wallets.TabIndex = 0;
            this.dgv_Wallets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Wallets_CellClick);
            // 
            // WalletsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 636);
            this.Controls.Add(this.dgv_Wallets);
            this.Name = "WalletsForm";
            this.Text = "WalletsForm";
            this.Activated += new System.EventHandler(this.WalletsForm_Activated);
            this.Load += new System.EventHandler(this.WalletsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Wallets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Wallets;
    }
}