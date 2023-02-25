using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasProjekt1
{
    internal class Car
    {
       
        
        public string Brand { get; set; }
        public string Model { get; set; } 
        public string Mileage { get; set; } 
        public string Cost { get; set; }   
        public string Phonenumber { get; set; }
        




        public Car (string brand, string model, string mileage, string cost, string phonenumber)
        {
            

           
            Brand = brand;
            Model = model;
            Mileage = mileage;
            Cost = cost;
            Phonenumber = phonenumber;
            


        }





    }
}
