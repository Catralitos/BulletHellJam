namespace PowerUps
{
    public class MoreBullets : PowerUp
    {
        protected override void ApplyBonus()
        {
            Player.AddBullets();
        }
    }
}