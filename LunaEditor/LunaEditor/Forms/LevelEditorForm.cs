using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LunaEngine.Entities;
using LunaEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LunaEditor.Forms
{
    public partial class LevelEditorForm : Form
    {

        #region Declarations

        private SpriteBatch spriteBatch_;
        private Texture2D tileTexture_;

        #endregion

#region Properties
        public GraphicsDevice GraphicsDevice
        {
            get { return lvlEditor.GraphicsDevice;  }
        }
#endregion

        public LevelEditorForm()
        {
            InitializeComponent();
        }

        #region Initialisation
        private void lvlEditor_OnInitialize(object sender, EventArgs e)
        {
            spriteBatch_ = new SpriteBatch(GraphicsDevice);

            Camera.WorldRectangle = new Rectangle(0, 0, 1600, 1600);
            Camera.ViewPortWidth = 800;
            Camera.ViewPortHeight = 600;

            TileMap.Initialise(tileTexture_);
        }
        #endregion

        #region Drawing
        private void lvlEditor_OnDraw(object sender, EventArgs e)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch_.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            TileMap.Draw(spriteBatch_);
            spriteBatch_.End();
        }
        #endregion
    }
}
