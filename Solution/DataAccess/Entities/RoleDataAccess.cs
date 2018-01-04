using Common.Entities;
using Common.Enums;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccess.Base;

namespace DataAccess.Entities
{
    public class RoleDataAccess : IRoleDataAccess
    {        
        public List<Role> GetRoleList()
        {
            List<Role> roleList = new List<Role>();

            SqlConnection SqlCon = new SqlConnection(Util.SqlConnection);
            SqlCommand command = new SqlCommand(Util.QueryListRole, SqlCon);            

            try 
	        {	        
		        SqlCon.Open();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    roleList.Add( new Role()
                    {
                        Id = Convert.ToInt32(dr["id_Role"]),
                        Name = Convert.ToString(dr["nm_Role"])
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

            return roleList;                                                
        }     
    }
}
