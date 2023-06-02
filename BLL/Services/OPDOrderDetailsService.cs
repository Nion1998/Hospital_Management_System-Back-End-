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
    public class OPDOrderDetailsService
    {
        public static List<OPDOrderDetailsDTO> Get()
        {
            var data = DataAccessFactory.OPDOrderDetailsDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OPDOrderDetails, OPDOrderDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<OPDOrderDetailsDTO>>(data);
        }
        public static OPDOrderDetailsDTO Get(int id)
        {
            var data = DataAccessFactory.OPDOrderDetailsDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OPDOrderDetails, OPDOrderDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<OPDOrderDetailsDTO>(data);
        }
        public static OPDOrderDetailsDTO Add(OPDOrderDetailsDTO OPDOrderDetails)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OPDOrderDetailsDTO, OPDOrderDetails>();
                c.CreateMap<OPDOrderDetails, OPDOrderDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            var cab = mapper.Map<OPDOrderDetails>(OPDOrderDetails);
            var data = DataAccessFactory.OPDOrderDetailsDataAccess().Add(cab);

            if (data != null) return mapper.Map<OPDOrderDetailsDTO>(data);
            return null;
        }
        public static OPDOrderDetailsDTO Delete(int id)
        {
            var data = DataAccessFactory.OPDOrderDetailsDataAccess().Get(id);
            DataAccessFactory.OPDOrderDetailsDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OPDOrderDetails, OPDOrderDetailsDTO>());
            var mapper = new Mapper(config);
            var op = mapper.Map<OPDOrderDetailsDTO>(data);

            return op;

        }
        public static OPDOrderDetailsDTO Update(OPDOrderDetailsDTO dto)
        {
            var data = DataAccessFactory.OPDOrderDetailsDataAccess().Get(dto.Id);
            data.Id = dto.Id;
            DataAccessFactory.OPDOrderDetailsDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OPDOrderDetails, OPDOrderDetailsDTO>());
            var mapper = new Mapper(config);
            var OPDOrderDetails = mapper.Map<OPDOrderDetailsDTO>(data);

            return OPDOrderDetails;

        }

        public static List<OPDOrderDetailsDTO> OrderView(int id)
        {
            string s = id.ToString();
            var data = Get();
            var dt = (from d in data
                      where d.CustomerOPDId.ToString().StartsWith(s)
                      select d).ToList();
            return dt;
        }
    }
}
