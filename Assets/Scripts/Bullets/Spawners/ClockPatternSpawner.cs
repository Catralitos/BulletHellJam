using System;
using UnityEngine;

namespace Bullets.Spawners
{
    public class ClockPatternSpawner : MonoBehaviour
    {
        private BulletPooler _bulletPooler;
        [SerializeField]
        private float shootInterval = 0.5f;
        [SerializeField]
        private int directions = 2;
        [SerializeField]
        private float angleStep = 0.5f;
        private float addAngle = 0f;

        private void Start()
        {
            _bulletPooler = BulletPooler.Instance;
            InvokeRepeating(nameof(Spawner), 0.0f, shootInterval);
        }

        private void Spawner()
        {

            for (int i = 0; i < directions; i++)
            {
                _bulletPooler.SpawnFromPool("Clock Pattern", transform.position, Quaternion.identity,
                    (i * 1.0f) / directions * 2 * Mathf.PI + addAngle);
            }
            addAngle += angleStep;

        }
    }
}
