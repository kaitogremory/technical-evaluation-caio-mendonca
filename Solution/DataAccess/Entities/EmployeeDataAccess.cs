using Common.Entities;
using Common.Enums;
using Common.Interfaces;
using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        public List<Employee> GetEmployeeList()
        {
            List<Employee> employeeList = new List<Employee>();

            SqlConnection SqlCon = new SqlConnection(Util.SqlConnection);
            SqlCommand command = new SqlCommand(Util.QueryListEmployee, SqlCon);           

            try
            {
                SqlCon.Open();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    employeeList.Add(new Employee()
                    {
                        Id = Convert.ToInt32(dr["id_Employee"]),
                        Name = Convert.ToString(dr["nm_Employee"]),
                        Birth = Convert.ToDateTime(dr["dt_Birth"]),
                        Email = Convert.ToString(dr["ds_Email"]),
                        Genre = (EnumGenre)Convert.ToInt32(dr["tp_Genre"]),
                        Role = new Role()
                        {
                            Id = Convert.ToInt32(dr["id_Role"]),
                            Name = Convert.ToString(dr["nm_Role"]) 
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }

            return employeeList;
        }

        public Employee GetEmployeeById(int idEmployee)
        {
            Employee register;

            SqlConnection SqlCon = new SqlConnection(Util.SqlConnection);
            SqlCommand command = new SqlCommand(Util.QueryGetEmployeeById, SqlCon);
            command.Parameters.Add("@id_Employee", SqlDbType.Int).Value = idEmployee;

            try
            {
                SqlCon.Open();
                SqlDataReader dr = command.ExecuteReader();

                dr.Read();

                register = new Employee()
                {
                    Id = Convert.ToInt32(dr["id_Employee"]),
                    Name = Convert.ToString(dr["nm_Employee"]),
                    Birth = Convert.ToDateTime(dr["dt_Birth"]),
                    Email = Convert.ToString(dr["ds_Email"]),
                    Genre = (EnumGenre)Convert.ToInt32(dr["tp_Genre"]),
                    Role = new Role()
                    {
                        Id = Convert.ToInt32(dr["id_Role"]),
                        Name = Convert.ToString(dr["nm_Role"])
                    }
                };                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }

            return register;
        }
        
        public void Insert(Employee register)
        {
            SqlConnection SqlCon = new SqlConnection(Util.SqlConnection);
            SqlCommand command = new SqlCommand(Util.QueryInsertEmployee, SqlCon);                        
            command.Parameters.Add("@nm_Employee", SqlDbType.VarChar).Value = register.Name;
            command.Parameters.Add("@ds_Email", SqlDbType.VarChar).Value = register.Email;
            command.Parameters.Add("@tp_Genre", SqlDbType.Int).Value = (int)register.Genre;
            command.Parameters.Add("@dt_Birth", SqlDbType.DateTime).Value = register.Birth;
            command.Parameters.Add("@id_Role", SqlDbType.Int).Value = register.Role.Id;

            try
            {
                SqlCon.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }
        }

        public void Update(Employee register)
        {
            SqlConnection SqlCon = new SqlConnection(Util.SqlConnection);
            SqlCommand command = new SqlCommand(Util.QueryUpdateEmployee, SqlCon);
            command.Parameters.Add("@id_Employee", SqlDbType.Int).Value = register.Id;
            command.Parameters.Add("@nm_Employee", SqlDbType.VarChar).Value = register.Name;
            command.Parameters.Add("@ds_Email", SqlDbType.VarChar).Value = register.Email;
            command.Parameters.Add("@tp_Genre", SqlDbType.Int).Value = (int)register.Genre;
            command.Parameters.Add("@dt_Birth", SqlDbType.DateTime).Value = register.Birth;
            command.Parameters.Add("@id_Role", SqlDbType.Int).Value = register.Role.Id;

            try
            {
                SqlCon.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }
        }

        public void Delete(int idEmployee)
        {
            SqlConnection SqlCon = new SqlConnection(Util.SqlConnection);
            SqlCommand command = new SqlCommand(Util.QueryDeleteEmployee, SqlCon);
            command.Parameters.Add("@id_Employee", SqlDbType.Int).Value = idEmployee;

            try
            {
                SqlCon.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }
        }
    }
}
