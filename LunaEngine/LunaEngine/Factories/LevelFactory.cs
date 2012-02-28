using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LunaEngine.Data;
using LunaEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LunaEngine.Factories
{
    public class LevelFactory : Factory
    {
        private GraphicsDevice graphicsDevice_;
        public LevelFactory(GraphicsDevice graphicsDevice, ContentManager contentManager) : base(contentManager)
        {
            graphicsDevice_ = graphicsDevice;
        }

        public TileMap Construct(string level)
        {
            level = Path.Combine(LEVEL_FOLDER, level);
            TileMapData data = Content.Load<TileMapData>(level);
            TileMap tileMap = new TileMap();

            string texture = Path.GetFileNameWithoutExtension(data.TextureSource);
            tileMap.TileSheet = Content.Load<Texture2D>(Path.Combine(TEXTURE_FOLDER, texture));
            tileMap.Initialise(data);

            Texture2D edgeCellTexture = new Texture2D(
                graphicsDevice_,
                TileSheetData.TILEWIDTH_DEFAULT,
                TileSheetData.TILEHEIGHT_DEFAULT);

            edgeCellTexture.SetData(new[] { Color.YellowGreen });
            tileMap.EdgeCellTexture = edgeCellTexture;


            return tileMap;
        }
    }
}
