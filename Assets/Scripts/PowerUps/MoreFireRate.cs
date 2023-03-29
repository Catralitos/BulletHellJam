namespace PowerUps
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PowerUps.PowerUp" />
    public class MoreFireRate : PowerUp
    {
        /// <summary>
        /// Applies the bonus.
        /// </summary>
        protected override void ApplyBonus()
        {
            Player.AddFireRate();
        }
    }
}