using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LunaEngine.Data
{
    public class TileSheetData
    {
        public enum TileSheetType
        {
            Level
        }

        public const int TILEWIDTH_DEFAULT = 48;
        public const int TILEHEIGHT_DEFAULT = 48;

        public string TextureSource { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public TileSheetType Type;

        #region Constructor

        public TileSheetData()
        {
            //Defaults
            TileWidth = TILEWIDTH_DEFAULT;
            TileHeight = TILEHEIGHT_DEFAULT;
            Type = TileSheetType.Level;
        }

        public TileSheetData(string texturePath) 
            : this()
        {
            TextureSource = texturePath;
            
        }

        public override string ToString()
        {
            if (TextureSource != null)
            {
                return Path.GetFileNameWithoutExtension(TextureSource);
            }

            return base.ToString();
        }

        #endregion

    }
}
