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
    public class OPDBillingService
    {
        public static List<OPDBillingDTO> Get()
        {
            var data = DataAccessFactory.OPDBillingDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OPDBilling, OPDBillingDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<OPDBillingDTO>>(data);
        }
        public static OPDBillingDTO Get(int id)
        {
            var data = DataAccessFactory.OPDBillingDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OPDBilling, OPDBillingDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<OPDBillingDTO>(data);
        }
        public static OPDBillingDTO Add(OPDBillingDTO OPDBilling)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OPDBillingDTO, OPDBilling>();
                c.CreateMap<OPDBilling, OPDBillingDTO>();

            });
            var mapper = new Mapper(cfg);
            var cab = mapper.Map<OPDBilling>(OPDBilling);
            var data = DataAccessFactory.OPDBillingDataAccess().Add(cab);

            if (data != null) return mapper.Map<OPDBillingDTO>(data);
            return null;
        }
        public static OPDBillingDTO Delete(int id)
        {
            var data = DataAccessFactory.OPDBillingDataAccess().Get(id);
            DataAccessFactory.OPDBillingDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OPDBilling, OPDBillingDTO>());
            var mapper = new Mapper(config);
            var op = mapper.Map<OPDBillingDTO>(data);

            return op;

        }
        public static OPDBillingDTO Update(OPDBillingDTO dto)
        {
            var data = DataAccessFactory.OPDBillingDataAccess().Get(dto.Id);
            data.Id = dto.Id;
            DataAccessFactory.OPDBillingDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OPDBilling, OPDBillingDTO>());
            var mapper = new Mapper(config);
            var OPDBilling = mapper.Map<OPDBillingDTO>(data);

            return OPDBilling;

        }
    }
}
