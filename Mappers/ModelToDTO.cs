using AutoMapper;
using EvaluacionAdvanced.Data.Context;
using EvaluacionAdvanced.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionAdvanced.Mappers
{
    public class ModelToDTO : Profile
    {
        public ModelToDTO()
        {
            CreateMap<User, DTO_User>();
        }
    }
}
