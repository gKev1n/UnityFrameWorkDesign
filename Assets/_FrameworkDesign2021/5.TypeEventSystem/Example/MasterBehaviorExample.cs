using UnityEngine;

namespace _FrameworkDesign2021._5.TypeEventSystem.Example
{
    public class MasterBehaviorExample : MonoBehaviour
    {
        public class EventA {}
        public class EventB {}

        // 创建服务
        EventService mEventService = new EventService();

        void Start()
        {
            mEventService.Register<EventA>(OnEventAReceive);

            // 注册支持用 lambda 表达式
            mEventService.Register<EventB>((EventB=>{
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
                mEventService.Send<EventA>(new EventA());
                mEventService.Send<EventB>(new EventB());
            }
        }

        void OnDestroy()
        {
            mEventService.UnRegisterAll();
            mEventService = null;
        }
    }
}
