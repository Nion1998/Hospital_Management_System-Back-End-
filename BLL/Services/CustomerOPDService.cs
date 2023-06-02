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
    public class CustomerOPDService
    {
        public static List<CustomerOPDDTO> Get()
        {
            var data = DataAccessFactory.CustomerOPDDataAccess().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerOPD, CustomerOPDDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<CustomerOPDDTO>>(data);
        }
        public static CustomerOPDDTO Get(int id)
        {
            var data = DataAccessFactory.CustomerOPDDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CustomerOPD, CustomerOPDDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CustomerOPDDTO>(data);
        }
        public static CustomerOPDDTO Add(CustomerOPDDTO customer)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerOPDDTO, CustomerOPD>();
                c.CreateMap<CustomerOPD, CustomerOPDDTO>();

            });
            var mapper = new Mapper(cfg);
            var cust = mapper.Map<CustomerOPD>(customer);
            var data = DataAccessFactory.CustomerOPDDataAccess().Add(cust);

            if (data != null) return mapper.Map<CustomerOPDDTO>(data);
            return null;
        }
        public static CustomerOPDDTO Delete(int id)
        {
            var data = DataAccessFactory.CustomerOPDDataAccess().Get(id);
            DataAccessFactory.CustomerOPDDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerOPD, CustomerOPDDTO>());
            var mapper = new Mapper(config);
            var Medi = mapper.Map<CustomerOPDDTO>(data);

            return Medi;

        }
        public static CustomerOPDDTO Update(CustomerOPDDTO dto)
        {
            var data = DataAccessFactory.CustomerOPDDataAccess().Get(dto.Id);
            data.Name = dto.Name;
            data.Address = dto.Address;
            data.Age = dto.Age;
            data.Gender = dto.Gender;
            data.BloodGroup = dto.BloodGroup;
            data.Phone = dto.Phone;
            data.RefdBy = dto.RefdBy;
            data.Remark = dto.Remark;
            data.DeliveryDate = dto.DeliveryDate;
            data.DeliveryStatus = dto.DeliveryStatus;
            DataAccessFactory.CustomerOPDDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerOPD, CustomerOPDDTO>());
            var mapper = new Mapper(config);
            var CustomerOPD = mapper.Map<CustomerOPDDTO>(data);

            return CustomerOPD;

        }
    }
}
