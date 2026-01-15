using Microsoft.EntityFrameworkCore;
using OrdersService.Api.Infrastructure.Data;
using OrdersService.Api.Infrastructure.Messaging;

namespace OrdersService.Api.Infrastructure.Background
{
    public class OutboxPublisher : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public OutboxPublisher(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<OrdersDbContext>();
                var publisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();

                var messages = await db.OutboxMessages
                    .Where(x => x.ProcessedOnUtc == null)
                    .OrderBy(x => x.OccurredOnUtc)
                    .Take(10)
                    .ToListAsync(cancellationToken);

                foreach (var message in messages)
                {
                    await publisher.PublishAsync(message.Type, message.Content);
                    message.ProcessedOnUtc = DateTime.UtcNow;
                }

                await db.SaveChangesAsync(cancellationToken);
                await Task.Delay(2000, cancellationToken);
            }
        }
    }
}
