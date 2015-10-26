using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace T7_Operating_Systems_Lab1
{
    public partial class MainForm : Form
    {
        List<Task> tasks = new List<Task>();
        int current_tact = 0;               // Number of the current tact
        int number = 0;                     // Number of the new task
        int now_working_with_task = -1;     // Index in list/table
        bool is_free = true;                // Shows does processor works on some task now (on current tact)
        int will_be_not_free_for;           // How many tacts left to complete current task
        int task_length;
        int tacts_when_resourse_was_free = 0;

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

            bStart.Enabled = false;
            bStop.Enabled = true;
            bBegin.Enabled = true;

            task_length = Convert.ToInt32(nudLength.Value);
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            OneTact.Stop();
     
            // Calculating average waiting time
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].completed_on != -1)
                {
                    waited_sum += tasks[i].tacts_waited;
                    tasks_sum++;
                }
            }

            bStart.Enabled = true;
            bStop.Enabled = false;
        }

        private void OneTact_Tick(object sender, EventArgs e)
        {
            current_tact++;

            // Deciding should we generate new task
            if ((new Random()).Next(100) < nudPossibility.Value * 100)
            {   // If yes
                tasks.Add(new Task(number++, current_tact, task_length));
                string[] strs = { tasks[tasks.Count - 1].number.ToString(),
                    tasks[tasks.Count - 1].spawned_on.ToString(),
                    tasks[tasks.Count - 1].length.ToString(),
                    "Not completed yet", "Not started yet" };
                lTasks.Items.Add(new ListViewItem(strs));
                if (0 < lTasks.Items.Count)     // Moving to the bottom of the listview
                    lTasks.EnsureVisible(lTasks.Items.Count - 1);
            }

            // If processor performing some task now
            if (!is_free)
            {
                will_be_not_free_for--;
                if (will_be_not_free_for == 0)
                {   // If it just ended
                    is_free = true;

                    // Calculating finish time
                    tasks[now_working_with_task].completed_on = current_tact;

                    string[] strs = { tasks[now_working_with_task].number.ToString(),
                        tasks[now_working_with_task].spawned_on.ToString(),
                        tasks[now_working_with_task].length.ToString(),
                        tasks[now_working_with_task].completed_on.ToString(),
                        tasks[now_working_with_task].tacts_waited.ToString() };
                    ListViewItem item = new ListViewItem(strs);
                    lTasks.Items[now_working_with_task] = item;
                }
            }

            // If processor becomes free
            if (is_free)
            {
                if (now_working_with_task + 1 < tasks.Count || now_working_with_task == -1 && tasks.Count != 0)
                {
                    is_free = false;

                    now_working_with_task++;
                }
                else // If no tasks now
                {
                    tacts_when_resourse_was_free++;
                    return;
                }

                will_be_not_free_for = tasks[now_working_with_task].length;

                // Calculating how long task waited
                tasks[now_working_with_task].tacts_waited = current_tact - tasks[now_working_with_task].spawned_on;

                string[] strs = { tasks[now_working_with_task].number.ToString(),
                    tasks[now_working_with_task].spawned_on.ToString(),
                    tasks[now_working_with_task].length.ToString(),
                    "Not completed yet",
                    tasks[now_working_with_task].tacts_waited.ToString() };
                ListViewItem item = new ListViewItem(strs);
                lTasks.Items[now_working_with_task] = item;

                string[] strs1 = { tasks[now_working_with_task].number.ToString() };
            }
        }

        private void bBegin_Click(object sender, EventArgs e)
        {
            // Rollback
            OneTact.Stop();
            lTasks.Items.Clear();
            tasks.Clear();
            current_tact = 0;
            number = 0;
            now_working_with_task = -1;
            is_free = true;
            waited_sum = 0;
            tasks_sum = 0;
            tacts_when_resourse_was_free = 0;

            bStart.Enabled = true;
            bStop.Enabled = false;
        }

        private void nudPossibility_ValueChanged(object sender, EventArgs e)
        {
            bBegin.PerformClick();
        }

        private void nudLength_ValueChanged(object sender, EventArgs e)
        {
            bBegin.PerformClick();
        }
    }
}
