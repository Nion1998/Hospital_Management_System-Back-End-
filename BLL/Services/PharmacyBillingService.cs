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
    public class PharmacyBillingService
    {
        public static List<PharmacyBillingDTO> Get()
        {
            var data = DataAccessFactory.PharmacyBillingDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PharmacyBilling, PharmacyBillingDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<PharmacyBillingDTO>>(data);
        }
        public static PharmacyBillingDTO Get(int id)
        {
            var data = DataAccessFactory.PharmacyBillingDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PharmacyBilling, PharmacyBillingDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<PharmacyBillingDTO>(data);
        }
        public static PharmacyBillingDTO Add(PharmacyBillingDTO PharmacyBilling)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PharmacyBillingDTO, PharmacyBilling>();
                c.CreateMap<PharmacyBilling, PharmacyBillingDTO>();

            });
            var mapper = new Mapper(cfg);
            var ph = mapper.Map<PharmacyBilling>(PharmacyBilling);
           
            var data = DataAccessFactory.PharmacyBillingDataAccess().Add(ph);

            if (data != null) return mapper.Map<PharmacyBillingDTO>(data);
            return null;
        }
        public static PharmacyBillingDTO Delete(int id)
        {
            var data = DataAccessFactory.PharmacyBillingDataAccess().Get(id);
            DataAccessFactory.PharmacyBillingDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PharmacyBilling, PharmacyBillingDTO>());
            var mapper = new Mapper(config);
            var op = mapper.Map<PharmacyBillingDTO>(data);

            return op;

        }
        public static PharmacyBillingDTO Update(PharmacyBillingDTO dto)
        {
            var data = DataAccessFactory.PharmacyBillingDataAccess().Get(dto.Id);
            data.Id = dto.Id;
            DataAccessFactory.PharmacyBillingDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PharmacyBilling, PharmacyBillingDTO>());
            var mapper = new Mapper(config);
            var PharmacyBilling = mapper.Map<PharmacyBillingDTO>(data);

            return PharmacyBilling;

        }
    }
}
