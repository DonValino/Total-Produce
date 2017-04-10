using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace CarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarService" in both code and config file together.
    [ServiceContract]
    public interface ICarServices
    {
        [OperationContract]
        void addCar(string Make, String Model, int Year, int Mileage, int Price);

        [OperationContract]
        void editCar(string Make, string Model, int Price, int Id, int Mileage, int Year);

        [OperationContract]
        void deleteCar(int id);

        [OperationContract]
        void dropTable();

        [OperationContract]
        void createTable();

        [OperationContract]
        List<DonTP.Data.Car> getAllData();
    }
}
