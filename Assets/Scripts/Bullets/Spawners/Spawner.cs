using UnityEngine;

namespace Bullets.Spawners
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public abstract class Spawner : MonoBehaviour
    {
        /// <summary>
        /// The bullet pooler
        /// </summary>
        protected BulletPooler _bulletPooler;
        /// <summary>
        /// The shoot interval
        /// </summary>
        [SerializeField]
        protected float shootInterval = 0.5f;
        /// <summary>
        /// The active
        /// </summary>
        public bool active = false;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        protected void Start()
        {
            _bulletPooler = BulletPooler.Instance;
            InvokeRepeating(nameof(Spawn), 0.0f, shootInterval);
        }

        /// <summary>
        /// Spawns this instance.
        /// </summary>
        public abstract void Spawn();
    }
}