using System;
using _FrameworkDesign2021._4.PackageKit;
using UnityEngine;

namespace _FrameworkDesign2021
{
    public class MasterBehaviourExample : MasterBehaviour
    {
        public class EventA
        {
            
        }

        public class EventB
        {
        }

        // Start is called before the first frame update
        void Start()
        {
            this.Register<EventA>(OnEventAReceive);
            
            // 由于可以一次全部注销的原因
            // 注册支持用 lambda 表达式
            this.Register<EventB>((EventB =>
            { 
                Debug.Log("On Event B Receive");
            }));
        }

        void OnEventAReceive(EventA eventA)
        { 
            Debug.Log("On Event A Receive");
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.Send<EventA>(new EventA());
                this.Send<EventB>(new EventB());
            }

            if (Input.GetMouseButtonDown(1))
            {
                this.UnRegister<EventA>(OnEventAReceive); // 注销多次测试
                this.UnregisterAll();
            }
        }
    }
}
