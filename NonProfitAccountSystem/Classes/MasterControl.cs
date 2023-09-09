using AAJControl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NonProfitAccountSystem.Classes
{
    public class MasterControl : DBControl
    {
        public MasterControl(string ConnectionString) : base(DatabaseType.MSSQL, ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString)
        {

        }

        public MasterControl(string ConnectionString, DatabaseType Tpe) : base(Tpe, ConnectionString)
        {

        }
    }
}