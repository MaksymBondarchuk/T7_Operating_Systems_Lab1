using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Operating_Systems_Lab1
{
    class Task
    {
        public int number;
        public int spawned_on;
        public int length;
        public int completed_on = -1;  // Not completed yet
        public int tacts_waited;

        public Task(int number, int spawned_on)
        {
            this.number = number;
            this.spawned_on = spawned_on;
            length = (new Random()).Next(1, 20);    // from 1 till 10
        }


    }
}
