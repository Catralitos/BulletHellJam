using System;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Explosion : MonoBehaviour
    {
    /// <summary>
    /// The time active
    /// </summary>
    public float timeActive;

    /// <summary>
    /// Awakes this instance.
    /// </summary>
    private void Awake()
        {
            Invoke(nameof(Terminate), timeActive);
        }

    /// <summary>
    /// Terminates this instance.
    /// </summary>
    private void Terminate()
        {
            Destroy(gameObject);
        }
    }
