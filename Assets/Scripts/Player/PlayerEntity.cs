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
        /// The PlayerMovement
        /// </summary>
        [HideInInspector] public PlayerMovement movement;
        /// <summary>
        /// The PlayerHealth
        /// </summary>
        [HideInInspector] public PlayerHealth health;
        /// <summary>
        /// The PlayerShooting
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
        /// Adds a bullet powerup
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
        /// Adds a fire rate power up
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