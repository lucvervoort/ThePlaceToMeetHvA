using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using ThePlaceToMeet.Contracts.Interfaces;

namespace ThePlaceToMeet.Filters
{
    [AttributeUsageAttribute(AttributeTargets.All, AllowMultiple = false)]
    public class KlantFilter:  ActionFilterAttribute
    {
        private readonly ICustomerRepository _klantRepository;
        private readonly IMapper _mapper;

        public KlantFilter(ICustomerRepository klantRepository, IMapper mapper)
        {
            _klantRepository = klantRepository;
            _mapper = mapper;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var customer = _klantRepository.GetByEmail(context.HttpContext.User.Identity.Name);
                Domain.Customer domainCustomer = new();
                context.ActionArguments["klant"] = _mapper.Map(customer, domainCustomer);
            }
            else
            {
                context.ActionArguments["klant"] = null;
            }
            base.OnActionExecuting(context);
        }
    }
}

