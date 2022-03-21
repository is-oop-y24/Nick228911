using AutoMapper;
using ReportsBLL.Models.Problems;

namespace ReportsBLL.Tools.Mapping
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}