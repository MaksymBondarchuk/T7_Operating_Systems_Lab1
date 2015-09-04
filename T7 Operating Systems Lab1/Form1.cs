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
        List<Task> tasks = new List<Task>();
        int current_tact = 0;
        int number = 0;
        bool is_free = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            OneTact.Start();

            //string[] strs = { "1", "2", "3", "4", "5" };
            //ListViewItem item = new ListViewItem(strs);
            //lTasks.Items.Add(item);
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            OneTact.Stop();

            //string[] strs = { "1", "2", "Some", "4", "5" };
            //ListViewItem item = new ListViewItem(strs);
            //lTasks.Items[2] = item;
        }

        private void OneTact_Tick(object sender, EventArgs e)
        {
            current_tact++;

            //Random gen = new Random();
            //int prob = (new Random()).Next(100);
            if ((new Random()).Next(100) < nudPossibility.Value * 100)
            {
                tasks.Add(new Task(number++, current_tact));
                string[] strs = { tasks[tasks.Count - 1].number.ToString(),
                    tasks[tasks.Count - 1].spawned_on.ToString(),
                    tasks[tasks.Count - 1].length.ToString(),
                    "Not completed yet", "Not completed yet" };
                ListViewItem item = new ListViewItem(strs);
                lTasks.Items.Add(item);
                if (0 < lTasks.Items.Count)
                    lTasks.EnsureVisible(lTasks.Items.Count - 1);
            }

            if (is_free)
            {

            }

        }
    }
}
