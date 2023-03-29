using System;
using Audio;
using UnityEngine;

namespace Bullets.Spawners
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Bullets.Spawners.Spawner" />
    public class ClockPatternSpawner : Spawner
    {
        /// <summary>
        /// The directions
        /// </summary>
        public int directions = 2;
        /// <summary>
        /// The angle step
        /// </summary>
        [SerializeField] private float angleStep = 0.5f;
        /// <summary>
        /// The add angle
        /// </summary>
        private float _addAngle = 0f;

        /// <summary>
        /// Spawns this instance.
        /// </summary>
        public override void Spawn()
        {
            if (!active) return;
            AudioManager.Instance.Play("EnemyFire");
            for (int i = 0; i < directions; i++)
            {
                _bulletPooler.SpawnFromPool("Clock", transform.position, Quaternion.identity,
                    (i * 1.0f) / directions * 2 * Mathf.PI + _addAngle);
            }

            _addAngle += angleStep;
        }
    }
}