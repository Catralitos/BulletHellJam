using System;
using UnityEngine;

namespace Bullets.Spawners
{
    public class CircleBulletSpawner : MonoBehaviour
    {
        private BulletPooler _bulletPooler;
        private float angle = 0.0f;
        private float angleStep = 0.1f;

        private void Start()
        {
            _bulletPooler = BulletPooler.Instance;
            InvokeRepeating(nameof(Spawner), 0.0f, 0.2f);
        }

        private void Spawner()
        {
            _bulletPooler.SpawnFromPool("Circles", transform.position, Quaternion.identity, angle);
            if (2 * Math.PI - angleStep < angle + angleStep && angle + angleStep < 2 * Math.PI + angleStep)
                angle = 0.0f;        
            else angle += angleStep;
        }
    }
}
