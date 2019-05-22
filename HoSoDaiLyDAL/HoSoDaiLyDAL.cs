using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoSoDaiLyDAL
{
    public class HoSoDaiLyDAL
    {
        private string connectionString;

        public HoSoDaiLyDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
    }
}
