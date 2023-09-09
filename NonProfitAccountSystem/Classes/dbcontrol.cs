using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NonProfitAccountSystem.Classes
{
    public class dbcontrol : MasterControl
    {
        public dbcontrol() : base("NonProfitAccountSystem")
        {

        }

        public dbcontrol(string Connectionstring, AAJControl.DatabaseType Tpe) : base(Connectionstring, Tpe)
        {

        }
    }
}