using System;
using System.Collections.Generic;
using Finisar.SQLite;
using DonTP.Data;

namespace CarService
{
    public class CarService : ICarServices
    {
        public void addCar(string Make, String Model, int Year, int Mileage, int Price)
        {

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            // connect to existing database
            sqlite_conn = new SQLiteConnection("Data Source=C:\\Users\\Jake Valino\\Documents\\Visual Studio 2015\\Projects\\DonTP\\DonTP\\bin\\Debug\\database.db;Version=3;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "INSERT INTO cars (make, model, year, mileage, price) VALUES ('" + Make + "', '" + Model + "', " + Year + ", " + Mileage + ", " + Price + "); ";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }

        public void createTable()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            /* create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");*/

            // connecting to an existing database:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\Users\\Jake Valino\\Documents\\Visual Studio 2015\\Projects\\DonTP\\DonTP\\bin\\Debug\\database.db;Version=3;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Creating The cars table
            sqlite_cmd.CommandText = "CREATE TABLE cars (id integer primary key, make varchar(100), model varchar(100),year integer, mileage integer, price integer);";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();
        }

        public void deleteCar(int id)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            /* create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");*/

            // connecting to an existing database:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\Users\\Jake Valino\\Documents\\Visual Studio 2015\\Projects\\DonTP\\DonTP\\bin\\Debug\\database.db;Version=3;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Creating The cars table
            sqlite_cmd.CommandText = "DELETE FROM cars WHERE id ="+id;

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();
        }

        public void dropTable()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            // connecting to an existing database:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\Users\\Jake Valino\\Documents\\Visual Studio 2015\\Projects\\DonTP\\DonTP\\bin\\Debug\\database.db;Version=3;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Dropping the cars table:
            sqlite_cmd.CommandText = "DROP TABLE cars;";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();
        }

        public void editCar(string Make, string Model, int Price, int Id, int Mileage, int Year)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            /* create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");*/

            // connect to existing database
            sqlite_conn = new SQLiteConnection("Data Source=C:\\Users\\Jake Valino\\Documents\\Visual Studio 2015\\Projects\\DonTP\\DonTP\\bin\\Debug\\database.db;Version=3;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "Update cars SET make='" + Make + "', model='" + Model + "', price='" + Price + "', mileage ='"+ Mileage + "', year = '" + Year + "' WHERE id = " + Id;

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }

        public List<Car> getAllData()
        {
            List<Car> Cars = new List<Car>();

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // connect to existing database
            sqlite_conn = new SQLiteConnection("Data Source=C:\\Users\\Jake Valino\\Documents\\Visual Studio 2015\\Projects\\DonTP\\DonTP\\bin\\Debug\\database.db;Version=3;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT * FROM cars";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                Cars.Add(new Car(sqlite_datareader.GetInt32(0), sqlite_datareader.GetString(1), sqlite_datareader.GetString(2), sqlite_datareader.GetInt32(3), sqlite_datareader.GetInt32(4), sqlite_datareader.GetInt32(5)));
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();

            return Cars;
        }
    }
}
