using System.Collections.Generic;
using Audio;
using Extensions;
using Managers;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Base
{
    /// <summary>
    /// 
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
        /// The player bullets
        /// </summary>
        public LayerMask playerBullets;

        /// <summary>
        /// The points per kill
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
        /// The power ups
        /// </summary>
        public List<GameObject> powerUps;

        /// <summary>
        /// The has invincibility
        /// </summary>
        public bool hasInvincibility = true;

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
        /// The invincibility frames
        /// </summary>
        public int invincibilityFrames;
        /// <summary>
        /// The invincible
        /// </summary>
        private bool _invincible;

        /// <summary>
        /// The explosion prefab
        /// </summary>
        public GameObject explosionPrefab;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        protected virtual void Start()
        {
            currentHealth = maxHealth;
            if (hasInvincibility)
            {
                _renderer = GetComponent<SpriteRenderer>();
                _defaultMaterial = _renderer.material;
            }
        }

        /// <summary>
        /// Calls the specified message name.
        /// </summary>
        /// <param name="messageName">Name of the message.</param>
        public void Call(string messageName)
        {
            SendMessage(messageName);
        }

        /// <summary>
        /// Hits the specified damage.
        /// </summary>
        /// <param name="damage">The damage.</param>
        protected virtual void Hit(int damage)
        {
            if (_invincible) return;
            if (!IsAlive) return;
            currentHealth = Mathf.Max(currentHealth - damage, 0);
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
        /// Dies this instance.
        /// </summary>
        protected virtual void Die()
        {
            TimeManager.Instance.IncreaseScore(pointsPerKill);
            var spawnPos = transform.position;
            if (explosionPrefab != null) Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
            //Destroy(gameObject);
            if (Random.Range(0.0f, 1.0f) <= randomDropChance)
            {
                Instantiate(powerUps[Random.Range(0, powerUps.Count)], spawnPos, Quaternion.identity);
            }

            Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
            AudioManager.Instance.Play("EnemyExplode");
            Destroy(gameObject);
        }

        /// <summary>
        /// Called when [trigger enter2 d].
        /// </summary>
        /// <param name="other">The other.</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!playerBullets.HasLayer(other.gameObject.layer)) return;

            Hit(1);
            Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEnemyType">The type of the enemy type.</typeparam>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public abstract class EnemyBase<TEnemyType> : EnemyBase where TEnemyType : EnemyBase<TEnemyType>
    {
        /// <summary>
        /// The state
        /// </summary>
        protected EnemyState<TEnemyType> State;

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="state">The state.</param>
        public void SetState(EnemyState<TEnemyType> state)
        {
            this.State = state;
        }

        /// <summary>
        /// Hits the specified damage.
        /// </summary>
        /// <param name="damage">The damage.</param>
        protected override void Hit(int damage)
        {
            base.Hit(damage);
            /*Debug.Log("Entrou no hit");
            if (!IsAlive) return;
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            State.OnGetHit();
            if (!IsAlive) Die();*/
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected virtual void Update()
        {
            if (!IsAlive) return;
            if (!State.Initialized) State.StateStart();
            State.StateUpdate();
        }

        /// <summary>
        /// Fixeds the update.
        /// </summary>
        protected virtual void FixedUpdate()
        {
            if (!IsAlive) return;
            if (!State.Initialized) State.StateStart();
            State.StateFixedUpdate();
        }
    }
}