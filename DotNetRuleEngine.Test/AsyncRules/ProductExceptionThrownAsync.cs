﻿using System;
using System.Threading.Tasks;
using DotNetRuleEngine.Core;
using DotNetRuleEngine.Core.Interface;
using DotNetRuleEngine.Test.Models;

namespace DotNetRuleEngine.Test.AsyncRules
{
    internal class ProductExceptionThrownAsync : RuleAsync<Product>
    {
        public override Task<IRuleResult> InvokeAsync()
        {
            throw new Exception();
        }
    }
}