
namespace Katana
{
    partial class Form3
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
            this.programOutputText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // programOutputText
            // 
            this.programOutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programOutputText.Location = new System.Drawing.Point(0, 0);
            this.programOutputText.Name = "programOutputText";
            this.programOutputText.ReadOnly = true;
            this.programOutputText.Size = new System.Drawing.Size(800, 450);
            this.programOutputText.TabIndex = 0;
            this.programOutputText.Text = "";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.programOutputText);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Output";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox programOutputText;
    }
}