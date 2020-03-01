using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CIS580HW3
{
    /// <summary>
    /// A class representing a platform
    /// </summary>
    public class Door
    {
        /// <summary>
        /// The door's sprite
        /// </summary>
        Sprite sprite;

        /// <summary>
        /// The door's position
        /// </summary>
        Vector2 pos;

        /// <summary>
        /// Constructs a new platform
        /// </summary>
        /// <param name="sprite">The platform's sprite</param>
        public Door(Vector2 pos, Sprite sprite)
        {
            this.pos = pos;
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
            sprite.Draw(spriteBatch, new Vector2(pos.X, pos.Y), Color.White);
        }
    }
}
