using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Windows.Controls;
using System.Windows.Documents;
using Newtonsoft.Json.Linq;
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
        /// </summary>
        /// <param name="url"></param>
        /// <param name="endPoint"></param>
        /// <param name="appToken"></param>
        public QueryManager(string url, string endPoint, string appToken) {
            //TODO: Must investigate to see if can use default app-token unless new one indicated.
            _client = new SodaClient(url, appToken);
            _metaData = _client.GetMetadata(endPoint);
            _dataset = _client.GetResource<Violation>(endPoint);
            
        }

        /// <summary>
        /// Testing method designed to retrieve first 500 rows of dataset.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Violation> GetAllRows() {
            return _dataset.GetRows(500).Cast<Violation>();
            
        }

        public ResourceMetadata GetMetaData() {
            return _metaData;
        }

        public IEnumerable<Violation> SearchViolationNumbers(string[] violationNumbers) {
            var result = new List<Violation>();
            foreach (var entry in violationNumbers) {
                var soql = new SoqlQuery().Select().Where(string.Format(@"ticket_number='{0}'", entry));
                result.Add((_dataset.Query<Violation>(soql).First()));
            }

            return result;
        }
    }
}