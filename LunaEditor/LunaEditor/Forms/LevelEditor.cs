using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LunaEditor.Forms
{
    public partial class LevelEditor : WinFormsGraphicsDevice.GraphicsDeviceControl
    {
        public event EventHandler OnInitialize;
        public event EventHandler OnDraw;

        #region Constructor
        public LevelEditor()
        {
            InitializeComponent();
        }
        #endregion

        protected override void Initialize()
        {
            if (OnInitialize != null)
            {
                OnInitialize(this, null);
            }
        }

        #region Drawing
        protected override void Draw()
        {
            if (OnDraw != null)
            {
                OnDraw(this, null);
            }
        }
        #endregion
    }
}
