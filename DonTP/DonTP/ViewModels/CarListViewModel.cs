using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DonTP.Data;
using DevExpress.Mvvm.POCO;
using DonTP.CarService;

namespace DonTP.ViewModels
{
    // In This View Model
    [POCOViewModel]
    public class CarListViewModel
    {
        // I am Using the Car Service I created
        CarServicesClient localClient = new CarServicesClient();

        // I then have a public virtual instance of the CarList Class defined with autoimplemented properties
        public virtual CarList Cars { get; set; }

        // In This class I only have one protected Constructor that initializes a fresh instance of the CarList class
        // This is a Default protected Constructor because we do not want this CarListViewModel to be instantiated by code
        // We want this View Model to be created through a factory which is inside the framework so we hide the constructor by making it protected
        protected CarListViewModel()
        {
            Cars = new CarList();
        }

        // Then I Have A Static Method called Create. This method uses lamba expression which allows us to create this new CarView Model
        // And Because this code is being executed inside this class, we can still instantiate this protected constructor
        public static CarListViewModel Create()
        {
            return ViewModelSource.Create(() => new CarListViewModel());
        }

        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }

        // Then I have an Edit A Car method Which takes in as parameter, a car object.
        // This Method uses IDocumentManagerService to invoke and display another view called CarView. This CarView will allow us to modify
        // Attribute about the car and also to save or cancel changes about the modeification.
        // So This EditCar Method will be used as a command in the CarListView when a row is double clicked.
        public void EditCar(Object carObject)
        {
            var car = carObject as Data.Car;
            // Inside The Edit Car Method, I am using the DocumentManagerService object to pass in as parameter to the CarViewModel constructor, The instance of the car to be edited.
            var document = DocumentManagerService.CreateDocument("CarView", CarViewModel.Create(car));
            document.Show();
        }

        // Also Have an Add A New Car Method to add a new Car. This method also invokes and opens another view called AddCarView
        public void AddCar()
        {
            // And I am also using the DocumentManagerService to initilize and show the AddCarView view
            var cars = this.Cars as CarList;
            var document = DocumentManagerService.CreateDocument("AddCarView", AddCarViewModel.Create(cars));
            document.Show();
        }

        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IMessageBoxService MessageBoxService { get { return null; } }

        // Lastly, I have a method to delete the selected Car / Row
        // This method takes in as parameter, an object of the car Class.
        // In This method, I am using a protected virtual instance of the IMessageBoxService to show a confirmation box with the options yes or no.
        // This confirmation box will ask the user whether they want to truely delete the selected car or row.
        public void DeleteRow(Object carObject)
        {
            if (MessageBoxService.ShowMessage("Are You Sure You Want To Delete This Row?",
                                 "Question",
                                 MessageButton.YesNo,
                                 MessageIcon.Question,
                                 MessageResult.No) == MessageResult.Yes)
            {
                var car = carObject as Data.Car;
                // To delete The Car from the database, I am using the service instance. Also I am removing the said Car from the in-momory list storage (i.e. from the CarList Class)
                // So that the View and the data from the database is synchonized.
                localClient.deleteCar(car.Id);
                this.Cars.Remove(car);
            }
        }
    }
}