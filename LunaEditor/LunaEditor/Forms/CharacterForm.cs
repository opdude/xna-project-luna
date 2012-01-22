using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LunaEngine.Data;

namespace LunaEditor.Forms
{
    public partial class CharacterForm : Form
    {
        #region Properties

        public EntityData EntityData { get; set; }

        #endregion

        public CharacterForm()
        {
            InitializeComponent();
        }

        private void CharacterForm_Load(object sender, EventArgs e)
        {
            if (EntityData != null)
            {
                txtName.Text = EntityData.Name;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //TODO: Validation

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EntityData = null;
            this.Close();
        }
    }
}
