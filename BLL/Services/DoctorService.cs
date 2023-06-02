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
    public class DoctorService
    {
        public static List<DoctorDTO> Get()
        {
            var data = DataAccessFactory.DoctorDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Doctor, DoctorDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<DoctorDTO>>(data);
        }
        public static DoctorDTO Get(int id)
        {
            var data = DataAccessFactory.DoctorDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Doctor, DoctorDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<DoctorDTO>(data);
        }
        public static DoctorDTO Add(DoctorDTO doctor)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DoctorDTO, Doctor>();
                c.CreateMap<Doctor, DoctorDTO>();

            });
            var mapper = new Mapper(cfg);
            var doc = mapper.Map<Doctor>(doctor);
            var data = DataAccessFactory.DoctorDataAccess().Add(doc);

            if (data != null) return mapper.Map<DoctorDTO>(data);
            return null;
        }
        public static DoctorDTO Delete(int id)
        {
            var data = DataAccessFactory.DoctorDataAccess().Get(id);
            DataAccessFactory.DoctorDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            var Medi = mapper.Map<DoctorDTO>(data);

            return Medi;

        }
        public static DoctorDTO Update(DoctorDTO dto)
        {
            var data = DataAccessFactory.DoctorDataAccess().Get(dto.Id);
            data.Name = dto.Name;
            data.Address = dto.Address;
            data.Gender = dto.Gender;
            data.Phone = dto.Phone;
            data.Qualification = dto.Qualification;
            data.Specialization = dto.Specialization;
            DataAccessFactory.DoctorDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            var Doctor = mapper.Map<DoctorDTO>(data);

            return Doctor;

        }
    }
}
