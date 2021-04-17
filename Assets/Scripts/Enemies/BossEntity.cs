using UnityEngine;

namespace Bullets.Spawners.Enemies
{
    public class BossEntity : MonoBehaviour
    {
        #region SingleTon

        public static BossEntity Instance;

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}