﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JasonRoberts.FeatureToggle.Tests
{
    [TestClass]
    public class SqlFeatureToggleTests
    {
        [TestMethod]
        public void ShouldDisableFeatureWhenToggleValueIsFalse()
        {
            var fakeProvider = new Mock<IBooleanToggleValueProvider>();

            fakeProvider.Setup(x => x.EvaluateBooleanToggleValue(It.IsAny<SqlFeatureToggle>())).Returns(false);

            var sut = new MySqlFeatureToggle();
            sut.ToggleValueProvider = fakeProvider.Object;

            Assert.IsFalse(sut.FeatureEnabled);
        }

        [TestMethod]
        public void ShouldEnableFeatureWhenToggleValueIsTrue()
        {
            var fakeProvider = new Mock<IBooleanToggleValueProvider>();

            fakeProvider.Setup(x => x.EvaluateBooleanToggleValue(It.IsAny<SqlFeatureToggle>())).Returns(true);

            var sut = new MySqlFeatureToggle();
            sut.ToggleValueProvider = fakeProvider.Object;

            Assert.IsTrue(sut.FeatureEnabled);
        }

        private class MySqlFeatureToggle : SqlFeatureToggle { }
    }  
}
