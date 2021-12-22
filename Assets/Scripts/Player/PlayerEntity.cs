using UnityEngine;

namespace Player
{
    public class PlayerEntity : MonoBehaviour
    {

        [HideInInspector] public PlayerHealth health;
        [HideInInspector] public PlayerShooting shooting;

        #region SingleTon
        
        public static PlayerEntity Instance;

        public int scorePerPowerUp;
        public int maxPowerUps;
        private int _fireRatesCollected;
        private int _moreBulletsCollected;
        
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

        public void AddBullets()
        {
            if (_moreBulletsCollected < maxPowerUps)
            {
                shooting.plus2++;
            }
            else
            {
                TimeManager.Instance.IncreaseScore(scorePerPowerUp);
            }
        }
        
        public void AddFireRate()
        {
            if (_fireRatesCollected < maxPowerUps)
            {
                shooting.currentFireRate /= 2;
            }
            else
            {
                TimeManager.Instance.IncreaseScore(scorePerPowerUp);
            }
        }
    }
}