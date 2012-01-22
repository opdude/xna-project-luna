namespace LunaEditor.Data
{
    public class LuGame
    {
        #region Declaration

        public string Name { get; set; }
        public string Description { get; set; }

        #endregion

        #region Constructor

        public LuGame()
        {
            
        }

        public LuGame(string name, string description)
        {
            Name = name;
            Description = description;
        }

        #endregion
    }
}
