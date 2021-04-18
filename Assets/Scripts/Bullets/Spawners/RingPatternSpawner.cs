using System;
using UnityEngine;

namespace Bullets.Spawners
{
    public class RingPatternSpawner : MonoBehaviour
    {
        private BulletPooler _bulletPooler;
        [SerializeField]
        private float angle = 0.0f;
        [SerializeField]
        private float angleStep = 0.1f;

        private void Start()
        {
            _bulletPooler = BulletPooler.Instance;
            InvokeRepeating(nameof(Spawner), 0.0f, 0.2f);
        }

        private void Spawner()
        {
            _bulletPooler.SpawnFromPool("RingPattern", transform.position, Quaternion.identity, angle);
            /*
            if (2 * Math.PI - angleStep < angle + angleStep && angle + angleStep < 2 * Math.PI + angleStep)
                angle = 0.0f;        
            else angle += angleStep;
            */
            angle += angleStep;
        }
    }
}
