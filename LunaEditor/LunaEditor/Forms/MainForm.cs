using System;
using System.IO;
using System.Windows.Forms;
using LunaEditor.Data;
using LunaEditor.Properties;

namespace LunaEditor.Forms
{
    public partial class MainForm : Form
    {
        #region Declarations

        private LuGame game_;
        private CharactersForm frmCharacters_;
        private LevelEditorForm frmLevelEditor_;

        private string gamePath_;
        private string texturePath_;
        private string levelPath_;

        public const string GAME_XML = @"\Game.xml";
        public const string GAME_FOLDER = @"Game";
        public const string TEXTURE_FOLDER = @"Textures";
        public const string LEVEL_FOLDER = @"Levels";

        #endregion

        #region Properties

        public LuGame Game
        {
            get { return game_; }
            set
            {
                game_ = value;

                if (game_ != null)
                {
                }

                EditingButtonsEnabled((game_ != null));
            }
        }

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewGameToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (NewGameForm frmNewGame = new NewGameForm())
            {
                DialogResult result = frmNewGame.ShowDialog();

                if (result == DialogResult.OK && frmNewGame.Game != null)
                {
                    tsmEntities.Enabled = true;

                    //Create a new game
                    FolderBrowserDialog frmFolder = new FolderBrowserDialog();
                    frmFolder.Description = Resources.txt_NewGame_Folder;
                    frmFolder.SelectedPath = Application.StartupPath;

                    DialogResult folderResult = frmFolder.ShowDialog();

                    if (folderResult == DialogResult.OK)
                    {
                        try
                        {
                            gamePath_ = Path.Combine(frmFolder.SelectedPath, GAME_FOLDER);
                            UpdatePaths();

                            if (Directory.Exists(gamePath_))
                                throw new Exception("Selected directory already exists.");

                            Directory.CreateDirectory(gamePath_);
                            Directory.CreateDirectory(texturePath_);
                            Directory.CreateDirectory(levelPath_);
                            Game = frmNewGame.Game;

                            SaveGame();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            EditingButtonsEnabled(false);
                            return;
                        }
                    }
                }
            }
        }

        private void TsmSaveGameClick(object sender, EventArgs e)
        {
            SaveGame();
        }

        private void TsmCharactersClick(object sender, EventArgs e)
        {
            if (frmCharacters_ == null)
            {
                frmCharacters_ = new CharactersForm();
                frmCharacters_.MdiParent = this;
            }

            frmCharacters_.Show();
        }

        private void TsmNewLevelClick(object sender, EventArgs e)
        {
            if (frmLevelEditor_ == null)
            {
                frmLevelEditor_ = new LevelEditorForm();
                frmLevelEditor_.MdiParent = this;
            }

            frmLevelEditor_.LevelFolder = levelPath_;
            frmLevelEditor_.TextureFolder = texturePath_;
            frmLevelEditor_.Show();
            frmLevelEditor_.NewLevel();
        }

        private void TsmLoadGameClick(object sender, EventArgs e)
        {
            OpenFileDialog frmFile = new OpenFileDialog();
            frmFile.Title = Resources.txtLoadGame;
            frmFile.Filter = "XML Files (*.xml)|*.xml";

            DialogResult result = frmFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    Game = XnaSerializer.Deserialize<LuGame>(frmFile.FileName);

                    gamePath_ = Path.GetDirectoryName(frmFile.FileName);
                    UpdatePaths();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    EditingButtonsEnabled(false);
                    return;
                }
            }
        }

        #endregion

        #region Helpers

        private void SaveGame()
        {
            //Serialize the data
            if (game_ != null)
            {
                XnaSerializer.Serialize<LuGame>(gamePath_ + GAME_XML, game_);
            }
        }

        private void UpdatePaths()
        {
            if (gamePath_ != null)
            {
                texturePath_ = Path.Combine(gamePath_, TEXTURE_FOLDER);
                levelPath_ = Path.Combine(gamePath_, LEVEL_FOLDER);
            }
        }

        private void EditingButtonsEnabled(bool enabled)
        {
            tsmEntities.Enabled = enabled;
            tsmLevel.Enabled = enabled;
        }

        #endregion
    }
}
