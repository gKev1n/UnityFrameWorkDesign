namespace _FrameworkDesign2021
{
    public abstract class Singleton<T> : ISingleton where T : Singleton<T>
    {
        protected static T mInstance;
        
        static object mLock = new object();

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

        public virtual void Dispose()
        {
            mInstance = null;
        }


        public void OnSingletonInit()
        {
        }
    }
}