using Audio;
using UnityEngine;

namespace Bullets.Spawners
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Bullets.Spawners.Spawner" />
    public class ShockwaveRingSpawner : Spawner
    {
        /// <summary>
        /// The directions
        /// </summary>
        [SerializeField] private int directions = 10;

        /// <summary>
        /// Spawns this instance.
        /// </summary>
        public override void Spawn()
        {
            if (!active) return;
            AudioManager.Instance.Play("EnemyFire");
            for (int i = 0; i < directions; i++)
            {
                _bulletPooler.SpawnFromPool("Wave", transform.position, Quaternion.identity,
                    (i * 1.0f) / directions * 2 * Mathf.PI);
            }
        }
    }
}