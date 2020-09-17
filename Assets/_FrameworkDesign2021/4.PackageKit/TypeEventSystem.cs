using System;
using System.Collections.Generic;
using UnityEngine;

namespace _FrameworkDesign2021._4.PackageKit
{
    public class TypeEventSystem 
    {
        /// <summary>
        /// 接口 只负责存储在字典中
        /// </summary>
        interface IRegisterations
        {
            
        }

        /// <summary>
        /// 多个注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class Registerations<T> : IRegisterations
        {
            /// <summary>
            /// 委托本身可以一对多注册
            /// </summary>
            public Action<T> OnRecieves = obg => { };
        }

        /// <summary>
        /// 定义字典
        /// </summary>
        private static Dictionary<Type, IRegisterations> mTypeEventDict = new Dictionary<Type, IRegisterations>();



        /// <summary>
        /// 注册事件
        /// </summary>
        public static void Register<T>(System.Action<T> onReceive)
        {
            var type = typeof(T);
            IRegisterations registerations = null;
            
            // 已经有同一个类型的注册了
            // 只需要在增加委托即可
            if (mTypeEventDict.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations<T>;
                reg.OnRecieves += onReceive;
            }
            
            // 从没注册过该类型
            // 需要创建一个该类型的注册对象
            else
            {
                var reg = new Registerations<T>();
                reg.OnRecieves += onReceive;
                mTypeEventDict.Add(type, reg);
            }
            
        }

        /// <summary>
        /// 注销事件
        /// </summary>
        public static void UnRegister<T>(System.Action<T> OnReceive)
        {
            var type = typeof(T);

            IRegisterations registerations = null;

            if (mTypeEventDict.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations<T>;
                reg.OnRecieves -= OnReceive;
            }
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        public static void Send<T>(T t)
        {
            var type = typeof(T);

            IRegisterations registerations = null;

            if (mTypeEventDict.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations<T>;
                reg.OnRecieves(t);
            }
        }
    }
}
