using System;
using UnityEngine;

namespace Bullets.Spawners
{
    public class RingPatternSpawner2 : MonoBehaviour
    {
        private BulletPooler _bulletPooler;
        [SerializeField]
        private float shootInterval = 0.2f;
        [SerializeField]
        private float angle = 0.0f;
        [SerializeField]
        private float angleStep = 0.1f;
        [SerializeField]
        private float angleDistance = 0.4f;
        [SerializeField]
        private int numberShots = 4;
        public bool active = true;

        private void Start()
        {
            _bulletPooler = BulletPooler.Instance;
            InvokeRepeating(nameof(Spawner), 0.0f, shootInterval);
        }

        private void Spawner()
        {
            if(active)
            {
                for (int i = 0; i < numberShots; i++)
                {
                    _bulletPooler.SpawnFromPool("RingPattern", transform.position, Quaternion.identity, angle + i * angleDistance);
                }
                angle += angleStep;
            }            
        }
    }
}
