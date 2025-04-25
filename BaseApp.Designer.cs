namespace ProjetoTS
{
    partial class BaseApp
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
            this.LBContacts = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBLContactName = new System.Windows.Forms.Label();
            this.BTNSend = new System.Windows.Forms.Button();
            this.TBMsg = new System.Windows.Forms.TextBox();
            this.LBChat = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBContacts
            // 
            this.LBContacts.FormattingEnabled = true;
            this.LBContacts.ItemHeight = 16;
            this.LBContacts.Location = new System.Drawing.Point(12, 56);
            this.LBContacts.Name = "LBContacts";
            this.LBContacts.Size = new System.Drawing.Size(274, 500);
            this.LBContacts.TabIndex = 0;
            this.LBContacts.SelectedIndexChanged += new System.EventHandler(this.listBoxContacts_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LBLContactName);
            this.panel1.Controls.Add(this.BTNSend);
            this.panel1.Controls.Add(this.TBMsg);
            this.panel1.Controls.Add(this.LBChat);
            this.panel1.Location = new System.Drawing.Point(310, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 538);
            this.panel1.TabIndex = 1;
            // 
            // LBLContactName
            // 
            this.LBLContactName.AutoSize = true;
            this.LBLContactName.Location = new System.Drawing.Point(77, 10);
            this.LBLContactName.Name = "LBLContactName";
            this.LBLContactName.Size = new System.Drawing.Size(44, 16);
            this.LBLContactName.TabIndex = 3;
            this.LBLContactName.Text = "label1";
            // 
            // BTNSend
            // 
            this.BTNSend.Location = new System.Drawing.Point(790, 435);
            this.BTNSend.Name = "BTNSend";
            this.BTNSend.Size = new System.Drawing.Size(75, 46);
            this.BTNSend.TabIndex = 2;
            this.BTNSend.Text = "button1";
            this.BTNSend.UseVisualStyleBackColor = true;
            // 
            // TBMsg
            // 
            this.TBMsg.Location = new System.Drawing.Point(80, 435);
            this.TBMsg.Multiline = true;
            this.TBMsg.Name = "TBMsg";
            this.TBMsg.Size = new System.Drawing.Size(707, 46);
            this.TBMsg.TabIndex = 1;
            // 
            // LBChat
            // 
            this.LBChat.FormattingEnabled = true;
            this.LBChat.ItemHeight = 16;
            this.LBChat.Items.AddRange(new object[] {
            "WEW",
            "DASDA"});
            this.LBChat.Location = new System.Drawing.Point(80, 41);
            this.LBChat.Name = "LBChat";
            this.LBChat.Size = new System.Drawing.Size(785, 388);
            this.LBChat.TabIndex = 0;
            this.LBChat.SelectedIndexChanged += new System.EventHandler(this.LBChat_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // BaseApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 581);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LBContacts);
            this.Name = "BaseApp";
            this.Text = "BaseApp";
            this.Load += new System.EventHandler(this.BaseApp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBContacts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox LBChat;
        private System.Windows.Forms.TextBox TBMsg;
        private System.Windows.Forms.Button BTNSend;
        private System.Windows.Forms.Label LBLContactName;
        private System.Windows.Forms.Label label1;
    }
}