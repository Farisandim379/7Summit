namespace SevenSummit.View
{
    partial class HistoryBooking
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
            this.btnHapus = new Guna.UI2.WinForms.Guna2Button();
            this.btnDataGunung = new Guna.UI2.WinForms.Guna2Button();
            this.BtnHistoryBooking = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lvwBooking = new System.Windows.Forms.ListView();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHapus
            // 
            this.btnHapus.BorderRadius = 5;
            this.btnHapus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHapus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHapus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHapus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHapus.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.ForeColor = System.Drawing.Color.White;
            this.btnHapus.Location = new System.Drawing.Point(688, 394);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(100, 27);
            this.btnHapus.TabIndex = 13;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnDataGunung
            // 
            this.btnDataGunung.BorderRadius = 5;
            this.btnDataGunung.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDataGunung.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDataGunung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDataGunung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDataGunung.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btnDataGunung.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataGunung.ForeColor = System.Drawing.Color.White;
            this.btnDataGunung.Location = new System.Drawing.Point(9, 75);
            this.btnDataGunung.Name = "btnDataGunung";
            this.btnDataGunung.Size = new System.Drawing.Size(173, 27);
            this.btnDataGunung.TabIndex = 2;
            this.btnDataGunung.Text = "Data Gunung";
            // 
            // BtnHistoryBooking
            // 
            this.BtnHistoryBooking.BorderRadius = 5;
            this.BtnHistoryBooking.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnHistoryBooking.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnHistoryBooking.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnHistoryBooking.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnHistoryBooking.FillColor = System.Drawing.Color.DarkSlateGray;
            this.BtnHistoryBooking.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHistoryBooking.ForeColor = System.Drawing.Color.White;
            this.BtnHistoryBooking.Location = new System.Drawing.Point(9, 108);
            this.BtnHistoryBooking.Name = "BtnHistoryBooking";
            this.BtnHistoryBooking.Size = new System.Drawing.Size(173, 27);
            this.BtnHistoryBooking.TabIndex = 2;
            this.BtnHistoryBooking.Text = "History Booking";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Controls.Add(this.BtnHistoryBooking);
            this.guna2Panel1.Controls.Add(this.btnDataGunung);
            this.guna2Panel1.Location = new System.Drawing.Point(3, -2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(182, 454);
            this.guna2Panel1.TabIndex = 12;
            // 
            // lvwBooking
            // 
            this.lvwBooking.HideSelection = false;
            this.lvwBooking.Location = new System.Drawing.Point(191, 73);
            this.lvwBooking.Name = "lvwBooking";
            this.lvwBooking.Size = new System.Drawing.Size(606, 283);
            this.lvwBooking.TabIndex = 6;
            this.lvwBooking.UseCompatibleStateImageBehavior = false;
            this.lvwBooking.SelectedIndexChanged += new System.EventHandler(this.lvwBooking_SelectedIndexChanged);
            // 
            // HistoryBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lvwBooking);
            this.Controls.Add(this.btnHapus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HistoryBooking";
            this.Text = "HistoryBooking";
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnHapus;
        private Guna.UI2.WinForms.Guna2Button btnDataGunung;
        private Guna.UI2.WinForms.Guna2Button BtnHistoryBooking;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.ListView lvwBooking;
    }
}