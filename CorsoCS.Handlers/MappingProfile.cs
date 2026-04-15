namespace CorsoCS.Handlers;

public class MappingProfile : MapZilla.Profile
{

  public MappingProfile()
  {
    CreateMap<Model.Note, Core.DTO.Note>().ReverseMap();
    CreateMap<Core.Commands.CreateNote, Model.Note>();


  }
  
}