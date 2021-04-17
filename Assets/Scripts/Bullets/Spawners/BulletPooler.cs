using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Bullets.Spawners
{
    public class BulletPooler : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }

        #region SingleTon
        public static BulletPooler Instance;
        private void Awake()
        {
            Instance = this;
        }
        #endregion
        
        public List<Pool> pools;
        private Dictionary<string, Queue<GameObject>> _poolDictionary;
        
        private void Start()
        {
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();
                for(int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                _poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject SpawnFromPool (string poolTag, Vector2 spawnPos, Quaternion rotation, /*[Optional]*/ float angle = 30f)
        {
            if (!_poolDictionary.ContainsKey(poolTag))
            {
                Debug.LogWarning("Pool with tag " + poolTag + " doesn't exist");
                return null;
            }
            GameObject objToSpawn = _poolDictionary[poolTag].Dequeue();

            objToSpawn.SetActive(true);
            objToSpawn.transform.position = spawnPos;
            objToSpawn.transform.rotation = rotation;

            IPooledObject pooledObj = objToSpawn.GetComponent<IPooledObject>();
            if(angle == 30f)
                pooledObj.OnObjectSpawn();
            else
                pooledObj.OnObjectSpawn(angle);
            
            _poolDictionary[poolTag].Enqueue(objToSpawn);

            return objToSpawn;

        }
    }
}
