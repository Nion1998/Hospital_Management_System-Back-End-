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
    public class PatientIPDService
    {
        public static List<PatientIPDDTO> Get()
        {
            var data = DataAccessFactory.PatientIPDDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PatientIPD, PatientIPDDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<PatientIPDDTO>>(data);
        }
        public static PatientIPDDTO Get(int id)
        {
            var data = DataAccessFactory.PatientIPDDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PatientIPD, PatientIPDDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<PatientIPDDTO>(data);
        }
        public static PatientIPDDTO Add(PatientIPDDTO patient)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PatientIPDDTO, PatientIPD>();
                c.CreateMap<PatientIPD, PatientIPDDTO>();

            });
            var mapper = new Mapper(cfg);
            var pat = mapper.Map<PatientIPD>(patient);
            var data = DataAccessFactory.PatientIPDDataAccess().Add(pat);

            if (data != null) return mapper.Map<PatientIPDDTO>(data);
            return null;
        }
        public static PatientIPDDTO Delete(int id)
        {
            var data = DataAccessFactory.PatientIPDDataAccess().Get(id);
            DataAccessFactory.PatientIPDDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PatientIPD, PatientIPDDTO>());
            var mapper = new Mapper(config);
            var Medi = mapper.Map<PatientIPDDTO>(data);

            return Medi;

        }
        public static PatientIPDDTO Update(PatientIPDDTO dto)
        {
            var data = DataAccessFactory.PatientIPDDataAccess().Get(dto.Id);
            data.Name = dto.Name;
            data.FatherName = dto.FatherName;
            data.MotherName = dto.MotherName;
            data.Address = dto.Address;
            data.Gender = dto.Gender;
            data.Age = dto.Age;
            data.Phone  = dto.Phone;
            data.Occupation = dto.Occupation;
            data.Nid = dto.Nid;
            data.AdmissionDate = dto.AdmissionDate;
            data.RoomDetails = dto.RoomDetails;
            data.RefdBy = dto.RefdBy;
            data.DutyDoctor = dto.DutyDoctor;
            data.PaidAmount = dto.PaidAmount;
            DataAccessFactory.PatientIPDDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PatientIPD, PatientIPDDTO>());
            var mapper = new Mapper(config);
            var PatientIPD = mapper.Map<PatientIPDDTO>(data);

            return PatientIPD;

        }
    }
}
