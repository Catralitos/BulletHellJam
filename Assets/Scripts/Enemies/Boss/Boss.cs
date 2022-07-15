using System;
using System.Collections.Generic;
using Audio;
using Bullets.Spawners;
using Enemies.Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enemies.Boss
{
    public class Boss : EnemyBase<Boss>
    {
        public bool clockwise = true;
        public int numActivePools = 1;
        public float phaseCooldown = 10f;
        public float rotateSpeed = 10f;
        public List<Spawner> spawners;
        public List<String> bulletPools;
        protected override void Start()
        {
            base.Start();
            State = BossShoot.Create(this);
        }

        public void IncreaseActivePools()
        {
            if (numActivePools >= 5) return;
            numActivePools++;
        }

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

        private void LoadCredits()
        {
            Debug.Log("Chamou Load Credits");
            //Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}