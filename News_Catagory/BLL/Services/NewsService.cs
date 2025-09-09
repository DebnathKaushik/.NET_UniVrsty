using AutoMapper;
using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NewsDTO, CatagoryDTO>().ReverseMap();
                cfg.CreateMap<NewsDTO, NewsCatDTO>().ReverseMap();
                cfg.CreateMap<NewsDTO, CatNewsDTO>().ReverseMap();
                cfg.CreateMap<CatagoryDTO, NewsCatDTO>().ReverseMap();
                cfg.CreateMap<CatagoryDTO, CatNewsDTO>().ReverseMap();
                cfg.CreateMap<NewsCatDTO, CatNewsDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

       




    }
