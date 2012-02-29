using Microsoft.Xna.Framework;

namespace LunaEngine.Entities
{
    public static class Camera
    {
        #region Declarations
        private static Vector2 position_ = Vector2.Zero;
        private static Vector2 viewPortSize_ = Vector2.Zero;
        private static Rectangle worldRectangle_ = new Rectangle(0,0,0,0);
        private static float worldScale_ = 0.5f;
        #endregion

        #region Properties
        public static Vector2 Position
        {
            get { return position_; }
            set
            {
                float clampedX = MathHelper.Clamp(value.X, worldRectangle_.X, (worldRectangle_.Width * worldScale_) - ViewPortWidth);
                float clampedY = MathHelper.Clamp(value.Y, worldRectangle_.Y, (worldRectangle_.Height * worldScale_) - ViewPortHeight);
                position_ = new Vector2(clampedX, clampedY);
            }
        }

        public static Rectangle WorldRectangle
        {
            get
            {
                return new Rectangle(0, 0,
                                     (int)(worldRectangle_.Width*worldScale_),
                                     (int)(worldRectangle_.Height * worldScale_));
            }
            private set { worldRectangle_ = value; }
        }

        public static int ViewPortWidth
        {
            get { return (int)viewPortSize_.X; }
            set { viewPortSize_.X = value; }
        }

        public static int ViewPortHeight
        {
            get { return (int) viewPortSize_.Y; }
            set { viewPortSize_.Y = value;  }
        }

        public static Rectangle ViewPort
        {
            get
            {
                return new Rectangle(
                    (int)(Position.X), 
                    (int)(Position.Y), 
                    (int)(ViewPortWidth), 
                    (int)(ViewPortHeight));
            }
        }

        public static float WorldScale
        {
            get { return worldScale_; }
            set { worldScale_ = value; }
        }
        #endregion


        #region  Public Methods
        /// <summary>
        /// Move the camera by a given offset
        /// </summary>
        /// <param name="offset"></param>
        public static void Move(Vector2 offset)
        {
            Position += offset * worldScale_;
        }

        /// <summary>
        /// Is the given rectangle visible by the camera?
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool IsRectVisible(Rectangle rect)
        {
            return ViewPort.Intersects(rect);
        }

        /// <summary>
        /// Transform a world location to a screen location
        /// </summary>
        /// <param name="worldLocation"></param>
        /// <returns></returns>
        public static Vector2 WorldToScreen(Vector2 worldLocation)
        {
            return (worldLocation * worldScale_) - position_;
        }

        /// <summary>
        /// Transform a world Rectangle to a screen rectangle
        /// </summary>
        /// <param name="worldRectangle"></param>
        /// <returns></returns>
        public static Rectangle WorldToScreen(Rectangle worldRectangle)
        {
            return new Rectangle(
                (int)((float)worldRectangle.Left * worldScale_) - (int) position_.X,
                (int)((float)worldRectangle.Top * worldScale_) - (int)position_.Y,
                (int)((float)worldRectangle.Width * worldScale_),
                (int)((float)worldRectangle.Height * worldScale_));
        }

        /// <summary>
        /// Transform a screen location to a world location
        /// </summary>
        /// <param name="screenLocation"></param>
        /// <returns></returns>
        public static Vector2 ScreenToWorld(Vector2 screenLocation)
        {
            return screenLocation + position_;
        }

        /// <summary>
        /// Transform a screen rectangle to a world rectangle
        /// </summary>
        /// <param name="screenRectangle"></param>
        /// <returns></returns>
        public static Rectangle ScreenToWorld(Rectangle screenRectangle)
        {
            return new Rectangle(
                (int)((float)screenRectangle.Left / worldScale_) + (int)position_.X,
                (int)((float)screenRectangle.Top / worldScale_) + (int)position_.Y,
                (int)((float)screenRectangle.Width / worldScale_),
                (int)((float)screenRectangle.Height / worldScale_));
        }

        /// <summary>
        /// Set the size of the world, this should be changed when
        /// a level is loaded or changed
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void SetWorldSize(int width, int height)
        {
            WorldRectangle = new Rectangle(0,0,width,height);
        }
        #endregion
    }
}
