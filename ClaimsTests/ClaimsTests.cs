using ClaimsLibrary.Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsTests
{
    [TestClass]
    public class ClaimsTests
    {
        ClaimsRepository _claimsRepo = new ClaimsRepository();

        [TestMethod]
        public void AddClaimTest()
        {
            Claim claimOne = new Claim();

            claimOne.ClaimId = 1;
            claimOne.ClaimType = ClaimType.Theft;
            claimOne.Description = "Stolen snowman";
            claimOne.ClaimAmount = 0.0;
            claimOne.DateOfClaim = new DateTime(12/24/2020);
            claimOne.DateOfClaim = new DateTime(12/25/2020);

            _claimsRepo.AddClaimToQueue(claimOne);
            bool wasAdded = _claimsRepo.AddClaimToQueue(claimOne);

            Assert.IsTrue(wasAdded);
        }
    }
}
