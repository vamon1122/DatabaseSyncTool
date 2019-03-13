using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SyncSql;

namespace GenerateSampleRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString;
            int noOfProductsToGenerate = 0;
            int noOfOrdersToGenerate = 0;

            GetInputConnectionString();
            GetInputNoOfProducts();
            GetInputNoOfOrders();
            GenerateRecords();

            void GetInputConnectionString()
            {
                WriteInput("Connection string: ");
                string response = Console.ReadLine();
                if (string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response))
                {
                    WriteLineError("You must specify a connection string to the database which you would like to generate the records on.");
                    GetInputConnectionString();
                }
                else
                {
                    if (Sync.ConnectionStringIsValid(response))
                    {
                        connectionString = response;
                    }
                    else
                    {
                        WriteLineError("Could not connect to a database using this connection string. Please try again.");
                        GetInputConnectionString();
                    }
                }
            }

            void GetInputNoOfProducts()
            {
                WriteInput("Number of products to generate: ");
                string response = Console.ReadLine();

                if (string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response))
                {
                    WriteLineError("You must specify a number of products to create on the database.");
                    GetInputNoOfProducts();
                }

                if(response == "0")
                {
                    noOfProductsToGenerate = 0;
                }
                else
                {
                    int.TryParse(response, out noOfProductsToGenerate);
                    if (noOfProductsToGenerate == 0)
                    {
                        WriteLineError(string.Format("Could not convert \"{0}\" to a number.", response));
                        GetInputNoOfProducts();
                    }
                }
            }

            void GetInputNoOfOrders()
            {
                WriteInput("Number of orders to generate: ");
                string response = Console.ReadLine();

                if (string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response))
                {
                    WriteLineError("You must specify a number of orders to create on the database.");
                    GetInputNoOfOrders();
                }

                if (response == "0")
                {
                    noOfOrdersToGenerate = 0;
                }
                else
                {
                    int.TryParse(response, out noOfOrdersToGenerate);
                    if (noOfOrdersToGenerate == 0)
                    {
                        WriteLineError(string.Format("Could not convert \"{0}\" to a number.", response));
                        GetInputNoOfOrders();
                    }
                }
            }

            void GenerateRecords()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    int endProductId = 0;
                    Random myRandom = new Random();

                    CreateProducts();
                    CreateOrders();
                    Console.WriteLine("Complete!");
                    Console.ReadLine();

                    void CreateProducts()
                    {

                        int currentProductId = 0;


                        GetMaxId();

                        /*if (currentProductId != endProductId)
                        {*/
                        CreateProductsOnDb();
                        //}

                        void GetMaxId()
                        {
                            SqlCommand getMaxId = new SqlCommand("SELECT MAX(ID) FROM Products", conn);
                            using (SqlDataReader reader = getMaxId.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (!string.IsNullOrEmpty(reader[0].ToString()) && !string.IsNullOrWhiteSpace(reader[0].ToString()))
                                        currentProductId = (int)reader[0] + 1;
                                    else
                                        currentProductId = 1;
                                }
                            }
                            endProductId = noOfProductsToGenerate + currentProductId - 1;
                        }

                        void CreateProductsOnDb()
                        {
                            while (currentProductId <= endProductId)
                            {
                                SqlCommand createProduct = new SqlCommand("INSERT INTO Products VALUES (@Id, @Name, @ListPrice)", conn);
                                createProduct.Parameters.Add(new SqlParameter("Id", currentProductId));
                                createProduct.Parameters.Add(new SqlParameter("Name", "Product" + currentProductId));
                                createProduct.Parameters.Add(new SqlParameter("ListPrice", string.Format("£{0}.{1}", myRandom.Next(100), myRandom.Next(100))));

                                createProduct.ExecuteNonQuery();

                                Console.Write(string.Format("\r{0}/{1} products were successfully created on the server!", noOfProductsToGenerate - (endProductId - currentProductId), noOfProductsToGenerate));

                                currentProductId++;
                            }
                            Console.WriteLine();
                        }
                    }

                    void CreateOrders()
                    {
                        int currentOrderId = 0;
                        int endOrderId = 0;


                        GetMaxId();
                        /*if (currentOrderId != endOrderId)
                        {*/
                        CreateOrdersOnDb();
                        //}

                        void GetMaxId()
                        {
                            SqlCommand getMaxId = new SqlCommand("SELECT MAX (OrderID) FROM Orders", conn);
                            using (SqlDataReader reader = getMaxId.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (!string.IsNullOrEmpty(reader[0].ToString()) && !string.IsNullOrWhiteSpace(reader[0].ToString()))
                                        currentOrderId = (int)reader[0] + 1;
                                    else
                                        currentOrderId = 1;
                                }
                            }
                            endOrderId = noOfOrdersToGenerate + currentOrderId - 1;
                        }

                        void CreateOrdersOnDb()
                        {

                            while (currentOrderId <= endOrderId)
                            {
                                SqlCommand createOrder = new SqlCommand("INSERT INTO Orders VALUES (@OrderId, @ProductId, @Quantity, @OriginState)", conn);
                                createOrder.Parameters.Add(new SqlParameter("OrderId", currentOrderId));
                                int RandId = myRandom.Next(1, endProductId > 1 ? endProductId - 1 : 1);
                                //Console.WriteLine("ProductId will be " + RandId);
                                createOrder.Parameters.Add(new SqlParameter("ProductId", RandId));
                                createOrder.Parameters.Add(new SqlParameter("Quantity", myRandom.Next(11)));
                                createOrder.Parameters.Add(new SqlParameter("OriginState", GetLetter().ToString() + GetLetter().ToString()));

                                try
                                {
                                    createOrder.ExecuteNonQuery();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Before the exception, THE PRODUCT ID WAS = " + RandId);
                                    throw e;
                                }


                                Console.Write(string.Format("\r{0}/{1} orders were successfully created on the server!", noOfOrdersToGenerate - (endOrderId - currentOrderId), noOfOrdersToGenerate));

                                currentOrderId++;
                            }

                            Console.WriteLine();

                        }

                        char GetLetter()
                        {
                            // This method returns a random lowercase letter.
                            // ... Between 'a' and 'z' inclusize.
                            int num = myRandom.Next(0, 26); // Zero to 25
                            char let = (char)('a' + num);
                            return let;
                        }
                    }
                }
            }

            void WriteInput(string pString)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(pString);
                Console.ResetColor();
            }

            void WriteLineError(string pString)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(pString);
                Console.ResetColor();
                Console.Write("(press enter to dismiss)");
                Console.ReadLine();
            }
        }
    }
}
