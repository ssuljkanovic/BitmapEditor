namespace Editovanje_bitpame {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pb_slika = new System.Windows.Forms.PictureBox();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.btn_posaljiSliku = new System.Windows.Forms.Button();
            this.btn_urediSliku = new System.Windows.Forms.Button();
            this.btn_ucitajSliku = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_prikaziSliku = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cb_comPorts = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_slika)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_slika
            // 
            this.pb_slika.Location = new System.Drawing.Point(6, 19);
            this.pb_slika.Name = "pb_slika";
            this.pb_slika.Size = new System.Drawing.Size(252, 144);
            this.pb_slika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_slika.TabIndex = 0;
            this.pb_slika.TabStop = false;
            // 
            // btn_posaljiSliku
            // 
            this.btn_posaljiSliku.Location = new System.Drawing.Point(29, 76);
            this.btn_posaljiSliku.Name = "btn_posaljiSliku";
            this.btn_posaljiSliku.Size = new System.Drawing.Size(104, 23);
            this.btn_posaljiSliku.TabIndex = 1;
            this.btn_posaljiSliku.Text = "Pošalji sliku";
            this.btn_posaljiSliku.UseVisualStyleBackColor = true;
            this.btn_posaljiSliku.Click += new System.EventHandler(this.btn_posaljiSliku_Click);
            // 
            // btn_urediSliku
            // 
            this.btn_urediSliku.Location = new System.Drawing.Point(29, 105);
            this.btn_urediSliku.Name = "btn_urediSliku";
            this.btn_urediSliku.Size = new System.Drawing.Size(104, 23);
            this.btn_urediSliku.TabIndex = 2;
            this.btn_urediSliku.Text = "Uredi sliku";
            this.btn_urediSliku.UseVisualStyleBackColor = true;
            this.btn_urediSliku.Click += new System.EventHandler(this.btn_urediSliku_Click);
            // 
            // btn_ucitajSliku
            // 
            this.btn_ucitajSliku.Location = new System.Drawing.Point(29, 134);
            this.btn_ucitajSliku.Name = "btn_ucitajSliku";
            this.btn_ucitajSliku.Size = new System.Drawing.Size(104, 23);
            this.btn_ucitajSliku.TabIndex = 3;
            this.btn_ucitajSliku.Text = "Učitaj sliku";
            this.btn_ucitajSliku.UseVisualStyleBackColor = true;
            this.btn_ucitajSliku.Click += new System.EventHandler(this.btn_ucitajSliku_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_comPorts);
            this.groupBox1.Controls.Add(this.btn_prikaziSliku);
            this.groupBox1.Controls.Add(this.btn_posaljiSliku);
            this.groupBox1.Controls.Add(this.btn_ucitajSliku);
            this.groupBox1.Controls.Add(this.btn_urediSliku);
            this.groupBox1.Location = new System.Drawing.Point(360, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 163);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Komande";
            // 
            // btn_prikaziSliku
            // 
            this.btn_prikaziSliku.Location = new System.Drawing.Point(29, 47);
            this.btn_prikaziSliku.Name = "btn_prikaziSliku";
            this.btn_prikaziSliku.Size = new System.Drawing.Size(104, 23);
            this.btn_prikaziSliku.TabIndex = 0;
            this.btn_prikaziSliku.Text = "Prikaži sliku";
            this.btn_prikaziSliku.UseVisualStyleBackColor = true;
            this.btn_prikaziSliku.Click += new System.EventHandler(this.btn_prikaziSliku_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pb_slika);
            this.groupBox2.Location = new System.Drawing.Point(50, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 170);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Slika";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 289);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 22);
            this.statusStrip.TabIndex = 4;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // cb_comPorts
            // 
            this.cb_comPorts.FormattingEnabled = true;
            this.cb_comPorts.Location = new System.Drawing.Point(29, 20);
            this.cb_comPorts.Name = "cb_comPorts";
            this.cb_comPorts.Size = new System.Drawing.Size(104, 21);
            this.cb_comPorts.TabIndex = 6;
            this.cb_comPorts.SelectedIndexChanged += new System.EventHandler(this.cb_comPorts_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editovanje bitmape";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Click += new System.EventHandler(this.Form1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pb_slika)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_slika;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Button btn_posaljiSliku;
        private System.Windows.Forms.Button btn_urediSliku;
        private System.Windows.Forms.Button btn_ucitajSliku;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_prikaziSliku;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox cb_comPorts;
    }
}

