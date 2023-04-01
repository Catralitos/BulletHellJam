using Managers;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Singleton to easily access all the player's components
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

        /// <summary>
        /// The score per power up
        /// </summary>
        public int scorePerPowerUp;
        /// <summary>
        /// The maximum number of power ups
        /// </summary>
        public int maxPowerUps;
        /// <summary>
        /// The fire rate increase powerups collected
        /// </summary>
        private int _fireRatesCollected;
        /// <summary>
        /// The more bullets powerups collected
        /// </summary>
        private int _moreBulletsCollected;
        
        #region SingleTon

        /// <summary>
        /// Gets the sole instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static PlayerEntity Instance { get; private set; }

        /// <summary>
        /// Awakes this instance (if none exist).
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                health = GetComponent<PlayerHealth>();
                shooting = GetComponent<PlayerShooting>();
                movement = GetComponent<PlayerMovement>();
            }
            else
            {
                Destroy(gameObject);
            }
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