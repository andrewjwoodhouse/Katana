using System;
using System.Windows.Forms;

namespace Katana
{ 
    


    public partial class Form1 : Form
    {

        


        public Form1()
        {
            InitializeComponent();

        }


        public void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void bCompile_Click(object sender, EventArgs e)
        {
            Form2.Compile();
        }





        private void bOpenFile_Click(object sender, EventArgs e)
        {
            string sourceFileName;
            var dialogResult1 = openFileDialog1.ShowDialog();
            if (dialogResult1 == DialogResult.OK)
            {

                // Read the file as one string.

                string fSourceFileName = openFileDialog1.FileName;
                Console.WriteLine("Instantiating Katana for " + fSourceFileName);
                Form2 gfx = new Form2(fSourceFileName);

            }
        }

        
    }



}


