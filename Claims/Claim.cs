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
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }

        private bool claimValid;
        public bool IsValid
        {
            get
            {
                return claimValid;
            }
            set
            {
                claimValid = DateOfClaim - DateOfIncident <= TimeSpan.FromDays(30);
            }
        }

        public Claim(int claimId, ClaimType claimType, string description, decimal amount, DateTime accidentDate, DateTime claimDate)
        {
            Id = claimId;
            Type = claimType;
            Description = description;
            Amount = amount;
            DateOfIncident = accidentDate;
            DateOfClaim = claimDate;
        }
        public Claim()
        {

        }
        public override string ToString()
        {
            return $"Claim ID: {Id}\n" +
                $"Claim Type: {Type}\n" +
                $"Description: {Description}\n" +
                $"Amount Approved: {Amount}\n" +
                $"Date of Incident: {DateOfIncident}\n" +
                $"Date of Claim: {DateOfClaim}\n" +
                $"Claim was submitted within 30 days: {IsValid}";
        }
    }
}
