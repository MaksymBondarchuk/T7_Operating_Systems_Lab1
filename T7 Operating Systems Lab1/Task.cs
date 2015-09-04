using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Operating_Systems_Lab1
{
    class Task
    {
        int number;
        int spawned_on;
        int length;
        int completed_on = -1;  // Not completed yet
        int tacts_waited;

        public Task(int spawned_on)
        {
            this.spawned_on = spawned_on;
            length = (new Random()).Next(1, 11);    // from 1 till 10
        }

    }
}
