using CXS.Framework.Core;
using CXS.Retail.Extensibility;
using CXS.SubSystem.RetailConfig;
using CXS.SubSystem.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HNLCore;
using CXS.SubSystem.Labor;

namespace HNLiVendConfigurationAddon
{
    class Base : BasePlugin
    {
        UserDefinedTable table_UDT;

        List<UDF> listUDF = new List<UDF>();

        public override string Name
        {
            get { return "AddOn Setting"; }
        }

        public override string CompanyName
        {
            get { return "Global Retail Experts"; }
        }

        public override string Description
        {
            get { return "AddOn para guardar datos de configuración"; }
        }

        public override Version VersionInfo
        {
            get { return new Version("1.0.0.0"); }
        }

        public override void Start()
        {
            try
            {
                CreateUDT("U_Table1", "Tabla de Configuracion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());    
            }

            AppExtensibilityContext.AddConsoleMenuItem(new MenuAddOnConfiguration());
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

        public List<UDF> listUDFtoCreate()
        {
            List<UDF> uDFs = new List<UDF>();

            UDF item1 = new UDF();

            item1.nameUDF = "U_ClubProductKey";
            item1.desciptionUDF = "ProductKey del articulo semanas de un club";
            item1.UDFType = UserDefinedFieldDataType.String;
            item1.lengthUDF = 200;
            uDFs.Add(item1);

            UDF item2 = new UDF();

            item2.nameUDF = "U_ClubPaymentWeeks";
            item2.desciptionUDF = "Cant semanas que se pueden pagar por transaccion";
            item2.UDFType = UserDefinedFieldDataType.Int32;
            item2.lengthUDF = 0;
            uDFs.Add(item2);

            UDF item3 = new UDF();

            item3.nameUDF = "U_ClubPathUser";
            item3.desciptionUDF = "Ruta XML para imprimir";
            item3.UDFType = UserDefinedFieldDataType.String;
            item3.lengthUDF = 200;
            uDFs.Add(item3);

            UDF item4 = new UDF();

            item4.nameUDF = "U_ClubRefundBalance";
            item4.desciptionUDF = "Saldo utilizado a un club. true-false";
            item4.UDFType = UserDefinedFieldDataType.Boolean;
            item4.lengthUDF = 0;
            uDFs.Add(item4);

            UDF item5 = new UDF();

            item5.nameUDF = "U_AludraApiManagement";
            item5.desciptionUDF = "URL de los Apis de Aludra";
            item5.UDFType = UserDefinedFieldDataType.String;
            item5.lengthUDF = 200;
            uDFs.Add(item5);

            UDF item6 = new UDF();

            item6.nameUDF = "U_AludraTenant";
            item6.desciptionUDF = "Base de datos, APis de Core";
            item6.UDFType = UserDefinedFieldDataType.Int32;
            item6.lengthUDF = 0;
            uDFs.Add(item6);

            UDF item7 = new UDF();

            item7.nameUDF = "U_AludraApiKey";
            item7.desciptionUDF = "Api_Key de Aludra";
            item7.UDFType = UserDefinedFieldDataType.String;
            item7.lengthUDF = 1000;
            uDFs.Add(item7);

            UDF item8 = new UDF();

            item8.nameUDF = "U_AludraApiSubKey";
            item8.desciptionUDF = "Api SubscriptionKey Apis de Aludra";
            item8.UDFType = UserDefinedFieldDataType.String;
            item8.lengthUDF = 1000;
            uDFs.Add(item8);

            //ValidValues
            UDF item9 = new UDF();

            item9.nameUDF = "U_ClubPrintMethod";
            item9.desciptionUDF = "Elegir metodo de impresion XML-JSON";
            item9.UDFType = UserDefinedFieldDataType.ValidValues;
            item9.lengthUDF = 50;

            UDFValidValue validValue1 = new UDFValidValue();
            validValue1.id = "XML";
            validValue1.description = "XML";

            item9.uDFValidValues = new List<UDFValidValue>();
            item9.uDFValidValues.Add(validValue1);

            UDFValidValue validValue2 = new UDFValidValue();

            validValue2.id = "JSON";
            validValue2.description = "JSON";
            item9.uDFValidValues.Add(validValue2);

            uDFs.Add(item9);

            //ValidValues

            UDF item10 = new UDF();

            item10.nameUDF = "U_AludraPortal";
            item10.desciptionUDF = "Para seleccionar el portal";
            item10.UDFType = UserDefinedFieldDataType.ValidValues;
            item10.lengthUDF = 50;

            UDFValidValue validValue3 = new UDFValidValue();

            validValue3.id = "prod";
            validValue3.description = "prod";

            item10.uDFValidValues = new List<UDFValidValue>();

            item10.uDFValidValues.Add(validValue3);

            UDFValidValue validValue4 = new UDFValidValue();

            validValue4.id = "qa";
            validValue4.description = "qa";
            item10.uDFValidValues.Add(validValue4);

            UDFValidValue validValue5 = new UDFValidValue();

            validValue5.id = "dev";
            validValue5.description = "dev";

            item10.uDFValidValues.Add(validValue5);

            uDFs.Add(item10);

            UDF item11 = new UDF();

            item11.nameUDF = "U_IsActive";
            item11.desciptionUDF = "Configuracion Activa";
            item11.UDFType = UserDefinedFieldDataType.Boolean;
            uDFs.Add(item11);

            //Valid value
            UDF item12 = new UDF();

            item12.nameUDF = "U_ClubTypePrint";
            item12.desciptionUDF = "Usara Laika o Impresora de recibos.";
            item12.UDFType = UserDefinedFieldDataType.ValidValues;
            item12.lengthUDF = 50;

            UDFValidValue validValue6 = new UDFValidValue();
            validValue6.id = "LAIKA";
            validValue6.description = "Usar Laika como impresora";

            item12.uDFValidValues = new List<UDFValidValue>();
            item12.uDFValidValues.Add(validValue6);

            UDFValidValue validValue7 = new UDFValidValue();
            validValue7.id = "RECIBOS";
            validValue7.description = "Utilizar impresora de recibos.";

            item12.uDFValidValues.Add(validValue7);

            uDFs.Add(item12);

            return uDFs;
        }
    }
}
