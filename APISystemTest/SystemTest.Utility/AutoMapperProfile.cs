using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SystemTest.DTO;
using SystemTest.Model;

namespace SystemTest.Utility
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente,ClienteDTO>().ReverseMap();

            CreateMap<Servicio, ServicioDTO>().ReverseMap();
        }
    }
}
