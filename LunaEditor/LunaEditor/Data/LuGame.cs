using System.Collections.Generic;
using LunaEngine.Data;
using Microsoft.Xna.Framework.Graphics;

namespace LunaEditor.Data
{
    public class LuGame
    {
        #region Declaration

        public string Name { get; set; }
        public string Description { get; set; }
        public List<TileSheetData> TileSheetData = new List<TileSheetData>();
        static public GraphicsDevice GraphicsDevice { get; set; }

        #endregion

        #region Constructor

        public LuGame()
        {
            
        }

        public LuGame(string name, string description)
        {
            
        }

        #endregion
    }
}
