namespace WebApplication1.Contracts
{
	/// <summary>
	/// The extent (bounding box) of the exported image. 
	/// Unless the bboxSR parameter has been specified, 
	/// the bbox is assumed to be in the spatial reference of the map.
	/// </summary>
	public class BoundingBox
	{
		public double XMin { get; set; }
		public double YMin { get; set; }
		public double XMax { get; set; }
		public double YMax { get; set; }
	}
}