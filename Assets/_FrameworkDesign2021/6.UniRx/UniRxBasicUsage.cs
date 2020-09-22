using UniRx;
using UnityEngine;

namespace _FrameworkDesign2021._6.UniRx
{
    public class UniRxBasicUsage : MonoBehaviour
    {
        void Start()
        {
            Observable.EveryUpdate()
                .Where(_ => Time.frameCount % 5 == 0)
                .Subscribe(_ => Debug.Log("Hello"));
        }
    }
}
