using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ChangeSprite : MonoBehaviour
{

    /// <summary>
    /// The light on
    /// </summary>
    public Sprite lightOn;

    /// <summary>
    /// The light off
    /// </summary>
    public Sprite lightOff;

    /// <summary>
    /// The sprite renderer
    /// </summary>
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    /// <summary>
    /// Starts this instance.
    /// </summary>
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    private void Update()
    {
        _spriteRenderer.sprite = PlayerEntity.Instance.movement.canDash ? lightOn : lightOff;
        _spriteRenderer.color = PlayerEntity.Instance.movement.canDash ? Color.red : Color.white;
    }
}
