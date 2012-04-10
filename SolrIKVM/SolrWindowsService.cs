using System.Configuration;
using System.ServiceProcess;
using org.apache.solr.client.solrj.embedded;
using System;

namespace SolrIKVM {
    public class SolrWindowsService : ServiceBase {
        private JettySolrRunner jetty;

        public static readonly string Name = "SolrIKVM";

        public SolrWindowsService() {
            var home = ConfigurationManager.AppSettings["solr.home"];
            Setup.SetHome(home);
            jetty = new JettySolrRunner("/solr", Setup.Port());
            ServiceName = Name;
        }

        public void Start() {
            OnStart(null);
        }

        protected override void OnStart(string[] args) {

            
            //var home = ConfigurationManager.AppSettings["solr.home"];
            //Setup.SetHome(home);
            //jetty = new JettySolrRunner("/solr", Setup.Port());
            var startJetty = new Action(StartJetty);
            startJetty.BeginInvoke(null, null);
            //jetty.waitForSolr("foo");
        }

        public void StartJetty()
        {
            jetty.start();
        }

        protected override void OnStop() {
            jetty.stop();

        }

        protected override void Dispose(bool disposing) {
            OnStop();
            base.Dispose(disposing);
        }
    }
}