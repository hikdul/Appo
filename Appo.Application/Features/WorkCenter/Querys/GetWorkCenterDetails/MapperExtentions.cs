

namespace Appo.Application.Features.WorkCenter.Querys.GetWorkCenterDetails
{
	static class MapperExtentions
	{

		public static WorkCenterDetails Dto(this Core.Entities.WorkCenter ent)
		{
			return new() 
			{
				Id = ent.Id,
				Name = ent.Name,
				Direction = ent.Direction != null 
					? ent.Direction?.Value : "",
				Latitud =ent.Direction != null 
					? ent.Direction.Latitud : 0,
				Longitud =ent.Direction != null 
					? ent.Direction.Longitud : 0
			};
		}


	}
}
