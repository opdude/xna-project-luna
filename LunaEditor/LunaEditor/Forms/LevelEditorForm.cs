using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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
        private List<Texture2D> textures_;
        private string levelPath_;
        private TileMap level_;

        private int selectedTexture_ = 0;

        #endregion

        #region Properties

        public GraphicsDevice GraphicsDevice
        {
            get { return lvlEditor.GraphicsDevice; }
        }

        public string LevelFolder { get; set; }
        public string TextureFolder { get; set; }

        public TileMap Level
        {
            get { return level_; } 
            set
            {
                textures_ = FindTextures(TextureFolder);
                UpdateTextureList();
                level_ = value;
            }
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
        }

        #endregion

        #region Drawing

        private void lvlEditor_OnDraw(object sender, EventArgs e)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch_.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            if (Level != null)
            {
                Level.Draw(spriteBatch_);
            }
            spriteBatch_.End();
        }

        #endregion

        #region Event Handling

        private void LstTilesetsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (Level != null)
            {
                Level.TileSheet = SelectedTexture();
            }
        }

        #endregion


        #region Helper Methods

        public void NewLevel()
        {
            SaveFileDialog frmSave = new SaveFileDialog();
            frmSave.InitialDirectory = LevelFolder;
            frmSave.DefaultExt = "xml";
            frmSave.AddExtension = true;
            frmSave.Filter = "XML Files (*.xml)|*.xml";

            DialogResult result = frmSave.ShowDialog();

            if (result == DialogResult.OK)
            {
                levelPath_ = frmSave.FileName;
                Level = new TileMap();
                Level.Initialise(SelectedTexture(), 0);
                SaveLevel();
            }
        }

        private void SaveLevel()
        {
            XnaSerializer.Serialize(levelPath_, Level);
        }

        private void LoadLevel(string fileName)
        {
            levelPath_ = fileName;
            Level = XnaSerializer.Deserialize<TileMap>(fileName);
        }

        private List<Texture2D> FindTextures(string texturePath)
        {
            string[] files = Directory.GetFiles(texturePath, "*.png");
            List<Texture2D> output = new List<Texture2D>();

            foreach (string file in files)
            {
                Stream stream = new FileStream(file, FileMode.Open);
                Texture2D tex = Texture2D.FromStream(GraphicsDevice, stream);
                output.Add(tex);
            }

            return output;
        }

        private void UpdateTextureList()
        {
            lstTilesets.Items.Clear();
            lstTilesets.Items.AddRange(textures_.ToArray());
            lstTilesets.SelectedIndex = 0;
        }

        private Texture2D SelectedTexture()
        {
            return textures_[selectedTexture_];
        }

        #endregion
    }
}
