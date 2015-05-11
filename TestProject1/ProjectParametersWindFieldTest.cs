//------------------------------------------------------------------------------
// Copyright (c) 2012, 2013, 2014, 2015 Francesco Paraggio.
// 
// Author: Francesco Paraggio fparaggio@gmail.com
// 
// This file is part of WindSimBattery
// 
// WindSimBattery is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License along with this program. If not, see http://www.gnu.org/licenses/.
// 
// The usage of a range of years within a copyright statement contained within this distribution should be interpreted as being equivalent to a list of years including the first and last year specified and all consecutive years between them. For example, a copyright statement that reads 'Copyright (c) 2005, 2007- 2009, 2011-2012' should be interpreted as being identical to a statement that reads 'Copyright (c) 2005, 2007, 2008, 2009, 2011, 2012' and a copyright statement that reads "Copyright (c) 2005-2012' should be interpreted as being identical to a statement that reads 'Copyright (c) 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012'."
//------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ProjectParametersWindFieldTest and is intended
    ///to contain all ProjectParametersWindFieldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectParametersWindFieldTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ProjectParametersWindField Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectParametersWindFieldConstructorTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AirDensity
        ///</summary>
        [TestMethod()]
        public void AirDensityTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.AirDensity = expected;
            actual = target.AirDensity;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BoundaryConditionTop
        ///</summary>
        [TestMethod()]
        public void BoundaryConditionTopTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.BoundaryConditionTop = expected;
            actual = target.BoundaryConditionTop;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConvergenceWizard
        ///</summary>
        [TestMethod()]
        public void ConvergenceWizardTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ConvergenceWizard = expected;
            actual = target.ConvergenceWizard;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DoNesting
        ///</summary>
        [TestMethod()]
        public void DoNestingTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.DoNesting = expected;
            actual = target.DoNesting;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HashCodeLastRun
        ///</summary>
        [TestMethod()]
        public void HashCodeLastRunTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.HashCodeLastRun = expected;
            actual = target.HashCodeLastRun;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HeightBoundaryLayer
        ///</summary>
        [TestMethod()]
        public void HeightBoundaryLayerTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.HeightBoundaryLayer = expected;
            actual = target.HeightBoundaryLayer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HeightReducedWindData
        ///</summary>
        [TestMethod()]
        public void HeightReducedWindDataTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.HeightReducedWindData = expected;
            actual = target.HeightReducedWindData;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsCoriolis
        ///</summary>
        [TestMethod()]
        public void IsCoriolisTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsCoriolis = expected;
            actual = target.IsCoriolis;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for KESource
        ///</summary>
        [TestMethod()]
        public void KESourceTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.KESource = expected;
            actual = target.KESource;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LastChanged
        ///</summary>
        [TestMethod()]
        public void LastChangedTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.LastChanged = expected;
            actual = target.LastChanged;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Latitude
        ///</summary>
        [TestMethod()]
        public void LatitudeTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.Latitude = expected;
            actual = target.Latitude;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MesoProjectName
        ///</summary>
        [TestMethod()]
        public void MesoProjectNameTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.MesoProjectName = expected;
            actual = target.MesoProjectName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MesoscaleDataFolder
        ///</summary>
        [TestMethod()]
        public void MesoscaleDataFolderTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.MesoscaleDataFolder = expected;
            actual = target.MesoscaleDataFolder;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MoninObukhovLength
        ///</summary>
        [TestMethod()]
        public void MoninObukhovLengthTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.MoninObukhovLength = expected;
            actual = target.MoninObukhovLength;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MonitoringFieldValue
        ///</summary>
        [TestMethod()]
        public void MonitoringFieldValueTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.MonitoringFieldValue = expected;
            actual = target.MonitoringFieldValue;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MonitoringSpotValueCoordSys
        ///</summary>
        [TestMethod()]
        public void MonitoringSpotValueCoordSysTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.MonitoringSpotValueCoordSys = expected;
            actual = target.MonitoringSpotValueCoordSys;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MonitoringSpotValueXpos
        ///</summary>
        [TestMethod()]
        public void MonitoringSpotValueXposTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.MonitoringSpotValueXpos = expected;
            actual = target.MonitoringSpotValueXpos;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MonitoringSpotValueYpos
        ///</summary>
        [TestMethod()]
        public void MonitoringSpotValueYposTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.MonitoringSpotValueYpos = expected;
            actual = target.MonitoringSpotValueYpos;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ParallelCores
        ///</summary>
        [TestMethod()]
        public void ParallelCoresTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ParallelCores = expected;
            actual = target.ParallelCores;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ParallelSimulationsPerCore
        ///</summary>
        [TestMethod()]
        public void ParallelSimulationsPerCoreTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ParallelSimulationsPerCore = expected;
            actual = target.ParallelSimulationsPerCore;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RadialDistribution
        ///</summary>
        [TestMethod()]
        public void RadialDistributionTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.RadialDistribution = expected;
            actual = target.RadialDistribution;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReferenceHeight
        ///</summary>
        [TestMethod()]
        public void ReferenceHeightTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.ReferenceHeight = expected;
            actual = target.ReferenceHeight;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReferenceTemperature
        ///</summary>
        [TestMethod()]
        public void ReferenceTemperatureTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.ReferenceTemperature = expected;
            actual = target.ReferenceTemperature;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RunInBatchMode
        ///</summary>
        [TestMethod()]
        public void RunInBatchModeTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.RunInBatchMode = expected;
            actual = target.RunInBatchMode;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Sector
        ///</summary>
        [TestMethod()]
        public void SectorTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float[] expected = null; // TODO: Initialize to an appropriate value
            float[] actual;
            target.Sector = expected;
            actual = target.Sector;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SectorInputType
        ///</summary>
        [TestMethod()]
        public void SectorInputTypeTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SectorInputType = expected;
            actual = target.SectorInputType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Solver
        ///</summary>
        [TestMethod()]
        public void SolverTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Solver = expected;
            actual = target.Solver;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Sweep
        ///</summary>
        [TestMethod()]
        public void SweepTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Sweep = expected;
            actual = target.Sweep;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Temperature
        ///</summary>
        [TestMethod()]
        public void TemperatureTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.Temperature = expected;
            actual = target.Temperature;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TemperatureGradient
        ///</summary>
        [TestMethod()]
        public void TemperatureGradientTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.TemperatureGradient = expected;
            actual = target.TemperatureGradient;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TurbMod
        ///</summary>
        [TestMethod()]
        public void TurbModTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.TurbMod = expected;
            actual = target.TurbMod;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UseInputPreviousRun
        ///</summary>
        [TestMethod()]
        public void UseInputPreviousRunTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.UseInputPreviousRun = expected;
            actual = target.UseInputPreviousRun;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UseMesoInput
        ///</summary>
        [TestMethod()]
        public void UseMesoInputTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.UseMesoInput = expected;
            actual = target.UseMesoInput;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VelocityBoundaryLayer
        ///</summary>
        [TestMethod()]
        public void VelocityBoundaryLayerTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.VelocityBoundaryLayer = expected;
            actual = target.VelocityBoundaryLayer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WindspeedInReferenceHeight
        ///</summary>
        [TestMethod()]
        public void WindspeedInReferenceHeightTest()
        {
            ProjectParametersWindField target = new ProjectParametersWindField(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.WindspeedInReferenceHeight = expected;
            actual = target.WindspeedInReferenceHeight;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
