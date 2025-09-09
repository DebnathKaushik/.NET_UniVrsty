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
    public class NewsService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News,NewsDTO>().ReverseMap();
                cfg.CreateMap<Catagory,CatagoryDTO>().ReverseMap();

                cfg.CreateMap<NewsDTO, CatagoryDTO>().ReverseMap();
                cfg.CreateMap<NewsDTO, NewsCatDTO>().ReverseMap();
                cfg.CreateMap<NewsDTO, CatNewsDTO>().ReverseMap();
                cfg.CreateMap<CatagoryDTO, NewsCatDTO>().ReverseMap();
                cfg.CreateMap<CatagoryDTO, CatNewsDTO>().ReverseMap();
                cfg.CreateMap<NewsCatDTO, CatNewsDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<NewsDTO> GetAll() 
        {
            var data = DataAccessFactory.NewsData().Get();
            return GetMapper().Map<List<NewsDTO>>(data);
        }

        public static NewsDTO GetNewsbyId(int Id)
        {
            var data = DataAccessFactory.NewsData().Get(Id);
            return GetMapper().Map<NewsDTO>(data);
        }

        public static List<NewsDTO> GetNewsbyCatagoryName(string CName)
        {
            var category = DataAccessFactory.CatagoryData().GetByName(CName);

            if (category == null) return new List<NewsDTO>();

            var data = DataAccessFactory.NewsData().Get(category);
            return GetMapper().Map<List<NewsDTO>>(data);
        }


    }
}
