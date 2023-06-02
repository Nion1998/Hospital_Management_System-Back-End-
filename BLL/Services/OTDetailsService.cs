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
    public class OTDetailsService
    {
        public static List<OTDetailsDTO> Get()
        {
            var data = DataAccessFactory.OTDetailsDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OTDetails, OTDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<OTDetailsDTO>>(data);
        }
        public static OTDetailsDTO Get(int id)
        {
            var data = DataAccessFactory.OTDetailsDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OTDetails, OTDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<OTDetailsDTO>(data);
        }
        public static OTDetailsDTO Add(OTDetailsDTO oTDetails)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OTDetailsDTO, OTDetails>();
                c.CreateMap<OTDetails, OTDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            var ot = mapper.Map<OTDetails>(oTDetails);
            var data = DataAccessFactory.OTDetailsDataAccess().Add(ot);

            if (data != null) return mapper.Map<OTDetailsDTO>(data);
            return null;
        }
        public static OTDetailsDTO Delete(int id)
        {
            var data = DataAccessFactory.OTDetailsDataAccess().Get(id);
            DataAccessFactory.OTDetailsDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OTDetails, OTDetailsDTO>());
            var mapper = new Mapper(config);
            var Medi = mapper.Map<OTDetailsDTO>(data);

            return Medi;

        }
        public static OTDetailsDTO Update(OTDetailsDTO dto)
        {
            var data = DataAccessFactory.OTDetailsDataAccess().Get(dto.Id);
            data.Name = dto.Name;
            data.PatientId = dto.PatientId;
            data.Details = dto.Details;
            data.Surgeon = dto.Surgeon;
            data.Anesthetist = dto.Anesthetist;
            data.OTDate = dto.OTDate;
            DataAccessFactory.OTDetailsDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OTDetails, OTDetailsDTO>());
            var mapper = new Mapper(config);
            var OTDetails = mapper.Map<OTDetailsDTO>(data);

            return OTDetails;

        }
    }
}
