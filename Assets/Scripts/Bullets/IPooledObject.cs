namespace Bullets
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPooledObject
    {
        /// <summary>
        /// Called when [object spawn].
        /// </summary>
        void OnObjectSpawn();
        /// <summary>
        /// Called when [object spawn].
        /// </summary>
        /// <param name="angle">The angle.</param>
        void OnObjectSpawn(float angle);
        /// <summary>
        /// Called when [object spawn].
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <param name="maxAngleStep">The maximum angle step.</param>
        void OnObjectSpawn(float angle, float maxAngleStep);
    }
}
