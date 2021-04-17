using UnityEngine;

namespace Player
{
    public class PlayerEntity : MonoBehaviour
    {

        public PlayerHealth health;
        
        #region SingleTon

        public static PlayerEntity Instance;

        private void Awake()
        {
            Instance = this;
            health = GetComponent<PlayerHealth>();
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