namespace Appo.Identity.Helpers
{
	///<summary>
	/// Lista de permisos que tiene cada usuario en los casos de participar como partner.
	/// Recordar que estos cambios solo aplican para partner ya que cuando se actual como cliente(Customer) simplemente el sistema interactuar diferente.
	///</summary>

	public enum Alloweds
	{
		belong = 0,

		// Solo el jefaso trabaja aca
		Company_power = 5,

		// Appoiment segment
		Appoiment_Created = 10,
		Appoiment_Details = 11,
		Appoimment_Cancel = 16,
		Appoiment_complete = 17,

		// Customer Segment
		Customer_created = 30,
		Customer_Details = 31,
		Customer_List = 32,
		Customer_Edit = 35,
		Customer_Delete = 39,


		// Partnet Segment
		Partnet_created = 30,
		Partnet_Details = 31,
		Partnet_List = 32,
		Partnet_Edit = 35,
		Partnet_Delete = 39,


		// Work Center Segment
		workcenter_created = 40,
		workcenter_Details = 41,
		workcenter_List = 42,
		workcenter_Edit = 45,
		workcenter_Delete = 49,



	}
}
