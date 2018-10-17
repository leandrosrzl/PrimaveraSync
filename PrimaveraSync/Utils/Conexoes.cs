using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaveraSync.Utils
{
    class Conexoes
    {
        private static string strConEcommerce = PrimaveraSync.Properties.Settings.Default.api;
        private static string strConSjobs = "User=SYSDBA;Password=masterkey;Database=" + PrimaveraSync.Properties.Settings.Default.dbPath + ";DataSource="+ PrimaveraSync.Properties.Settings.Default.dbServer +";Port=3050;Dialect=3;";
        private static string strConBDG10 = "User=SYSDBA;Password=masterkey;Database=" + PrimaveraSync.Properties.Settings.Default.dbPathBDG + ";DataSource=" + PrimaveraSync.Properties.Settings.Default.dbServer + ";Port=3050;Dialect=3;";

        public static string conexaoEcommerce()
        {
            return strConEcommerce;
        }

        public static string conexaoSjobs
        {
            get{ return strConSjobs; }
        }

        public static string conexaoBDG
        {
            get { return strConBDG10; }
        }
    }
}
