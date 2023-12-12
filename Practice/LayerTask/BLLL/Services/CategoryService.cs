using AutoMapper;
using BLLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLL.Services
{
    public class CategoryService
    {
        public static CategoryDTO Get(int id)
        {
            var data = CatagoryRepo.Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<CategoryDTO>(data);
            return ret;
        }
        public static void Create(CategoryDTO n)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CategoryDTO, Category>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Category>(n);
            CatagoryRepo.Create(data);
        }

    }
}

