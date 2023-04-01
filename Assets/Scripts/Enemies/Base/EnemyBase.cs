using System.Collections.Generic;
using Audio;
using Extensions;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Base
{
    /// <summary>
    /// Enemy class. Specific enemies inherit this class
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public abstract class EnemyBase : MonoBehaviour
    {
        /// <summary>
        /// Gets a value indicating whether this instance is alive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is alive; otherwise, <c>false</c>.
        /// </value>
        protected bool IsAlive => currentHealth > 0;

        /// <summary>
        /// The player bullets layer
        /// </summary>
        public LayerMask playerBullets;

        /// <summary>
        /// The points the player receives when they kill this enemy
        /// </summary>
        public int pointsPerKill;
        /// <summary>
        /// The current health
        /// </summary>
        public int currentHealth;
        /// <summary>
        /// The maximum health
        /// </summary>
        public int maxHealth;
        /// <summary>
        /// The random drop chance
        /// </summary>
        public float randomDropChance = 0.1f;
        /// <summary>
        /// The power ups it can drop when it dies
        /// </summary>
        public List<GameObject> powerUps;

        /// <summary>
        /// If the enemy becomes invincible on hit
        /// </summary>
        public bool hasInvincibility = true;

        /// <summary>
        /// The SpriteRenderer
        /// </summary>
        private SpriteRenderer _renderer;
        /// <summary>
        /// The default material
        /// </summary>
        private Material _defaultMaterial;
        /// <summary>
        /// The material when the enemy is hit
        /// </summary>
        public Material hitMaterial;
        /// <summary>
        /// The number of invincibility frames
        /// </summary>
        public int invincibilityFrames;
        /// <summary>
        /// If the enemy is currently invincible
        /// </summary>
        private bool _invincible;

        /// <summary>
        /// The explosion prefab that spawns when the enemy dies
        /// </summary>
        public GameObject explosionPrefab;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        protected virtual void Start()
        {
            currentHealth = maxHealth;
            //Save the default material, so it can be switched out on hit
            if (hasInvincibility)
            {
                _renderer = GetComponent<SpriteRenderer>();
                _defaultMaterial = _renderer.material;
            }
        }
        
        /// <summary>
        /// Deal damage to the enemy
        /// </summary>
        /// <param name="damage">The damage.</param>
        protected virtual void Hit(int damage)
        {
            if (_invincible) return;
            if (!IsAlive) return;
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            //If it's the boss, play the BossHit sound, otherwise, the EnemyHit souns
            var x = this as Boss.Boss;
            if (x != null)
            {
                AudioManager.Instance.Play("BossHit");
            }
            else
            {
                AudioManager.Instance.Play("EnemyHit");

            }
            if (!IsAlive)
            {
                Die();
            }
            else
            {
                //If the enemy has i-frames, switch to a different white material, and make it invulnerable to damage
                //We then invoke a function to restore vulnerability and switch back the material
                if (hasInvincibility)
                {
                    _renderer.material = hitMaterial;
                    _invincible = true;
                    Invoke(nameof(RestoreVulnerability), invincibilityFrames * Time.deltaTime);
                }
            }
        }

        /// <summary>
        /// Restores the vulnerability.
        /// </summary>
        private void RestoreVulnerability()
        {
            _renderer.material = _defaultMaterial;
            _invincible = false;
        }

        /// <summary>
        /// Kills this instance.
        /// </summary>
        protected virtual void Die()
        {
            //Increase the player's score
            TimeManager.Instance.IncreaseScore(pointsPerKill);
            //Spawn the explosion
            var spawnPos = transform.position;
            if (explosionPrefab != null) Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
            //Spawn a power up at random
            if (Random.Range(0.0f, 1.0f) <= randomDropChance)
            {
                Instantiate(powerUps[Random.Range(0, powerUps.Count)], spawnPos, Quaternion.identity);
            }

            AudioManager.Instance.Play("EnemyExplode");
            Destroy(gameObject);
        }

        /// <summary>
        /// Called when [trigger enter2 d].
        /// </summary>
        /// <param name="other">The other.</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            //If an enemy collides with a player's bullet
            if (!playerBullets.HasLayer(other.gameObject.layer)) return;

            //It will take damage
            Hit(1);
            //And destroy the player's bullets
            Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// Every Enemy inherits from this class.
    /// This class allows it to easily switch between states.
    /// </summary>
    /// <typeparam name="TEnemyType">The type of the enemy type.</typeparam>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public abstract class EnemyBase<TEnemyType> : EnemyBase where TEnemyType : EnemyBase<TEnemyType>
    {
        /// <summary>
        /// The current state of the enemy
        /// </summary>
        protected EnemyState<TEnemyType> state;

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="state">The state.</param>
        public void SetState(EnemyState<TEnemyType> state)
        {
            this.state = state;
        }
        
        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected virtual void Update()
        {
            if (!IsAlive) return;
            //If the state has not started, start it.
            if (!state.Initialized) state.StateStart();
            //Update the state
            state.StateUpdate();
        }

        /// <summary>
        /// Updates this instance at a fixed rate
        /// </summary>
        protected virtual void FixedUpdate()
        {
            if (!IsAlive) return;
            //If the state has not started, start it.
            if (!state.Initialized) state.StateStart();
            //Update the state using FixedUpdate (for physics and such)
            state.StateFixedUpdate();
        }
    }
}