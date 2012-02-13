namespace LunaEditor.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSaveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLoadGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEntities = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCharacters = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNewLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLoadLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tsmEntities,
            this.tsmLevel,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1156, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.tsmSaveGame,
            this.tsmLoadGame,
            this.toolStripMenuItem1,
            this.tsmExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.newGameToolStripMenuItem.Text = "&New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.NewGameToolStripMenuItemClick);
            // 
            // tsmSaveGame
            // 
            this.tsmSaveGame.Name = "tsmSaveGame";
            this.tsmSaveGame.Size = new System.Drawing.Size(154, 24);
            this.tsmSaveGame.Text = "&Save Game";
            this.tsmSaveGame.Click += new System.EventHandler(this.TsmSaveGameClick);
            // 
            // tsmLoadGame
            // 
            this.tsmLoadGame.Name = "tsmLoadGame";
            this.tsmLoadGame.Size = new System.Drawing.Size(154, 24);
            this.tsmLoadGame.Text = "&Load Game";
            this.tsmLoadGame.Click += new System.EventHandler(this.TsmLoadGameClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(154, 24);
            this.tsmExit.Text = "E&xit";
            this.tsmExit.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // tsmEntities
            // 
            this.tsmEntities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCharacters});
            this.tsmEntities.Enabled = false;
            this.tsmEntities.Name = "tsmEntities";
            this.tsmEntities.Size = new System.Drawing.Size(69, 24);
            this.tsmEntities.Text = "&Entities";
            // 
            // tsmCharacters
            // 
            this.tsmCharacters.Name = "tsmCharacters";
            this.tsmCharacters.Size = new System.Drawing.Size(147, 24);
            this.tsmCharacters.Text = "&Characters";
            this.tsmCharacters.Click += new System.EventHandler(this.TsmCharactersClick);
            // 
            // tsmLevel
            // 
            this.tsmLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNewLevel,
            this.tsmLoadLevel});
            this.tsmLevel.Enabled = false;
            this.tsmLevel.Name = "tsmLevel";
            this.tsmLevel.Size = new System.Drawing.Size(55, 24);
            this.tsmLevel.Text = "Level";
            // 
            // tsmNewLevel
            // 
            this.tsmNewLevel.Name = "tsmNewLevel";
            this.tsmNewLevel.Size = new System.Drawing.Size(149, 24);
            this.tsmNewLevel.Text = "&New Level";
            this.tsmNewLevel.Click += new System.EventHandler(this.TsmNewLevelClick);
            // 
            // tsmLoadLevel
            // 
            this.tsmLoadLevel.Name = "tsmLoadLevel";
            this.tsmLoadLevel.Size = new System.Drawing.Size(149, 24);
            this.tsmLoadLevel.Text = "&Load Level";
            this.tsmLoadLevel.Click += new System.EventHandler(this.TsmLoadLevelClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 567);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Luna Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmLoadGame;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmEntities;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveGame;
        private System.Windows.Forms.ToolStripMenuItem tsmCharacters;
        private System.Windows.Forms.ToolStripMenuItem tsmLevel;
        private System.Windows.Forms.ToolStripMenuItem tsmNewLevel;
        private System.Windows.Forms.ToolStripMenuItem tsmLoadLevel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

