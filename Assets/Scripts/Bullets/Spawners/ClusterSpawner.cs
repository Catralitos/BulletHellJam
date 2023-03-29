using Audio;
using UnityEngine;

namespace Bullets.Spawners
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Bullets.Spawners.Spawner" />
    public class ClusterSpawner : Spawner
    {
        /// <summary>
        /// The angle
        /// </summary>
        [SerializeField] private float angle = 0f;
        /// <summary>
        /// The maximum angle step
        /// </summary>
        [SerializeField] private float maxAngleStep = 0.3f;

        /// <summary>
        /// Spawns this instance.
        /// </summary>
        public override void Spawn()
        {
            if (!active) return;
            AudioManager.Instance.Play("EnemyFire");
            _bulletPooler.SpawnFromPool("Cluster", transform.position, Quaternion.identity, angle,
                maxAngleStep);
        }
    }
}