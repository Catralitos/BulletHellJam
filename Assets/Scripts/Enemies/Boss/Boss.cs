using System.Collections.Generic;
using Audio;
using Bullets.Spawners;
using Enemies.Base;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enemies.Boss
{
    /// <summary>
    /// The Boss class
    /// </summary>
    /// <seealso cref="Enemies.Base.EnemyBase&lt;Enemies.Boss.Boss&gt;" />
    public class Boss : EnemyBase<Boss>
    {
        /// <summary>
        /// If the boss is spinning clockwise
        /// </summary>
        public bool clockwise = true;
        /// <summary>
        /// The number of active bullet pools
        /// </summary>
        public int numActivePools = 1;
        /// <summary>
        /// The phase cooldown
        /// </summary>
        public float phaseCooldown = 10f;
        /// <summary>
        /// The rotation speed
        /// </summary>
        public float rotateSpeed = 10f;
        /// <summary>
        /// The bullet spawners
        /// </summary>
        public List<Spawner> spawners;
        /// <summary>
        /// The bullet pools
        /// </summary>
        public List<string> bulletPools;
        
        /// <summary>
        /// Starts this instance.
        /// </summary>
        protected override void Start()
        {
            base.Start();
            //Sets the state as BossShoot
            state = BossShoot.Create(this);
        }

        /// <summary>
        /// Increases the number of active bullet pools.
        /// </summary>
        public void IncreaseActivePools()
        {
            if (numActivePools >= 5) return;
            numActivePools++;
        }

        /// <summary>
        /// Kills this instance.
        /// </summary>
        protected override void Die()
        {
            TimeManager.Instance.IncreaseScore(pointsPerKill);
            var spawnPos = transform.position;
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
                AudioManager.Instance.Play("BossExplode");
            }
            TimeManager.Instance.gameEnded = true;
            AudioManager.Instance.Stop("LevelMusic");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Invoke(nameof(LoadCredits), 2.75f);
        }

        /// <summary>
        /// Loads the credits.
        /// </summary>
        private void LoadCredits()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}