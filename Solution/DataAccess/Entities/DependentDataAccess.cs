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
    public class DependentDataAccess : IDependentDataAccess
    {
        public List<Dependent> GetDependentList(int idEmployee)
        {
            List<Dependent> dependentList = new List<Dependent>();

            SqlConnection SqlCon = new SqlConnection(Util.SqlConnection);
            SqlCommand command = new SqlCommand(Util.QueryListDependent, SqlCon);
            command.Parameters.Add("@id_Employee", SqlDbType.Int).Value = idEmployee;

            try
            {
                SqlCon.Open();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    dependentList.Add(new Dependent()
                    {
                        Id = Convert.ToInt32(dr["id_Dependent"]),
                        Name = Convert.ToString(dr["nm_Dependent"]),
                        IdEmployee = Convert.ToInt32(dr["id_Employee"])                        
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

            return dependentList;
        }

        public void Insert(Dependent register)
        {
            SqlConnection SqlCon = new SqlConnection(Util.SqlConnection);
            SqlCommand command = new SqlCommand(Util.QueryInsertDependent, SqlCon);
            command.Parameters.Add("@nm_Dependent", SqlDbType.VarChar).Value = register.Name;
            command.Parameters.Add("@id_Employee", SqlDbType.Int).Value = register.IdEmployee;            

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

        public void Delete(int idDependent)
        {
            SqlConnection SqlCon = new SqlConnection(Util.SqlConnection);
            SqlCommand command = new SqlCommand(Util.QueryDeleteDependent, SqlCon);
            command.Parameters.Add("@id_Dependent", SqlDbType.Int).Value = idDependent;

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

        public void DeleteByEmployee(int idEmployee)
        {
            SqlConnection SqlCon = new SqlConnection(Util.SqlConnection);
            SqlCommand command = new SqlCommand(Util.QueryDeleteDependentByEmployee, SqlCon);
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
