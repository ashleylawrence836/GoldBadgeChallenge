using ClaimsLibrary.Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsTests
{
    [TestClass]
    public class ClaimsTests
    {
        Claim _claimsRepo = new Claim();

        [TestMethod]
        public void AddClaimTest()
        {
            Claim claimOne = new Claim(1, ClaimType.Theft, "Stolen snowman", 00.00, new DateTime(2021, 02, 15), new DateTime(2021, 02, 17));

            //_claimsRepo.AddClaimToQueue(claimOne);
            //bool wasAdded = _claimsRepo.AddClaimToQueue(claimOne);

            //Assert.IsTrue(wasAdded);
        }
    }
}
