using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Tests
{
    [TestClass()]
    public class PersonDACTests
    {
        [TestMethod()]
        public void GetPersonTest()
        {
            PersonDAC pdac = new PersonDAC();
            var person = pdac.GetPerson(1);

            Assert.Fail();
        }
    }
}