using System;
using UnityEngine;

namespace _FrameworkDesign2021.Example
{
    public class SingletonExample : MonoBehaviour
    {
        public class GameManager : Singleton<GameManager>
        {
            private GameManager()
            {
            }

            public void PlayGame()
            {
                Debug.Log("PlayGame");
            }
        }

        private void Start()
        {
            GameManager.Instance.PlayGame();

            var instance = GameManager.Instance;
            var instance1 = GameManager.Instance;
            
            Debug.Log(instance.GetHashCode() == instance1.GetHashCode());
        }
    }
}