using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;


namespace _FrameworkDesign2021
{
    public static class MonoSingletonProperty<T> where T : MonoBehaviour, ISingleton
    {
        private static T mInstance;

        public static T Instance
        {
            get
            {
                if (mInstance ==null)
                {
                    mInstance = MonoSingletonCreator.CreateMonoSingleton<T>();
                }

                return mInstance;
            }
        }

        public static void Dispose()
        {
            Object.Destroy(mInstance.gameObject);

            mInstance = null;
        }

    }
}

