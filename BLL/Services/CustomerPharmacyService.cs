using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerPharmacyService
    {
        public static List<CustomerPharmacyDTO> Get()
        {
            var data = DataAccessFactory.CustomerPharmacyDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CustomerPharmacy, CustomerPharmacyDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<CustomerPharmacyDTO>>(data);
        }

        public static CustomerPharmacyDTO Get(int id)
        {
            var data = DataAccessFactory.CustomerPharmacyDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CustomerPharmacy, CustomerPharmacyDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CustomerPharmacyDTO>(data);
        }

        public static CustomerPharmacyDTO Add(CustomerPharmacyDTO hotel)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CustomerPharmacyDTO, CustomerPharmacy>();
                c.CreateMap<CustomerPharmacy, CustomerPharmacyDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<CustomerPharmacy>(hotel);
            var data = DataAccessFactory.CustomerPharmacyDataAccess().Add(ht);

            if (data != null) return mapper.Map<CustomerPharmacyDTO>(data);
            return null;
        }
        public static CustomerPharmacyDTO Delete(int id)
        {
            var data = DataAccessFactory.CustomerPharmacyDataAccess().Get(id);
            DataAccessFactory.CustomerPharmacyDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerPharmacy, CustomerPharmacyDTO>());
            var mapper = new Mapper(config);
            var Medi = mapper.Map<CustomerPharmacyDTO>(data);

            return Medi;

        }
        public static CustomerPharmacyDTO Update(CustomerPharmacyDTO dto)
        {
            var data = DataAccessFactory.CustomerPharmacyDataAccess().Get(dto.Id);
            data.Name = dto.Name;
            DataAccessFactory.CustomerPharmacyDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerPharmacy, CustomerPharmacyDTO>());
            var mapper = new Mapper(config);
            var CustomerPharmacy = mapper.Map<CustomerPharmacyDTO>(data);

            return CustomerPharmacy;

        }
    }
}
