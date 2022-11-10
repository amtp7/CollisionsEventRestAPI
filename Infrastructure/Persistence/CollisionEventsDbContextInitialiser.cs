using CollisionsEventRestAPI.Application.Common.Interfaces;
using CollisionsEventRestAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CollisionsEventRestAPI.Infrastructure.Persistence
{
    public class CollisionEventsDbContextInitialiser
    {
        private readonly ILogger<CollisionEventsDbContextInitialiser> _logger;
        private readonly ICollisionEventIdentifier _identifier;
        private readonly IDateTimeGenerator _dateTimeGenerator;
        private readonly CollisionEventsDbContext _context;

        public CollisionEventsDbContextInitialiser(
            ILogger<CollisionEventsDbContextInitialiser> logger,
            ICollisionEventIdentifier identifier,
            IDateTimeGenerator dateTimeGenerator,
            CollisionEventsDbContext context)
        {
            _logger = logger;
            _identifier = identifier;
            _dateTimeGenerator = dateTimeGenerator;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            if (!_context.CollisionEvents.Any())
            {
                _context.CollisionEvents.AddRange(
                    new CollisionEvent
                    {
                        MessageId = _identifier.New,
                        CollisionEventId = _identifier.New,
                        SatelliteId = "1999-1232",
                        OperatorId = 12345,
                        ProbabilityOfCollision = 0.5,
                        CollisionDate = _dateTimeGenerator.InThirtyDays,
                        ChaserObjectId = "2016-4321",
                    },
                    new CollisionEvent
                    {
                        MessageId = _identifier.New,
                        CollisionEventId = _identifier.New,
                        SatelliteId = "1999-1232",
                        OperatorId = 12345,
                        ProbabilityOfCollision = 0.8,
                        CollisionDate = _dateTimeGenerator.InThirtyDays,
                        ChaserObjectId = "2014-6732"
                    },
                    new CollisionEvent
                    {
                        MessageId = _identifier.New,
                        CollisionEventId = _identifier.New,
                        SatelliteId = "2016-2547",
                        OperatorId = 54321,
                        ProbabilityOfCollision = 0.3,
                        CollisionDate = _dateTimeGenerator.InThirtyDays,
                        ChaserObjectId = "2018-4321"
                    },
                    new CollisionEvent
                    {
                        MessageId = _identifier.New,
                        CollisionEventId = _identifier.New,
                        SatelliteId = "2016-2547",
                        OperatorId = 54321,
                        ProbabilityOfCollision = 0.75,
                        CollisionDate = _dateTimeGenerator.InThirtyDays,
                        ChaserObjectId = "2020-7364"
                    },
                    new CollisionEvent
                    {
                        MessageId = _identifier.New,
                        CollisionEventId = _identifier.New,
                        SatelliteId = "2016-2547",
                        OperatorId = 54321,
                        ProbabilityOfCollision = 0.74,
                        CollisionDate = _dateTimeGenerator.InThirtyDays,
                        ChaserObjectId = "2020-7347"
                    },
                    new CollisionEvent
                    {
                        MessageId = _identifier.New,
                        CollisionEventId = _identifier.New,
                        SatelliteId = "2018-3478",
                        OperatorId = 98765,
                        ProbabilityOfCollision = 0.9,
                        CollisionDate = _dateTimeGenerator.InThirtyDays,
                        ChaserObjectId = "2016-2547"
                    });
                await _context.SaveChangesAsync();
            }
        }
    }
}
