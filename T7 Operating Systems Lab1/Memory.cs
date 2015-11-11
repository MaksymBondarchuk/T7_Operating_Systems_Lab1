using System;
using System.Collections.Generic;
using System.Linq;

namespace T7_Operating_Systems_Lab1
{
    public class Memory
    {
        class MemoryUnitInfo
        {
            public int Addr;
            public int Size;

            public MemoryUnitInfo(int addr, int size)
            {
                Addr = addr;
                Size = size;
            }
        };

        // Information about memory
        private readonly List<MemoryUnitInfo> _infoFree;
        private readonly List<MemoryUnitInfo> _infoInUse;

        // Memory
        readonly List<long> _memoryBlock;

        public Memory(int size)
        {
            _infoFree = new List<MemoryUnitInfo> {new MemoryUnitInfo(0, size)};
            _infoInUse = new List<MemoryUnitInfo>();
            _memoryBlock = new List<long>(Convert.ToInt32(size / 8));
        }

        public int mem_alloc(int size)
        {
            for (var i = 0; i < _infoFree.Count; i++)
                if (size <= _infoFree[i].Size)
                {
                    _infoInUse.Add(new MemoryUnitInfo(_infoFree[i].Addr, size));
                    if (_infoFree[i].Size == size)  // If allocating the whole block
                        _infoFree.RemoveAt(i);
                    else
                    {  // Part of a block
                        _infoFree[i].Addr += size;
                        _infoFree[i].Size -= size;
                    }
                    return _infoInUse[_infoInUse.Count - 1].Addr;
                }
            return -1;
        }

        public void mem_free(int idx)
        {
            for (var i = 0; i < _infoInUse.Count; i++)
                if (idx == _infoInUse[i].Addr)
                {
                    _infoFree.Add(new MemoryUnitInfo(_infoInUse[i].Addr, _infoInUse[i].Size));
                    _infoInUse.RemoveAt(i);
                    break;
                }

            // Finding free block after current to merge
            for (var i = 0; i < _infoFree.Count - 1; i++)
                if (_infoFree[_infoFree.Count - 1].Addr + _infoFree[_infoFree.Count - 1].Size == _infoFree[i].Addr)
                {
                    _infoFree[_infoFree.Count - 1].Size += _infoFree[i].Size;
                    _infoFree.RemoveAt(i);
                    break;
                }

            // Finding free block before current to merge
            for (var i = 0; i < _infoFree.Count - 1; i++)
                if (_infoFree[i].Addr + _infoFree[i].Size == _infoFree[_infoFree.Count - 1].Addr)
                {
                    _infoFree[i].Size += _infoFree[_infoFree.Count - 1].Size;
                    _infoFree.RemoveAt(1);
                    break;
                }
        }

        public string mem_dump()
        {
            var result = "";
            int[] i = {0};
            while (i[0] < _memoryBlock.Capacity * 8)
            {
                foreach (var t in _infoFree.Where(t => t.Addr == i[0]))
                {
                    result += new string('_', t.Size / 8);
                    i[0] += t.Size;
                }

                foreach (var t in _infoInUse.Where(t => t.Addr == i[0]))
                {
                    result += new string('*', t.Size / 8);
                    i[0] += t.Size;
                }
            }

            return result;
        }

        public int Offset(int idx)
        {
            for (var i = 0; i < _infoInUse.Count; i++)
                if (idx == _infoInUse[i].Addr)
                {
                    return _infoInUse[i].Addr;
                }
            return -1;
        }
    };
}
