using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CatagoryService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>().ReverseMap();
                cfg.CreateMap<Catagory, CatagoryDTO>().ReverseMap();

                cfg.CreateMap<NewsDTO, CatagoryDTO>().ReverseMap();
                cfg.CreateMap<NewsDTO, NewsCatDTO>().ReverseMap();
                cfg.CreateMap<NewsDTO, CatNewsDTO>().ReverseMap();
                cfg.CreateMap<CatagoryDTO, NewsCatDTO>().ReverseMap();
                cfg.CreateMap<CatagoryDTO, CatNewsDTO>().ReverseMap();
                cfg.CreateMap<NewsCatDTO, CatNewsDTO>().ReverseMap();
            });
            return new Mapper(config);
        }


        public static bool deleteCatagory(int Id)
        {
            var data = DataAccessFactory.CatagoryData().Delete(Id);
            return data;

        }


        public static bool updateCatagory(CatagoryDTO c)
        {
            var st = GetMapper().Map<Catagory>(c);
            var data = DataAccessFactory.CatagoryData().Update(st);
            return data;
        }
    }
}
