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
    public class CabinService
    {
        public static List<CabinDTO> Get()
        {
            var data = DataAccessFactory.CabinDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Cabin, CabinDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<CabinDTO>>(data);
        }
        public static CabinDTO Get(int id)
        {
            var data = DataAccessFactory.CabinDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Cabin, CabinDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CabinDTO>(data);
        }
        public static CabinDTO Add(CabinDTO cabin)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CabinDTO, Cabin>();
                c.CreateMap<Cabin, CabinDTO>();

            });
            var mapper = new Mapper(cfg);
            var cab = mapper.Map<Cabin>(cabin);
            var data = DataAccessFactory.CabinDataAccess().Add(cab);

            if (data != null) return mapper.Map<CabinDTO>(data);
            return null;
        }
        public static CabinDTO Delete(int id)
        {
            var data = DataAccessFactory.CabinDataAccess().Get(id);
            DataAccessFactory.CabinDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Cabin, CabinDTO>());
            var mapper = new Mapper(config);
            var cab = mapper.Map<CabinDTO>(data);

            return cab;

        }
        public static CabinDTO Update(CabinDTO dto)
        {
            var data = DataAccessFactory.CabinDataAccess().Get(dto.Id);
            data.CategoryName = dto.CategoryName;
            data.Status = dto.Status;
            data.Rent = dto.Rent;
            DataAccessFactory.CabinDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Cabin, CabinDTO>());
            var mapper = new Mapper(config);
            var cabin = mapper.Map<CabinDTO>(data);

            return cabin;

        }
    }
}
