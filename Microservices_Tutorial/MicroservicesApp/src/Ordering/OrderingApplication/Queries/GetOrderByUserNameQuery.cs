using MediatR;
using OrderingApplication.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingApplication.Queries
{
    public class GetOrderByUserNameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }

        public GetOrderByUserNameQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
