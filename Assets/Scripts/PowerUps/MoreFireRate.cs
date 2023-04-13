using Player;

namespace PowerUps
{
    /// <summary>
    /// The powerup that increases the player's fire rate
    /// </summary>
    /// <seealso cref="PowerUps.PowerUp" />
    public class MoreFireRate : PowerUp
    {
        /// <summary>
        /// Applies the bonus.
        /// </summary>
        protected override void ApplyBonus()
        {
            PlayerEntity.Instance.AddFireRate();
        }
    }
}