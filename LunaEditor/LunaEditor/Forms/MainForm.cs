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

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
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
                            gamePath_ = Path.Combine(frmFolder.SelectedPath, "Game");
                            texturePath_ = Path.Combine(gamePath_, "Textures");

                            if (Directory.Exists(gamePath_))
                                throw new Exception("Selected directory already exists.");

                            Directory.CreateDirectory(gamePath_);
                            Directory.CreateDirectory(texturePath_);
                            game_ = frmNewGame.Game;

                            //Serialize the data
                            XnaSerializer.Serialize<LuGame>(gamePath_ + @"\Game.xml", game_);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            EditingButtonsEnabled(false);
                            return;
                        }

                        EditingButtonsEnabled(true);
                    }
                }
            }
        }

        private void tsmSaveGame_Click(object sender, EventArgs e)
        {

        }

        private void tsmCharacters_Click(object sender, EventArgs e)
        {
            if (frmCharacters_ == null)
            {
                frmCharacters_ = new CharactersForm();
                frmCharacters_.MdiParent = this;
            }

            frmCharacters_.Show();
        }

        private void tsmNewLevel_Click(object sender, EventArgs e)
        {
            if (frmLevelEditor_ == null)
            {
                frmLevelEditor_ = new LevelEditorForm();
                frmLevelEditor_.MdiParent = this;
            }

            frmLevelEditor_.Show();
        }

        private void tsmLoadGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog frmFile = new OpenFileDialog();
            frmFile.Title = "Load a game into the editor";
            frmFile.InitialDirectory = Application.StartupPath;

            DialogResult result = frmFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    game_ = XnaSerializer.Deserialize<LuGame>(frmFile.FileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    EditingButtonsEnabled(false);
                    return;
                }
            }

            EditingButtonsEnabled(true);
        }
#endregion

        #region Helpers

        private void EditingButtonsEnabled(bool enabled)
        {
            tsmEntities.Enabled = enabled;
            tsmLevel.Enabled = enabled;
        }
        #endregion
    }
}
