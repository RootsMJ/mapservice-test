using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace WebApplication1.Contracts
{
    public class MapService
    {
        // Constants
        private const string _serviceRequestUri = "https://sampleserver1.arcgisonline.com/ArcGIS/rest/services/Demographics/ESRI_Census_USA/MapServer/";
        private const string _jsonFormatQuery = "f=json";
        
        // Service Representation
        public double CurrentVersion { get; set; }
        public string ServiceDescription { get; set; }
        public string MapName { get; set; }
        public string Description { get; set; }
        public string CopyrightText { get; set; }
        public IEnumerable<LayerWithService> Layers { get; set; }
        public IEnumerable<object> Tables { get; set; }
        public SpatialReference SpatialReference { get; set; }
        public bool SingleFusedMapCache { get; set; }
        public Extent InitialExtent { get; set; }
        public Extent FullExtent { get; set; }
        public string Units { get; set; }
        public string SupportedImageFormatTypes { get; set; }
        public DocumentInfo DocumentInfo { get; set; }
        public string Capabilities { get; set; }

        /// <summary>
        /// Creates an instance of MapService and gets service information
        /// </summary>
        /// <returns>Instance of map service</returns>
        public static MapService GetInstance()
        {
            var httpClient = new HttpClient();
            string response;

            try
            {
                response = httpClient.GetStringAsync($"{_serviceRequestUri}?{_jsonFormatQuery}").Result;
            }
            catch (AggregateException exc)
            {
                response = null;
            }

            httpClient.Dispose();

            if (response == null) return null;

            return JsonConvert.DeserializeObject<MapService>(response);
            
        }

        /// <summary>
        /// Get all Layers from this map service
        /// </summary>
        /// <returns>All Layers</returns>
        public IEnumerable<Layer> GetLayers()
        {
            return GetLayersById();
        }

        /// <summary>
        /// Get all Layers from the map service that support the operation "Query"
        /// </summary>
        /// <returns>All queriable Layers</returns>
        public IEnumerable<Layer> GetQueriableLayers()
        {
            var layers = GetLayersById();
            
            return layers.Where(layer => layer.Capabilities.Contains("Query"));
        }

        /// <summary>
        /// Get the Url for the exported map image
        /// </summary>
        /// <param name="bbox"></param>
        /// <returns>Exported image Url</returns>
        public string GetMapImageUrl(BoundingBox bbox)
        {
            var exportInfo = GetExportImageInformation(bbox);

            if (exportInfo == null) return null;

            return exportInfo.Href;
        }

        /// <summary>
        /// Get specific Layer by Id
        /// </summary>
        /// <param name="layerId"></param>
        /// <returns>A Layer</returns>
        private Layer GetLayerById(int layerId)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync($"{_serviceRequestUri}{layerId}?{_jsonFormatQuery}").Result;

                if (response == null) return null;

                return JsonConvert.DeserializeObject<Layer>(response);
            }
        }

        /// <summary>
        /// Get multiple layers by id using the same HttpClient
        /// </summary>
        /// <returns>List of layers</returns>
        private IEnumerable<Layer> GetLayersById()
        {
            var layerIds = Layers.Select(layer => layer.Id);
            var results = new List<Layer>();

            using (var httpClient = new HttpClient())
            {
                foreach (var id in layerIds)
                {
                    var response = httpClient.GetStringAsync($"{_serviceRequestUri}{id}?{_jsonFormatQuery}").Result;

                    if (response == null) continue;

                    results.Add(JsonConvert.DeserializeObject<Layer>(response));
                }

                return results;
            }
        }

        /// <summary>
        /// Returns image url and export information
        /// </summary>
        /// <param name="bbox"></param>
        /// <returns>Exported image information</returns>
        private ExportImageInfo GetExportImageInformation(BoundingBox bbox)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync($"{_serviceRequestUri}/export?bbox={bbox.XMin},{bbox.YMin},{bbox.XMax},{bbox.YMax}&{_jsonFormatQuery}").Result;

                if (response == null) return null;

                var exportInfo = JsonConvert.DeserializeObject<ExportImageInfo>(response);

                return exportInfo;
            }
            
        }
    }
}