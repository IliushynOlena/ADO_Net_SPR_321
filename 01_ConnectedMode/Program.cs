using System.Data.SqlClient;
using System.Text;

namespace _01_ConnectedMode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Connection String - містить всю інформацію для підключення до сервера в
            // певному форматі
            /* SQL Server:
                - Windows Authentication:    "Data Source=server_name;Initial Catalog=db_name;Integrated Security=True";
                - SQL Server Authentication: "Data Source=server_name;Initial Catalog=db_name;User ID=login;Password=password";
            */
            //connectionString : Property = value; property2 = value;
            string connectionString = @"Data Source = DESKTOP-1LCG8OH\SQLEXPRESS;
                                        Initial Catalog= SportShop;
                                        Integrated Security=true;
                                        Connect Timeout = 2;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connected success");
            #region Execute Non-Query
            //string cmdText = @"INSERT INTO Products
            //                  VALUES ('FootballBall', 'Equipment', 14, 1500, 'Ukraine', 2000)";

            //SqlCommand command = new SqlCommand(cmdText, connection);
            //command.CommandTimeout = 5; // default - 30sec


            ////// ExecuteNonQuery - виконує команду яка не повертає результат 
            /////(insert, update, delete...),
            //////але метод повертає кількітсь рядків, які були задіяні
            //int rows = command.ExecuteNonQuery();

            //Console.WriteLine(rows + " rows affected!");
            #endregion
            #region Execute Scalar
            //string cmdText = @"select AVG(Price) from Products";

            //SqlCommand command = new SqlCommand(cmdText, connection);

            //// Execute Scalar - виконує команду, яка повертає одне значення
            //int res = (int)command.ExecuteScalar();

            //Console.WriteLine("Result: " + res);
            #endregion
            #region Execute Reader
            string cmdText = @"select * from Products";

            SqlCommand command = new SqlCommand(cmdText, connection);

            //// ExecuteReader - виконує команду select та повертає результат у вигляді
            //// DbDataReader
            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;

            //// відображається назви всіх колонок таблиці
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            ////// відображаємо всі значення кожного рядка
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],14} ");
                }
                Console.WriteLine();
            }

            reader.Close();
            #endregion

            connection.Close();
        }
    }
}
