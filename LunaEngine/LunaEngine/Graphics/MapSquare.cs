using LunaEngine.Data;

namespace LunaEngine.Graphics
{
    public class MapSquare
    {
        #region Declaration

        public int[] LayerTiles = new int[3];
        public string CodeValue = "";
        public bool Passable = true;

        #endregion

        #region Constructor

        public MapSquare(MapSquareData data)
        {
            LayerTiles = data.LayerTiles;
            CodeValue = data.CodeValue;
            Passable = data.Passable;
        }
        #endregion

        #region Public Methods

        public void TogglePassable()
        {
            Passable = !Passable;
        }

        #endregion
    }
}
