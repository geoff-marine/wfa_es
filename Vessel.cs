using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfa_es
{
    public class Vessel
    {
        public string cfr { get; set; }
        public string CountryCode { get; set; }
        public string VesselName { get; set; }
        public string ExactName { get; set; }
        public string PortCode { get; set; }
        public string PortName { get; set; }
        public string Loa { get; set; }
        public string Lbp { get; set; }
        public string TonRef { get; set; }
        public string PowerMain { get; set; }

        ESClient eSClient;
        public List<Vessel> GetAll()
        {
            var hits = eSClient.Current.Search<Vessel>(s => s.Query(q => q.MatchAll())).Hits;

            List<Vessel> typedList = hits.Select(hit => ConvertHitToVessel(hit)).ToList();

            return typedList;
        }

        private Vessel ConvertHitToVessel(IHit<Vessel> hit)
        {
            Func<IHit<Vessel>, Vessel> func = (XPackBuildInformation) =>
             {
                 
                 return hit.Source;
             };

            return func.Invoke(hit);
        }

    } 
}
