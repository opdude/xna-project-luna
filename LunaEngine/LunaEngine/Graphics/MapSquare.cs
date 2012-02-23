using LunaEngine.Data;

namespace LunaEngine.Graphics
{
    public class MapSquare
    {
        #region Declaration

        private MapSquareData data_;

        #endregion

        #region Forwarding Methods

        public bool Passable
        {
            get { return data_.Passable; }
            set { data_.Passable = value; }
        }

        public string CodeValue
        {
            get { return data_.CodeValue; }
            set { data_.CodeValue = value; }
        }

        public int[] LayerTiles
        {
            get { return data_.LayerTiles; }
        }

        #endregion

        #region Constructor

        public MapSquare(MapSquareData data)
        {
            data_ = data;
        }
        #endregion

        #region Public Methods

        public void TogglePassable()
        {
            data_.Passable = !data_.Passable;
        }

        #endregion
    }
}
