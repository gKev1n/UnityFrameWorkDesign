using UnityEngine;

namespace _FrameworkDesign2021._4.PackageKit
{
    public class ObserverPatternWithTES : MonoBehaviour
    {
        
        /// <summary>
        /// 通知消息
        /// </summary>
        class NotifyEvent
        {
        }

        /// <summary>
        /// 主题
        /// </summary>
        class Subject
        {
            public void DoObserverInterestedThings()
            {
                Notify();
            }

            void Notify()
            {
                TypeEventSystem.Send(new NotifyEvent());
            }
        }

        /// <summary>
        /// 观察者
        /// </summary>
        class Observer
        {
            public Observer()
            {
                Subscribe();
            }

            void Subscribe()
            {
                TypeEventSystem.Register<NotifyEvent>(Update);
            }

            void Update(NotifyEvent notifyEvent)
            {
                Debug.Log("Received Notification");
            }

            public void Dispose()
            {
                TypeEventSystem.UnRegister<NotifyEvent>(Update);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            var subject = new Subject();
            var observerA = new Observer();
            var observerB = new Observer();
            
            subject.DoObserverInterestedThings();
        }
    }
}
