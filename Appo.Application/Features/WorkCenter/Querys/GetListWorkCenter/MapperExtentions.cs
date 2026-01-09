
namespace Appo.Application.Features.WorkCenter.Querys.GetListWorkCenter
{
    public static  class MapperExtentions
    {
		public static WorkCenter_out Dto(this Core.Entities.WorkCenter workCenter)
		{
			return new WorkCenter_out() {
				Id = workCenter.Id,
				Name = workCenter.Name,
				Direction = workCenter.Direction != null ? workCenter.Direction.Value : "",
			};
		}
    }
}
