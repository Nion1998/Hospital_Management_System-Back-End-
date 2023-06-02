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
    public class SupplierService
    {
        public static List<SupplierDTO> Get()
        {
            var data = DataAccessFactory.SupplierDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Supplier, SupplierDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<SupplierDTO>>(data);
        }

        public static SupplierDTO Get(int id)
        {
            var data = DataAccessFactory.SupplierDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Supplier, SupplierDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<SupplierDTO>(data);
        }

        public static SupplierDTO Add(SupplierDTO hotel)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<SupplierDTO, Supplier>();
                c.CreateMap<Supplier, SupplierDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Supplier>(hotel);
            var data = DataAccessFactory.SupplierDataAccess().Add(ht);

            if (data != null) return mapper.Map<SupplierDTO>(data);
            return null;
        }
        public static SupplierDTO Delete(int id)
        {
            var data = DataAccessFactory.SupplierDataAccess().Get(id);
            DataAccessFactory.SupplierDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierDTO>());
            var mapper = new Mapper(config);
            var Medi = mapper.Map<SupplierDTO>(data);

            return Medi;

        }
        public static SupplierDTO Update(SupplierDTO dto)
        {
            var data = DataAccessFactory.SupplierDataAccess().Get(dto.Id);
            data.Name = dto.Name;
            DataAccessFactory.SupplierDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierDTO>());
            var mapper = new Mapper(config);
            var Supplier = mapper.Map<SupplierDTO>(data);

            return Supplier;

        }
    }
}
