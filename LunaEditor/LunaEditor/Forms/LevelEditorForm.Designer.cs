using LunaEditor.XNA;

namespace LunaEditor.Forms
{
    partial class LevelEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditorForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewLevel = new System.Windows.Forms.ToolStripButton();
            this.lvlEditor = new LunaEditor.XNA.LevelEditor();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTiles = new System.Windows.Forms.TabPage();
            this.numTile = new System.Windows.Forms.NumericUpDown();
            this.lstTilesets = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imgCurrentTilesheet = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbErase = new System.Windows.Forms.RadioButton();
            this.rbDraw = new System.Windows.Forms.RadioButton();
            this.imgTile = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabLayers = new System.Windows.Forms.TabPage();
            this.lstLayers = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCurrentTilesheet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTile)).BeginInit();
            this.tabLayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.lvlEditor);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(743, 524);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewLevel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(500, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNewLevel
            // 
            this.tsbNewLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewLevel.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewLevel.Image")));
            this.tsbNewLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewLevel.Name = "tsbNewLevel";
            this.tsbNewLevel.Size = new System.Drawing.Size(23, 22);
            this.tsbNewLevel.Text = "New Level";
            this.tsbNewLevel.Click += new System.EventHandler(this.TsbNewLevelClick);
            // 
            // lvlEditor
            // 
            this.lvlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvlEditor.Location = new System.Drawing.Point(0, 0);
            this.lvlEditor.Name = "lvlEditor";
            this.lvlEditor.Size = new System.Drawing.Size(500, 524);
            this.lvlEditor.TabIndex = 0;
            this.lvlEditor.Text = "lvlEditor";
            this.lvlEditor.OnInitialize += new System.EventHandler(this.lvlEditor_OnInitialise);
            this.lvlEditor.OnDraw += new System.EventHandler(this.lvlEditor_OnDraw);
            this.lvlEditor.Click += new System.EventHandler(this.lvlEditor_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTiles);
            this.tabControl1.Controls.Add(this.tabLayers);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(239, 524);
            this.tabControl1.TabIndex = 0;
            // 
            // tabTiles
            // 
            this.tabTiles.Controls.Add(this.numTile);
            this.tabTiles.Controls.Add(this.lstTilesets);
            this.tabTiles.Controls.Add(this.label3);
            this.tabTiles.Controls.Add(this.imgCurrentTilesheet);
            this.tabTiles.Controls.Add(this.label2);
            this.tabTiles.Controls.Add(this.groupBox1);
            this.tabTiles.Controls.Add(this.imgTile);
            this.tabTiles.Controls.Add(this.label1);
            this.tabTiles.Location = new System.Drawing.Point(4, 25);
            this.tabTiles.Name = "tabTiles";
            this.tabTiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabTiles.Size = new System.Drawing.Size(231, 495);
            this.tabTiles.TabIndex = 0;
            this.tabTiles.Text = "Tiles";
            this.tabTiles.UseVisualStyleBackColor = true;
            // 
            // numTile
            // 
            this.numTile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numTile.Location = new System.Drawing.Point(10, 90);
            this.numTile.Name = "numTile";
            this.numTile.Size = new System.Drawing.Size(210, 22);
            this.numTile.TabIndex = 8;
            this.numTile.ValueChanged += new System.EventHandler(this.numTile_ValueChanged);
            // 
            // lstTilesets
            // 
            this.lstTilesets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTilesets.FormattingEnabled = true;
            this.lstTilesets.ItemHeight = 16;
            this.lstTilesets.Location = new System.Drawing.Point(10, 351);
            this.lstTilesets.Name = "lstTilesets";
            this.lstTilesets.Size = new System.Drawing.Size(210, 132);
            this.lstTilesets.TabIndex = 7;
            this.lstTilesets.SelectedIndexChanged += new System.EventHandler(this.LstTilesetsSelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tilesheets";
            // 
            // imgCurrentTilesheet
            // 
            this.imgCurrentTilesheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.imgCurrentTilesheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCurrentTilesheet.Location = new System.Drawing.Point(10, 135);
            this.imgCurrentTilesheet.Name = "imgCurrentTilesheet";
            this.imgCurrentTilesheet.Size = new System.Drawing.Size(210, 193);
            this.imgCurrentTilesheet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgCurrentTilesheet.TabIndex = 5;
            this.imgCurrentTilesheet.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Tilesheet";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbErase);
            this.groupBox1.Controls.Add(this.rbDraw);
            this.groupBox1.Location = new System.Drawing.Point(69, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Draw Mode";
            // 
            // rbErase
            // 
            this.rbErase.AutoSize = true;
            this.rbErase.Location = new System.Drawing.Point(7, 50);
            this.rbErase.Name = "rbErase";
            this.rbErase.Size = new System.Drawing.Size(66, 21);
            this.rbErase.TabIndex = 1;
            this.rbErase.Text = "Erase";
            this.rbErase.UseVisualStyleBackColor = true;
            // 
            // rbDraw
            // 
            this.rbDraw.AutoSize = true;
            this.rbDraw.Checked = true;
            this.rbDraw.Location = new System.Drawing.Point(7, 22);
            this.rbDraw.Name = "rbDraw";
            this.rbDraw.Size = new System.Drawing.Size(61, 21);
            this.rbDraw.TabIndex = 0;
            this.rbDraw.TabStop = true;
            this.rbDraw.Text = "Draw";
            this.rbDraw.UseVisualStyleBackColor = true;
            // 
            // imgTile
            // 
            this.imgTile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgTile.Location = new System.Drawing.Point(10, 28);
            this.imgTile.Name = "imgTile";
            this.imgTile.Size = new System.Drawing.Size(53, 53);
            this.imgTile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgTile.TabIndex = 1;
            this.imgTile.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tile";
            // 
            // tabLayers
            // 
            this.tabLayers.Controls.Add(this.lstLayers);
            this.tabLayers.Location = new System.Drawing.Point(4, 25);
            this.tabLayers.Name = "tabLayers";
            this.tabLayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabLayers.Size = new System.Drawing.Size(231, 495);
            this.tabLayers.TabIndex = 1;
            this.tabLayers.Text = "Layers";
            this.tabLayers.UseVisualStyleBackColor = true;
            // 
            // lstLayers
            // 
            this.lstLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLayers.FormattingEnabled = true;
            this.lstLayers.Location = new System.Drawing.Point(3, 3);
            this.lstLayers.Name = "lstLayers";
            this.lstLayers.Size = new System.Drawing.Size(225, 489);
            this.lstLayers.TabIndex = 0;
            // 
            // LevelEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(743, 524);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(761, 564);
            this.Name = "LevelEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Level Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LevelEditorForm_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabTiles.ResumeLayout(false);
            this.tabTiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCurrentTilesheet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTile)).EndInit();
            this.tabLayers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTiles;
        private System.Windows.Forms.TabPage tabLayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgTile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbErase;
        private System.Windows.Forms.RadioButton rbDraw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox imgCurrentTilesheet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstTilesets;
        private System.Windows.Forms.CheckedListBox lstLayers;
        private LevelEditor lvlEditor;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNewLevel;
        private System.Windows.Forms.NumericUpDown numTile;
    }
}