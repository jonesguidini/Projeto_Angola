using AutoMapper;
using Clinica.Dominio.Entidades.Dto;

namespace Clinica.Dominio.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Mapeia todas as VMs para Model (entity) e vice versa através do usod do ReverseMap
            Mapper.Initialize(cfg => {

                cfg.CreateMap<ClinicaDto, Entidades.Clinica>()
                .ReverseMap();

                cfg.CreateMap<ClienteDto, Entidades.Cliente>()
                .ReverseMap();

                cfg.CreateMap<MassagemDto, Entidades.Massagem>()
                .ReverseMap();

            });
        }
    }
}
