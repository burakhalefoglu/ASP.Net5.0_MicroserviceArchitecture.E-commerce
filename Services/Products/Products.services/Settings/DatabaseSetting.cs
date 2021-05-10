using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.services.Settings
{
    public class DatabaseSetting : IDatabaseSetting
    {
        public string ProductCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
