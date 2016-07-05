﻿using DotNetRuleEngine.Core;
using DotNetRuleEngine.Core.Extensions;
using DotNetRuleEngine.Test.Models;
using DotNetRuleEngine.Test.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetRuleEngine.Test
{
    [TestClass]
    public class TestNestedRule
    {
        [TestMethod]
        public void TestNestedRules()
        {
            var ruleEngineExecutor = RuleEngine<Product>.GetInstance(new Product());
            ruleEngineExecutor.AddRules(new ProductNestedRule());
            var ruleResults = ruleEngineExecutor.Execute();
            var nestedRuleResult = ruleResults.FindRuleResult<ProductNestedRuleC>();

            Assert.IsNotNull(nestedRuleResult);
            Assert.AreEqual("ProductNestedRuleC", nestedRuleResult.Name);
        }

        [TestMethod]
        public void TestNestedRuleError()
        {
            var ruleEngineExecutor = RuleEngine<Product>.GetInstance(new Product());
            ruleEngineExecutor.AddRules(new ProductNestedErrorRule());
            var ruleResults = ruleEngineExecutor.Execute();
            var errors = ruleResults.GetErrors();

            Assert.IsNotNull(errors);
            Assert.AreEqual("Error", errors.FindRuleResult<ProductChildErrorRule>().Error.Message);
        }
    }
}
