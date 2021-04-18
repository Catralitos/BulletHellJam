namespace Bullets
{
    public interface IPooledObject
    {
        void OnObjectSpawn();
        void OnObjectSpawn(float angle);
    }
}
