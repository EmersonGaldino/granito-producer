using AutoMapper;
using granito.api.Models.ModelView.Fees;
using granito.domain.Entity.Fees;


public class MappingProfilesModelView : Profile
{
    public MappingProfilesModelView()
    {

        CreateMap<FeesSchema, FeesModelView>().ReverseMap();
        CreateMap<FeesModelView,FeesSchema>().ReverseMap();
    }
}