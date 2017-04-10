using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DonTP.Data;
using DevExpress.Mvvm.POCO;
using System.ComponentModel;
using Finisar.SQLite;
using DonTP.CarService;
using System.Linq;

namespace DonTP.ViewModels
{
    [POCOViewModel]
    public class AddCarViewModel : IEditableObject
    {
        // Connecting to the service class
        CarServicesClient localClient = new CarServicesClient();

        // Instance Of Car List Class
        private CarList cars { get; set; }

        // Default Protected Constructor
        protected AddCarViewModel() : this(new CarList()) { }

        // Static Method called Create. The view model source has a method called which uses lamba expression which allows us to create this new AddCarCarView Model
        public static AddCarViewModel Create()
        {
            return ViewModelSource.Create(() => new AddCarViewModel());
        }

        // Takes in a parameter of the CarList Class 
        protected AddCarViewModel(CarList cars)
        {
            if (cars == null)
                throw new ArgumentException("Car", "Car is null");

            // Initialize the attributes of this class
            Load(cars);
        }

        // Static Method called Create. The view model source has a method called which uses lamba expression which allows us to create this new AddCarCarView Model
        public static AddCarViewModel Create(CarList cars)
        {
            return ViewModelSource.Create(() => new AddCarViewModel(cars));
        }

        // Initialize the attributes of this class
        private void Load(CarList car)
        {
            this.cars = car;
            Make = "";
            Model = "";
            Year = 0;
            Mileage = 0;
            Price = 0;
        }

        // Binded to the view - allow modification of the data without synchonously affecting the original data
        public virtual string Make { get; set; }
        public virtual string Model { get; set; }
        public virtual int Year { get; set; }
        public virtual int Mileage { get; set; }
        public virtual int Price { get; set; }

        void IEditableObject.BeginEdit()
        {

        }

        void IEditableObject.EndEdit()
        {
            if (cars != null && !String.IsNullOrEmpty(Make) && !String.IsNullOrEmpty(Model) && Year != 0 && Mileage != 0 && Price != 0)
            {
                if (MessageBoxService.ShowMessage("Are You Sure You Want To Add A New Row?",
                                                 "Question",
                                                 MessageButton.YesNo,
                                                 MessageIcon.Question,
                                                 MessageResult.No) == MessageResult.Yes)
                {
                    var lastCar = cars.Last();
                    cars.Add(new Data.Car(lastCar.Id + 1, Make,Model,Year,Mileage,Price));

                    localClient.addCar(Make, Model, Year, Mileage, Price);
                    WindowService.Close();
                }
            }
        }

        void IEditableObject.CancelEdit()
        {
            Load(this.cars);
        }

        public void Save() { ((IEditableObject)this).EndEdit(); }
        public void Revert() { ((IEditableObject)this).CancelEdit(); }

        // Services
        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IMessageBoxService MessageBoxService { get { return null; } }

        public virtual ICurrentWindowService WindowService { get { return null; } }
    }
}