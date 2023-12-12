using BLLL.DTOs;
using AutoMapper;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Models;

namespace BLLL.Services
{
    public class NewsService
    {
        public static NewsDTO Get(int id)
        {
            var data = NewsRepo.Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<NewsDTO>(data);
            return ret;
        }
        public static void Create(NewsDTO n) { 
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NewsDTO, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(n);
            NewsRepo.Create(data);
            }

    }
}
