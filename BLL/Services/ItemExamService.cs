using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ItemExamService
    {
        public static List<ItemExamDTO> Get()
        {
            var data = DataAccessFactory.ItemExamDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ItemExam, ItemExamDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<ItemExamDTO>>(data);
        }
        public static ItemExamDTO Get(int id)
        {
            var data = DataAccessFactory.ItemExamDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ItemExam, ItemExamDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<ItemExamDTO>(data);
        }
        public static ItemExamDTO Add(ItemExamDTO item)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ItemExamDTO, ItemExam>();
                c.CreateMap<ItemExam, ItemExamDTO>();

            });
            var mapper = new Mapper(cfg);
            var itm = mapper.Map<ItemExam>(item);
            var data = DataAccessFactory.ItemExamDataAccess().Add(itm);

            if (data != null) return mapper.Map<ItemExamDTO>(data);
            return null;
        }
        public static ItemExamDTO Delete(int id)
        {
            var data = DataAccessFactory.ItemExamDataAccess().Get(id);
            DataAccessFactory.ItemExamDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ItemExam, ItemExamDTO>());
            var mapper = new Mapper(config);
            var Medi = mapper.Map<ItemExamDTO>(data);

            return Medi;

        }
        public static ItemExamDTO Update(ItemExamDTO dto)
        {
            var data = DataAccessFactory.ItemExamDataAccess().Get(dto.Id);
            data.Name = dto.Name;
            data.Rate = dto.Rate;
            DataAccessFactory.ItemExamDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ItemExam, ItemExamDTO>());
            var mapper = new Mapper(config);
            var ItemExam = mapper.Map<ItemExamDTO>(data);

            return ItemExam;

        }

        public static List<ItemExamDTO> Msearch(string name)
        {
            var data = Get();
            var dt = (from d in data
                      where d.Name.ToLower().StartsWith(name)
                      select d).ToList();
            return dt;
        }
    }
}
