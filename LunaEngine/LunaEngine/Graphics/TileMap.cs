using System;
using System.IO;
using LunaEngine.Data;
using LunaEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LunaEngine.Graphics
{
    public class TileMap
    {
        #region Declarations

        public TileMapData Data;

        //Instance based variables
        private MapSquare[,] mapCells_;
        private static Texture2D tileSheet_;
        public Texture2D EdgeCellTexture;

        private const int CELL_PADDING = 5;

        #endregion

        #region Properties

        public int TileWidth { get { return Data.TileWidth;  } set { Data.TileWidth = value; } }
        public int TileHeight { get { return Data.TileHeight; } set { Data.TileHeight = value; } }
        public int MapWidth { get { return Data.MapWidth; } set { Data.MapWidth = value; } }
        public int MapHeight { get { return Data.MapHeight; } set { Data.MapHeight = value; } }
        public int MapLayers { get { return Data.MapLayers; } set { Data.MapLayers = value; } }

        public int ScaledTileWidth { get { return (int) (Data.TileWidth * Camera.WorldScale); } }
        public int ScaledTileHeight { get { return (int)(Data.TileWidth * Camera.WorldScale); } }

        public Texture2D TileSheet
        {
            set { tileSheet_ = value; }
        }

        #endregion

        #region Initializer

        /// <summary>
        /// Initialise the map with the given mapData, note that this
        /// map data should be initialised before sending to this method
        /// </summary>
        /// <param name="data"></param>
        public void Initialise(TileMapData data)
        {
            Data = data;

            //Create our isntances of MapSquare which can later be saved/re-loaded
            mapCells_ = new MapSquare[MapWidth, MapHeight];
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    MapSquareData mapSquareData = data.MapSquareData[data.GetMapSquareIndex(x, y)];
                    mapCells_[x, y] = new MapSquare(mapSquareData);
                }
            }
        }

        /// <summary>
        /// Intialise our tile map within the already given
        /// data, this is used when we load the map from
        /// a data file.
        /// 
        /// Note: This method is called from the level editor
        /// only and includes some extra funtionallity so that
        /// it works there happily
        /// </summary>
        public void Initialise(string textureFolder, GraphicsDevice graphicsDevice)
        {
            Initialise(Data);
            string texturePath = Path.Combine(textureFolder, Data.TextureSource);
            try
            {
                if (LEProperties.InDesignMode)
                {
                    using (Stream stream = new FileStream(texturePath, FileMode.Open))
                    {
                        tileSheet_ = Texture2D.FromStream(graphicsDevice, stream);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error opening texture file {0}", texturePath);
            }

            //Create EdgeCellTexture
            EdgeCellTexture = new Texture2D(graphicsDevice,1,1);
            EdgeCellTexture.SetData(new Color[] { Color.Black });
        }

        /// <summary>
        /// Initialise a map with the given tileSheet
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tileSheet"></param>
        public void Initialise(TileMapData data, Texture2D tileSheet)
        {
            tileSheet_ = tileSheet;
            Initialise(data);
        }

        #endregion

        #region Tile and Tile Sheet Handling

        /// <summary>
        /// The number of tiles per row on the tile sheet
        /// </summary>
        public int TilesPerRow
        {
            get { return tileSheet_.Width/TileWidth; }
        }

        /// <summary>
        /// The tile texture rectangle of a given index
        /// </summary>
        /// <param name="tileIndex">The tile index to use</param>
        /// <returns></returns>
        public Rectangle TileSourceRectangle(int tileIndex)
        {
            return new Rectangle(
                (tileIndex%TilesPerRow)*TileWidth,
                (tileIndex/TilesPerRow)*TileHeight,
                TileWidth,
                TileHeight);
        }

        #endregion

        #region Information about Map Cells

        /// <summary>
        /// Get the cell x index at the specified x pixel
        /// </summary>
        /// <param name="pixelX"></param>
        /// <returns></returns>
        public int GetCellByPixelX(int pixelX)
        {
            return pixelX / ScaledTileWidth;
        }

        /// <summary>
        /// Get the cell y index at the specified x pixel
        /// </summary>
        /// <param name="pixelY"></param>
        /// <returns></returns>
        public int GetCellByPixelY(int pixelY)
        {
            return pixelY / ScaledTileHeight;
        }

        /// <summary>
        /// Get the cell at the specified pixel location
        /// </summary>
        /// <param name="pixelLocation"></param>
        /// <returns></returns>
        public Vector2 GetCellAtPixel(Vector2 pixelLocation)
        {
            return new Vector2(
                GetCellByPixelX((int) pixelLocation.X),
                GetCellByPixelY((int) pixelLocation.Y));
        }

        /// <summary>
        /// Get the center of a cell
        /// </summary>
        /// <param name="cellX"></param>
        /// <param name="cellY"></param>
        /// <returns></returns>
        public Vector2 GetCellCenter(int cellX, int cellY)
        {
            return new Vector2(
                (cellX*TileWidth) + (TileWidth/2),
                (cellY*TileHeight) + (TileHeight/2));
        }

        /// <summary>
        /// Get the center of a cell
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public Vector2 GetCellCenter(Vector2 cell)
        {
            return GetCellCenter((int) cell.X, (int) cell.Y);
        }

        /// <summary>
        /// Get the world rectangle of the specified cell
        /// </summary>
        /// <param name="cellX"></param>
        /// <param name="cellY"></param>
        /// <returns></returns>
        public Rectangle CellWorldRectangle(int cellX, int cellY)
        {
            return new Rectangle(
                cellX*TileWidth,
                cellY*TileHeight,
                TileWidth,
                TileHeight);
        }

        /// <summary>
        /// Get the world rectangle of a specified cell
        /// </summary>
        /// <param name="square"></param>
        /// <returns></returns>
        public Rectangle CellWorldRectangle(Vector2 cell)
        {
            return CellWorldRectangle((int) cell.X, (int) cell.Y);
        }

        /// <summary>
        /// Get the screen rectangle of a specified cell
        /// </summary>
        /// <param name="cellX"></param>
        /// <param name="cellY"></param>
        /// <returns></returns>
        public Rectangle CellScreenRectangle(int cellX, int cellY)
        {
            return Camera.WorldToScreen(CellWorldRectangle(cellX, cellY));
        }

        /// <summary>
        /// Get the screen rectangle of a specified cell
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public Rectangle CellScreenRectangle(Vector2 cell)
        {
            return Camera.WorldToScreen(CellWorldRectangle((int) cell.X, (int) cell.Y));
        }

        /// <summary>
        /// Is this cell passable?
        /// </summary>
        /// <param name="cellX"></param>
        /// <param name="cellY"></param>
        /// <returns></returns>
        public bool CellIsPassable(int cellX, int cellY)
        {
            MapSquare tile = GetMapSquareAtCell(cellX, cellY);

            if (tile == null)
            {
                return false;
            }

            return tile.Passable;
        }

        /// <summary>
        /// Is this cell passable?
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public bool CellIsPassable(Vector2 cell)
        {
            return CellIsPassable((int) cell.X, (int) cell.Y);
        }

        /// <summary>
        /// Is the cell at the pixel location passable?
        /// </summary>
        /// <param name="pixelLocation"></param>
        /// <returns></returns>
        public bool CellIsPassableByPixel(Vector2 pixelLocation)
        {
            return CellIsPassable(
                GetCellByPixelX((int) pixelLocation.X),
                GetCellByPixelY((int) pixelLocation.Y));
        }

        /// <summary>
        /// Get the code value of the specified cell
        /// </summary>
        /// <param name="cellX"></param>
        /// <param name="cellY"></param>
        /// <returns></returns>
        public string GetCellCodeValue(int cellX, int cellY)
        {
            MapSquare tile = GetMapSquareAtCell(cellX, cellY);

            if (tile == null)
            {
                return "";
            }

            return tile.CodeValue;
        }

        /// <summary>
        /// Get the code value at the specified cell
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public string GetCellCodeValue(Vector2 cell)
        {
            return GetCellCodeValue((int) cell.X, (int) cell.Y);
        }

        #endregion

        #region Information about Tile objects

        public bool MapCellExists(int tileX, int tileY)
        {
            if ((tileX >= 0 && tileX < MapWidth) &&
                (tileY >= 0 && tileY < MapHeight))
            {
                return true;
            }

            return false;
        }


        public MapSquare GetMapSquareAtCell(int cellX, int cellY)
        {
            if (MapCellExists(cellX, cellY))
            {
                return mapCells_[cellX, cellY];
            }

            return null;
        }

        public MapSquare GetMapSquareAtPixel(int pixelX, int pixelY)
        {
            return GetMapSquareAtCell(GetCellByPixelX(pixelX), GetCellByPixelY(pixelY));
        }

        public MapSquare GetMapSquareAtPixel(Vector2 position)
        {
            return GetMapSquareAtPixel((int)position.X, (int)position.Y);
        }

        private void SetMapSquareAtCell(int cellX, int cellY, MapSquare tile)
        {
            if (MapCellExists(cellX, cellY))
            {
                mapCells_[cellX, cellY] = tile;
            }
        }

        public void SetTileAtCell(int cellX, int cellY, int layer, int tileIndex)
        {
            if (MapCellExists(cellX, cellY) && layer >= 0)
            {
                MapSquare tile = mapCells_[cellX, cellY];

                if (layer < tile.LayerTiles.Length)
                {
                    tile.LayerTiles[layer] = tileIndex;
                }
            }
        }

        public int GetMapCellAtPixel(int pixelX, int pixelY)
        {
            return GetMapCellAtPixel(
                GetCellByPixelX(pixelX),
                GetCellByPixelY(pixelY));
        }

        public int GetMapCellAtPixel(Vector2 pixelLocation)
        {
            return GetMapCellAtPixel(
                GetCellByPixelX((int) pixelLocation.X),
                GetCellByPixelY((int) pixelLocation.Y));
        }

        #endregion

        #region Drawing

        public void Draw(SpriteBatch spriteBatch)
        {
            if (tileSheet_ == null)
            {
                return;
            }

            int startX = GetCellByPixelX((int) Camera.Position.X - TileWidth) - CELL_PADDING;
            int endX = GetCellByPixelX((int) Camera.ViewPort.Right) + CELL_PADDING;

            int startY = GetCellByPixelY((int) Camera.Position.Y) - CELL_PADDING;
            int endY = GetCellByPixelY((int) Camera.ViewPort.Bottom) + CELL_PADDING;

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    for (int z = 0; z < MapLayers; z++)
                    {
                        if (MapCellExists(x, y))
                        {
                            spriteBatch.Draw(
                                tileSheet_,
                                CellScreenRectangle(x, y),
                                TileSourceRectangle(mapCells_[x, y].LayerTiles[z]),
                                Color.Pink,
                                0.0f,
                                Vector2.Zero,
                                SpriteEffects.None,
                                1f - ((float) z*0.1f));
                        }
                        else if (EdgeCellTexture != null)
                        {
                            spriteBatch.Draw(
                                EdgeCellTexture,
                                CellScreenRectangle(x,y),
                                Color.White);
                        }
                    }
                }
            }
        }

        #endregion

        #region Helpers

        #endregion
    }
}
