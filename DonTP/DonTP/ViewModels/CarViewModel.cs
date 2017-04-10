using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DonTP.Data;
using DevExpress.Mvvm.POCO;
using System.ComponentModel;
using DonTP.CarService;

namespace DonTP.ViewModels
{
    // In This View Model
    [POCOViewModel]
    public class CarViewModel : IEditableObject
    {
        // Uses the Car Service I created
        CarServicesClient localClient = new CarServicesClient();

        // Private Instance Of The Car Class
        private Data.Car car { get; set; }

        // A Default protected Constructor. It is protected because we do not want this CarViewModel to be instantiated by code
        // We want this View Model to be created through a factory which is inside the framework so we hide the constructor by making it protected
        protected CarViewModel() : this(new CarList()[1]) { }

        // Then I Have A Static Method called Create. The view model source has a method called which uses lamba expression which allows us to create this new CarView Model
        public static CarViewModel Create()
        {
            return ViewModelSource.Create(() => new CarViewModel());
        }

        protected CarViewModel(Data.Car car)
        {
            if (car == null)
                throw new ArgumentException("Car", "Car is null");
            Load(car);
        }

        public static CarViewModel Create(Data.Car car)
        {
            return ViewModelSource.Create(() => new CarViewModel(car));
        }

        // To Prevent us from binding directly to the properies of the Car Data Object,
        // We Created public virtual variables to hide certain properties while doing edits
        // Will be using these properties in the UI
        // Using the load method to update does properties
        private void Load(Data.Car car)
        {
            this.car = car;
            this.Id = car.Id;
            this.Make = car.Make;
            this.Model = car.Model;
            this.Mileage = car.Mileage;
            this.Price = car.Price;
            this.Year = car.Year;
        }

        // Binded to the view - allow modification of the data without synchonously affecting the original data
        public virtual int Id { get; set; }
        public virtual string Make { get; set; }
        public virtual string Model { get; set; }
        public virtual int Mileage { get; set; }
        public virtual int Year { get; set; }
        public virtual double Price { get; set; }



        public bool CanResetAllData()
        {
            return car != null && !String.IsNullOrEmpty(Make) && !String.IsNullOrEmpty(Model);
        }

        public void ResetAllData()
        {
            if (car != null)
            {
                if (MessageBoxService.ShowMessage("Are You Sure You Want To Clear All The Data?",
                                                 "Question",
                                                 MessageButton.YesNo,
                                                 MessageIcon.Question,
                                                 MessageResult.No) == MessageResult.Yes)
                {
                    
                    Make = "";
                    Model = "";
                    Mileage = 0;
                    Price = 0;
                    Year = 0;
                }
            }
        }

        // To Continue using this Save and Cancel button behavior, I implemented an interface called IEditableObject
        // I implemented the methods of this interface explicitly to prevent them from showing up in the View as commands

        void IEditableObject.BeginEdit()
        {

        }

        void IEditableObject.EndEdit()
        {
            if (!String.Equals(Make, car.Make))
                car.Make = Make;
            if (!String.Equals(Model, car.Model))
                car.Model = Model;
            if (Price != car.Price)
                car.Price = Price;
            if (Mileage != car.Mileage)
                car.Mileage = Mileage;
            if (Year != car.Year)
                car.Year = Year;

            localClient.editCar(Make,Model,(int)Price, Id, Mileage, Year);
            WindowService.Close();
        }

        // Uses the Load Method
        void IEditableObject.CancelEdit()
        {
            Load(this.car);
        }

        // Because I explicitly implemented the interface, I need to cast the object which is doing all this stuff
        // and explicitly cast it to IeditableObject for those methods to be found.

        // End Edit Method used by save method
        public void Save() { ((IEditableObject)this).EndEdit(); }
        // Cancel Edit Method used by save method
        public void Revert() { ((IEditableObject)this).CancelEdit(); }


        // Services   
        // To Display Confirmation Box
        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IMessageBoxService MessageBoxService { get { return null; } }

        public virtual ICurrentWindowService WindowService { get { return null; } }

    }

}