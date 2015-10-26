using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Operating_Systems_Lab1
{
    public class Memory
    {
        class Memory_unit_info
        {
            public int addr;
            public int size;

            public Memory_unit_info(int addr, int size)
            {
                this.addr = addr;
                this.size = size;
            }
        };

        // Information about memory
        private List<Memory_unit_info> info_free;
        private List<Memory_unit_info> info_in_use;

        // Memory
        List<long> memory_block;

        public Memory(int size)
        {
            info_free = new List<Memory_unit_info>();
            info_free.Add(new Memory_unit_info(0, size)); // All memory is free

            info_in_use = new List<Memory_unit_info>();

            memory_block = new List<long>(Convert.ToInt32(size / 8));
        }

        public int mem_alloc(int size)
        {
            for (int i = 0; i < info_free.Count; i++)
                if (size <= info_free[i].size)
                {
                    info_in_use.Add(new Memory_unit_info(info_free[i].addr, size));
                    if (info_free[i].size == size)  // If allocating the whole block
                        info_free.RemoveAt(i);
                    else
                    {  // Part of a block
                        info_free[i].addr += size;
                        info_free[i].size -= size;
                    }
                    return info_in_use[info_in_use.Count - 1].addr;
                }
            return -1;
        }

        public void mem_free(int idx)
        {
            for (int i = 0; i < info_in_use.Count; i++)
                if (idx == info_in_use[i].addr)
                {
                    info_free.Add(new Memory_unit_info(info_in_use[i].addr, info_in_use[i].size));
                    info_in_use.RemoveAt(i);
                    break;
                }

            // Finding free block after current to merge
            for (int i = 0; i < info_free.Count - 1; i++)
                if (info_free[info_free.Count - 1].addr + info_free[info_free.Count - 1].size == info_free[i].addr)
                {
                    info_free[info_free.Count - 1].size += info_free[i].size;
                    info_free.RemoveAt(i);
                    break;
                }

            // Finding free block before current to merge
            for (int i = 0; i < info_free.Count - 1; i++)
                if (info_free[i].addr + info_free[i].size == info_free[info_free.Count - 1].addr)
                {
                    info_free[i].size += info_free[info_free.Count - 1].size;
                    info_free.RemoveAt(1);
                    break;
                }
        }

        public string mem_dump()
        {
            string result = "";
            int i = 0;
            while (i < memory_block.Capacity * 8)
            {
                for (int j = 0; j < info_free.Count; j++)
                    if (info_free[j].addr == i)
                    {
                        result += new string('_', info_free[j].size / 8);
                        i += info_free[j].size;
                    }

                for (int j = 0; j < info_in_use.Count; j++)
                    if (info_in_use[j].addr == i)
                    {
                        result += new string('*', info_in_use[j].size / 8);
                        i += info_in_use[j].size;
                    }
            }

            return result;
        }
    };
}
