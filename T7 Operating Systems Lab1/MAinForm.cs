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
        int now_working_with_task = -1;
        bool is_free = true;
        int will_be_not_free_for;

        // For calculating average value
        int waited_sum = 0;
        int tasks_sum = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            OneTact.Start();
            lAverage.Text = "";

            bStart.Enabled = false;
            bStop.Enabled = true;
            bBegin.Enabled = true;
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            OneTact.Stop();


            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].completed_on != -1)
                {
                    waited_sum += tasks[i].tacts_waited;
                    tasks_sum++;
                }
            }

            lAverage.Text = String.Format("Average waiting time is " + (waited_sum / (double)tasks_sum).ToString("0.00") + " tacts");

            bStart.Enabled = true;
            bStop.Enabled = false;
        }

        private void OneTact_Tick(object sender, EventArgs e)
        {
            current_tact++;

            if ((new Random()).Next(100) < nudPossibility.Value * 100)
            {
                tasks.Add(new Task(number++, current_tact));
                string[] strs = { tasks[tasks.Count - 1].number.ToString(),
                    tasks[tasks.Count - 1].spawned_on.ToString(),
                    tasks[tasks.Count - 1].length.ToString(),
                    "Not completed yet", "Not started yet" };
                //ListViewItem item = new ListViewItem(strs);
                lTasks.Items.Add(new ListViewItem(strs));
                if (0 < lTasks.Items.Count)
                    lTasks.EnsureVisible(lTasks.Items.Count - 1);
            }

            if (!is_free)
            {
                will_be_not_free_for--;
                if (will_be_not_free_for == 0)
                {
                    is_free = true;

                    tasks[now_working_with_task].completed_on = current_tact - tasks[now_working_with_task].tacts_waited;

                    string[] strs = { tasks[now_working_with_task].number.ToString(),
                        tasks[now_working_with_task].spawned_on.ToString(),
                        tasks[now_working_with_task].length.ToString(),
                        tasks[now_working_with_task].completed_on.ToString(),
                        tasks[now_working_with_task].tacts_waited.ToString() };
                    ListViewItem item = new ListViewItem(strs);
                    lTasks.Items[now_working_with_task] = item;
                }
            }

            if (is_free)
            {
                is_free = false;

                int min_length = -1;
                for (int i = 0; i < tasks.Count; i++)
                    if (tasks[i].completed_on == -1)
                    {
                        min_length = tasks[i].length;
                        break;
                    }

                if (min_length == -1)
                {
                    is_free = true;
                    return;
                }

                for (int i = 0; i < tasks.Count; i++)
                    if (tasks[i].completed_on == -1 && tasks[i].length <= min_length)
                    {
                        min_length = tasks[i].length;
                        now_working_with_task = i;
                        will_be_not_free_for = tasks[i].length;
                    }

                tasks[now_working_with_task].tacts_waited = current_tact - tasks[now_working_with_task].spawned_on;

                string[] strs = { tasks[now_working_with_task].number.ToString(),
                    tasks[now_working_with_task].spawned_on.ToString(),
                    tasks[now_working_with_task].length.ToString(),
                    "Not completed yet",
                    tasks[now_working_with_task].tacts_waited.ToString() };
                ListViewItem item = new ListViewItem(strs);
                lTasks.Items[now_working_with_task] = item;

                string[] strs1 = { tasks[now_working_with_task].number.ToString() };
                lQueue.Items.Add(new ListViewItem(strs1));
                if (0 < lQueue.Items.Count)
                    lQueue.EnsureVisible(lQueue.Items.Count - 1);
            }

        }

        private void bBegin_Click(object sender, EventArgs e)
        {
            OneTact.Stop();
            lTasks.Items.Clear();
            lQueue.Items.Clear();
            tasks.Clear();
            current_tact = 0;
            number = 0;
            now_working_with_task = -1;
            is_free = true;
            waited_sum = 0;
            tasks_sum = 0;

            bStart.Enabled = true;
            bStop.Enabled = false;
            lAverage.Text = "";
        }

        private void lAverage_Click(object sender, EventArgs e)
        {

        }
    }
}
