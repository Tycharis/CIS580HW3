using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CIS580HW3
{
    /// <summary>
    /// A class representing a platform
    /// </summary>
    public class Gem : IBoundable
    {
        /// <summary>
        /// The platform's bounds
        /// </summary>
        BoundingRectangle bounds;

        /// <summary>
        /// The platform's sprite
        /// </summary>
        Sprite sprite;

        /// <summary>
        /// The bounding rectangle of the 
        /// </summary>
        public BoundingRectangle Bounds => bounds;

        /// <summary>
        /// Constructs a new platform
        /// </summary>
        /// <param name="bounds">The platform's bounds</param>
        /// <param name="sprite">The platform's sprite</param>
        public Gem(BoundingRectangle bounds, Sprite sprite)
        {
            this.bounds = bounds;
            this.sprite = sprite;
        }

        /// <summary>
        /// Draws the platform
        /// </summary>
        /// <param name="spriteBatch">The spriteBatch to render to</param>
        public void Draw(SpriteBatch spriteBatch)
        {
#if VISUAL_DEBUG
            VisualDebugging.DrawRectangle(spriteBatch, bounds, Color.Green);
#endif

            sprite.Draw(spriteBatch, new Vector2(bounds.X, bounds.Y), Color.White);
        }
    }
}
