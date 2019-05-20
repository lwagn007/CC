using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimRepository : IClaimRepository
    {
        Queue<IClaim> _claims;
        public ClaimRepository()
        {
            _claims = new Queue<IClaim>();
        }
        public bool AddClaimToQueue(IClaim claim)
        {
            if (claim.IsValid != false)
            {
                _claims.Enqueue(claim);
                return true;
            }
            return false;
        }

        public IClaim GetClaimById(int id)
        {
            foreach (var claim in _claims)
            {
                if (claim.Id == id)
                {
                    return claim;
                }
            }
            return new Claim();
        }

        public IEnumerable<IClaim> GetClaims()
        {
            return _claims;
        }

        public Tuple<bool, IClaim> HandleClaim(bool removeClaim)
        {
            if (removeClaim == true)
            {
                var handledClaim = _claims.Dequeue();
                return new Tuple<bool, IClaim>(true, handledClaim);
            }
            else return new Tuple<bool, IClaim>(false, new Claim());
        }

        public IClaim SeeNextClaim()
        {
            return _claims.Peek();

        }
    }
}
