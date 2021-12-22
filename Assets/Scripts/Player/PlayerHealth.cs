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

        private SpriteRenderer _renderer;
        private Material _defaultMaterial;
        public Material hitMaterial;
        public int playerHits = 5;
        public int hitsLeft = 5;
        public float invincibilityTime;
        private bool _invincible;
        
        private void Start()
        {
            hitsLeft = playerHits;
            _renderer = GetComponent<SpriteRenderer>();
            _defaultMaterial = _renderer.material;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!damagers.HasLayer(other.gameObject.layer)) return;
            if (!_invincible) DoDamage();
        }

        public void DoDamage()
        {
            if (hitsLeft > 1)
            {
                hitsLeft--;
                _renderer.material = hitMaterial;
                _invincible = true;
                Invoke(nameof(RestoreVulnerability), invincibilityTime);
            }
            else Die();
        }

        private void RestoreVulnerability()
        {
            _renderer.material = _defaultMaterial;
            _invincible = false;
        }
        
        private void Die()
        {
            var spawnPos = gameObject.transform.position;
            Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
            Invoke(nameof(BackToTitleScreen), 3f);
        }

        private void BackToTitleScreen()
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }
}