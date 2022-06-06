using Microsoft.Data.SqlClient;
using SproutNet.Models;
using System.Text;

namespace SproutNet.Shared
{
    public class MasterData
    {
        public Fruit[] fruits;

        public MasterData()
        {
            List<Fruit> returnList = new List<Fruit>();
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=.\\SQLExpress;Initial Catalog=ApplicationData;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Trusted_Connection=true;Connection Timeout=30;"))
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM Fruit");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Fruit tempFruit = new Fruit();
                                tempFruit.Name = reader[0].ToString();
                                tempFruit.Type = reader[1].ToString();
                                tempFruit.SubType = reader[2].ToString();
                                returnList.Add(tempFruit);
                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            returnList.OrderBy(fruit => fruit.Name).ToList();
            fruits = returnList.ToArray();
        }
    }
}
