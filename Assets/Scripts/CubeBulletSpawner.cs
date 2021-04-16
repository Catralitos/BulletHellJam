using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBulletSpawner : MonoBehaviour
{
    BulletPooler bulletPooler;

    private void Start()
    {
        bulletPooler = BulletPooler.Instance;
        InvokeRepeating("Spawner", 0.0f, 0.5f);
    }

    private void Spawner()
    {
        bulletPooler.SpawnFromPool("Cube", transform.position, Quaternion.identity);
    }


}
