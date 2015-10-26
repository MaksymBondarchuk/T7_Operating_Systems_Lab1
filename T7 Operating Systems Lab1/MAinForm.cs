using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace T7_Operating_Systems_Lab1
{
    public partial class MainForm : Form
    {
        private readonly List<Task> _tasks = new List<Task>();
        private int _currentTact;               // Number of the current tact
        private int _number;                     // Number of the new task
        private int _nowWorkingWithTask = -1;     // Index in list/table
        private bool _isFree = true;                // Shows does processor works on some task now (on current tact)
        private int _willBeNotFreeFor;           // How many tacts left to complete current task
        private int _taskLength;
        private int _maxMemory;

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

            _taskLength = Convert.ToInt32(nudLength.Value);
            _maxMemory = Convert.ToInt32(nudMemory.Value);
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            OneTact.Stop();

            bStart.Enabled = true;
            bStop.Enabled = false;
        }

        private void OneTact_Tick(object sender, EventArgs e)
        {
            _currentTact++;

            // Deciding should we generate new task
            if ((new Random()).Next(100) < nudPossibility.Value * 100)
            {   // If yes
                _tasks.Add(new Task(_number++, _currentTact, _taskLength, _maxMemory));
                string[] strs = { _tasks[_tasks.Count - 1].Number.ToString(),
                    _tasks[_tasks.Count - 1].SpawnedOn.ToString(),
                    _tasks[_tasks.Count - 1].Length.ToString(),
                    "Not started yet", "Not started yet",
                    _tasks[_tasks.Count - 1].Memory.ToString() };
                lTasks.Items.Add(new ListViewItem(strs));
                if (0 < lTasks.Items.Count)     // Moving to the bottom of the listview
                    lTasks.EnsureVisible(lTasks.Items.Count - 1);
            }

            // If processor performing some task now
            if (!_isFree)
            {
                _willBeNotFreeFor--;
                if (_willBeNotFreeFor == 0)
                {   // If it just ended
                    _isFree = true;

                    // Calculating finish time
                    _tasks[_nowWorkingWithTask].CompletedOn = _currentTact;

                    string[] strs = { _tasks[_nowWorkingWithTask].Number.ToString(),
                        _tasks[_nowWorkingWithTask].SpawnedOn.ToString(),
                        _tasks[_nowWorkingWithTask].Length.ToString(),
                        (_tasks[_nowWorkingWithTask].CompletedOn - _tasks[_nowWorkingWithTask].Length).ToString(),
                        _tasks[_nowWorkingWithTask].CompletedOn.ToString(),
                        _tasks[_tasks.Count - 1].Memory.ToString() };
                    var item = new ListViewItem(strs);
                    lTasks.Items[_nowWorkingWithTask] = item;
                }
            }

            // If processor becomes free
            if (_isFree)
            {
                if (_nowWorkingWithTask + 1 < _tasks.Count || _nowWorkingWithTask == -1 && _tasks.Count != 0)
                {
                    _isFree = false;

                    _nowWorkingWithTask++;
                }
                else // If no tasks now
                    return;

                _willBeNotFreeFor = _tasks[_nowWorkingWithTask].Length;

                string[] strs = { _tasks[_nowWorkingWithTask].Number.ToString(),
                    _tasks[_nowWorkingWithTask].SpawnedOn.ToString(),
                    _tasks[_nowWorkingWithTask].Length.ToString(),
                    "Not completed yet" };
                var item = new ListViewItem(strs);
                lTasks.Items[_nowWorkingWithTask] = item;
            }
        }

        private void bBegin_Click(object sender, EventArgs e)
        {
            // Rollback
            OneTact.Stop();
            lTasks.Items.Clear();
            _tasks.Clear();
            _currentTact = 0;
            _number = 0;
            _nowWorkingWithTask = -1;
            _isFree = true;

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
