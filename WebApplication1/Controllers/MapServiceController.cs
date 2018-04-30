using System;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Contracts;

namespace WebApplication1.Controllers
{
	// TODO: solve as many of the unimplemented tasks below as you can
	// All tasks should be implemented using the same service specified below
	// service url: https://sampleserver1.arcgisonline.com/ArcGIS/rest/services/Demographics/ESRI_Census_USA/MapServer/
	// service api help page: http://sampleserver1.arcgisonline.com/ArcGIS/SDK/REST/index.html?mapserver.html
	/// <summary>
	/// Controller for getting information about map services
	/// </summary>
	[RoutePrefix("api/mapservice")]
	public class MapServiceController : ApiController
	{
        private readonly MapService _mapService;

        public MapServiceController()
        {
            _mapService = MapService.GetInstance();
        }

		// TODO: Implement endpoint that returns a class representation of the service(hint: convert json to C# contract class)
		/// <summary>
		/// Get a map service
		/// </summary>
		/// <returns>MapService</returns>
		[HttpGet]
		[Route("GetService")]
		public async Task<IHttpActionResult> GetService()
		{
            if (_mapService == null) return InternalServerError();

            return Ok(_mapService);
		}

		// TODO: implement endpoint that returns a list of layers from a given service (use the service provided above)
		// api help page: http://sampleserver1.arcgisonline.com/ArcGIS/SDK/REST/index.html?layer.html
		/// <summary>
		/// Get all layers from a map service
		/// </summary>
		/// <returns>A list of layers</returns>
		[HttpGet]
		[Route("GetLayers")]
		public IHttpActionResult GetLayers()
		{
            try
            {
                var layers = _mapService.GetLayers();
                return Ok(layers);
            }
            catch (NullReferenceException exc)
            {
                // TODO: Log Exception

                return InternalServerError();
            }
		}

		// TODO: implement endpoint that returns a list of layers that supports the "Query" Operation (use the service provided above)
		// api help page: http://sampleserver1.arcgisonline.com/ArcGIS/SDK/REST/index.html?layer.html
		/// <summary>
		/// Gets all layers that support the "query" operation
		/// </summary>
		/// <returns>A list of layers</returns>
		[HttpGet]
		[Route("GetQueriableLayers")]
		public IHttpActionResult GetQueriableLayers()
		{
            try
            {
                var layers = _mapService.GetQueriableLayers();
                return Ok(layers);

            }
            catch (NullReferenceException exc)
            {
                // TODO: Log Exception

                return InternalServerError();
            }
        }

		// TODO: implement a endpoint that returns the image url of the map for a given bounding box
		// api help page: http://sampleserver1.arcgisonline.com/ArcGIS/SDK/REST/index.html?export.html
		// test values: -207.682974279982,-40.6075371681153,-37.1804225764967,129.89501453537
		/// <summary>
		/// Gets the url of a generated image given a specific bounding box
		/// </summary>
		/// <param name="bbox"></param>
		/// <returns>A image url</returns>
		[HttpGet]
		[Route("GetMapImage")]
		public IHttpActionResult GetMapImage([FromUri]BoundingBox bbox)
		{
            if(bbox == null)
            {
                return BadRequest();
            }

            try
            {
                var mapUrl = _mapService.GetMapImageUrl(bbox);

                if (mapUrl == null) return InternalServerError();

                return Ok(mapUrl);
            }
            catch (NullReferenceException exc)
            {
                // TODO: Log Exception

                return InternalServerError();
            }
            
        }
	}
}
