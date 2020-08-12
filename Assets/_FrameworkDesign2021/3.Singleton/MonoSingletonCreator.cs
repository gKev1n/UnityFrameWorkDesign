using UnityEngine;

namespace _FrameworkDesign2021
{
    public class MonoSingletonCreator
    {
        public static T CreateMonoSingleton<T>() where T : MonoBehaviour,ISingleton
        {
            // 获取场景中使用T的脚本
            var instance = Object.FindObjectOfType<T>();
            
            // 如果存在，直接返回
            if (instance)
            {
                instance.OnSingletonInit();
                return instance;
            }
            
            //创建实例
            if (!instance)
            {
                var gameObj = new GameObject(typeof(T).Name);
                Object.DontDestroyOnLoad(gameObj);
                instance = gameObj.AddComponent<T>();
            }
            
            instance.OnSingletonInit();
            return instance;
        }
    }
}