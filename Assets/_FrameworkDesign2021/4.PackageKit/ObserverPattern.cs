using System.Collections.Generic;
using UnityEngine;

namespace _FrameworkDesign2021._4.PackageKit
{
    public class ObserverPattern : MonoBehaviour
    {
        abstract class Subject
        {
            List<Observer> mObservers = new List<Observer>();
            
            // 加入观察者
            public void Attach(Observer observer)
            {
                mObservers.Add(observer);
            }
            
            // 删除观察者
            public void Detach(Observer observer)
            {
                mObservers.Remove(observer);
            }
            
            // 通知所有观察者
            public void Notify()
            {
                mObservers.ForEach(observer => observer.Update());
            }
        }

        abstract class Observer
        {
            public abstract void Update();
        }

        class ConcreteSubject : Subject
        {
            private string mSubjectState;

            public void SetState(string state)
            {
                mSubjectState = state;
                Notify();
            }

            public string GetState()
            {
                return mSubjectState;
            }
        }

        class ConcreteObserver : Observer
        {

            private ConcreteSubject mSubject = null;

            public ConcreteObserver(ConcreteSubject subject)
            {
                mSubject = subject;
            }

            public override void Update()
            {
                Debug.Log("ConcreteObserver.Update");
                Debug.Log("ConcreteObserver:Subject 当前的主题： " + mSubject.GetState());
            }
        }

        void Start()
        {
            var subject = new  ConcreteSubject();
            var observer = new ConcreteObserver(subject);
            
            subject.Attach(observer);
            
            subject.SetState("测试");
        }
    }
}
