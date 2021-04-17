using Player;
using UnityEngine;

namespace Enemies.Base
{
    public abstract class EnemyBase : MonoBehaviour
    {
        protected bool isAlive
        {
            get => currentHealth > 0;
        }

        public int currentHealth;
        public int maxHealth;
        [SerializeField] private GameObject explosionPrefab;
        [SerializeField] private Transform explosionSpawn;

        protected virtual void Start()
        {
            currentHealth = maxHealth;
        }

        protected virtual bool IsAlive
        {
            get => currentHealth > 0;
        }

        public void Call(string messageName)
        {
            SendMessage(messageName);
        }

        public virtual void Hit(int damage)
        {
            if (!isAlive) return;
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            if (!isAlive) Die();
        }

        protected virtual void Die()
        {
            var spawnPos = explosionSpawn != null ? explosionSpawn.position : transform.position;
            if (explosionPrefab != null) Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
            else Debug.LogWarning("ExplosionPrefab not set!");
            Destroy(gameObject);
        }
    }

    public abstract class EnemyBase<TEnemyType> : EnemyBase where TEnemyType : EnemyBase<TEnemyType>
    {
        protected EnemyState<TEnemyType> State;

        public void SetState(EnemyState<TEnemyType> state)
        {
            this.State = state;
        }

        public override void Hit(int damage)
        {
            if (!isAlive) return;
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            State.OnGetHit();
            if (!isAlive) Die();
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