using System;
using System.Collections.Generic;
using LunaEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LunaEngine.Graphics
{
    public class Sprite
    {
        #region Declarations

        public Texture2D Texture;

        private Vector2 worldLocation_ = Vector2.Zero;
        private Vector2 velocity_ = Vector2.Zero;

        private readonly List<Rectangle> frames_ = new List<Rectangle>();

        private int currentFrame_;
        private float frameTime_ = 0.1f;
        private float timeForCurrentFrame_;

        private Color tintColor_ = Color.White;

        private float rotation_;

        public bool Expired;
        public bool Animate = true;
        public bool AnimateWhenStopped = true;

        public bool Collidable = true;
        public int CollisionRadius;
        public int BoundingXPadding;
        public int BoundingYPadding;

        #endregion

        #region Constructor

        public Sprite(Vector2 worldLocation, Texture2D texture, Rectangle initialFrame, Vector2 velocity)
        {
            worldLocation_ = worldLocation;
            Texture = texture;
            velocity_ = velocity;

            frames_.Add(initialFrame);
        }

        #endregion

        #region Drawing and Animation Properties

        public int FrameWidth
        {
            get { return frames_[0].Width; }
        }

        public int FrameHeight
        {
            get { return frames_[0].Height; }
        }

        public Color TintColor
        {
            get { return tintColor_; }
            set { tintColor_ = value; }
        }

        public float Rotation
        {
            get { return rotation_; }
            set { rotation_ = value%MathHelper.Pi; }
        }

        public int Frame
        {
            get { return currentFrame_; }
            set { currentFrame_ = (int) MathHelper.Clamp(value, 0, frames_.Count - 1); }
        }

        public float FrameTime
        {
            get { return frameTime_; }
            set { frameTime_ = MathHelper.Max(0, value); }
        }

        public Rectangle Source
        {
            get { return frames_[currentFrame_]; }
        }

        #endregion

        #region Positional Properties

        public Vector2 WorldLocation
        {
            get { return worldLocation_; }
            set { worldLocation_ = value; }
        }

        public Vector2 ScreenLocation
        {
            get { return Camera.WorldToScreen(worldLocation_); }
        }

        public Vector2 Velocity
        {
            get { return velocity_; }
            set { velocity_ = value; }
        }

        public Rectangle WorldRectangle
        {
            get { return new Rectangle((int) worldLocation_.X, (int) worldLocation_.Y, FrameWidth, FrameHeight); }
        }

        public Rectangle ScreenRectangle
        {
            get { return Camera.WorldToScreen(WorldRectangle); }
        }

        public Vector2 RelativeCenter
        {
            get { return new Vector2(FrameWidth/2.0f, FrameHeight/2.0f); }
        }

        public Vector2 WorldCenter
        {
            get { return worldLocation_ + RelativeCenter; }
        }

        public Vector2 ScreenCenter
        {
            get { return Camera.WorldToScreen(worldLocation_ + RelativeCenter); }
        }

        #endregion

        #region Collision Related Properties

        public Rectangle BoundingBoxRect
        {
            get
            {
                return new Rectangle(
                    (int) worldLocation_.X + BoundingXPadding,
                    (int) worldLocation_.Y + BoundingYPadding,
                    FrameWidth - (BoundingXPadding*2),
                    FrameHeight - (BoundingYPadding*2));
            }
        }

        #endregion

        #region Collision Detection Methods

        public bool IsBoxColliding(Rectangle otherBox)
        {
            if (Collidable && !Expired)
            {
                return BoundingBoxRect.Intersects(otherBox);
            }

            return false;
        }

        public bool IsSphereColliding(Vector2 otherCenter, float otherRadius)
        {
            if (Collidable && !Expired)
            {
                if (Vector2.Distance(WorldCenter, otherCenter) < (CollisionRadius + otherRadius))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Animation-Related Methods

        public void AddFrame(Rectangle frameRectangle)
        {
            frames_.Add(frameRectangle);
        }

        public void RotateTo(Vector2 direction)
        {
            Rotation = (float) Math.Atan2(direction.Y, direction.X);
        }

        #endregion

        #region Update and Draw Methods

        public virtual void Update(GameTime gameTime)
        {
            if (!Expired)
            {
                float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;

                timeForCurrentFrame_ += elapsed;

                if (Animate)
                {
                    if (timeForCurrentFrame_ >= frameTime_)
                    {
                        if (AnimateWhenStopped || velocity_ != Vector2.Zero)
                        {
                            currentFrame_ = (currentFrame_ + 1)%frames_.Count;
                            timeForCurrentFrame_ = 0.0f;
                        }
                    }
                }

                if (Velocity != Vector2.Zero)
                {
                    worldLocation_ += (velocity_*elapsed);
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!Expired)
            {
                if (Camera.IsRectVisible(WorldRectangle))
                {
                    spriteBatch.Draw(
                        Texture,
                        ScreenCenter,
                        Source,
                        tintColor_,
                        rotation_,
                        RelativeCenter,
                        1.0f,
                        SpriteEffects.None,
                        0.0f);
                }
            }
        }

        #endregion
    }
}
