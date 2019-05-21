using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class Claim : IClaim
    {
        public int Id { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset DateOfIncidentUTC { get; set; }
        public DateTimeOffset DateOfClaimUTC { get; set; }

        private bool claimValid;
        public bool IsValid
        {
            get
            {
                return claimValid;
            }
            set
            {
                claimValid = DateOfClaimUTC - DateOfIncidentUTC <= TimeSpan.FromDays(30);
            }
        }
        public override string ToString()
        {
            return $"Claim ID: {Id}\n" +
                $"Claim Type: {Type}\n" +
                $"Description: {Description}\n" +
                $"Amount Approved: {Amount}\n" +
                $"Date of Incident: {DateOfIncidentUTC}\n" +
                $"Date of Claim: {DateOfClaimUTC}\n" +
                $"Claim was submitted within 30 days: {IsValid}";
        }
    }
}
