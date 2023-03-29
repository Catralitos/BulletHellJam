using Audio;
using UnityEngine;

namespace Bullets.Spawners
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Bullets.Spawners.Spawner" />
    public class RingPatternSpawner2 : Spawner
    {
        /// <summary>
        /// The angle
        /// </summary>
        [SerializeField] private float angle = 0.0f;
        /// <summary>
        /// The angle step
        /// </summary>
        [SerializeField] private float angleStep = 0.1f;
        /// <summary>
        /// The angle distance
        /// </summary>
        [SerializeField] private float angleDistance = 0.4f;
        /// <summary>
        /// The number shots
        /// </summary>
        [SerializeField] private int numberShots = 4;

        /// <summary>
        /// Spawns this instance.
        /// </summary>
        public override void Spawn()
        {
            if (!active) return;

            AudioManager.Instance.Play("EnemyFire");
            for (int i = 0; i < numberShots; i++)
            {
                _bulletPooler.SpawnFromPool("Ring", transform.position, Quaternion.identity,
                    angle + i * angleDistance);
            }

            angle += angleStep;
        }
    }
}