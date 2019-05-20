using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public interface IClaim
    {
        int Id { get; set; }
        string Description { get; set; }
        decimal Amount { get; set; }
        DateTimeOffset DateOfIncidentUTC { get; set; }
        DateTimeOffset DateOfClaimUTC { get; set; }
        bool IsValid { get; set; }
    }
}
