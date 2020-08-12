using System;
using System.Collections.Generic;
using System.Linq;


namespace FrameworkDesign2021._2.ServiceLocator.Default
{
    public class DefaultModuleCache : IModuleCache
    {
        private Dictionary<Type, List<object>> mModulesByType = new Dictionary<Type, List<object>>();

        public object GetModule(ModuleSearchKeys keys)
        {
            List<object> output = null;

            if (mModulesByType.TryGetValue(keys.Type, out output))
            {
                return output.FirstOrDefault();
            }

            return null;
        }

        public object GetAllModules()
        {
            //  SelectMany 可以理解成 二维遍历
            return mModulesByType.Values.SelectMany(list => list);
        }


        public void AddModule(ModuleSearchKeys keys, object module)
        {
            if (mModulesByType.ContainsKey(keys.Type))
            {
                mModulesByType[keys.Type].Add(module);
            }
            else
            {
                mModulesByType.Add(keys.Type, new List<object>() {module});
            }
        }
        
    }
}