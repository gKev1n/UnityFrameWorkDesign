using UniRx;
using UnityEngine;

namespace _FrameworkDesign2021._6.UniRx
{
    public class UniRxSubjectExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var subject = new Subject<int>();

            subject.Subscribe(number =>
            {
                Debug.Log(number);
            });
        
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(3);
        }
    }
}
