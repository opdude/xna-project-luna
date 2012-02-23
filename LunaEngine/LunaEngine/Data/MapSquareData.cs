using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaEngine.Data
{
    /// <summary>
    /// Data repersentation of our MapSquare this 
    /// is used to save the data to XML
    /// </summary>
    public class MapSquareData
    {
        #region Data

        public int[] LayerTiles;
        public string CodeValue = "";
        public bool Passable = true;

        #endregion

        #region Constructor

        public MapSquareData()
        {
            
        }

        public MapSquareData(int numberOfLayers)
        {
            LayerTiles = new int[numberOfLayers];
        }

        #endregion
    }
}
