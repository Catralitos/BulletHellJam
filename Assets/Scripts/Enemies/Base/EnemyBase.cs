using System.Collections.Generic;
using Extensions;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Base
{
    public abstract class EnemyBase : MonoBehaviour
    {
        protected bool IsAlive => currentHealth > 0;

        public LayerMask playerBullets;

        public int pointsPerKill;
        public int currentHealth;
        public int maxHealth;
        public float randomDropChance = 0.1f;
        public List<GameObject> powerUps;
        
        public GameObject explosionPrefab;

        protected virtual void Start()
        {
            currentHealth = maxHealth;
        }

        public void Call(string messageName)
        {
            SendMessage(messageName);
        }

        protected virtual void Hit(int damage)
        {
            if (!IsAlive) return;
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            if (!IsAlive) Die();
        }

        protected virtual void Die()
        {
            TimeManager.Instance.IncreaseScore(pointsPerKill);
            var spawnPos = transform.position;
            if (explosionPrefab != null) Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
            Destroy(gameObject);
            if (Random.Range(0.0f, 1.0f) <= randomDropChance)
            {
                Instantiate(powerUps[Random.Range(0, powerUps.Count)], spawnPos, Quaternion.identity);
            }

            Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!playerBullets.HasLayer(other.gameObject.layer)) return;

            Hit(1);
            Destroy(other.gameObject);
        }
    }

    public abstract class EnemyBase<TEnemyType> : EnemyBase where TEnemyType : EnemyBase<TEnemyType>
    {
        protected EnemyState<TEnemyType> State;

        public void SetState(EnemyState<TEnemyType> state)
        {
            this.State = state;
        }

        protected override void Hit(int damage)
        {
            if (!IsAlive) return;
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            State.OnGetHit();
            if (!IsAlive) Die();
        }

        protected virtual void Update()
        {
            if (!IsAlive) return;
            if (!State.Initialized) State.StateStart();
            State.StateUpdate();
        }

        protected virtual void FixedUpdate()
        {
            if (!IsAlive) return;
            if (!State.Initialized) State.StateStart();
            State.StateFixedUpdate();
        }
    }
}