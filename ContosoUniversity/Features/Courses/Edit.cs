﻿using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Features.Courses
{
    public class Edit
    {
        public class Query : IRequest<Command>
        {
            public int? Id { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(m => m.Id).NotNull();
            }
        }

        public class QueryHandler : IRequestHandler<Query, Command>
        {
            private readonly SchoolContext _db;
            private readonly IConfigurationProvider _configuration;

            public QueryHandler(SchoolContext db, IConfigurationProvider configuration) {
                _db = db;
                _configuration = configuration;

            }

            public Task<Command> Handle(Query message, CancellationToken token) =>
                _db.Courses
                    .Where(c => c.Id == message.Id)
                    .ProjectTo<Command>(_configuration)
                    .SingleOrDefaultAsync(token);
        }

        public class Command : IRequest
        {
            [Display(Name = "Number")]
            public int Id { get; set; }
            public string Title { get; set; }
            public int? Credits { get; set; }
            public Department Department { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(m => m.Title).NotNull().Length(3, 50);
                RuleFor(m => m.Credits).NotNull().InclusiveBetween(0, 5);
            }
        }

        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly SchoolContext _db;
            private readonly IMapper _mapper;

            public CommandHandler(SchoolContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command message, CancellationToken token)
            {
                var course = await _db.Courses.FindAsync(new object[] { message.Id }, token);

                _mapper.Map(message, course);

                return default;
            }
        }
    }
}