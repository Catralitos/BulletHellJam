using System;
using Player;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// The horizontal limit
    /// </summary>
    public float horizontalLimit;
    /// <summary>
    /// The vertical limit
    /// </summary>
    public float verticalLimit;

    /// <summary>
    /// The player
    /// </summary>
    public Transform _player;

    /// <summary>
    /// Starts this instance.
    /// </summary>
    private void Start()
    {
        //_player = PlayerEntity.Instance.gameObject.transform;
    }

    /// <summary>
    /// Updates this instance.
    /// </summary>
    private void Update()
    {
        if (_player == null) return;
        var playerPosition = _player.position;
        var cameraTransform = transform;
        cameraTransform.position = new Vector3(
            Mathf.Clamp(playerPosition.x, -horizontalLimit, horizontalLimit),
            Mathf.Clamp(playerPosition.y, -verticalLimit, verticalLimit),
            cameraTransform.position.z);
    }
}