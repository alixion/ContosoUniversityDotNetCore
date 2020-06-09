using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ContosoUniversity.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Features.Students
{
    public class Delete
    {
        public class Query : IRequest<Command>
        {
            public int Id { get; set; }
        }

        public class Command : IRequest
        {
            public int ID { get; set; }
            [Display(Name = "First Name")]
            public string FirstMidName { get; set; }
            public string LastName { get; set; }
            public DateTime EnrollmentDate { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Command>
        {
            private readonly SchoolContext _db;
            private readonly IConfigurationProvider _configuration;

            public QueryHandler(SchoolContext db, IConfigurationProvider configuration)
            {
                _db = db;
                _configuration = configuration;
            }

            public async Task<Command> Handle(Query message, CancellationToken token) => await _db
                .Students
                .Where(s => s.Id == message.Id)
                .ProjectTo<Command>(_configuration)
                .SingleOrDefaultAsync();
        }

        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly SchoolContext _db;

            public CommandHandler(SchoolContext db) => _db = db;

            public async Task<Unit> Handle(Command message, CancellationToken token)
            {
                _db.Students.Remove(await _db.Students.FindAsync(message.ID));
                return default;
            }
        }

    }
}