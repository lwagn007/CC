using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public interface IClaimRepository
    {
        bool AddClaimToQueue(IClaim claim);
        IEnumerable<IClaim> GetClaims();
        IClaim GetClaimById(int id);
        Tuple<bool,IClaim> HandleClaim(bool removeClaim);
        IClaim SeeNextClaim();
    }
}
