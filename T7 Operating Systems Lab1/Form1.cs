using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T7_Operating_Systems_Lab1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            OneTact.Start();

            string[] strs = { "1", "2", "3", "4", "5" };
            ListViewItem item = new ListViewItem(strs);
            lTasks.Items.Add(item);
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            string[] strs = { "1", "2", "Some", "4", "5" };
            ListViewItem item = new ListViewItem(strs);
            lTasks.Items[2] = item;
        }

        private void OneTact_Tick(object sender, EventArgs e)
        {
            //Random gen = new Random();
            //int prob = (new Random()).Next(100);
            if ((new Random()).Next(100) < nudPossibility.Value * 100)
            {   // Yep

            }
        }
    }
}
