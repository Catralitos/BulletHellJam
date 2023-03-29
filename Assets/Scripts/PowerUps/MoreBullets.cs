namespace PowerUps
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PowerUps.PowerUp" />
    public class MoreBullets : PowerUp
    {
        /// <summary>
        /// Applies the bonus.
        /// </summary>
        protected override void ApplyBonus()
        {
            Player.AddBullets();
        }
    }
}