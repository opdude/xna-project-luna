using Microsoft.Xna.Framework;

namespace LunaEngine.Entities
{
    public static class Camera
    {
        #region Declarations
        private static Vector2 position_ = Vector2.Zero;
        private static Vector2 viewPortSize_ = Vector2.Zero;
        private static Rectangle worldRectangle_ = new Rectangle(0,0,0,0);
        #endregion

        #region Properties
        public static Vector2 Position
        {
            get { return position_; }
            set
            {
                float clampedX = MathHelper.Clamp(value.X, worldRectangle_.X, worldRectangle_.Width - ViewPortWidth);
                float clampedY = MathHelper.Clamp(value.Y, worldRectangle_.Y, worldRectangle_.Width - ViewPortHeight);
                position_ = new Vector2(clampedX, clampedY);
            }
        }

        public static Rectangle WorldRectangle
        {
            get { return worldRectangle_; }
            set { worldRectangle_ = value; }
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
                return new Rectangle((int)Position.X, (int)Position.Y, ViewPortWidth, ViewPortHeight);
            }
        }
        #endregion


        #region  Public Methods
        /// <summary>
        /// Move the camera by a given offset
        /// </summary>
        /// <param name="offset"></param>
        public static void Move(Vector2 offset)
        {
            Position += offset;
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
            return worldLocation - position_;
        }

        /// <summary>
        /// Transform a world Rectangle to a screen rectangle
        /// </summary>
        /// <param name="worldRectangle"></param>
        /// <returns></returns>
        public static Rectangle WorldToScreen(Rectangle worldRectangle)
        {
            return new Rectangle(
                worldRectangle.Left - (int) position_.X,
                worldRectangle.Top - (int) position_.Y,
                worldRectangle.Width,
                worldRectangle.Height);
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
                screenRectangle.Left + (int)position_.X,
                screenRectangle.Top + (int)position_.Y,
                screenRectangle.Width,
                screenRectangle.Height);
        }
        #endregion
    }
}
