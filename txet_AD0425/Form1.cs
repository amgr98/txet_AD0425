using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace txet_AD0425
{
    public partial class txtTextEditor : Form
    {
        public txtTextEditor()
        {
            InitializeComponent();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void btnChangeFormColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog.FileName);
                MessageBox.Show("The file has been saved successfully");
            }
        }

        private void btnFontD_Click(object sender, EventArgs e)
        {
            FontDialog fntDlg = new FontDialog();
            DialogResult result = fntDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fntDlg.Font;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string fileName = getOpenFileDialog();
            if (fileName.Length > 0)
                richTextBox1.LoadFile(fileName);
        }
        private string getOpenFileDialog()
        {
            string rtnValue = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                rtnValue = openFileDialog.FileName;
            }
            return rtnValue;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
            richTextBox1.SelectedText=String.Empty;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);

        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string xx =Clipboard.GetText();
            richTextBox1.Text=richTextBox1.Text.Insert(richTextBox1.SelectionStart,xx);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
          
}
    
