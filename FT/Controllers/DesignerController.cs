﻿using FT.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FT.Controllers
{
    public class DesignerController : Controller
    {
        public ActionResult Index(int id)
        {
            //var conn = new SqlConnection(@"Server = DESKTOP-088U1OD\SQLEXPRESS; Database = Freshtraditons; Trusted_Connection = True;");
            using (SqlConnection connection = new SqlConnection(
                           @"Server = DESKTOP-088U1OD\SQLEXPRESS; Trusted_Connection = yes; database = Freshtraditions;"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                    ("Select * FROM Designer WHERE ID = " + id +
                    " SELECT * FROM Bio WHERE Designer_ID = " + id + " ORDER BY [Order] ASC" +
                    " SELECT Name FROM Design WHERE Designer_ID = " + id + " AND Main = 0" +
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