using Player;

namespace PowerUps
{
    /// <summary>
    /// The powerup that adds 2 more bullet streams to the player
    /// </summary>
    /// <seealso cref="PowerUps.PowerUp" />
    public class MoreBullets : PowerUp
    {
        /// <summary>
        /// Applies the bonus.
        /// </summary>
        protected override void ApplyBonus()
        {
            PlayerEntity.Instance.AddBullets();
        }
    }
}