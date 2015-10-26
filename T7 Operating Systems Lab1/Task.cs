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
        public int MemoryRef;

        public Task(int number, int spawnedOn, int length, int memory)
        {
            Number = number;
            SpawnedOn = spawnedOn;
            var random = new Random();
            Length = random.Next(1, length + 1);    // from 1 till length
            var _memory = random.Next(1, memory + 1);
            if (_memory%4 != 0)
                _memory += 4 - _memory%4;
            Memory = _memory;
        }
    }
}
