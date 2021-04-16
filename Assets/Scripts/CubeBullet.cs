using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBullet : MonoBehaviour, IPooledObject
{
    public float horizontalForce = 0.0f;
    public float verticalForce = 5.0f;
    public void OnObjectSpawn()
    {
        //float xForce = Random.Range(-horizontalForce, horizontalForce);
        //float yForce = Random.Range(-verticalForce, verticalForce);

        float xForce = Mathf.Sin(horizontalForce + Time.deltaTime);
        float yForce = Random.Range(-verticalForce, verticalForce);
        Vector2 force = new Vector2(xForce, yForce);

        GetComponent<Rigidbody2D>().velocity = force;
    }
}
