using HospitalAppLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HospitalAppLibTests
{
    [TestClass]
    public class HospAppTest
    {
        TimeFieldsClass TestDrive = new TimeFieldsClass();
        [TestMethod]
        public void IsRightTime_HalloWord_ReturnFalse()
        {
            //Arrange
            string entryString = "Здравствуйтте";


            //Assert
            Assert.IsFalse(TestDrive.IsRightTime(entryString));
        }
        [TestMethod]
        public void IsRightDuration_WrongHalloWrod_ReturnFalse()
        {
            //Arrange
            string entryString = "Zdravstvujtte";


            //Assert
            Assert.IsFalse(TestDrive.IsRightDuration(entryString));
        }

        [TestMethod]
        public void IsRightTime_WrongTimeHoursRecord_ReturnFalse()
        {
            //Arrange
            string entryString = "25:00";


            //Assert
            Assert.IsFalse(TestDrive.IsRightTime(entryString));
        }


        [TestMethod]
        public void IsRightTime_WrongTime_ReturnFalse()
        {
            //Arrange
            string entryString = "23:60";


            //Assert
            Assert.IsFalse(TestDrive.IsRightTime(entryString));
        }


        [TestMethod]
        public void IsRightTime_BlankNumber_ReturnFalse()
        {
            //Arrange
            string entryString = " ";


            //Assert
            Assert.IsFalse(TestDrive.IsRightTime(entryString));
        }


        [TestMethod]
        public void IsRightDuration_BlankSpaceNumber_ReturnFalse()
        {
            //Arrange
            string entryString = "";


            //Assert
            Assert.IsFalse(TestDrive.IsRightDuration(entryString));
        }


        [TestMethod]
        public void IsRightTime_RightTime_ReturnTrue()
        {
            //Arrange
            string entryString = "23:10";


            //Assert
            Assert.IsTrue(TestDrive.IsRightTime(entryString));
        }


        [TestMethod]
        public void IsRightDuration_RightOneNumber_ReturnFalse()
        {
            //Arrange
            string entryString = "1";


            //Assert
            Assert.IsTrue(TestDrive.IsRightDuration(entryString));
        }


        [TestMethod]
        public void IsRightDuration_RightTwoNumbers_ReturnTrue()
        {
            //Arrange
            string entryString = "20";


            //Assert
            Assert.IsTrue(TestDrive.IsRightDuration(entryString));
        }


        [TestMethod]
        public void IsRightDuration_RightOverLimitNumbers_ReturnTrue()
        {
            //Arrange
            string entryString = "70";


            //Assert
            Assert.IsTrue(TestDrive.IsRightDuration(entryString));
        }


        [TestMethod]
        public void IsRightDuration_NegativeTwoNumbers_ReturnTrue()
        {
            //Arrange
            string entryString = "-10";


            //Assert
            Assert.IsFalse(TestDrive.IsRightDuration(entryString));
        }


        [TestMethod]
        public void IsRightDuration_RightOneNumber_ReturnTrue()
        {
            //Arrange
            string entryString = "0";


            //Assert
            Assert.IsTrue(TestDrive.IsRightDuration(entryString));
        }
    }
}
