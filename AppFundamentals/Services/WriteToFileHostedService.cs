using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace AppFundamentals.Services
{
    public class WriteToFileHostedService : IHostedService, IDisposable
    {
        private readonly IHostEnvironment _environment;
        private readonly string _fileName = "File 1.txt";
        private Timer _timer;

        public WriteToFileHostedService(IHostEnvironment environment) => _environment = environment;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            WriteToFile($"Start: {DateTime.Now:dd/mm:aaaa hh:mm:ss}");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile($"Stop: {DateTime.Now:dd/mm:aaaa hh:mm:ss}");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void DoWork(object state)
            => WriteToFile($"Doing some Work at {DateTime.Now:dd/mm/aaaa hh:mm:ss}");

        public async void WriteToFile(string message)
        {
            var path = $"{_environment.ContentRootPath}/wwwroot/{_fileName}";
            
            using var write = new StreamWriter(path, append: true);
            await write.WriteLineAsync(message);
        }

        public void Dispose() => _timer?.Dispose();
    }
}