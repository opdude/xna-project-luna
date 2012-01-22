using System.Collections.Generic;
using LunaEngine.Entities;

namespace LunaEngine.Data
{
    public class EntityDataManager
    {
        #region Declarations

        private readonly Dictionary<string, EntityData> entityData_ = new Dictionary<string, EntityData>();

        #endregion

        #region Properties

        public Dictionary<string, EntityData> EntityData
        {
            get { return entityData_; }
        }

        #endregion
    }
}
