using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;
using ShopyList.ApplicationServices.API.Domain.UserRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Queries.ShopsQueries;
using ShopyList.DataAccess.CQRS.Queries.UsersQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.ApplicationServices.API.Handlers.UsersHandlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();
            var users = await this.queryExecutor.Execute(query);
            var mappedUsers = this.mapper.Map<List<Domain.Models.User>>(users);

            var response = new GetUsersResponse()
            {
                Data = mappedUsers
            };
            return response;
        }
    }
}
