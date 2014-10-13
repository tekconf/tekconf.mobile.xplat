using AutoMapper;
using System.Linq;

namespace TekConf.Mobile
{
	public class Bootstrapper
	{
		public void Automapper()
		{
			Mapper.CreateMap<Dtos.Conference, Models.Conference> ()
				.ForMember(dest => dest.Latitude, opt => opt.ResolveUsing<LatitudeResolver>())
				.ForMember(dest => dest.Longitude, opt => opt.ResolveUsing<LongitudeResolver>());
		}
	}

	public class LatitudeResolver : ValueResolver<Dtos.Conference, double?>
	{
		protected override double? ResolveCore(Dtos.Conference source)
		{
//			if (source == null || source.Position == null || !source.Position.Any ()) {
//				return 0;
//			}
//			return source.Position[0];

			return null;
		}
	}

	public class LongitudeResolver : ValueResolver<Dtos.Conference, double?>
	{
		protected override double? ResolveCore(Dtos.Conference source)
		{
//			if (source == null || source.Position == null || !source.Position.Any ()) {
//				return 0;
//			}
//			return source.Position[1];

			return null;
		}
	}
}