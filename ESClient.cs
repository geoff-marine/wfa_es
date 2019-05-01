using System;
using Nest;

namespace wfa_es
{
    public class ESClient
    {
        private const string ES_URI = "http://10.11.1.70:9200";

        private ConnectionSettings _settings;

        public ElasticClient Current { get; set; }

        public ESClient()
        {
            var node = new Uri(ES_URI);

            _settings = new ConnectionSettings(node);
            _settings.DefaultIndex("/vesselname/allnames/");

            var client = new ElasticClient(_settings);
        }

    }
}
