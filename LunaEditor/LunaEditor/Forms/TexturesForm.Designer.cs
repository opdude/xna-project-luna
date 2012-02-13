namespace LunaEditor.Forms
{
    partial class frmTextures
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
            this.imgSheet = new System.Windows.Forms.PictureBox();
            this.lstTextures = new System.Windows.Forms.ListBox();
            this.btnAddTexture = new System.Windows.Forms.Button();
            this.btnRemoveTexture = new System.Windows.Forms.Button();
            this.numTileWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numTileHeight = new System.Windows.Forms.NumericUpDown();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imgTile = new System.Windows.Forms.PictureBox();
            this.numTile = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.imgSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTile)).BeginInit();
            this.SuspendLayout();
            // 
            // imgSheet
            // 
            this.imgSheet.Location = new System.Drawing.Point(12, 44);
            this.imgSheet.Name = "imgSheet";
            this.imgSheet.Size = new System.Drawing.Size(286, 206);
            this.imgSheet.TabIndex = 0;
            this.imgSheet.TabStop = false;
            // 
            // lstTextures
            // 
            this.lstTextures.FormattingEnabled = true;
            this.lstTextures.ItemHeight = 16;
            this.lstTextures.Location = new System.Drawing.Point(374, 44);
            this.lstTextures.Name = "lstTextures";
            this.lstTextures.Size = new System.Drawing.Size(216, 372);
            this.lstTextures.TabIndex = 1;
            this.lstTextures.SelectedIndexChanged += new System.EventHandler(this.LstTexturesSelectedIndexChanged);
            // 
            // btnAddTexture
            // 
            this.btnAddTexture.Location = new System.Drawing.Point(374, 15);
            this.btnAddTexture.Name = "btnAddTexture";
            this.btnAddTexture.Size = new System.Drawing.Size(23, 23);
            this.btnAddTexture.TabIndex = 2;
            this.btnAddTexture.Text = "+";
            this.btnAddTexture.UseVisualStyleBackColor = true;
            this.btnAddTexture.Click += new System.EventHandler(this.btnAddTexture_Click);
            // 
            // btnRemoveTexture
            // 
            this.btnRemoveTexture.Location = new System.Drawing.Point(403, 15);
            this.btnRemoveTexture.Name = "btnRemoveTexture";
            this.btnRemoveTexture.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveTexture.TabIndex = 3;
            this.btnRemoveTexture.Text = "-";
            this.btnRemoveTexture.UseVisualStyleBackColor = true;
            // 
            // numTileWidth
            // 
            this.numTileWidth.Location = new System.Drawing.Point(125, 267);
            this.numTileWidth.Name = "numTileWidth";
            this.numTileWidth.Size = new System.Drawing.Size(62, 22);
            this.numTileWidth.TabIndex = 4;
            this.numTileWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tile Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tile Height:";
            // 
            // numTileHeight
            // 
            this.numTileHeight.Location = new System.Drawing.Point(125, 299);
            this.numTileHeight.Name = "numTileHeight";
            this.numTileHeight.Size = new System.Drawing.Size(62, 22);
            this.numTileHeight.TabIndex = 7;
            this.numTileHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Character",
            "Level"});
            this.cmbType.Location = new System.Drawing.Point(125, 328);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 24);
            this.cmbType.Sorted = true;
            this.cmbType.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sheet Type:";
            // 
            // imgTile
            // 
            this.imgTile.Location = new System.Drawing.Point(304, 44);
            this.imgTile.Name = "imgTile";
            this.imgTile.Size = new System.Drawing.Size(64, 64);
            this.imgTile.TabIndex = 10;
            this.imgTile.TabStop = false;
            // 
            // numTile
            // 
            this.numTile.Location = new System.Drawing.Point(304, 115);
            this.numTile.Name = "numTile";
            this.numTile.Size = new System.Drawing.Size(64, 22);
            this.numTile.TabIndex = 11;
            // 
            // frmTextures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 427);
            this.Controls.Add(this.numTile);
            this.Controls.Add(this.imgTile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.numTileHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numTileWidth);
            this.Controls.Add(this.btnRemoveTexture);
            this.Controls.Add(this.btnAddTexture);
            this.Controls.Add(this.lstTextures);
            this.Controls.Add(this.imgSheet);
            this.Name = "frmTextures";
            this.Text = "Textures";
            ((System.ComponentModel.ISupportInitialize)(this.imgSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgSheet;
        private System.Windows.Forms.ListBox lstTextures;
        private System.Windows.Forms.Button btnAddTexture;
        private System.Windows.Forms.Button btnRemoveTexture;
        private System.Windows.Forms.NumericUpDown numTileWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numTileHeight;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox imgTile;
        private System.Windows.Forms.NumericUpDown numTile;
    }
}