using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MedicineService
    {
        public static List<MedicineDTO> Get()
        {
            var data = DataAccessFactory.MedicineDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Medicine, MedicineDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<MedicineDTO>>(data);
        }

        public static MedicineDTO Get(int id)
        {
            var data = DataAccessFactory.MedicineDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Medicine, MedicineDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<MedicineDTO>(data);
        }

        public static MedicineDTO Add(MedicineDTO hotel)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<MedicineDTO, Medicine>();
                c.CreateMap<Medicine, MedicineDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Medicine>(hotel);
            var data = DataAccessFactory.MedicineDataAccess().Add(ht);

            if (data != null) return mapper.Map<MedicineDTO>(data);
            return null;
        }
        public static MedicineDTO Delete(int id)
        {
            var data = DataAccessFactory.MedicineDataAccess().Get(id);
            DataAccessFactory.MedicineDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Medicine, MedicineDTO>());
            var mapper = new Mapper(config);
            var Medi = mapper.Map<MedicineDTO>(data);

            return Medi;

        }
        public static MedicineDTO Update(MedicineDTO dto)
        {
            var data = DataAccessFactory.MedicineDataAccess().Get(dto.Id);
            data.Name = dto.Name;
            data.Price = dto.Price;
            data.Quantity = dto.Quantity;
            data.TotalPrice = dto.TotalPrice;
            DataAccessFactory.MedicineDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Medicine, MedicineDTO>());
            var mapper = new Mapper(config);
            var Medicine = mapper.Map<MedicineDTO>(data);

            return Medicine;

        }

        public static List<MedicineDTO> Msearch(string name)
        {
            var data = Get();
            var dt = (from d in data
                      where d.Name.ToLower().StartsWith(name)
                      select d).ToList();
            return dt;
        }


        public static void DMedicine(int id ,int quantity)
        {   
            var obj = MedicineService.Get(id);
            obj.Quantity -= quantity;
            var d=MedicineService.Update(obj);

        }


    }
}
