﻿using System.Threading.Tasks;
using DotNetRuleEngine.Core;
using DotNetRuleEngine.Core.Extensions;
using DotNetRuleEngine.Core.Interface;
using DotNetRuleEngine.Core.Models;
using DotNetRuleEngine.Test.Models;

namespace DotNetRuleEngine.Test.AsyncRules
{
    class ProductTryGetValueAsync : RuleAsync<Product>
    {
        public override async Task<IRuleResult> InvokeAsync()
        {
            Model.Description = TryGetValueAsync("Description").To<string>();
            return await Task.FromResult(new RuleResult { Name = "ProductRule", Result = Model.Description });
        }
    }
}