using AutoMapper;
using EvaluacionAdvanced.Data.Context;
using EvaluacionAdvanced.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionAdvanced.Mappers
{
    public class DTOToModel : Profile
    {
        public DTOToModel()
        {
            CreateMap<DTO_User, User>();
        }
                
    }
}
