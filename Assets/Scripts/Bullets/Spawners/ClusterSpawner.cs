using UnityEngine;

namespace Bullets.Spawners
{
    public class ClusterSpawner : Spawner
    {
        [SerializeField] private float angle = 0f;
        [SerializeField] private float maxAngleStep = 0.3f;

        public override void Spawn()
        {
            if (active)
                _bulletPooler.SpawnFromPool("Cluster", transform.position, Quaternion.identity, angle,
                    maxAngleStep);
        }
    }
}