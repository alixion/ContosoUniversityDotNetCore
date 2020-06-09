using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ContosoUniversity.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Features.Departments
{
    public class Details
    {
        public class Query : IRequest<Model>
        {
            public int Id { get; set; }
        }

        public class Model
        {
            public string Name { get; set; }

            public decimal Budget { get; set; }

            public DateTime StartDate { get; set; }

            public int Id { get; set; }

            [Display(Name = "Administrator")]
            public string AdministratorFullName { get; set; }

        }

        public class QueryHandler : IRequestHandler<Query, Model>
        {
            private readonly SchoolContext _db;
            private readonly IConfigurationProvider _configuration;

            public QueryHandler(SchoolContext db, IConfigurationProvider configuration)
            {
                _db = db;
                _configuration = configuration;
            }

            public Task<Model> Handle(Query message, CancellationToken token) => 
                _db.Departments
                .FromSqlRaw(@"SELECT * FROM Department WHERE DepartmentID = {0}", message.Id)
                .ProjectTo<Model>(_configuration)
                .SingleOrDefaultAsync(token);
        }
    }
}