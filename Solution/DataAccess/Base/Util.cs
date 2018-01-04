using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public class Util
    {
        public const string SqlConnection = @"Integrated Security=SSPI; Data Source=.\SQLExpress;Initial Catalog=master";

        #region [ Role ]
        public const string QueryListRole = "SELECT * FROM cm.Role";
        #endregion

        #region [ Employee ]
        public const string QueryListEmployee = "SELECT * FROM cm.Employee E INNER JOIN cm.Role r on r.id_Role = e.id_Role";
        public const string QueryGetEmployeeById = "SELECT * FROM cm.Employee E INNER JOIN cm.Role r on r.id_Role = e.id_Role WHERE @id_Employee = e.id_Employee";
        public const string QueryInsertEmployee = "INSERT INTO cm.Employee OUTPUT INSERTED.id_Employee VALUES (@nm_Employee, @ds_Email, @tp_Genre, @dt_Birth, @id_Role)";
        public const string QueryUpdateEmployee = "UPDATE cm.Employee set nm_Employee = @nm_Employee, ds_Email = @ds_Email, tp_Genre = @tp_Genre, dt_Birth = @dt_Birth, id_Role = @id_Role WHERE id_Employee = @id_Employee";
        public const string QueryDeleteEmployee = "DELETE FROM cm.Employee WHERE @id_Employee = id_Employee";
        #endregion

        #region [ Dependent ]
        public const string QueryListDependent = "SELECT * FROM cm.Dependent WHERE id_Employee = @id_Employee";
        public const string QueryInsertDependent = "INSERT INTO cm.Dependent VALUES (@nm_Dependent, @id_Employee)";
        public const string QueryDeleteDependent = "DELETE FROM cm.Dependent WHERE @id_Dependent = id_Dependent";
        public const string QueryDeleteDependentByEmployee = "DELETE FROM cm.Dependent WHERE @id_Employee = id_Employee";
        #endregion
    }
}
