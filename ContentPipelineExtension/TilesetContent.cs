using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace ContentPipelineExtension
{
    class TilesetContent
    {
        public string Name { get; set; }

        public int TileWidth { get; set; }

        public int TileHeight { get; set; }

        public int Spacing { get; set; }

        public int Margin { get; set; }

        public int TileCount { get; set; }

        public int Columns { get; set; }

        public string ImageFilename { get; set; }

        public string ImageColorKey { get; set; }

        public TextureContent Texture { get; set; }

        public TileContent[] Tiles;

        /// <summary>
        /// Builds the tiles for this tileset
        /// </summary>
        public void BuildTiles()
        {

        }
    }
}
