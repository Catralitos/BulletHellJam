using UnityEngine;

namespace Player
{
    public class PlayerEntity : MonoBehaviour
    {

        [HideInInspector] public PlayerHealth health;
        [HideInInspector] public PlayerShooting shooting;

        #region SingleTon

        public static PlayerEntity Instance;

        private void Awake()
        {
            Instance = this;
            health = GetComponent<PlayerHealth>();
            shooting = GetComponent<PlayerShooting>();
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