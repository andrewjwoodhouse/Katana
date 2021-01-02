
namespace Katana
{
    partial class Form1
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
        public void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bCompile = new System.Windows.Forms.Button();
            this.bOpenFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Silk source (*.ssc)|*.ssc";
            // 
            // bCompile
            // 
            this.bCompile.Location = new System.Drawing.Point(129, 22);
            this.bCompile.Name = "bCompile";
            this.bCompile.Size = new System.Drawing.Size(98, 30);
            this.bCompile.TabIndex = 2;
            this.bCompile.Text = "Build and Run";
            this.bCompile.UseVisualStyleBackColor = true;
            this.bCompile.Click += new System.EventHandler(this.bCompile_Click);
            // 
            // bOpenFile
            // 
            this.bOpenFile.Location = new System.Drawing.Point(15, 19);
            this.bOpenFile.Name = "bOpenFile";
            this.bOpenFile.Size = new System.Drawing.Size(98, 33);
            this.bOpenFile.TabIndex = 6;
            this.bOpenFile.Text = "Open";
            this.bOpenFile.UseVisualStyleBackColor = true;
            this.bOpenFile.Click += new System.EventHandler(this.bOpenFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.bOpenFile);
            this.groupBox1.Controls.Add(this.bCompile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 74);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 122);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Katana Controller";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bCompile;
        private System.Windows.Forms.Button bOpenFile;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

