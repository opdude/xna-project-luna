using System;

namespace LunaEditor.XNA
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
