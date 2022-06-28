using System;
namespace ApplicationCore.Models
{
	public class PurchaseRequestModel
	{
        public int MovieId { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchaseDateF
        {
            get { return PurchaseDate.ToString("MMMM dd, yyyy"); }
        }
        public decimal Price { get; set; }
        public Guid PurchaseNumber { get; set; }
    }
}

