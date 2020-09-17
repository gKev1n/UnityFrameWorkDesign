﻿using UnityEngine;

namespace _FrameworkDesign2021._4.PackageKit
{
    public class EventExample : MonoBehaviour
    {
        
        class A
        {
        }

        class B
        {
        }
        // Start is called before the first frame update
        void Start()
        {
            TypeEventSystem.Register<A>(ReceiveA);

            TypeEventSystem.Register<B>(ReceiveB);
        }


        void ReceiveA(A a)
        {
            Debug.Log("Receive A");
        }

        void ReceiveB(B b)
        {
            Debug.Log("Receive B");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TypeEventSystem.Send(new A());
            }

            if (Input.GetMouseButtonDown(1))
            {
                TypeEventSystem.Send(new B());
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                TypeEventSystem.UnRegister<A>(ReceiveA);
                TypeEventSystem.UnRegister<B>(ReceiveB);
            }
        }
    }
}
