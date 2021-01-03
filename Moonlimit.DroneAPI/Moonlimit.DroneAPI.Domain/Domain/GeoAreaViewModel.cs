namespace Moonlimit.DroneAPI.Domain
{
	using Moonlimit.DroneAPI.Entity;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;

	public class GeoAreaViewModel : BaseDomain
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public virtual AreaKind Kind { get; set; }
		public virtual System.Collections.Generic.ICollection<GeoPointViewModel> Points { get; set; }
	}
}
