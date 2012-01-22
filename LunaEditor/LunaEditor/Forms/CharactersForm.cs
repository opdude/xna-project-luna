using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LunaEditor.Forms;

namespace LunaEditor
{
    public partial class CharactersForm : Form
    {
        public CharactersForm()
        {
            InitializeComponent();
        }

        #region Event Handling

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (CharacterForm frmChar = new CharacterForm())
            {
                frmChar.ShowDialog();

                if (frmChar.EntityData != null)
                {
                    lstCharacters.Items.Add(frmChar.EntityData.ToString());
                }
            }
        }

        #endregion
    }
}
