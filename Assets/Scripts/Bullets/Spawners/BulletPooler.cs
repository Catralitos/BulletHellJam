using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bullets.Spawners
{
    /// <summary>
    /// A pool of bullets. Our enemy bullet's aren't destroyed.
    /// They exist in a queue and are activated/deactivated as needed.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class BulletPooler : MonoBehaviour
    {
        /// <summary>
        /// A pool of objects
        /// </summary>
        [System.Serializable]
        public class Pool
        {
            /// <summary>
            /// The tag
            /// </summary>
            public string tag;
            /// <summary>
            /// The prefab of the object
            /// </summary>
            public GameObject prefab;
            /// <summary>
            /// The size
            /// </summary>
            public int size;
        }

        #region SingleTon
        /// <summary>
        /// Gets the sole instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static BulletPooler Instance  { get; private set; }
        /// <summary>
        /// Awakes this instance (if none already exist).
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        #endregion

        /// <summary>
        /// The pools
        /// </summary>
        public List<Pool> pools;
        /// <summary>
        /// The pool dictionary. One for each type of bullet trajectory.
        /// </summary>
        private Dictionary<string, Queue<GameObject>> _poolDictionary;

        /// <summary>
        /// Starts this instance.
        /// </summary>
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

        /// <summary>
        /// Spawns from pool.
        /// </summary>
        /// <param name="poolTag">The pool tag.</param>
        /// <param name="spawnPos">The spawn position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="maxAngleStep">The maximum angle step.</param>
        /// <returns></returns>
        public GameObject SpawnFromPool (string poolTag, Vector2 spawnPos, Quaternion rotation, float angle = -1.0f, float maxAngleStep = -1.0f)
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
            if(Math.Abs(angle - -1.0f) <= 0.001f && Math.Abs(maxAngleStep - -1.0f) <= 0.001f)
                pooledObj.OnObjectSpawn();
            else if(Math.Abs(maxAngleStep - -1.0f) <= 0.001f)
                pooledObj.OnObjectSpawn(angle);
            else
                pooledObj.OnObjectSpawn(angle, maxAngleStep);

            _poolDictionary[poolTag].Enqueue(objToSpawn);

            return objToSpawn;
        }
    }
}
