using Managers;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class PlayerEntity : MonoBehaviour
    {

        /// <summary>
        /// The movement
        /// </summary>
        [HideInInspector] public PlayerMovement movement;
        /// <summary>
        /// The health
        /// </summary>
        [HideInInspector] public PlayerHealth health;
        /// <summary>
        /// The shooting
        /// </summary>
        [HideInInspector] public PlayerShooting shooting;

        #region SingleTon

        /// <summary>
        /// The instance
        /// </summary>
        public static PlayerEntity Instance;

        /// <summary>
        /// The score per power up
        /// </summary>
        public int scorePerPowerUp;
        /// <summary>
        /// The maximum power ups
        /// </summary>
        public int maxPowerUps;
        /// <summary>
        /// The fire rates collected
        /// </summary>
        private int _fireRatesCollected;
        /// <summary>
        /// The more bullets collected
        /// </summary>
        private int _moreBulletsCollected;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake()
        {
            Instance = this;
            health = GetComponent<PlayerHealth>();
            shooting = GetComponent<PlayerShooting>();
            movement = GetComponent<PlayerMovement>();
        }

        #endregion

        /// <summary>
        /// Called when [destroy].
        /// </summary>
        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        /// <summary>
        /// Adds the bullets.
        /// </summary>
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

        /// <summary>
        /// Adds the fire rate.
        /// </summary>
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