namespace PowerUps
{
    public class MoreFireRate : PowerUp
    {
        protected override void ApplyBonus()
        {
            Player.shooting.currentFireRate *= 2;
        }
    }
}