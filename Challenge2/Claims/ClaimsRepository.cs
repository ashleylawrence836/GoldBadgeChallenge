using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsLibrary.Claims
{
    public class ClaimsRepository
    {
        private Queue<Claim> _claimsQueue = new Queue<Claim>();
        public bool AddClaimToQueue(Claim newClaim)
        {
            int startCount = _claimsQueue.Count;
            _claimsQueue.Enqueue(newClaim);

            bool wasAdded = _claimsQueue.Count > startCount;
            return wasAdded;
        }

        public Queue<Claim> GetClaims()
        {
            return _claimsQueue;
        }

        public Claim GetById(int claimId)
        {
            foreach (Claim item in _claimsQueue)
            {
                if (item.ClaimId == claimId)
                {
                    return item;
                }
            }
                return null;
        }

        public void RemoveClaim()
        {
            _claimsQueue.Dequeue();
        }
    }
}
