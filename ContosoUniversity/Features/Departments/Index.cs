using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Features.Departments
{
    public class Index
    {
        public class Query : IRequest<List<Model>>
        {
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

        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly SchoolContext _context;
            private readonly IConfigurationProvider _configuration;
            private readonly IMapper _mapper;

            public QueryHandler(SchoolContext context, IConfigurationProvider configuration, IMapper mapper)
            {
                _context = context;
                _configuration = configuration;
                _mapper = mapper;
            }

            public async Task<List<Model>> Handle(Query message, CancellationToken token)
            {

                // throws null exceptions on Should_list_departments
                //return await _context.Departments
                //    .ProjectTo<Model>(_configuration)
                //    .ToListAsync(token);

                var departments = await _context.Departments.ToListAsync(token);

                return departments.Select(x => _mapper.Map<Model>(x)).ToList();
            }
        }
    }
}