using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;


namespace FrameworkDesign2021._2.ServiceLocator.Pattern.Example
{
    public class Expamle : MonoBehaviour
    {
        /// <summary>
        /// 自定义的 InitialContext
        /// </summary>
        private class InitialContext : AbstractInitialContext
        {
            public override IService LookUp(string name)
            { 
                /*
                    // 获取 Example 所在的 Service
                    var assembly = typeof(Example).Assembly;

                    var serviceType = typeof(IService);

                    var service = assembly
                        .GetTypes()
                        .Where(t => serviceType.IsAssignableFrom(t) && !t.IsAbstract)
                        .Select(t => t.GetConstructors().First<ConstructorInfo>().Invoke(null))
                        .Cast<IService>()
                        .SingleOrDefault(s => s.Name == name);
                */
                IService iService = null;
                if (name == "bluetooth")
                {
                    iService = new BluetoothService();
                }

                return iService;
            }
        }
        
        public class BluetoothService : IService
        {
            /// <summary>
            /// 服务
            /// </summary>
            public string Name
            {
                get { return "bluetooth"; }
            }

            public void Execute()
            {
                Debug.Log("蓝牙服务启动");
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            var context = new InitialContext();
            
            var serviceLocator = new ServiceLocator(context);

            var bluetoothService = serviceLocator.GetService("bluetooth");
            
            bluetoothService.Execute();
        }
    }
}
