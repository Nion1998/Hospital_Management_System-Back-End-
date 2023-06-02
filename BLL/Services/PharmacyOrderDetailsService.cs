using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class PharmacyOrderDetailsService
    {
        public static List<PharmacyOrderDetailsDTO> Get()
        {
            var data = DataAccessFactory.PharmacyOrderDetailsDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PharmacyOrderDetails, PharmacyOrderDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<PharmacyOrderDetailsDTO>>(data);
        }
        public static PharmacyOrderDetailsDTO Get(int id)
        {
            var data = DataAccessFactory.PharmacyOrderDetailsDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PharmacyOrderDetails, PharmacyOrderDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<PharmacyOrderDetailsDTO>(data);
        }
        public static PharmacyOrderDetailsDTO Add(PharmacyOrderDetailsDTO PharmacyOrderDetails)
        {
            PharmacyOrderDetailsDTO obj = new PharmacyOrderDetailsDTO() { Id = PharmacyOrderDetails.Id, MedicineName = PharmacyOrderDetails.MedicineName, Quantity = PharmacyOrderDetails.Quantity, TotalPrice = PharmacyOrderDetails.Quantity * PharmacyOrderDetails.TotalPrice, CustomerPharmacyId = PharmacyOrderDetails.CustomerPharmacyId, MedicineId = PharmacyOrderDetails.MedicineId };
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PharmacyOrderDetailsDTO, PharmacyOrderDetails>();
                c.CreateMap<PharmacyOrderDetails, PharmacyOrderDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            var cab = mapper.Map<PharmacyOrderDetails>(obj);
            var data = DataAccessFactory.PharmacyOrderDetailsDataAccess().Add(cab);

            if (data != null) 
            {
                MedicineService.DMedicine(data.MedicineId, data.Quantity);
                return mapper.Map<PharmacyOrderDetailsDTO>(data);
            }
            
            return null;
        }
        public static PharmacyOrderDetailsDTO Delete(int id)
        {
            var data = DataAccessFactory.PharmacyOrderDetailsDataAccess().Get(id);
            DataAccessFactory.PharmacyOrderDetailsDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PharmacyOrderDetails, PharmacyOrderDetailsDTO>());
            var mapper = new Mapper(config);
            var op = mapper.Map<PharmacyOrderDetailsDTO>(data);

            return op;

        }
        public static PharmacyOrderDetailsDTO Update(PharmacyOrderDetailsDTO dto)
        {
            var data = DataAccessFactory.PharmacyOrderDetailsDataAccess().Get(dto.Id);
            data.Id = dto.Id;
            DataAccessFactory.PharmacyOrderDetailsDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PharmacyOrderDetails, PharmacyOrderDetailsDTO>());
            var mapper = new Mapper(config);
            var PharmacyOrderDetails = mapper.Map<PharmacyOrderDetailsDTO>(data);

            return PharmacyOrderDetails;

        }

        public static List<PharmacyOrderDetailsDTO> OrderView(int id)
        {
            string s = id.ToString();
            var data = Get();
            var dt = (from d in data
                      where d.CustomerPharmacyId.ToString().StartsWith(s)
                      select d).ToList();
            return dt;
        }

        public static void Addd(PharmacyOrderDetailsDTO PharmacyOrderDetails)
        {
            PharmacyOrderDetailsDTO obj= new PharmacyOrderDetailsDTO() {Id= PharmacyOrderDetails.Id, Quantity= PharmacyOrderDetails.Quantity, TotalPrice= PharmacyOrderDetails.Quantity* PharmacyOrderDetails.TotalPrice,CustomerPharmacyId= PharmacyOrderDetails.CustomerPharmacyId ,MedicineId= PharmacyOrderDetails.MedicineId };
            PharmacyOrderDetailsService.Add(obj);

        }


    }
}
