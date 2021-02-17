using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsLibrary.Claims
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class Claim
    {
        public int ClaimId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan claimSpan = DateOfIncident - DateOfClaim;
                int isClaimValid = Convert.ToInt32(claimSpan.TotalDays);
                if (isClaimValid <= 30)
                {
                    return true;
                }
                return false;
            }
        }

        public Claim() { }
        public Claim(int claimId, ClaimType claimType, string desciption, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = desciption;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
