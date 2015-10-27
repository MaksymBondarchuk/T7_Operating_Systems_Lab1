using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace T7_Operating_Systems_Lab1
{
    public partial class MainForm : Form
    {
        private readonly List<Task> _tasksToPerform = new List<Task>();
        private readonly List<Task> _tasksActive = new List<Task>();
        private int _currentTact;               // Number of the current tact
        private int _number;                     // Number of the new task
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
            // Deciding should we generate new task
            if ((new Random()).Next(100) < nudPossibility.Value * 100)
            {   // If yes
                var _taskNew = new Task(_number++, _currentTact, _taskLength, _maxMemory);
                _tasksToPerform.Add(_taskNew);
                string[] strsNew = { _taskNew.Number.ToString(),
                    _taskNew.SpawnedOn.ToString(),
                    _taskNew.Length.ToString(),
                    "Not started yet", "Not completed yet",
                    _taskNew.Memory.ToString() };
                lvTasks.Items.Add(new ListViewItem(strsNew));
                if (0 < lvTasks.Items.Count)     // Moving to the bottom of the listview
                    lvTasks.EnsureVisible(lvTasks.Items.Count - 1);
            }

            // Looking for tasks we can perform
            for (var i = 0; i < _tasksToPerform.Count; i++)
            {
                var refTryAlloc = _memory.mem_alloc(_tasksToPerform[i].Memory);
                if (refTryAlloc == -1) continue;

                _tasksToPerform[i].MemoryRef = refTryAlloc;
                _tasksToPerform[i].StartedOn = _currentTact;
                _tasksActive.Add(_tasksToPerform[i]);

                string[] strsStarted = { _tasksToPerform[i].Number.ToString(),
                    _tasksToPerform[i].SpawnedOn.ToString(),
                    _tasksToPerform[i].Length.ToString(),
                    _currentTact.ToString(), "Not completed yet",
                    _tasksToPerform[i].Memory.ToString() };
                lvTasks.Items[_tasksToPerform[i].Number] = new ListViewItem(strsStarted);

                _tasksToPerform.RemoveAt(i);
            }

            // Looking for completed tasks
            for (var i = 0; i < _tasksActive.Count; i++)
            {
                if (_tasksActive[i].StartedOn + _tasksActive[i].Length != _currentTact) continue;

                _tasksActive[i].CompletedOn = _currentTact;

                string[] strsCompleted = { _tasksActive[i].Number.ToString(),
                    _tasksActive[i].SpawnedOn.ToString(),
                    _tasksActive[i].Length.ToString(),
                    _tasksActive[i].StartedOn.ToString(),
                    _tasksActive[i].CompletedOn.ToString(),
                    _tasksActive[i].Memory.ToString() };
                lvTasks.Items[_tasksActive[i].Number] = new ListViewItem(strsCompleted);

                _memory.mem_free(_tasksActive[i].MemoryRef);
                _tasksActive.RemoveAt(i);
            }

            // Adding information about memory
            string[] strsMem = { _currentTact.ToString(),
                    _memory.mem_dump() };
            var itemMem = new ListViewItem(strsMem);
            lvMemory.Items.Add(itemMem);
            if (0 < lvMemory.Items.Count)     // Moving to the bottom of the listview
                lvMemory.EnsureVisible(lvMemory.Items.Count - 1);

            _currentTact++;
        }

        private void bBegin_Click(object sender, EventArgs e)
        {
            // Rollback
            OneTact.Stop();
            lvTasks.Items.Clear();
            lvMemory.Items.Clear();
            
            _tasksToPerform.Clear();
            _tasksActive.Clear();
            _currentTact = 0;
            _number = 0;

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
