﻿using AutomergerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Automerger.Model.Tests
{
    [TestClass()]
    public class ConflictTests
    {
        [TestMethod()]
        public void ConflictTest()
        {
            string[] content1 = new string[1] { "Test1" };
            string[] content2 = new string[1] { "Test2" };

            MyAssert.Throws<ArgumentException>(() => new Conflict(-1, 1, content1, content2));
            MyAssert.Throws<ArgumentException>(() => new Conflict(0, 0, content1, content2));

            MyAssert.Throws<ArgumentNullException>(() => new Conflict(0, 1, null, content2));
            MyAssert.Throws<ArgumentNullException>(() => new Conflict(0, 1, content1, null));

            var conflict = new Conflict(0, 1, content1, content2);

            Assert.IsTrue(conflict.Start == 0);
            Assert.IsTrue(conflict.RemovedAmount == 1);
            Assert.IsTrue(content1.SequenceEqual(conflict.NewContent1));
            Assert.IsTrue(content2.SequenceEqual(conflict.NewContent2));
        }
    }
}