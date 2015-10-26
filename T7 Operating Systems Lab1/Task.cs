using System;

namespace T7_Operating_Systems_Lab1
{
    class Task
    {
        public int Number;
        public int SpawnedOn;
        public int Length;
        public int CompletedOn = -1;  // Not completed yet
        public int Memory;

        public Task(int number, int spawnedOn, int length, int memory)
        {
            this.Number = number;
            this.SpawnedOn = spawnedOn;
            this.Length = (new Random()).Next(1, length + 1);    // from 1 till length
            this.Memory = (new Random()).Next(1, memory + 1);
        }
    }
}
