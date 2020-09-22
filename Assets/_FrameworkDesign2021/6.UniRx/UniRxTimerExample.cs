using System;
using UniRx;
using UnityEngine;

namespace _FrameworkDesign2021._6.UniRx
{
    public class UniRxTimerExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("此时：" +  DateTime.Now);

            Observable.Timer(TimeSpan.FromSeconds(2.0f))
                .Subscribe(_ => Debug.Log("此时：" + DateTime.Now))
                .AddTo(this);

            Observable.Timer(TimeSpan.FromSeconds(0.5f))
                .Subscribe(_ =>
                {
                    Destroy(gameObject);
                    Debug.Log("已删除。");
                });
        }
    
    
    }
}
