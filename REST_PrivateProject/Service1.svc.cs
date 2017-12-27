using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ModelLibrary;

namespace REST_PrivateProject
{
    // NOTE You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private Model1 catchdb = new Model1();
        private static string connectingString =
               "Server=tcp:natascha.database.windows.net,1433;Initial Catalog=School;Persist Security Info=False;User ID=nataschajakobsen;Password=Roskilde4000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";



        #region STATIC LIST
        private static List<Catch> catches = new List<Catch>()
        {
            new Catch(1,"Tas","Torsk",3.4,"Øresund",22),
            new Catch(2,"Poul","Skalle",1.2,"Furesø",23),
            new Catch(){Id=3,Navn = "Hans",Art="Ørred",Sted="Øresund",Uge=44,Vægt = 3.1}

        };
        #endregion

        #region POST
        public void AddCatch(Catch newCatch)
        {
            catches.Add(newCatch);
        }
        #endregion

        #region DELETE
        public Catch DeleteCatch(int id)
        {
            var deleteCatch = GetOneCatch(id.ToString());
            if (deleteCatch != null)
            {
                catches.Remove(deleteCatch);
                return deleteCatch;
            }

            return null;
        }
        #endregion

        #region GET
        public List<Catch> GetCatches()
        {
            return catches;
        }
        #endregion

        #region GET BY ID
        public Catch GetOneCatch(string id)
        {
            int idint = Int32.Parse(id);

            return catches.Find(c => c.Id == idint);
        }
        #endregion

        #region PUT
        public Catch UpdateCatch(Catch myCatch)
        {
            var updateCatch = GetOneCatch(myCatch.Id.ToString());
            if (updateCatch != null)
            {
                //updateCatch.Id = myCatch.Id;
                updateCatch.Navn = myCatch.Navn;
                updateCatch.Art = myCatch.Art;
                updateCatch.Vægt = myCatch.Vægt;
                updateCatch.Sted = myCatch.Sted;
                updateCatch.Uge = myCatch.Uge;
                return updateCatch;
            }

            return null;
        }
        #endregion

        #region GET DB
        public List<Catchings> GetCatchesDB()
        {
            return catchdb.Catches.ToList();
        }
        #endregion

        #region GET V2 DB
        public List<Catchings> GetCatchesv2DB()
        {
            List<Catchings> liste = new List<Catchings>();
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                conn.Open();
                String sql = "SELECT * FROM Catch";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Catchings c = new Catchings
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Species = reader.GetString(2),
                        Weigtht = reader.GetDecimal(3),
                        Place = reader.GetString(4),
                        Week = reader.GetInt32(5)
                    };
                    liste.Add(c);
                }

            }

            return liste;
        }
        #endregion

        #region GET BY ID DB
        public Catchings GetOneCatchDB(string id)
        {
            int idint = Int32.Parse(id);
            return catchdb.Catches.ToList().Find(c => c.Id == idint);
            
        }
        #endregion
    }
}
