using System;

namespace T7_Operating_Systems_Lab1
{
    class Task
    {
        public int Number;
        public int SpawnedOn;
        public int Length;
        public int StartedOn;
        public int CompletedOn;
        public int Memory;
        public int MemoryRef;

        public Task(int number, int spawnedOn, int length, int memory)
        {
            Number = number;
            SpawnedOn = spawnedOn;
            var random = new Random();
            Length = random.Next(1, length + 1);    // from 1 till length
            var mem = random.Next(1, memory - 8 + 1);
            if (mem % 8 != 0)
                mem += 8 - mem % 8;
            Memory = mem;
        }
    }
}
