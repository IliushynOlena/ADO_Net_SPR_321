using System.Data.SqlClient;
using System.Text;

namespace _02_CRUD_Interface
{

    public class SportShopDb
    {
        //CRUD Interface
        //[C]reate
        //[R]ead
        //[U]pdate
        //[D]elete

        private SqlConnection connection;
        private string connectionString;
        public SportShopDb()
        {
            //connectionString = @"Data Source = DESKTOP-1LCG8OH\SQLEXPRESS;
            //                     Initial Catalog= SportShop;
            //                     Integrated Security=true;
            //                     Connect Timeout = 2;";
            connectionString = @"workstation id=ShopDb123456.mssql.somee.com;
                                packet size=4096;
                                user id=helen_iliushyn_SQLLogin_1;
                                pwd=hi9ub29ivw;
                                data source=ShopDb123456.mssql.somee.com;
                                persist security info=False;
                                initial catalog=ShopDb123456;
                                TrustServerCertificate=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        public void Create(Product product)
        {
            string cmdText = $@"INSERT INTO Products
                              VALUES ('{product.Name}', 
                                      '{product.Type}', 
                                       {product.Quantity}, 
                                       {product.CostPrice}, 
                                      '{product.Producer}', 
                                       {product.Price})";

            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5; // default - 30sec
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");

        }
        public List<Product> GetAll()
        {
            #region Execute Reader
            string cmdText = @"select * from Products";

            SqlCommand command = new SqlCommand(cmdText, connection);

            //// ExecuteReader - виконує команду select та повертає результат у вигляді
            //// DbDataReader
            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6]
                });
            }
            reader.Close();
            return products;
            #endregion

        }
        public Product GetById(int id)
        {
            #region Execute Reader
            string cmdText = $@"select * from Products where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, connection);

            SqlDataReader reader = command.ExecuteReader();

            Product product = new Product();

            while (reader.Read())
            {

                product.Id = (int)reader[0];
                product.Name = (string)reader[1];
                product.Type = (string)reader[2];
                product.Quantity = (int)reader[3];
                product.CostPrice = (int)reader[4];
                product.Producer = (string)reader[5];
                product.Price = (int)reader[6];
             
            }
            reader.Close();
            return product;
            #endregion

        }
        public void Update(Product product)
        {

            string cmdText = $@"UPDATE Products
                              SET Name ='{product.Name}', 
                                  TypeProduct ='{product.Type}', 
                                  Quantity ={product.Quantity}, 
                                  CostPrice ={product.CostPrice}, 
                                  Producer ='{product.Producer}', 
                                  Price ={product.Price}
                                  where Id = {product.Id}";

            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5; // default - 30sec

            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            string cmdText = $@"delete Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SportShopDb db = new SportShopDb();
            Product product = new Product()
            {
                 Name = "Cross",
                 Type = "Shoes",
                 Quantity = 5,
                 Price = 4500,
                 Producer = "England",
                 CostPrice = 5000
            };
            //db.Create(product);

            var products = db.GetAll();
            foreach (Product pr in products)
            {
                Console.WriteLine(pr.ToString());
            }
            Console.WriteLine();
            Product item = db.GetById(8);
            Console.WriteLine(item);
          
            item.Price += 150;
            item.CostPrice += 200;
            db.Update(item);

            db.Delete(17);
        }
    }
}
