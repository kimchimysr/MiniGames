using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGames
{
    public partial class FrmSaveToFile : Form
    {
        private List<string> listItems = new List<string>();
        //private string filePath = 
        //    @"I:\Study Materials\Year III\Semester II\C# Programming II\MiniGames\Saves\ItemsList.txt";
        private string filePath =
            @"I:\Study Materials\Year III\Semester II\C# Programming II\MiniGames\Saves\ItemsList.bin";
        private Boolean isEdited = false;
        private Boolean isSaved = false;

        public FrmSaveToFile()
        {
            InitializeComponent();
            this.txtItem.Select();
        }

        private void FrmSaveToFile_Load(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs, Encoding.Default))
                    {
                        while (fs.Position < fs.Length)
                        {
                            string line = br.ReadString();
                            this.listItems.Add(line);
                        }
                    }
                }

                foreach (string line in this.listItems)
                {
                    this.lbItems.Items.Add(line);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtItem.Text))
            {
                if(this.lbItems.Items.Count == 0)
                {
                    this.lbItems.Items.Add(this.txtItem.Text);
                    this.listItems.Add(this.txtItem.Text);
                }
                else
                {
                    if (this.lbItems.Items.Contains(this.txtItem.Text))
                        MessageBox.Show(this.txtItem.Text + " already exist!", "Duplicate Entry", MessageBoxButtons.OK);
                    else
                    {
                        this.lbItems.Items.Add(this.txtItem.Text);
                        this.listItems.Add(this.txtItem.Text);
                    }
                }
                this.isEdited = true;
            }
            this.txtItem.Text = "";
            this.isSaved = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.lbItems.SelectedIndex;
            if (selectedIndex != -1)
            {
                this.lbItems.Items.RemoveAt(selectedIndex);
                this.listItems.RemoveAt(selectedIndex);
                this.isSaved = false;
                this.isEdited = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.listItems.Count > 0)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                //File.WriteAllLines(filePath, listItems);
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Default))
                    {
                        foreach (string line in this.listItems)
                            bw.Write(line);
                        //new FileInfo(filePath).Encrypt();
                    }
                }
                this.isSaved = true;
                this.isEdited = true;
            }
            else MessageBox.Show("List is Empty!");
        }

        private void FrmSaveToFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.isSaved == false && this.isEdited == true && this.listItems.Count > 0)
            {
                DialogResult result = 
                    MessageBox.Show("Do you want to save your work before exit?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    //File.WriteAllLines(filePath, listItems);
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Default))
                        {
                            foreach (string line in this.listItems)
                                bw.Write(line);
                            //new FileInfo(filePath).Encrypt();
                        }
                    }
                }
            }
        }
    }
}
