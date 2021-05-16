using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class Bank
    {
        public void GetTaxes(double tax)
        {
            Money += tax;
        }
        public void RateIncoms(double partialIncome, Inflation inflation) 
        {
            var income = partialIncome * inflation.Value;
            if (income <= 300)
                inflation.Value += 0.02;
            else if (income > 300 && income <= 500)
            {
            }
            else 
            {
                inflation.Value -= 0.02;
            }

        }
        public void AttachSellers(List<Seller> observers)
        {            
            this.SellersObservers.AddRange(observers);
        }
        public void AttachConsumers(List<Consumer> observers)
        {
            this.ConsumersObservers.AddRange(observers);
        }
        public void Notify()            
        {
            foreach (var observer in SellersObservers)
            {
                observer.Update(this);
            }
            foreach (var observer in ConsumersObservers)
            {
                observer.Update(this);
            }
        }
        private List<Seller> SellersObservers = new List<Seller>();
        private List<Consumer> ConsumersObservers = new List<Consumer>();

        public Dictionary<Product, double> ProductPrieces { get; set; }
        public Inflation Inflation { get; set; } 
        public double Money { get; set; }
        public double PartialIncome { get; set; }
    }
}
