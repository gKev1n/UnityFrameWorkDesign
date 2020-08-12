using System;
using System.Collections.Generic;

namespace FrameworkDesign2021
{
    public class ModuleSearchKeys
    {
        public string Name { get; set; }

        public Type Type { get; set; }


        private ModuleSearchKeys()
        {
            
        }
        
        private static Stack<ModuleSearchKeys> mPool = new Stack<ModuleSearchKeys>(10);

        public static ModuleSearchKeys Allocate<T>()
        {
            ModuleSearchKeys outputKeys = null;

            outputKeys = mPool.Count != 0 ? mPool.Pop() : new ModuleSearchKeys();

            outputKeys.Type = typeof(T);

            return outputKeys;
        }

        public void Release2Pool()
        {
            Type = null;
            Name = null;
            
            mPool.Push(this);
        }
    }
}

