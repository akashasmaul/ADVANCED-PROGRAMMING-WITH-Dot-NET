using System;
using DAL.EF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class NewsRepo
    {
        public static string Get(int id)
        {
            return "Found News";
        }

        public static string Create(News n)
        {
            return "Created News";
        }
    }
}
