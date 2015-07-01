using System;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AnalyzerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var cn = new OleDbConnection();
            var repo = new MyRepo();
        }
    }

    public class glennType
    {
        public glennType()
        {

        }
    }

    public class MyRepo
    {
        private string cs;
        private OleDbConnection cn;

        public MyRepo()
        {
            cs = ConfigurationManager.ConnectionStrings["MyRepo"].ConnectionString;
            cn = new OleDbConnection(cs);
            cn.Open();
        }

        // TODO: lets deprecate this.
        public MyRepo(OleDbConnection conn)
        {
            cn = conn;
        }
    }
}
