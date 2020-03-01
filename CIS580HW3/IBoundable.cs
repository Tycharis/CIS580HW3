namespace CIS580HW3
{
    /// <summary>
    /// An interface defining game objects with bounds
    /// </summary>
    public interface IBoundable
    {
        BoundingRectangle Bounds { get; }
    }
}
