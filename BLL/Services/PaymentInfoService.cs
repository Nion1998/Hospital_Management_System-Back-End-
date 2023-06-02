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
    public class PaymentInfoService
    {
        public static List<PaymentInfoDTO> Get()
        {
            var data = DataAccessFactory.PaymentInfoDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PaymentInfo, PaymentInfoDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<PaymentInfoDTO>>(data);
        }
        public static PaymentInfoDTO Get(int id)
        {
            var data = DataAccessFactory.PaymentInfoDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PaymentInfo, PaymentInfoDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<PaymentInfoDTO>(data);
        }
        public static PaymentInfoDTO Add(PaymentInfoDTO paymentInfo)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentInfoDTO, PaymentInfo>();
                c.CreateMap<PaymentInfo, PaymentInfoDTO>();

            });
            var mapper = new Mapper(cfg);
            var pay = mapper.Map<PaymentInfo>(paymentInfo);
            var data = DataAccessFactory.PaymentInfoDataAccess().Add(pay);

            if (data != null) return mapper.Map<PaymentInfoDTO>(data);
            return null;
        }
        public static PaymentInfoDTO Delete(int id)
        {
            var data = DataAccessFactory.PaymentInfoDataAccess().Get(id);
            DataAccessFactory.PaymentInfoDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentInfo, PaymentInfoDTO>());
            var mapper = new Mapper(config);
            var Medi = mapper.Map<PaymentInfoDTO>(data);

            return Medi;

        }
        public static PaymentInfoDTO Update(PaymentInfoDTO dto)
        {
            var data = DataAccessFactory.PaymentInfoDataAccess().Get(dto.Id);
            data.PaymentType = dto.PaymentType;
            DataAccessFactory.PaymentInfoDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentInfo, PaymentInfoDTO>());
            var mapper = new Mapper(config);
            var PaymentInfo = mapper.Map<PaymentInfoDTO>(data);

            return PaymentInfo;

        }
    }
}
