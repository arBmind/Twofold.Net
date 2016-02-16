﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Helper;
using Twofold.Compilation;
using Twofold.Interface.Compilation;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class CallRuleTest
    {
        [TestMethod]
        public void Empty()
        {
            var line = Tools.CreateFileLine(@"=", 0);
            var rule = new CallRule();
            List<AsbtractCodeFragment> fragments = rule.Parse(line, new NullMessageHandler());

            Assert.AreEqual(3, fragments.Count);

            Assert.AreEqual(CodeFragmentTypes.TargetPushIndentation, fragments[0].Type);
            Assert.AreEqual("", fragments[0].Span.Text);

            Assert.AreEqual(CodeFragmentTypes.OriginScript, fragments[1].Type);
            Assert.AreEqual("", fragments[1].Span.Text);

            Assert.AreEqual(CodeFragmentTypes.TargetPopIndentation, fragments[2].Type);
            Assert.AreEqual("", fragments[2].Span.Text);
        }

        [TestMethod]
        public void NoIndentation()
        {
            var line = Tools.CreateFileLine(@"=A;", 0);
            var rule = new CallRule();
            List<AsbtractCodeFragment> fragments = rule.Parse(line, new NullMessageHandler());

            Assert.AreEqual(3, fragments.Count);

            Assert.AreEqual(CodeFragmentTypes.TargetPushIndentation, fragments[0].Type);
            Assert.AreEqual("", fragments[0].Span.Text);

            Assert.AreEqual(CodeFragmentTypes.OriginScript, fragments[1].Type);
            Assert.AreEqual("A;", fragments[1].Span.Text);

            Assert.AreEqual(CodeFragmentTypes.TargetPopIndentation, fragments[2].Type);
            Assert.AreEqual("", fragments[2].Span.Text);
        }

        [TestMethod]
        public void Indentation()
        {
            var line = Tools.CreateFileLine(@"=   A;", 0);
            var rule = new CallRule();
            List<AsbtractCodeFragment> fragments = rule.Parse(line, new NullMessageHandler());

            Assert.AreEqual(3, fragments.Count);

            Assert.AreEqual(CodeFragmentTypes.TargetPushIndentation, fragments[0].Type);
            Assert.AreEqual("   ", fragments[0].Span.Text);

            Assert.AreEqual(CodeFragmentTypes.OriginScript, fragments[1].Type);
            Assert.AreEqual("A;", fragments[1].Span.Text);

            Assert.AreEqual(CodeFragmentTypes.TargetPopIndentation, fragments[2].Type);
            Assert.AreEqual("", fragments[2].Span.Text);
        }
    }
}
