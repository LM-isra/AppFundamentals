using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AppFundamentals.Contexts;
using AppFundamentals.Entities;

namespace AppFundamentals.Services
{
    public class ConsumeScopedService : IHostedService, IDisposable
    {
        public IServiceProvider Service { get; }
        private Timer _timer;

        public ConsumeScopedService(IServiceProvider service) => Service = service;


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(20));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            using var scope = Service.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var message = $"ConsumeScopedService: {DateTime.Now:dd/mm/aaaa hh:mm:ss}";
            var log = new HostedServiceLog { Message = message };

            context.HostedServiceLogs.Add(log);
            await context.SaveChangesAsync();
        }

        public void Dispose() => _timer?.DisposeAsync();
    }
}