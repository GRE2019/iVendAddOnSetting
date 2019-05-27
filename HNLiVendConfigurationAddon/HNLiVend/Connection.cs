using CXS.Framework.Core;
using CXS.Platform.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNLCore;

namespace HNLiVend
{
    public class Connection
    {
        private static Connection instance;
        private static readonly object padlock = new object();

        private UserDefinedTableSubSystem UDFSubSystem;
        private IDbConnection SqlConnection;

        private const int TimesForRetry = 3;
        private const int DelayOnRetry = 1000;

        private Connection()
        {
            UDFSubSystem = UserDefinedTableSubSystem.Instance;
            SqlConnection = SessionManager.Instance.CurrentSession.Connection;
        }

        public static Connection Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Connection();
                    }
                    return instance;
                }
            }
        }

        public string CreateAddOnConfiguration(List <AddOnField> addOnFields)
        {
            string result = "";
            try
            {
                UserDefinedTable table = UDFSubSystem.Load("U_Table1");

                UDTRow row = UDTRowSubSystem.Instance.Create(table);

                foreach (var field in addOnFields)
                {
                    row.UserDefinedFields[field.columnName] = field.value;
                }

                row.UserDefinedFields["U_IsActive"] = false;

                UDTRowSubSystem.Instance.Commit(row);

                result = "Done!";
            }
            catch (Exception ex)
            {
                result = ex.ToString();    
            }

            return result;
        }

        public string UpdateAddOnConfiguration(List<AddOnField> addOnFields, long configurationKey)
        {
            string result = "";

            try
            {
                UserDefinedTable table = UDFSubSystem.Load("U_Table1");
                UDTRow row = UDTRowSubSystem.Instance.LoadByKey(table, configurationKey);

                if (row != null)
                {
                    foreach (var field in addOnFields)
                    {
                        row.UserDefinedFields[field.columnName] = field.value;
                    }

                    UDTRowSubSystem.Instance.Commit(row);

                    result = "Done!";
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }

        public string UpdateActive(long configurationKey, bool value)
        {
            string result = "";

            try
            {
                UserDefinedTable table = UDFSubSystem.Load("U_Table1");
                List<UDTRow> rowList = UDTRowSubSystem.Instance.LoadList(table);

                foreach (var row in rowList)
                {
                    row.UserDefinedFields["U_IsActive"] = false;

                    if (row.Key == configurationKey)
                    {
                        row.UserDefinedFields["U_IsActive"] = value;
                    }

                    UDTRowSubSystem.Instance.Commit(row);
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }

        public string DeleteAddOnConfiguration(long configurationKey)
        {
            string result = "";

            try
            {
                UserDefinedTable table = UDFSubSystem.Load("U_Table1");
                UDTRow row = UDTRowSubSystem.Instance.LoadByKey(table, configurationKey);

                if (row != null)
                {
                    UDTRowSubSystem.Instance.Delete(row);

                    UDTRowSubSystem.Instance.Commit(row);

                    result = "Done!";
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }

        public long SelectAddOnConfigurationKey()
        {
            long key = 0;

            string query = string.Format("Select ConfigurationAddonKey from U_Table1");

            IDbConnection connection = SqlConnection;
            IDbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = query;

            DataSet result = new DataSet();
            result = SessionManager.Instance.FillDataSet(dbCommand);

            foreach (DataRow row in result.Tables[0].Rows)
            {
                key = Convert.ToInt64(row["ConfigurationAddonKey"].ToString());
            }

            return key;
        }

        public List<Configuration> ConfigurationList()
        {
            List<Configuration> configurationList = new List<Configuration>();

            string query = string.Format("Select * from U_Table1");

            IDbConnection connection = SqlConnection;
            IDbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = query;

            DataSet result = new DataSet();
            result = SessionManager.Instance.FillDataSet(dbCommand);

            foreach (DataRow row in result.Tables[0].Rows)
            {
                Configuration configuration = new Configuration();

                configuration.configurationKey = Convert.ToInt64(row["ConfigurationAddonKey"].ToString());
                configuration.AludraPortal = row["U_AludraPortal"].ToString();
                configuration.isActive = Convert.ToBoolean(row["U_IsActive"].ToString());

                configurationList.Add(configuration);
            }

            return configurationList;
        }

        public List<AddOnField> GetRowName(long configurationKey)
        {
            string query = "Select * from CfgUserDefinedFieldDetail where UserDefinedTableKey = (Select UserDefinedTableKey from CfgUserDefinedTable where TableName = 'U_Table1')";

            List<AddOnField> addOnFields = new List<AddOnField>();

            try
            {
                IDbConnection connection = SqlConnection;
                IDbCommand dbCommand = connection.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = query;

                DataSet result = new DataSet();
                result = SessionManager.Instance.FillDataSet(dbCommand);


                if (result.Tables[0].Rows.Count <= 0)
                {
                    return null;
                }

                foreach (DataRow row in result.Tables[0].Rows)
                {
                    AddOnField addOnField = new AddOnField();
                    addOnField.columnName = row["FieldName"].ToString();
                    addOnField.columnDescription = row["Description"].ToString();
                    addOnField.type = Convert.ToInt32(row["DataType"].ToString());
                    addOnField.value = valueConfiguration(addOnField.columnName, configurationKey);
                    addOnField.columnKey = Convert.ToInt64(row["UserDefinedFieldDetailKey"].ToString());

                    if (addOnField.columnName != "U_IsActive")
                    {
                        addOnFields.Add(addOnField);
                    }
                }
                return addOnFields;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ValidValue> GetValidValues(long validValueKey)
        {
            string query =  string.Format("Select * from CfgUserDefinedFieldValidValue where UserDefinedFieldDetailKey = {0}",validValueKey);

            List<ValidValue> listValidValues = new List<ValidValue>();

            try
            {
                IDbConnection connection = SqlConnection;
                IDbCommand dbCommand = connection.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = query;

                DataSet result = new DataSet();
                result = SessionManager.Instance.FillDataSet(dbCommand);


                if (result.Tables[0].Rows.Count <= 0)
                {
                    return null;
                }

                foreach (DataRow row in result.Tables[0].Rows)
                {
                    ValidValue value = new ValidValue();
                    value.id = row["Id"].ToString();
                    value.description = row["Description"].ToString();

                    listValidValues.Add(value);
                }

                return listValidValues;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public string valueConfiguration(string columnName, long configurationKey)
        {
            string columnValue = "";
            string query = string.Format("Select {0} from U_Table1 where ConfigurationAddonKey = {1}", columnName, configurationKey);

            IDbConnection connection = SqlConnection;
            IDbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = query;

            DataSet result = new DataSet();
            result = SessionManager.Instance.FillDataSet(dbCommand);

            foreach (DataRow row in result.Tables[0].Rows)
            {
                columnValue = row[columnName].ToString();
            }

            if (columnValue == null)
            {
                columnValue = "";
            }

            return columnValue; ;
        }

        public List<UDTRow> GetValuesConfigurationUDF()
        {
            List<UDTRow> uDTRows = new List<UDTRow>();

            List<UDTRow> deleteRows = new List<UDTRow>();

            try
            {
                UserDefinedTable table = UDFSubSystem.Load("U_Table1");

                uDTRows = UDTRowSubSystem.Instance.LoadList(table);

                for(int i = 0; i< uDTRows.Count;i++)
                {
                    if (uDTRows[i].IsDeleted == true)
                    {
                        deleteRows.Add(uDTRows[i]);
                    }
                }

                foreach (var key in deleteRows)
                {
                    uDTRows.Remove(key);
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return uDTRows;
        }
    }
}
