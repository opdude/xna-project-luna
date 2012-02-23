using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LunaEngine.Data
{
    /// <summary>
    /// A data reperesentation of our TileMap, this is
    /// used for saving to XML
    /// </summary>
    public class TileMapData
    {
        #region Declarations

        private const int MAPWIDTH_DEFAULT = 160;
        private const int MAPHEIGHT_DEFAULT = 12;
        private const int MAPLAYERS_DEFAULT = 3;

        public MapSquareData[] MapSquareData;
        public TileSheetData TileSheetData;
        public string Name;

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        public int MapLayers { get; set; }

        public string TextureSource { get { return TileSheetData.TextureSource; } }

        #endregion

        #region Constructor

        public TileMapData()
        {
            //Defaults
            MapWidth = MAPWIDTH_DEFAULT;
            MapHeight = MAPHEIGHT_DEFAULT;
            MapLayers = MAPLAYERS_DEFAULT;

            MapSquareData = new MapSquareData[MapWidth * MapHeight];
        }

        #endregion

        #region Initialise Map

        /// <summary>
        /// Initialise a new map with all of the cells set to the given skyTile
        /// </summary>
        public void Initialise(TileSheetData data)
        {
            TileSheetData = data;
            TileWidth = data.TileWidth;
            TileHeight = data.TileHeight;

            MapSquareData = new MapSquareData[MapWidth*MapHeight];

            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    MapSquareData[GetMapSquareIndex(x, y)] = new MapSquareData(MapLayers)
                                                                 {
                                                                     Passable = true,
                                                                     CodeValue = ""
                                                                 };

                    for (int z=0; z < MapLayers; z++)
                    {
                        MapSquareData[GetMapSquareIndex(x, y)].LayerTiles[z] = 5;
                    }
                }
            }
        }

        #endregion

        #region Map Square Information

        /// <summary>
        /// Get the map square index, this is necessary as to save
        /// data to XML we need to store the array as a single 
        /// dimension
        /// </summary>
        /// <param name="cellX"></param>
        /// <param name="cellY"></param>
        /// <returns></returns>
        public int GetMapSquareIndex(int cellX, int cellY)
        {
            return cellY*TileWidth + cellX;
        }

        public void SetMapSquare(int cellX, int cellY, MapSquareData data)
        {
            MapSquareData[GetMapSquareIndex(cellX, cellY)] = data;
        }

        public void SetMapSquare(Vector2 cellPosition, MapSquareData data)
        {
            SetMapSquare((int) cellPosition.X, (int) cellPosition.Y, data);
        }

        public MapSquareData GetMapSquare(int cellX, int cellY)
        {
            return MapSquareData[GetMapSquareIndex(cellX, cellY)];
        }

        public MapSquareData GetMapSquare(Vector2 cellPosition)
        {
            return GetMapSquare((int) cellPosition.X, (int) cellPosition.Y);
        }

        #endregion
    }
}
