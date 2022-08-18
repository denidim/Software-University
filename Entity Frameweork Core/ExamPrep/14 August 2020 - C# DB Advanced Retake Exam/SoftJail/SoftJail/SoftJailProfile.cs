namespace SoftJail
{
    using AutoMapper;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ExportDto;
    using System.Linq;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            this.CreateMap<Prisoner, PrisonerViewModel>()
                .ForMember(x => x.IncarcerationDate,
                    y => y.MapFrom(s => s.IncarcerationDate.ToString("yyyy-MM-dd")))
                .ForMember(x => x.Name, y => y.MapFrom(s => s.FullName))
                .ForMember(x => x.EncryptedMessages, y => y.MapFrom(s => s.Mails));

            this.CreateMap<Mail, EncryptedMessageViewModel>()
                .ForMember(x => x.Description,
                    y => y.MapFrom(s => string.Join("", s.Description.Reverse())));
        }
    }
}
