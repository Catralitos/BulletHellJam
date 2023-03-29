using Audio;
using UnityEngine;

namespace Bullets.Spawners
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Bullets.Spawners.Spawner" />
    public class PiramidalPatternSpawner : Spawner
    {
        /// <summary>
        /// The number shots
        /// </summary>
        [SerializeField] private int numberShots = 2;
        /// <summary>
        /// The angle
        /// </summary>
        [SerializeField] private float angle = 0f;
        /// <summary>
        /// The angle range
        /// </summary>
        [SerializeField] private float angleRange = .3f;


        /// <summary>
        /// Spawns this instance.
        /// </summary>
        public override void Spawn()
        {
            if (!active) return;
            AudioManager.Instance.Play("EnemyFire");
            for (int i = 0; i < numberShots; i++)
            {
                _bulletPooler.SpawnFromPool("Pyramid", transform.position, Quaternion.identity,
                    angle + i * angleRange / numberShots);
            }
            //addAngle += angleStep;
        }
    }
}