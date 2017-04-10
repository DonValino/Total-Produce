using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finisar.SQLite;
using DonTP.CarService;
using System.Collections;

namespace DonTP.Data
{
    // Collection set Of pre-loaded Cars data
    // This Class implements the ObservableCollection interface to hold Car class instances.
    public class CarList : ObservableCollection<Car>
    {
        // Here I am using the CarSerice WCF service that I created to connect to the database
        // and query to return all the data from the Cars table of the database and add it to the list.

        // So We Have a pre-loaded set of cars

        // Connecting to the Service Class
        CarServicesClient localClient = new CarServicesClient();


        public CarList()
        {
            // Dropping the table
           // localClient.dropTable();
            //Create The Table
           // localClient.createTable();

            /* Initialize The DB using the addCar method of the service class
            localClient.addCar("Mercedes - Benz", "C - Class", 2017, 15000, 30000);
            localClient.addCar("BMW", "3 Series", 2016, 10000, 32000);
            localClient.addCar("Ford", "Mondeo", 2015, 6000, 28000);
            localClient.addCar("Chrysler", "300", 2017, 10000, 27000);
            localClient.addCar("Ford", "Expedition", 2013, 5000, 50000);
            localClient.addCar("Toyota", "Land Cruiser", 2017, 1000, 90000);
            localClient.addCar("Lexus", "Lx-570", 2017, 10000, 120000);
            localClient.addCar("Chevrolet", "Lacetti", 2015, 6000, 28000);
            localClient.addCar("Lexus", "Rx-350", 2017, 3000, 90000);
            localClient.addCar("Toyota", "86", 2017, 7, 30000);*/

            // Initializing the list with the values stored in the database.
            // We Will Bind This List To The Grid Table Of The 
            for(int i = 0; i < localClient.getAllData().Length;i++)
            {
                this.Add(new Car(localClient.getAllData()[i].Id, localClient.getAllData()[i].Make, localClient.getAllData()[i].Model, localClient.getAllData()[i].Year, localClient.getAllData()[i].Mileage, localClient.getAllData()[i].Price));
            }
        }
    }
}
