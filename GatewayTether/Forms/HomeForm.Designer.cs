namespace GatewayTether.Forms
{
    partial class HomeForm
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
            this.txt_log = new System.Windows.Forms.TextBox();
            this.btn_AddWallet = new System.Windows.Forms.Button();
            this.btn_ShowWallets = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_log
            // 
            this.txt_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_log.Location = new System.Drawing.Point(12, 66);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.Size = new System.Drawing.Size(776, 667);
            this.txt_log.TabIndex = 0;
            // 
            // btn_AddWallet
            // 
            this.btn_AddWallet.Location = new System.Drawing.Point(12, 12);
            this.btn_AddWallet.Name = "btn_AddWallet";
            this.btn_AddWallet.Size = new System.Drawing.Size(75, 23);
            this.btn_AddWallet.TabIndex = 1;
            this.btn_AddWallet.Text = "Add Wallet";
            this.btn_AddWallet.UseVisualStyleBackColor = true;
            this.btn_AddWallet.Click += new System.EventHandler(this.btn_AddWallet_Click);
            // 
            // btn_ShowWallets
            // 
            this.btn_ShowWallets.Location = new System.Drawing.Point(93, 12);
            this.btn_ShowWallets.Name = "btn_ShowWallets";
            this.btn_ShowWallets.Size = new System.Drawing.Size(102, 23);
            this.btn_ShowWallets.TabIndex = 2;
            this.btn_ShowWallets.Text = "Show Wallets";
            this.btn_ShowWallets.UseVisualStyleBackColor = true;
            this.btn_ShowWallets.Click += new System.EventHandler(this.btn_ShowWallets_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 745);
            this.Controls.Add(this.btn_ShowWallets);
            this.Controls.Add(this.btn_AddWallet);
            this.Controls.Add(this.txt_log);
            this.Name = "HomeForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Button btn_AddWallet;
        private System.Windows.Forms.Button btn_ShowWallets;
    }
}

