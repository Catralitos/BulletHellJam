using System;
using UnityEngine;

namespace Bullets.Spawners
{
    public class PiramidalPatternSpawner : MonoBehaviour
    {
        private BulletPooler _bulletPooler;
        [SerializeField]
        private float shootInterval = 0.5f;
        [SerializeField]
        private int numberShots = 2;
        [SerializeField]
        private float angle = 0f;
        [SerializeField]
        private float angleRange = .3f;

        private void Start()
        {
            _bulletPooler = BulletPooler.Instance;
            InvokeRepeating(nameof(Spawner), 0.0f, shootInterval);
        }

        private void Spawner()
        {

            for (int i = 0; i < numberShots; i++)
            {
                _bulletPooler.SpawnFromPool("Piramidal Pattern", transform.position, Quaternion.identity,
                    angle + i * angleRange / numberShots);
            }
            //addAngle += angleStep;
        }
    }
}