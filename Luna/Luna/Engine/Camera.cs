using Microsoft.Xna.Framework;

namespace Luna.Engine
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

        public static Rectangle WorldRectangle { get; set; }

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


        #region Methods
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
        /// Transform a point into camera space
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector2 Transform(Vector2 point)
        {
            return point - position_;
        }

        /// <summary>
        /// Transform a rectangle into camera space
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static Rectangle Transform(Rectangle rect)
        {
            return new Rectangle(
                rect.Left - (int)position_.X,
                rect.Top - (int)position_.Y, 
                rect.Width, 
                rect.Height);
        }
        #endregion
    }
}
