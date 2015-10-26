using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace T7_Operating_Systems_Lab1
{
    public partial class MainForm : Form
    {
        private readonly List<Task> _tasksToPerform = new List<Task>();
        private readonly List<Task> _tasksCompleted = new List<Task>();
        private readonly List<Task> _tasksActive = new List<Task>();
        private int _currentTact;               // Number of the current tact
        private int _number;                     // Number of the new task
        private int _nowWorkingWithTask = -1;     // Index in list/table
        private int _taskLength;
        private int _maxMemory;
        private Memory _memory;

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
            _memory = new Memory(_maxMemory);
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
                _tasksToPerform.Add(new Task(_number++, _currentTact, _taskLength, _maxMemory));
                string[] strs = { _tasksToPerform[_tasksToPerform.Count - 1].Number.ToString(),
                    _tasksToPerform[_tasksToPerform.Count - 1].SpawnedOn.ToString(),
                    _tasksToPerform[_tasksToPerform.Count - 1].Length.ToString(),
                    "Not started yet", "Not started yet",
                    _tasksToPerform[_tasksToPerform.Count - 1].Memory.ToString() };
                lTasks.Items.Add(new ListViewItem(strs));
                if (0 < lTasks.Items.Count)     // Moving to the bottom of the listview
                    lTasks.EnsureVisible(lTasks.Items.Count - 1);
            }

            for (var i = 0; i < _tasksToPerform.Count; i++)
            {
                var refTryAlloc = _memory.mem_alloc(_tasksToPerform[i].Memory);
                if (refTryAlloc == -1) continue;
                _tasksToPerform[i].MemoryRef = refTryAlloc;
                _tasksToPerform[i].CompletedOn = _currentTact + _tasksToPerform[i].Length;
                _tasksActive.Add(_tasksToPerform[i]);
                _tasksToPerform.RemoveAt(i);
            }


            // Calculating finish time
            _tasksToPerform[_nowWorkingWithTask].CompletedOn = _currentTact;

            string[] strs1 = { _tasksToPerform[_nowWorkingWithTask].Number.ToString(),
                        _tasksToPerform[_nowWorkingWithTask].SpawnedOn.ToString(),
                        _tasksToPerform[_nowWorkingWithTask].Length.ToString(),
                        (_tasksToPerform[_nowWorkingWithTask].CompletedOn - _tasksToPerform[_nowWorkingWithTask].Length).ToString(),
                        _tasksToPerform[_nowWorkingWithTask].CompletedOn.ToString(),
                        _tasksToPerform[_tasksToPerform.Count - 1].Memory.ToString() };
            var item1 = new ListViewItem(strs1);
            lTasks.Items[_nowWorkingWithTask] = item1;

            // If processor becomes free
            if (_nowWorkingWithTask + 1 < _tasksToPerform.Count || _nowWorkingWithTask == -1 && _tasksToPerform.Count != 0)
                _nowWorkingWithTask++;
            else // If no tasks now
                return;


            string[] strs2 = { _tasksToPerform[_nowWorkingWithTask].Number.ToString(),
                    _tasksToPerform[_nowWorkingWithTask].SpawnedOn.ToString(),
                    _tasksToPerform[_nowWorkingWithTask].Length.ToString(),
                    "Not completed yet" };
            var item = new ListViewItem(strs2);
            lTasks.Items[_nowWorkingWithTask] = item;
        }

        private void bBegin_Click(object sender, EventArgs e)
        {
            // Rollback
            OneTact.Stop();
            lTasks.Items.Clear();
            _tasksToPerform.Clear();
            _currentTact = 0;
            _number = 0;
            _nowWorkingWithTask = -1;

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
