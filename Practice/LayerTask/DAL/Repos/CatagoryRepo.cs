using System;
using DAL.EF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CatagoryRepo
    {
        public static string Get(int id)
        {
            return "Found Category";
        }

        public static string Create(Category category)
        {
            return "Created Category";
        }
    }
}
