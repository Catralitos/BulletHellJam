using UnityEngine;

namespace Bullets.Spawners
{
    public class ClusterSpawner : MonoBehaviour
    {
        private BulletPooler _bulletPooler;
        [SerializeField]
        private float shootInterval = 0.5f;
        [SerializeField]
        private float angle = 0f;
        [SerializeField]
        private float maxAngleStep = 0.3f;
        public bool active = true;
        private void Start()
        {
            _bulletPooler = BulletPooler.Instance;
            InvokeRepeating(nameof(Spawner), 0.0f, shootInterval);
        }

        private void Spawner()
        {
            if (active)
            _bulletPooler.SpawnFromPool("ClusterPattern", transform.position, Quaternion.identity, angle, maxAngleStep);
        }
    
    }
}
