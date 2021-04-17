using UnityEngine;

namespace Bullets.Spawners
{
    public class ClusterSpawner : MonoBehaviour
    {
        private BulletPooler _bulletPooler;

        private void Start()
        {
            _bulletPooler = BulletPooler.Instance;
            InvokeRepeating(nameof(Spawner), 0.0f, 0.5f);
        }

        private void Spawner()
        {
            _bulletPooler.SpawnFromPool("ClusterPattern", transform.position, Quaternion.identity);
        }
    
    }
}
