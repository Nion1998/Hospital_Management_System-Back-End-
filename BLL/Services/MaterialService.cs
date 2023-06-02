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
    public class MaterialService
    {
        public static List<MaterialDTO> Get()
        {
            var data = DataAccessFactory.MaterialDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Material, MaterialDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<MaterialDTO>>(data);
        }
        public static MaterialDTO Get(int id)
        {
            var data = DataAccessFactory.MaterialDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Material, MaterialDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<MaterialDTO>(data);
        }
        public static MaterialDTO Add(MaterialDTO material)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<MaterialDTO, Material>();
                c.CreateMap<Material, MaterialDTO>();

            });
            var mapper = new Mapper(cfg);
            var mat = mapper.Map<Material>(material);
            var data = DataAccessFactory.MaterialDataAccess().Add(mat);

            if (data != null) return mapper.Map<MaterialDTO>(data);
            return null;
        }
        public static MaterialDTO Delete(int id)
        {
            var data = DataAccessFactory.MaterialDataAccess().Get(id);
            DataAccessFactory.MaterialDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Material, MaterialDTO>());
            var mapper = new Mapper(config);
            var Medi = mapper.Map<MaterialDTO>(data);

            return Medi;

        }
        public static MaterialDTO Update(MaterialDTO dto)
        {
            var data = DataAccessFactory.MaterialDataAccess().Get(dto.Id);
            data.Name = dto.Name;
            data.Details = dto.Details;
            data.Quantity = dto.Quantity;
            data.Price = dto.Price;
            data.TotalPrice = dto.TotalPrice;
            DataAccessFactory.MaterialDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Material, MaterialDTO>());
            var mapper = new Mapper(config);
            var Material = mapper.Map<MaterialDTO>(data);

            return Material;

        }
    }
}
