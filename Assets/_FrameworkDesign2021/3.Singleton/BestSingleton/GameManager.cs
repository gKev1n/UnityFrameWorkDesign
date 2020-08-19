using UnityEngine;

namespace _FrameworkDesign2021._3.Singleton.BestSingleton
{
    public class GameManager : MonoBehaviour,ISingleton
    {
        private static GameManager mInstance
        {
            get { return MonoSingletonProperty<GameManager>.Instance; }
        }
        
        void ISingleton.OnSingletonInit() { }

        private int _mScore = 0;

        private int _mHealth = 100;

        public void Play(int addScore,int addHealth)
        {
            mInstance._mScore += addScore;
            mInstance._mHealth += addHealth;
        }
        public void Pause() { }
        public void Resume() { }
        public void GameOver() { }
        
    }
}
