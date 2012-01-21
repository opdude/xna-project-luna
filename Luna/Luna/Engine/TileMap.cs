using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Luna.Engine
{
    internal class TileMap
    {
        public const int TileWidth = 32;
        public const int TileHeight = 32;
        public const int MapWidth = 50;
        public const int MapHeight = 50;

        public const int FloorTileStart = 0;
        public const int FloorTileEnd = 3;
        public const int WallTileStart = 4;
        public const int WallTileEnd = 7;

        private static Texture2D texture_;

        private static List<Rectangle> tiles_ = new List<Rectangle>();

        private static int[,] mapSquares_ = new int[MapWidth,MapHeight];

        private static Random rand_ = new Random();

        #region Initializer 

        public static void Initialize(Texture2D tileTexture)
        {
            texture_ = tileTexture;
            tiles_.Clear();
            AddTilesWithTexture(tiles_, texture_, TileWidth, TileHeight,0 ,0, 12, 2);

            Random rand = new Random();

            //TODO: This should be smarter
            for (int col = 0; col < MapWidth; col++)
            {
                for (int row = 0; row < MapHeight; row++)
                {
                    const float wallChance = 1;
                    int randWall = rand.Next(WallTileStart, WallTileEnd + 1);
                    int randFloor = FloorTileStart;

                    mapSquares_[col, row] = randFloor;

                    if (rand.Next(0,100) < wallChance)
                    {
                        mapSquares_[col, row] = randWall;
                    }
                }
            }
        }

        #endregion

        #region Information about Map Squares

        public static int GetSquareByPixelX(int pixelX)
        {
            return pixelX/TileWidth;
        }

        public static int GetSquareByPixelY(int pixelY)
        {
            return pixelY/TileHeight;
        }

        static public Vector2 GetSquareAtPixel(Vector2 pixelLocation)
        {
            return  new Vector2(GetSquareByPixelX((int)pixelLocation.X), GetSquareByPixelY((int)pixelLocation.Y));
        }

        static public Vector2 GetSquareCenter(int squareX, int squareY)
        {
            return new Vector2(
                (squareX*TileWidth) + (TileWidth/2),
                (squareY*TileHeight) + (TileHeight/2));
        }

        static public Vector2 GetSquareCenter(Vector2 square)
        {
            return GetSquareCenter((int)square.X, (int)square.Y);
        }

        static public Rectangle SquareWorldRectangle(int x, int y)
        {
            return new Rectangle(
                x * TileWidth,
                y * TileHeight,
                TileWidth,
                TileHeight);
        }

        static public Rectangle SquareWorldRectangle(Vector2 square)
        {
            return SquareWorldRectangle((int) square.X, (int) square.Y);
        }

        static public Rectangle SquareScreenRectangle(int x, int y)
        {
            return Camera.Transform(SquareWorldRectangle(x, y));
        }

        static public Rectangle SquareScreenRectangle(Vector2 square)
        {
            return Camera.Transform(SquareWorldRectangle((int)square.X, (int)square.Y));
        }

        #endregion

        #region Information about Map Tiles
        static public bool TileExists(int tileX, int tileY)
        {
             if ((tileX >= 0 && tileX < MapWidth) &&
                (tileY >= 0 && tileY < MapHeight))
             {
                 return true;
             }

            return false;
        }

        static public int GetTileAtSquare(int tileX, int tileY)
        {
            if (TileExists(tileX, tileY))
            {
                return mapSquares_[tileX, tileY];
            }

            return -1;
        }

        public static void SetTileAtSquare(int tileX, int tileY, int tile)
        {
            if (TileExists(tileX, tileY))
            {
                mapSquares_[tileX, tileY] = tile;
            }
        }

        static public int GetTileAtPixel(int pixelX, int pixelY)
        {
            return GetTileAtSquare(
                GetSquareByPixelX(pixelX),
                GetSquareByPixelY(pixelY));
        }

        static public int GetTileAtPixel(Vector2 pixelLocation)
        {
            return GetTileAtSquare(
                GetSquareByPixelX((int)pixelLocation.X),
                GetSquareByPixelY((int)pixelLocation.Y));
        }

        static public bool IsWallTile(int tileX, int tileY)
        {
            int tileIndex = GetTileAtPixel(tileX, tileY);
            return (tileIndex >= WallTileStart);
        }

        static public bool IsWallTile(Vector2 tileLocation)
        {
            return IsWallTile((int) tileLocation.X, (int) tileLocation.Y);
        }

        static public bool IsWallTileByPixel(Vector2 pixelLocation)
        {
            return IsWallTile(
                GetSquareByPixelX((int) pixelLocation.X),
                GetSquareByPixelY((int) pixelLocation.Y));
        }
        #endregion

        #region Drawing
        static public void Draw(SpriteBatch spriteBatch)
        {
            int startX = GetSquareByPixelX((int) Camera.Position.X);
            int endX = GetSquareByPixelX((int) Camera.ViewPort.Right);

            int startY = GetSquareByPixelY((int)Camera.Position.Y);
            int endY = GetSquareByPixelY((int) Camera.ViewPort.Bottom);

            for (int x=startX; x <= endX; x++)
            {
                for (int y=startY; y <= endY; y++)
                {
                    if (TileExists(x, y))
                    {
                        spriteBatch.Draw(
                            texture_,
                            SquareScreenRectangle(x,y),
                            tiles_[GetTileAtSquare(x, y)],
                            Color.White);
                    }
                }
            }
        }
        #endregion

        #region Helpers

        public static void AddTilesWithTexture(List<Rectangle> tiles, Texture2D texture, int tileWidth, int tileHeight,
                                               int startColumn, int startRow, int tileColumns, int tileRows)
        {
            for (int col = startColumn; col < tileColumns; col++)
            {
                for (int row = startRow; row < tileRows; row++)
                {
                    Rectangle tile = new Rectangle(col*tileWidth, row*tileHeight, tileColumns, tileRows);

                    //Make sure the tile is found within the texture
                    if (tile.Intersects(texture.Bounds))
                    {
                        tiles_.Add(tile);
                    }
                }
            }
        }

        #endregion
    }
}
