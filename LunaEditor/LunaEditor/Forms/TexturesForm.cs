using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using LunaEditor.Data;
using LunaEngine.Data;
using Microsoft.Xna.Framework.Graphics;

namespace LunaEditor.Forms
{
    public partial class frmTextures : Form
    {
        #region Declarations

        public string GamePath;
        public LuGame Game;

        #endregion

        public frmTextures()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void btnAddTexture_Click(object sender, EventArgs e)
        {
            OpenFileDialog frmOpen = new OpenFileDialog();
            frmOpen.Filter = "Images (.*png)|*.png";

            DialogResult result = frmOpen.ShowDialog();

            if (result == DialogResult.OK)
            {
                TileSheetData data = new TileSheetData();
                Uri gamePath = new Uri(GamePath);
                Uri filePath = new Uri(frmOpen.FileName);

                data.TextureSource = filePath.MakeRelativeUri(gamePath).ToString();

                ReloadTextures();
            }
        }

        private void LstTexturesSelectedIndexChanged(object sender, EventArgs e)
        {
            TileSheetData data = SelectedTileSheet();
            numTileWidth.Value = data.TileWidth;
            numTileHeight.Value = data.TileHeight;
            numTile.Value = 0;

            Stream stream = new FileStream(Path.Combine(GamePath), FileMode.Open);
            Texture2D tex = Texture2D.FromStream(LuGame.GraphicsDevice, stream);
            imgSheet.Image = UIHelpers.Texture2Image(tex);
        }
        #endregion

        #region Helpers

        private void ReloadTextures()
        {
            lstTextures.Items.Clear();
            lstTextures.Items.AddRange(Game.TileSheetData.ToArray());
        }

        private TileSheetData SelectedTileSheet()
        {
            return Game.TileSheetData[lstTextures.SelectedIndex];
        }

        #endregion
    }
}
