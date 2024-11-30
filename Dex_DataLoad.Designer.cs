namespace WinFormsApp
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Button0 = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Result.SuspendLayout();
            this.SuspendLayout();
            //
            // Button0
            //
            this.Button0.Text =  "Track";
            this.Button0.Location = new System.Drawing.Point(396,16);
            this.Button0.TabIndex = 2;
            //
            // TextBox1
            //
            this.TextBox1.Text =  "Dex Address";
            this.TextBox1.Location = new System.Drawing.Point(120,16);
            this.TextBox1.Size = new System.Drawing.Size(272,23);
            this.TextBox1.TabIndex = 1;
            //
            // Result
            //
            this.Result.Controls.Add(this.Label1);
            this.Result.Controls.Add(this.Label2);
            this.Result.Controls.Add(this.Label3);
            this.Result.Controls.Add(this.Label4);
            this.Result.Controls.Add(this.Label5);
            this.Result.Controls.Add(this.Label6);
            this.Result.Text =  "Result";
            this.Result.Location = new System.Drawing.Point(12,72);
            this.Result.Size = new System.Drawing.Size(456,116);
            this.Result.TabIndex = 10;
            //
            // Label1
            //
            this.Label1.AutoSize =  true;
            this.Label1.Text =  "PairAddress :";
            this.Label1.Location = new System.Drawing.Point(12,24);
            this.Label1.Size = new System.Drawing.Size(76,15);
            this.Label1.TabIndex = 11;
            //
            // Label2
            //
            this.Label2.AutoSize =  true;
            this.Label2.Text =  "BaseTokenAddress :";
            this.Label2.Location = new System.Drawing.Point(12,56);
            this.Label2.Size = new System.Drawing.Size(112,15);
            this.Label2.TabIndex = 12;
            //
            // Label3
            //
            this.Label3.AutoSize =  true;
            this.Label3.Text =  "Price :";
            this.Label3.Location = new System.Drawing.Point(12,88);
            this.Label3.Size = new System.Drawing.Size(40,15);
            this.Label3.TabIndex = 13;
            //
            // Label4
            //
            this.Label4.AutoSize =  true;
            this.Label4.Text =  "";
            this.Label4.Location = new System.Drawing.Point(92,24);
            this.Label4.Size = new System.Drawing.Size(42,15);
            this.Label4.TabIndex = 14;
            //
            // Label5
            //
            this.Label5.AutoSize =  true;
            this.Label5.Text =  "";
            this.Label5.Location = new System.Drawing.Point(128,56);
            this.Label5.Size = new System.Drawing.Size(42,15);
            this.Label5.TabIndex = 15;
            //
            // Label6
            //
            this.Label6.AutoSize =  true;
            this.Label6.Text =  "";
            this.Label6.Location = new System.Drawing.Point(56,88);
            this.Label6.Size = new System.Drawing.Size(42,15);
            this.Label6.TabIndex = 16;
            //
            // Label7
            //
            this.Label7.AutoSize =  true;
            this.Label7.Text =  "Status :";
            this.Label7.Location = new System.Drawing.Point(12,48);
            this.Label7.Size = new System.Drawing.Size(47,15);
            this.Label7.TabIndex = 17;
            //
            // Label8
            //
            this.Label8.AutoSize =  true;
            this.Label8.Text =  "Nomal";
            this.Label8.Location = new System.Drawing.Point(64,48);
            this.Label8.Size = new System.Drawing.Size(43,15);
            this.Label8.TabIndex = 19;
            //
            // ComboBox1
            //
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.DropDownWidth = 96;
            this.ComboBox1.ItemHeight = 15;
            this.ComboBox1.Location = new System.Drawing.Point(12, 16);
            this.ComboBox1.Size = new System.Drawing.Size(96, 23);
            this.ComboBox1.TabIndex = 11;
            this.ComboBox1.Items.AddRange(new string[] { "solana", "ethereum", "sui" });
            this.ComboBox1.SelectedIndex = 0; // 기본 선택 항목 설정
         //
         // form
         //
            this.MaximizeBox =  false;
            this.MinimizeBox =  false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(488,244);
            this.Text =  "Dexscreener Auto Load";
            this.Controls.Add(this.Button0);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.ComboBox1);
            this.Result.ResumeLayout(false);
            this.ResumeLayout(false);
        } 

        private System.Windows.Forms.Button Button0;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.GroupBox Result;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.ComboBox ComboBox1;
    }
}

