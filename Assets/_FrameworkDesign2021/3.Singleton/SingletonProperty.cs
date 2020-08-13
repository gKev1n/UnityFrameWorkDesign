using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _FrameworkDesign2021
{
    public static class SingletonProperty<T> where T : class, ISingleton
    {
        private static T mInstance;
        private static readonly object mLock = new Object();

        public static T Instance
        {
            get
            {
                lock (mLock)
                {
                    if (mInstance == null)
                    {
                        mInstance = SingletonCreator.CreateSingleton<T>();
                    }
                }

                return mInstance;
            }
        }

        public static void Dispose()
        {
            mInstance = null;
        }
    }
}

