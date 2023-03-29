using System;
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
    /// 
    /// </summary>
    /// <seealso cref="Enemies.Base.EnemyBase&lt;Enemies.Boss.Boss&gt;" />
    public class Boss : EnemyBase<Boss>
    {
        /// <summary>
        /// The clockwise
        /// </summary>
        public bool clockwise = true;
        /// <summary>
        /// The number active pools
        /// </summary>
        public int numActivePools = 1;
        /// <summary>
        /// The phase cooldown
        /// </summary>
        public float phaseCooldown = 10f;
        /// <summary>
        /// The rotate speed
        /// </summary>
        public float rotateSpeed = 10f;
        /// <summary>
        /// The spawners
        /// </summary>
        public List<Spawner> spawners;
        /// <summary>
        /// The bullet pools
        /// </summary>
        public List<String> bulletPools;
        /// <summary>
        /// Starts this instance.
        /// </summary>
        protected override void Start()
        {
            base.Start();
            State = BossShoot.Create(this);
        }

        /// <summary>
        /// Increases the active pools.
        /// </summary>
        public void IncreaseActivePools()
        {
            if (numActivePools >= 5) return;
            numActivePools++;
        }

        /// <summary>
        /// Dies this instance.
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
            Debug.Log("Chamou Load Credits");
            //Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}