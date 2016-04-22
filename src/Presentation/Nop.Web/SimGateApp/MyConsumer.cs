using Nop.Core.Domain.Customers;
using Nop.Core.Events;
using Nop.Services.Common;
using Nop.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Web.SimGateApp
{
    class MyConsumer : IConsumer<EntityUpdated<Customer>>
    {

        private readonly IGenericAttributeService _genericAttributeService;

        public MyConsumer(IGenericAttributeService genericAttributeService)
        {

            this._genericAttributeService = genericAttributeService;

        }

        public void HandleEvent(EntityUpdated<Customer> eventMessage)
        {
            Customer customer = eventMessage.Entity;
            string customerTelerivetProjectID = customer.GetAttribute<string>(SystemCustomerAttributeNames.TelerivetProjectID);
            if (customer.Active && customerTelerivetProjectID == null)
            {
                _genericAttributeService.SaveAttribute(customer, SystemCustomerAttributeNames.TelerivetProjectID, "PJaa0b3bd060afa118");
            }


            // stuff to be done when a customer is updated
        }
    }
}