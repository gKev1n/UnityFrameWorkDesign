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
            this.Register<EventA>(OnEventReceiveA);
            this.Register<EventB>(OnEventReceiveB);
        }

        void OnEventReceiveA(EventA eventA)
        { 
            Debug.Log("On Event A Receive");
        }

        void OnEventReceiveB(EventB eventB)
        {
            Debug.Log("On Event B Receive");
        }

        private void OnDestroy()
        {
            // this.UnRegister<EventA>(OnEventReceiveA);
            // this.UnRegister<EventB>(OnEventReceiveB);
            this.UnregisterAll();
        }
    }
}
