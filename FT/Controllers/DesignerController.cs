using FT.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace FT.Controllers
{
    public class DesignerController : Controller
    {
        public ActionResult Index(int id)
        {
            
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FreshTraditionsConnection"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                    ("SELECT * FROM Designer WHERE ID = " + id +

                    " SELECT * FROM Bio WHERE Designer_ID = " + id + " ORDER BY [Order] ASC" +

                    " SELECT d.Name FROM Design d INNER JOIN DesignOrder do ON d.ID = do.Design_ID INNER JOIN Designer dsr " +
                    "ON d.Designer_ID = dsr.ID WHERE dsr.ID = " + id + " ORDER BY dsr.ID, do.[Order]" +

                    " SELECT Name, Description FROM Design WHERE Designer_ID = " + id + " AND Main = 1", connection);

                SqlDataReader reader = command.ExecuteReader();

                var designerModel = new DesignerViewModel();

                while (reader.Read())
                {
                    designerModel.Name = reader[1].ToString();
                    designerModel.HeadShot = reader[2].ToString();
                    designerModel.ImageFolderName = reader[3].ToString();
                }

                reader.NextResult();

                while (reader.Read())
                {
                    designerModel.Bio.Add(reader[2].ToString());
                }



                reader.NextResult();

                while (reader.Read())
                {
                    designerModel.Designs.Add(reader[0].ToString());
                }

                reader.NextResult();

                reader.Read();

                designerModel.MainDesign = reader[0].ToString();

                designerModel.Description = reader[1].ToString();

                return View(designerModel);
            }
        }
    }
}