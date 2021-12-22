using System;
using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public LayerMask damagers;
        public GameObject explosionPrefab;

        public int playerHits = 1;
        public int hitsLeft = 1;

        private void Start()
        {
            hitsLeft = playerHits;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Collision");
            if (!damagers.HasLayer(other.gameObject.layer)) return;
            DoDamage();
        }

        public void DoDamage()
        {
            if (hitsLeft > 1) hitsLeft--;
            else Die();
        }

        private void Die()
        {
            var spawnPos = gameObject.transform.position;
            Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
            BackToTitleScreen();
        }

        private void BackToTitleScreen()
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }
}