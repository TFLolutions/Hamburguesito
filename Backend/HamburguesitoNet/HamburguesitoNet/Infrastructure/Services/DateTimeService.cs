using HamburguesitoNet.Application.Common.Interfaces;
using System;

namespace HamburguesitoNet.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
