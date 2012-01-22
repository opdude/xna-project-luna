using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LunaEditor.Data;
using LunaEditor.Properties;

namespace LunaEditor
{
    public partial class NewGameForm : Form
    {

        #region Declarations

        #endregion

        #region Properties

        public LuGame Game { get; private set; }

        #endregion

        public NewGameForm()
        {
            InitializeComponent();
            btnOK.Click += new EventHandler(BtnOkClick);
        }

        #region Event Handling

        void BtnOkClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show(Resources.NewGameForm_Text_Empty, Resources.TxtError);
                return;
            }

            Game = new LuGame(txtName.Text, txtDescription.Text);

            this.Close();
        }

        #endregion
    }
}
