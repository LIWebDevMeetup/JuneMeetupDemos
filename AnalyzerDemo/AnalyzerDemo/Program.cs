using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var cn = new OleDbConnection();
            var repo = new MyRepo(cn);
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

        // lets deprecate this.
        public MyRepo(OleDbConnection conn)
        {
            cn = conn;
        }
    }
}
