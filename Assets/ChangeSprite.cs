using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    public Sprite lightOn;

    public Sprite lightOff;

    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        _spriteRenderer.sprite = PlayerEntity.Instance.movement.canDash ? lightOn : lightOff;
        _spriteRenderer.color = PlayerEntity.Instance.movement.canDash ? Color.red : Color.white;
    }
}
