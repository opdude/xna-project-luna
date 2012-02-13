using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LunaEditor.Properties;
using LunaEngine.Data;
using LunaEngine.Entities;
using LunaEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
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
                imgCurrentTilesheet.Image = UIHelpers.Texture2Image(SelectedTexture());
                level_ = value;
            }
        }

        #endregion

        #region Initialisation

        public LevelEditorForm()
        {
            InitializeComponent();

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

        private void lvlEditor_OnInitialise(object sender, EventArgs e)
        {
            spriteBatch_ = new SpriteBatch(GraphicsDevice);
        }

        #endregion

        #region Event Handling

        private void LevelEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveLevel();
        }

        private void LstTilesetsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (Level != null)
            {
                Level.TileSheet = SelectedTexture();
                imgCurrentTilesheet.Image = UIHelpers.Texture2Image(SelectedTexture());
            }
        }

        private void TsbNewLevelClick(object sender, EventArgs e)
        {
            NewLevel();
        }

        private void numTile_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void lvlEditor_Click(object sender, EventArgs e)
        {

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
                InitialiseLevel();
                SaveLevel();
            }
        }

        /// <summary>
        /// Intialise a level or reset it
        /// </summary>
        private void InitialiseLevel()
        {
            if (Level == null)
                return;

            if (SelectedTexture() == null)
                return;

            TileMapData tileMapData = new TileMapData();
            tileMapData.Initialise(new TileSheetData(SelectedTexture().Name));
            Level.Initialise(tileMapData, SelectedTexture());
        }

        private void SaveLevel()
        {
            XnaSerializer.Serialize(levelPath_, Level);
        }

        public void LoadLevel(string fileName)
        {
            levelPath_ = fileName;
            try
            {
                Level = XnaSerializer.Deserialize<TileMap>(fileName);
            }
            catch (InvalidContentException)
            {
                UIHelpers.Error(Resources.txtUnrecognisedFileFormat);
            }
        }

        private List<Texture2D> FindTextures(string texturePath)
        {
            string[] files = Directory.GetFiles(texturePath, "*.png");
            List<Texture2D> output = new List<Texture2D>();

            foreach (string file in files)
            {
                Stream stream = new FileStream(file, FileMode.Open);
                Texture2D tex = Texture2D.FromStream(GraphicsDevice, stream);
                tex.Name = file;
                output.Add(tex);
            }

            return output;
        }

        private void UpdateTextureList()
        {
            lstTilesets.Items.Clear();
            foreach (var texture2D in textures_)
            {
                lstTilesets.Items.Add(texture2D.Name);
            }
            lstTilesets.SelectedIndex = 0;
        }

        private Texture2D SelectedTexture()
        {
            return textures_[selectedTexture_];
        }

        #endregion




    }
}