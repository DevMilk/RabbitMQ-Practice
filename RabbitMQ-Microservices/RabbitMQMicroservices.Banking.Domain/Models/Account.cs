﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Domain.Models
{
    public class Account
    {
        public long Id { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }

    }
}
