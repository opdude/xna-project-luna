using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace LunaEngine.Factories
{
    public class Factory
    {
        public static string LEVEL_FOLDER = "Levels";
        public static string TEXTURE_FOLDER = "Textures";

        protected ContentManager Content;

        public Factory(ContentManager contentManager)
        {
            Content = contentManager;
        }
    }
}
