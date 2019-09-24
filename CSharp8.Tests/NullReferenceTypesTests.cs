using EssemtialCSharp8;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace EssemtialCSharp8.Tests
{
    [TestClass]
    public class NullReferenceTypesTests
    {
        [TestMethod]
        public void GetTempPathInDirectory_GivenCurrentDirectory_SuccessfullyConcat()
        {
            string expected = Path.Combine(Directory.GetCurrentDirectory(), NullReferenceTypes.Path.RandomFileName);
            Assert.AreEqual(
                NullReferenceTypes.GetTempPathInDirectory(Directory.GetCurrentDirectory()), expected);
        }

        [TestMethod]
        public void GetTempPathInDirectory_GivenNoDirectory_SuccessfullyConcatUsingTempPath()
        {
            string expected = Path.Combine(Path.GetTempPath(), NullReferenceTypes.Path.RandomFileName);
            Assert.AreEqual(
                NullReferenceTypes.GetTempPathInDirectory(), expected);
        }

        //[TestMethod]
        //public void IsNotNull_GivenNonNullableValueType_ReturnTrue()
        //{
        //    Assert.IsTrue(IsNull((ValueType?)null));
        //    Assert.IsTrue(IsNull((int?)null));
        //}

        [TestMethod]
        public void IsNotNull_GivenNullOnNullableReferenceType_ReturnTrue()
        {
            Assert.IsTrue(IsNull<object?>(null));
            Assert.IsTrue(IsNull<string?>(null));
        }

        [TestMethod]
        public void IsNotNull_GivenNotNullOnNullableReferenceType_ReturnTrue()
        {
            Assert.IsFalse(IsNull<object?>(new object()));
            Assert.IsFalse(IsNull<string?>("Inigo Montoya"));
        }


        [TestMethod]
        public void IsNotNull_GivenNullOnNullableRValueType_ReturnTrue()
        {
            Assert.IsTrue(IsNull<ValueType?>(null));
            Assert.IsTrue(IsNull<int?>(null));
        }

        [TestMethod]
        public void IsNotNull_GivenNotNullOnNullableValueType_ReturnFalse()
        {
            Assert.IsFalse(IsNull<ValueType?>(1));
            Assert.IsFalse(IsNull<int?>(1));
        }

        bool IsNull<T>(T thing)
        {
            //return (thing is ValueType value) ?
            //    NullReferenceTypes.IsNull(value) && !NullReferenceTypes.IsNotNull(value) :
            return NullReferenceTypes.IsNull<T>(thing) && !NullReferenceTypes.IsNotNull<T>(thing);
        }
    }
}
