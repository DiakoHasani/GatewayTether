namespace GatewayTether.Forms
{
    partial class AddWalletForm
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
            this.txt_WalletAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_CoinType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_TokenType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_WebhookAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_WalletAddress
            // 
            this.txt_WalletAddress.Location = new System.Drawing.Point(12, 53);
            this.txt_WalletAddress.Name = "txt_WalletAddress";
            this.txt_WalletAddress.Size = new System.Drawing.Size(600, 20);
            this.txt_WalletAddress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wallet Address";
            // 
            // cmb_CoinType
            // 
            this.cmb_CoinType.FormattingEnabled = true;
            this.cmb_CoinType.Location = new System.Drawing.Point(12, 122);
            this.cmb_CoinType.Name = "cmb_CoinType";
            this.cmb_CoinType.Size = new System.Drawing.Size(600, 21);
            this.cmb_CoinType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CoinType";
            // 
            // cmb_TokenType
            // 
            this.cmb_TokenType.FormattingEnabled = true;
            this.cmb_TokenType.Location = new System.Drawing.Point(12, 194);
            this.cmb_TokenType.Name = "cmb_TokenType";
            this.cmb_TokenType.Size = new System.Drawing.Size(600, 21);
            this.cmb_TokenType.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TokenType";
            // 
            // txt_WebhookAddress
            // 
            this.txt_WebhookAddress.Location = new System.Drawing.Point(12, 272);
            this.txt_WebhookAddress.Name = "txt_WebhookAddress";
            this.txt_WebhookAddress.Size = new System.Drawing.Size(600, 20);
            this.txt_WebhookAddress.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Webhook Address";
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(12, 334);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(110, 23);
            this.btn_Add.TabIndex = 8;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // AddWalletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 389);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_WebhookAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_TokenType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_CoinType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_WalletAddress);
            this.Name = "AddWalletForm";
            this.Text = "AddWalletForm";
            this.Load += new System.EventHandler(this.AddWalletForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_WalletAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_CoinType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_TokenType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_WebhookAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Add;
    }
}