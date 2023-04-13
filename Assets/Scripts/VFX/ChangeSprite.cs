using Player;
using UnityEngine;

namespace VFX
{
    /// <summary>
    /// This class is used to change the sprite/color of the jetpack the player uses
    /// It changes based on whether the player is dashing or not
    /// </summary>
    public class ChangeSprite : MonoBehaviour
    {

        /// <summary>
        /// The sprite for the light being on
        /// </summary>
        public Sprite lightOn;

        /// <summary>
        /// The sprite for the light being off
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
            //If it the player is dashing, change the sprite and color
            _spriteRenderer.sprite = PlayerEntity.Instance.movement.canDash ? lightOn : lightOff;
            _spriteRenderer.color = PlayerEntity.Instance.movement.canDash ? Color.red : Color.white;
        }
    }
}
