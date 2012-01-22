using Luna.Engine;
using LunaEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LunaEngine.Graphics
{
    public class TileMap
    {
        #region Declarations

        public const int TileWidth = 48;
        public const int TileHeight = 48;
        public const int MapWidth = 160;
        public const int MapHeight = 12;
        public const int MapLayers = 3;
        private const int SkyTile = 2;

        private static MapSquare[,] mapCells_ = new MapSquare[MapWidth,MapHeight];

        public static bool EditorMode = false;

        private static SpriteFont spriteFont_;
        private static Texture2D tileSheet_;

        #endregion

        #region Initializer

        /// <summary>
        /// Initialise our tile map with air tiles
        /// </summary>
        /// <param name="tileTexture">The tilesheet to be used on this tile map</param>
        public void Initialise(Texture2D tileTexture)
        {
            tileSheet_ = tileTexture;

            //Spawn a map with just air tiles
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    for (int z = 0; z < MapLayers; z++)
                    {
                        mapCells_[x, y] = new MapSquare(SkyTile, 0, 0, "", true);
                    }
                }
            }
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
                (tileIndex%TilesPerRow)*TileHeight,
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
            return pixelX/TileWidth;
        }

        /// <summary>
        /// Get the cell y index at the specified x pixel
        /// </summary>
        /// <param name="pixelY"></param>
        /// <returns></returns>
        public int GetCellByPixelY(int pixelY)
        {
            return pixelY/TileHeight;
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
            MapSquare mapSquare = GetMapSquareAtCell(cellX, cellY);

            if (mapSquare == null)
            {
                return false;
            }

            return mapSquare.Passable;
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
            MapSquare mapSquare = GetMapSquareAtCell(cellX, cellY);

            if (mapSquare == null)
            {
                return "";
            }

            return mapSquare.CodeValue;
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

        #region Information about MapSquare objects

        public bool MapSquareExists(int tileX, int tileY)
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
            if (MapSquareExists(cellX, cellY))
            {
                return mapCells_[cellX, cellY];
            }

            return null;
        }

        private static void SetMapSquareAtCell(int cellX, int cellY, MapSquare tile)
        {
            if (MapSquareExists(cellX, cellY))
            {
                mapCells_[cellX, cellY] = tile;
            }
        }

        public void SetTileAtCell(int cellX, int cellY, int layer, int tileIndex)
        {
            if (MapSquareExists(cellX, cellY) && layer >= 0)
            {
                MapSquare mapSquare = mapCells_[cellX, cellY];

                if (layer < mapSquare.LayerTiles.Length)
                {
                    mapSquare.LayerTiles[layer] = tileIndex;
                }
            }
        }

        public int GetMapSquareAtPixel(int pixelX, int pixelY)
        {
            return GetMapSquareAtPixel(
                GetCellByPixelX(pixelX),
                GetCellByPixelY(pixelY));
        }

        public int GetMapSquareAtPixel(Vector2 pixelLocation)
        {
            return GetMapSquareAtPixel(
                GetCellByPixelX((int) pixelLocation.X),
                GetCellByPixelY((int) pixelLocation.Y));
        }

        #endregion

        #region Drawing

        public void Draw(SpriteBatch spriteBatch)
        {
            int startX = GetCellByPixelX((int) Camera.Position.X);
            int endX = GetCellByPixelX((int) Camera.ViewPort.Right);

            int startY = GetCellByPixelY((int) Camera.Position.Y);
            int endY = GetCellByPixelY((int) Camera.ViewPort.Bottom);

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    for (int z = 0; z < MapLayers; z++)
                    {
                        if (MapSquareExists(x, y))
                        {
                            spriteBatch.Draw(
                                tileSheet_,
                                CellScreenRectangle(x, y),
                                TileSourceRectangle(mapCells_[x, y].LayerTiles[z]),
                                Color.White,
                                0.0f,
                                Vector2.Zero,
                                SpriteEffects.None,
                                1f - ((float) z*0.1f));
                        }
                    }

                    if (EditorMode)
                    {
                        //TODO: 
                    }
                }
            }
        }

        #endregion

        #region Helpers

        #endregion
    }
}
