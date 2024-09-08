using HamburguesitoNet.Application.Common.Interfaces.Services;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace HamburguesitoNet.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public RequestLogger(ILogger<TRequest> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            string userName = _userService.GetUser();

            _logger.LogInformation(string.Format("User '{0}' requested '{1}'", userName, requestName));
        }


    }
}
