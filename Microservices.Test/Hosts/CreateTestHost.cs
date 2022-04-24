using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Test.Hosts
{
    public class CreateTestHost<T> : WebApplicationFactory<T> where T : class
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            return base.CreateHost(builder);
        }
    }
    public class CreateTestClient<T> where T : class
    {
        private CreateTestHost<T> Host;
      

        public HttpClient   Client
        {
            get { return Host.CreateClient(); }
          
        }

        public CreateTestClient()
        {
            Host = new CreateTestHost<T>();
        }
    }
}
