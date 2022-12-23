using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesData.Interface;
using VehiclesData.Model;

namespace VehiclesData.Repository
{

    public class VehicleRepository:IVehicle
    {
        // string ConnectionString = @"data source=VM1122;initial catalog=master;user id=sa;password=myadmin";   

        public string CreateVehicle(int Year, string Make, string Model,string conStr)
        {
            DataTable NewVehicle = new DataTable();
            string message;
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.Create_NewVehicle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Year", SqlDbType.Int).Value = int.Parse(Year.ToString()); ;
                    cmd.Parameters.Add("@Make", SqlDbType.VarChar).Value = Make.ToString();
                    cmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = Model.ToString();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    NewVehicle = ds.Tables[0];
                    con.Close();
                }
            }
            catch (Exception exception)
            {
                //Logger.WriteToLogFile("DALCreateVehicle :" + exception.Message);
            }
            message=NewVehicle.Rows[0]["Messages"].ToString();
            return message;
        }

        public List<Vehicle> GetVehicleById(int id,string conStr)
        {
            DataTable VehicleSet = new DataTable();
            List<Vehicle> vehicleList = new List<Vehicle>();
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.Get_VehicleDetailsByID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Int32.Parse(id.ToString());
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    VehicleSet = ds.Tables[0];
                    con.Close();
                    foreach (DataRow vehicleDr in VehicleSet.Rows)
                    {
                        Vehicle item = new Vehicle();
                        item.Id = int.Parse(vehicleDr[0].ToString());
                        item.Year = int.Parse(vehicleDr[1].ToString());
                        item.Make = vehicleDr[2].ToString();
                        item.Model = vehicleDr[3].ToString();
                        vehicleList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
               // Logger.WriteToLogFile("DALGetVehicleById :" + ex.Message);

            }
            return vehicleList;
        }

        public List<Vehicle> GetVehicles(string conStr)
        {
            DataTable VehicleSet = new DataTable();
            List<Vehicle> vehicleList = new List<Vehicle>();
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.Get_VehiclesDetails";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    VehicleSet = ds.Tables[0];
                    //Logger.WriteToLogFile(VehicleSet.ToString());
                    con.Close();
                    foreach (DataRow vehicleDr in VehicleSet.Rows)
                    {
                        Vehicle item = new Vehicle();
                        item.Id = int.Parse(vehicleDr[0].ToString());
                        item.Year = int.Parse(vehicleDr[1].ToString());
                        item.Make = vehicleDr[2].ToString();
                        item.Model = vehicleDr[3].ToString();
                        vehicleList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.WriteToLogFile("DALGetVehicles :" + ex.Message);

            }
            return vehicleList;
        }

        public string RemoveVehicles(int id, string conStr)
        {           
            DataTable DeleteVehicle = new DataTable();
            string message;

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[dbo].[Remove_VehicleDetails]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(id.ToString());
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DeleteVehicle = ds.Tables[0];
                    con.Close();
                }
            }
            catch (Exception exception)
            {
               // Logger.WriteToLogFile("DALDeleteVehicle :" + exception.Message);
            }
            message = DeleteVehicle.Rows[0]["Messages"].ToString();
            return message;
        }

        public string UpdateVehicles(int id, int Year, string Make, string Model, string conStr)
        {
            
            DataTable UpdateVehicle = new DataTable();
            string message;
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[dbo].[Update_VehicleDetails]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(id.ToString());
                    cmd.Parameters.Add("@Year", SqlDbType.Int).Value = int.Parse(Year.ToString()); ;
                    cmd.Parameters.Add("@Make", SqlDbType.VarChar).Value = Make.ToString();
                    cmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = Model.ToString();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    UpdateVehicle = ds.Tables[0];
                    con.Close();
                }
            }
            catch (Exception exception)
            {
                //Logger.WriteToLogFile("DALUpdateVehicle :" + exception.Message);
            }
            message = UpdateVehicle.Rows[0]["Messages"].ToString();
            return message;
        }
    }
}
