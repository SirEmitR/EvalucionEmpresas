using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EvaluacionEmpresa.Services
{
    public class WriteToFileHostedService : IHostedService
    {
        private readonly IHostingEnvironment environment;
        private readonly string filename = "File.txt";
        public WriteToFileHostedService(IHostingEnvironment environment)
        {
            this.environment = environment;
        }
        //Al iniciar la aplicación
        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //Al finalizar la aplicación
        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        private void WriteFile(string message)
        {

        }
    }
}
