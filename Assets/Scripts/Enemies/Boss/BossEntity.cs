using UnityEngine;

namespace Enemies.Boss
{
    public class BossEntity : MonoBehaviour
    {
        [HideInInspector] public Boss boss;
        
        #region SingleTon

        public static BossEntity Instance;

        private void Awake()
        {
            Instance = this;
            boss = GetComponent<Boss>();
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