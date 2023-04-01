using Audio;
using Extensions;
using Managers;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// This class handles player health and getting hit
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class PlayerHealth : MonoBehaviour
    {
        /// <summary>
        /// The layers of the damaging objects
        /// </summary>
        public LayerMask damagers;
        /// <summary>
        /// The explosion prefab
        /// </summary>
        public GameObject explosionPrefab;
        
        /// <summary>
        /// The renderer
        /// </summary>
        private SpriteRenderer _renderer;
        /// <summary>
        /// The default material
        /// </summary>
        private Material _defaultMaterial;
        /// <summary>
        /// The hit material
        /// </summary>
        public Material hitMaterial;
        /// <summary>
        /// How many hits the player can take before dying
        /// </summary>
        public int playerHits = 5;
        /// <summary>
        /// The hits left
        /// </summary>
        public int hitsLeft = 5;
        /// <summary>
        /// The number of invincibility frames
        /// </summary>
        public int invincibilityFrames;
        /// <summary>
        /// If the player is currently invincible
        /// </summary>
        private bool _invincible;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            hitsLeft = playerHits;
            _renderer = GetComponent<SpriteRenderer>();
            _defaultMaterial = _renderer.material;
        }

        /// <summary>
        /// Called when [collision stay2 d].
        /// </summary>
        /// <param name="other">The other.</param>
        private void OnCollisionStay2D(Collision2D other)
        {
            if (!damagers.HasLayer(other.gameObject.layer)) return;
            DoDamage();
        }

        /// <summary>
        /// Does the damage.
        /// </summary>
        public void DoDamage()
        {
            if (_invincible || _playerMovement.dashing || TimeManager.Instance.gameEnded) return;
            if (hitsLeft > 1)
            {
                AudioManager.Instance.Play("PlayerHit");
                hitsLeft--;
                TimeManager.Instance.healthText.text = TimeManager.Instance.healthText.text.Substring(0, hitsLeft * 2);
                _renderer.material = hitMaterial;
                _invincible = true;
                Invoke(nameof(RestoreVulnerability), invincibilityFrames * Time.deltaTime);
            }
            else
            {
                AudioManager.Instance.Play("PlayerDeath");
                Die();
            }
        }

        /// <summary>
        /// Restores the vulnerability.
        /// </summary>
        private void RestoreVulnerability()
        {
            _invincible = false;
            _renderer.material = _defaultMaterial;
        }

        /// <summary>
        /// Dies this instance.
        /// </summary>
        private void Die()
        {
            TimeManager.Instance.healthText.text = "";
            var spawnPos = gameObject.transform.position;
            Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
            TimeManager.Instance.GoToDeathScreen();
            Destroy(gameObject);
        }
    }
}