using Luna.Engine;
using LunaEngine;
using LunaEngine.Entities;
using LunaEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Luna.Game
{
    class Player
    {
        #region Declarations

        //TODO: Make this a layer based sprite system
        public static Sprite BaseSprite;
        public static Sprite TurretSprite;
        private static float playerSpeed_ = 180; //TODO: Make this depend on the character gear
        private static Vector2 baseAngle_;
        private static Rectangle scrollArea_ = new Rectangle(300,150,500,400);
        #endregion

        #region Initialization
        public static void Initialize(Texture2D texture, Rectangle baseInitialFrame, int baseFrameCount, 
            Rectangle turretInitialFrame, int turretFrameCount, Vector2 worldLocation)
        {
            //Assumes all sizes are the same when this is made into a layer based
            //system we shouldn't assume that
            int frameWidth = baseInitialFrame.Width;
            int frameHeight = baseInitialFrame.Height;

            BaseSprite = new Sprite(worldLocation, texture, baseInitialFrame, Vector2.Zero);
            BaseSprite.BoundingXPadding = 4;
            BaseSprite.BoundingYPadding = 4;
            BaseSprite.AnimateWhenStopped = false;

            for (int x=1; x < baseFrameCount; x++)
            {
                BaseSprite.AddFrame(new Rectangle(
                    baseInitialFrame.X + (frameHeight * x),
                    baseInitialFrame.Y, 
                    frameWidth, 
                    frameHeight));
            }

            TurretSprite = new Sprite(
                worldLocation,
                texture,
                turretInitialFrame,
                Vector2.Zero);

            TurretSprite.Animate = false;

            //TODO: Make this deal with a number of layers
            for (int x=1; x < turretFrameCount; x++)
            {
                TurretSprite.AddFrame(new Rectangle(
                    turretInitialFrame.X + (frameHeight * x),
                    turretInitialFrame.Y,
                    frameWidth,
                    frameHeight));
            }
        }
        #endregion

        #region Update and Draw
        public static void Update(GameTime gameTime)
        {
            HandleInput(gameTime);
            BaseSprite.Update(gameTime);

            ClampToWorld();
            TurretSprite.WorldLocation = BaseSprite.WorldLocation;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            BaseSprite.Draw(spriteBatch);
            TurretSprite.Draw(spriteBatch);
        }
        #endregion

        #region Handling Input
        private static void HandleInput(GameTime gameTime)
        {
            float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 moveAngle = Vector2.Zero;

            moveAngle += HandleKeybordMovement(Keyboard.GetState());

            if (moveAngle != Vector2.Zero)
            {
                moveAngle.Normalize();
                baseAngle_ = moveAngle;
                moveAngle = CheckTileObsticles(elapsed, moveAngle);
            }

            BaseSprite.RotateTo(moveAngle);

            BaseSprite.Velocity = moveAngle*playerSpeed_;

            //Reposition Camera
            RepositionCamera(gameTime, moveAngle);
        }

        private static Vector2 HandleKeybordMovement(KeyboardState keyboardState)
        {
            Vector2 keyMovement = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W))
                keyMovement.Y--;
            if (keyboardState.IsKeyDown(Keys.A))
                keyMovement.X--;
            if (keyboardState.IsKeyDown(Keys.S))
                keyMovement.Y++;
            if (keyboardState.IsKeyDown(Keys.D))
                keyMovement.X++;
            return keyMovement;
        }
        #endregion

        #region Movement Limitations

        /// <summary>
        /// Clamp the player to the world
        /// TODO: Move this to character
        /// </summary>
        private static void ClampToWorld()
        {
            float currentX = BaseSprite.WorldLocation.X;
            float currentY = BaseSprite.WorldLocation.Y;

            currentX = MathHelper.Clamp(currentX, 0, Camera.WorldRectangle.Right - BaseSprite.FrameWidth);
            currentY = MathHelper.Clamp(currentY, 0, Camera.WorldRectangle.Bottom - BaseSprite.FrameHeight);

            BaseSprite.WorldLocation = new Vector2(currentX, currentY);
        }

        /// <summary>
        /// Check if a player is moving into an obsticle
        /// TODO: This can be improved for sure!
        /// </summary>
        /// <param name="elapsedTime"></param>
        /// <param name="movedAngle"></param>
        /// <returns></returns>
        private static Vector2 CheckTileObsticles(float elapsedTime, Vector2 movedAngle)
        {
            float deltaMovement = playerSpeed_*elapsedTime;
            Vector2 newHorizontalLoc = BaseSprite.WorldLocation + (new Vector2(movedAngle.X, 0) * deltaMovement);
            Vector2 newVerticalLoc = BaseSprite.WorldLocation + (new Vector2(0, movedAngle.Y) * deltaMovement);

            Rectangle newHorizontalRect = new Rectangle(
                (int)newHorizontalLoc.X, 
                (int)BaseSprite.WorldLocation.Y,
                BaseSprite.FrameWidth,
                BaseSprite.FrameHeight);

            Rectangle newVerticalRect = new Rectangle(
                (int)BaseSprite.WorldLocation.X,
                (int)newVerticalLoc.Y,
                BaseSprite.FrameWidth,
                BaseSprite.FrameHeight);


            int horizontalLeftPixel = 0;
            int horizontalRightPixel = 0;
            int verticalTopPixel = 0;
            int verticalBottomPixel = 0;

            if (movedAngle.X < 0)
            {
                horizontalLeftPixel = (int) newHorizontalRect.Left;
                horizontalRightPixel = (int) BaseSprite.WorldRectangle.Left;
            }
            else if (movedAngle.X > 0)
            {
                horizontalLeftPixel = (int)BaseSprite.WorldRectangle.Right;
                horizontalRightPixel = (int)newHorizontalRect.Right;
            }

            if (movedAngle.Y < 0)
            {
                verticalTopPixel = (int)newVerticalRect.Top;
                verticalBottomPixel = (int)BaseSprite.WorldRectangle.Top;
            }
            else if (movedAngle.Y > 0)
            {
                verticalTopPixel = (int)BaseSprite.WorldRectangle.Bottom;
                verticalBottomPixel = (int)newVerticalRect.Bottom;
            }

            if (movedAngle.X != 0)
            {
                for (int x=horizontalLeftPixel; x < horizontalRightPixel ; x++)
                {
                    for (int y=0; y < BaseSprite.FrameHeight; y++)
                    {
                       /* if (TileMap.IsWallTileByPixel(new Vector2(x, newHorizontalLoc.Y + y)))
                        {
                            movedAngle.X = 0;
                            break;
                        }*/
                    }

                    if (movedAngle.X == 0)
                    {
                        break;
                    }
                }
            }

            if (movedAngle.Y != 0)
            {
                for (int y = verticalTopPixel; y < verticalBottomPixel; y++)
                {
                    for (int x = 0; x < BaseSprite.FrameWidth; x++)
                    {
                        /*if (TileMap.IsWallTileByPixel(new Vector2(newVerticalLoc.X + x, y)))
                        {
                            movedAngle.Y = 0;
                            break;
                        }*/
                    }

                    if (movedAngle.Y == 0)
                    {
                        break;
                    }
                }
            }

            return movedAngle;
        }

        private static void RepositionCamera(GameTime gameTime, Vector2 moveAngle)
        {
            float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;
            float moveScale = playerSpeed_*elapsed;

            if (BaseSprite.ScreenRectangle.X < scrollArea_.X && moveAngle.X < 0)
            {
                Camera.Move(new Vector2(moveAngle.X, 0) * moveScale);
            }

            if (BaseSprite.ScreenRectangle.Right > scrollArea_.X && moveAngle.X > 0)
            {
                Camera.Move(new Vector2(moveAngle.X, 0) * moveScale);
            }

            if (BaseSprite.ScreenRectangle.Y < scrollArea_.Y && moveAngle.Y < 0)
            {
                Camera.Move(new Vector2(0, moveAngle.Y) * moveScale);
            }

            if (BaseSprite.ScreenRectangle.Bottom > scrollArea_.Y && moveAngle.Y > 0)
            {
                Camera.Move(new Vector2(0, moveAngle.Y) * moveScale);
            }
        }
        #endregion
    }
}
