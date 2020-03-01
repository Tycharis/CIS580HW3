using Microsoft.Xna.Framework;

namespace ContentPipelineExtension
{
    /// <summary>
    /// A class representing the details of a single 
    /// tile in a TiledSpriteSheet
    /// </summary>
    class TileContent
    {
        /// <summary>
        /// The Tile's source rectangle
        /// </summary>
        public Rectangle Source { get; set; }

        /// <summary>
        /// Creates a new TileContent with the specified source rectangle
        /// </summary>
        /// <param name="source">The source rectangle of the tile in its spritesheet</param>
        public TileContent(Rectangle source)
        {
            Source = source;
        }
    }
}
