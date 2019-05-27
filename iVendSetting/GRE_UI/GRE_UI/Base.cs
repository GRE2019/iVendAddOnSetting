using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CXS.Framework.Core;
using CXS.Retail.Extensibility;
using GRE_Model;

namespace GRE_UI
{
    public class Base : BasePlugin
    {
        UserDefinedTable table_UDT;

        List<UDF> listUDF = new List<UDF>();
        public override string Name => "AddOn Configuration";

        public override string CompanyName => "Global Retail Experts";

        public override string Description => "AddOn de configuación para AddOns de POS y MC";

        public override Version VersionInfo => new Version("1.0.0.0");

        public override void Start()
        {

            AppExtensibilityContext.AddConsoleMenuItem(new Menu());
        }

        public void CreateUDT(string nameUDT, string descriptionUDT, List<UDF> listUDF = null)
        {
            table_UDT = UserDefinedTableSubSystem.Instance.Load(nameUDT);

            if (table_UDT == null)
            {
                table_UDT = UserDefinedTableSubSystem.Instance.Create();
                table_UDT.TableName = nameUDT;
                table_UDT.Description = descriptionUDT;
                table_UDT.IsHistoryTracked = false;
                table_UDT.AllowImportExport = false;
            }

            if (listUDF != null)
            {
                foreach (var udf in listUDF)
                {
                    UserDefinedField fieldUDF = table_UDT.Fields.FirstOrDefault(d => d.FieldName == udf.nameUDF);

                    if (fieldUDF == null)
                    {
                        fieldUDF = table_UDT.CreateField();

                        fieldUDF.FieldName = udf.nameUDF;
                        fieldUDF.Description = udf.desciptionUDF;
                        fieldUDF.DataType = udf.UDFType;
                        fieldUDF.DataLength = udf.lengthUDF;

                        if (udf.UDFType == UserDefinedFieldDataType.ValidValues)
                        {
                            var validValueList = fieldUDF.UserDefinedFieldValidValueList;

                            foreach (var value in udf.uDFValidValues)
                            {
                                UserDefinedFieldValidValue vValue = UserDefinedFieldValidValueSubSystem.Instance.Create();

                                vValue.Id = value.id;
                                vValue.Description = vValue.Description;

                                fieldUDF.AddValidValue(vValue);
                            }
                        }

                        table_UDT.AddField(fieldUDF);

                        CXS.Retail.BusinessLogic.UDFHelperClass.CommitUserDefinedFields(table_UDT);
                    }


                }
            }
        }
    }
}
