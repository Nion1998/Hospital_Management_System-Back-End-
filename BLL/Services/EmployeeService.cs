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
    public class EmployeeService
    {
        public static List<EmployeeDTO> Get()
        {
            var data = DataAccessFactory.EmployeeDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Employee, EmployeeDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<EmployeeDTO>>(data);
        }
        public static EmployeeDTO Get(int id)
        {
            var data = DataAccessFactory.EmployeeDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Employee, EmployeeDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<EmployeeDTO>(data);
        }
        public static EmployeeDTO Add(EmployeeDTO employee)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeDTO, Employee>();
                c.CreateMap<Employee, EmployeeDTO>();

            });
            var mapper = new Mapper(cfg);
            var emp = mapper.Map<Employee>(employee);
            var data = DataAccessFactory.EmployeeDataAccess().Add(emp);

            if (data != null) return mapper.Map<EmployeeDTO>(data);
            return null;
        }
        public static EmployeeDTO Delete(int id)
        {
            var data = DataAccessFactory.EmployeeDataAccess().Get(id);
            DataAccessFactory.EmployeeDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            var mapper = new Mapper(config);
            var Medi = mapper.Map<EmployeeDTO>(data);

            return Medi;

        }
        public static EmployeeDTO Update(EmployeeDTO dto)
        {
            var data = DataAccessFactory.EmployeeDataAccess().Get(dto.Id);
            data.Name = dto.Name;
            data.Address = dto.Address;
            data.Gender = dto.Gender;
            data.Phone = dto.Phone;
            data.Role = dto.Role;
            data.Username = dto.Username;
            data.Password = dto.Password;
            DataAccessFactory.EmployeeDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            var mapper = new Mapper(config);
            var Employee = mapper.Map<EmployeeDTO>(data);

            return Employee;

        }

        public static List<EmployeeDTO> Msearch(string Username)
        {
            var data = Get();
            var dt = (from d in data
                      where d.Username.ToLower().StartsWith(Username)
                      select d).ToList();
            return dt;
        }
    }
}
