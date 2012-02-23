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

        private bool trackMouse_;
        private bool mouseDown_;
        private Point mouse_ = new Point();

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
                if (this.IsHandleCreated == true && textures_ == null)
                {
                    textures_ = FindTextures(TextureFolder);
                    UpdateTextureList();
                    imgCurrentTilesheet.Image = UIHelpers.Texture2Image(SelectedTexture());
                }

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

        #region Drawing & Logic

        private void lvlEditor_OnInitialise(object sender, EventArgs e)
        {
            if (textures_ == null)
            {
                textures_ = FindTextures(TextureFolder);
                UpdateTextureList();
                imgCurrentTilesheet.Image = UIHelpers.Texture2Image(SelectedTexture());
            }

            spriteBatch_ = new SpriteBatch(GraphicsDevice);
        }

        private void lvlEditor_OnDraw(object sender, EventArgs e)
        {
            Update();
            Render();
        }

        private void Render()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch_.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            if (Level != null)
            {
                Level.Draw(spriteBatch_);
            }
            spriteBatch_.End();
        }

        /// <summary>
        /// Update logic and other things within the level editor
        /// </summary>
        private void Update()
        {
            if (trackMouse_)
            {
                if (mouseDown_)
                {
                    MapSquare square = Level.GetMapSquareAtPixel(mouse_.X, mouse_.Y);

                    if (square != null)
                    {
                        square.LayerTiles[2] = (int)numTile.Value;
                    }
                }
            }
        }

        #endregion

        #region Event Handling

        private void LevelEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveLevel();
        }

        private void LstTilesetsSelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTexture_ = lstTilesets.SelectedIndex;

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

        private void lvlEditor_MouseEnter(object sender, EventArgs e)
        {
            trackMouse_ = true;
        }

        private void lvlEditor_MouseLeave(object sender, EventArgs e)
        {
            trackMouse_ = false;
        }

        private void lvlEditor_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown_ = true;
        }

        private void lvlEditor_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown_ = false;
        }

        private void lvlEditor_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_.X = e.X;
            mouse_.Y = e.Y;
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
            XnaSerializer.Serialize(levelPath_, Level.Data);
        }

        public void LoadLevel(string fileName)
        {
            levelPath_ = fileName;
            try
            {
                Level = new TileMap()
                            {
                                Data = XnaSerializer.Deserialize<TileMapData>(fileName)
                            };
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
                try
                {
                    Stream stream = new FileStream(file, FileMode.Open);
                    Texture2D tex = Texture2D.FromStream(GraphicsDevice, stream);
                    tex.Name = Path.GetFileNameWithoutExtension(file);
                    output.Add(tex);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Couldn't open texture file {0} {1}",file, e);
                    //Do nothing for now
                }
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

            if (textures_.Count() > 0)
                lstTilesets.SelectedIndex = 0;
        }

        private Texture2D SelectedTexture()
        {
            if (textures_.Count() > selectedTexture_)
            {
                return textures_[selectedTexture_];
            }

            return null;
        }

        #endregion

        #region Toolstrip
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewLevel();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveLevel();
        }

        #endregion
    }
}