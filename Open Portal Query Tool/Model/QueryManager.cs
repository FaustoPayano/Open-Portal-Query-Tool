using System.Security.Policy;
using System.Windows.Controls;
using SODA;

namespace Open_Portal_Query_Tool.Model {
    public class QueryManager {
        private string _apiEndpoint;
        private string _apiUrl;
        private SodaClient _client;
        private ResourceMetadata _metaData;
        private Resource<Violation> _dataset;


        /// <summary>
        /// Create instance of QueryManager and establish connection to Dataset.
        /// Todo:Implemement appToken control for dynamic Application Token Entry.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="endPoint"></param>
        /// <param name="appToken"></param>
        public QueryManager(string url, string endPoint, string appToken) {
            //TODO: Must investigate to see if can use default app-token unless new one indicated.
            _client = new SodaClient(url, string.Empty);
            _metaData = _client.GetMetadata(endPoint);
            _dataset = _client.GetResource<Violation>(endPoint);

        }

        public ResourceMetadata GetMetaData() {
            return _metaData;
        }
    }
}