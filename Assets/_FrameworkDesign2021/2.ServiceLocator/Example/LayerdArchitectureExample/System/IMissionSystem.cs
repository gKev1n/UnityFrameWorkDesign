using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace FrameworkDesign2021._2.ServiceLocator.Example.LayerdArchitectureExample
{
    public interface IMissionSystem : ISystem
    {
        void OnEvent(string eventName);
    }

    public class MissionSystem : IMissionSystem
    {
        public void SetmJumpCount()
        {
            PlayerPrefs.SetInt("JUMP_COUNT", 0);
        }

        private int mJumpCount
        {
            get { return PlayerPrefs.GetInt("JUMP_COUNT"); }
            set { PlayerPrefs.SetInt("JUMP_COUNT", value); }
        }

        public void OnEvent(string eventName)
        {

            if (eventName == "JUMP")
            {
                mJumpCount++;
                
                Debug.Log(mJumpCount);

                if (mJumpCount == 1)
                {
                    Debug.Log("第一次跳跃 任务完成");
                }

                if (mJumpCount == 5)
                {
                    Debug.Log("跳跃新手 任务完成");
                }

                if (mJumpCount == 10)
                {
                    Debug.Log("跳跃达人 任务完成");
                }
            }
        }
    }
}