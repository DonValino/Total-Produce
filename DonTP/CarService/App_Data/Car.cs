using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonTP.Data
{
    // Blue Print of a car
    public class Car : INotifyPropertyChanged
    {
        // Contains The Following Variable:
        //    id, make, model, year, mileage, price
        // The variable are set up with auto implemented properties with the get and set

        public event PropertyChangedEventHandler PropertyChanged;

        // Default Constructor
        public Car() { }

        // Constructor
        public Car(int id, string make, string model, int year, int mileage, double price)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Mileage = mileage;
            Price = price;
        }

        int id;

        public int Id
        {
            get { return id; }

            set
            {
                if (id == value)
                    return;
                id = value;
                OnPropertyChanged("Id");
            }
        }

        string make;

        public string Make
        {
            get { return make; }
            set
            {
                if (make == value)
                    return;
                make = value;
                OnPropertyChanged("Make");
            }
        }

        string model;

        public string Model
        {
            get { return model; }
            set
            {
                if (model == value)
                    return;
                model = value;
                OnPropertyChanged("Model");
            }
        }

        int year;

        public int Year
        {
            get { return year; }

            set
            {
                if (year == value)
                    return;
                year = value;
                OnPropertyChanged("Year");
            }
        }

        int mileage;

        public int Mileage
        {
            get { return mileage; }

            set
            {
                if (mileage == value)
                    return;
                mileage = value;
                OnPropertyChanged("Mileage");
            }
        }

        double price;

        public double Price
        {
            get { return price; }

            set
            {
                if (price == value)
                    return;
                price = value;
                OnPropertyChanged("Price");
            }
        }

        protected void OnPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
