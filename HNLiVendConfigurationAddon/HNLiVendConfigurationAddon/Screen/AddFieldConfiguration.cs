using CXS.Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HNLCore;

namespace HNLiVendConfigurationAddon.Screen
{
    public partial class AddFieldConfiguration : Form
    {
        UDF uDTObject = new UDF();

        public AddFieldConfiguration()
        {
            InitializeComponent();

            dtg_validValues.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                uDTObject.nameUDF = txt_fieldName.Text.Trim();
                uDTObject.desciptionUDF = txt_Description.Text.Trim();
                uDTObject.lengthUDF = Convert.ToInt32(txt_dataLength.Text);

                switch (cm_dataType.SelectedIndex)
                {
                    case 0: //string
                        uDTObject.UDFType = UserDefinedFieldDataType.String;
                        break;
                    case 1: //int
                        uDTObject.UDFType = UserDefinedFieldDataType.Int32;
                        break;
                    case 2: //decimal
                        uDTObject.UDFType = UserDefinedFieldDataType.Decimal;
                        break;
                    case 3: //bool
                        uDTObject.UDFType = UserDefinedFieldDataType.Boolean;
                        break;
                    case 4: //validValues
                        uDTObject.UDFType = UserDefinedFieldDataType.ValidValues;
                        break;
                    case 5: //long
                        uDTObject.UDFType = UserDefinedFieldDataType.Int64;
                        break;
                }

                uDTObject.uDFValidValues = new List<UDFValidValue>();

                for (int i = 0; i < dtg_validValues.Rows.Count; i++)
                {
                    if (dtg_validValues.Rows[i].Cells[0].Value != null || dtg_validValues.Rows[i].Cells[1].Value != null)
                    {
                        UDFValidValue validValue = new UDFValidValue();
                        validValue.id = dtg_validValues.Rows[i].Cells[0].Value.ToString();
                        validValue.description = dtg_validValues.Rows[i].Cells[1].Value.ToString();

                        uDTObject.uDFValidValues.Add(validValue);
                    }
                }

                var table_UDT = UserDefinedTableSubSystem.Instance.Load("U_ConfigurationAddon");

                if (uDTObject.UDFType != UserDefinedFieldDataType.ValidValues)
                {
                    UserDefinedField fieldUDF = table_UDT.CreateField();

                    fieldUDF.FieldName = uDTObject.nameUDF;
                    fieldUDF.Description = uDTObject.desciptionUDF;
                    fieldUDF.DataType = uDTObject.UDFType;
                    fieldUDF.DataLength = uDTObject.lengthUDF;

                    table_UDT.AddField(fieldUDF);
                }
                else
                {
                    UserDefinedField fieldUDF = table_UDT.CreateField();

                    fieldUDF.FieldName = uDTObject.nameUDF;
                    fieldUDF.Description = uDTObject.desciptionUDF;
                    fieldUDF.DataType = uDTObject.UDFType;

                    var validValueList = fieldUDF.UserDefinedFieldValidValueList;

                    foreach (var value in uDTObject.uDFValidValues)
                    {
                        UserDefinedFieldValidValue vValue = UserDefinedFieldValidValueSubSystem.Instance.Create();

                        vValue.Id = value.id;
                        vValue.Description = vValue.Description;

                        fieldUDF.AddValidValue(vValue);
                    }

                    table_UDT.AddField(fieldUDF);
                }

                CXS.Retail.BusinessLogic.UDFHelperClass.CommitUserDefinedFields(table_UDT);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                DialogResult = DialogResult.Cancel;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cm_dataType_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cm_dataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cm_dataType.SelectedIndex != 4)
            {
                dtg_validValues.Visible = false;
                dtg_validValues.BackgroundColor = Color.LightGray;
            }
            else
            {
                dtg_validValues.Visible = true;
                dtg_validValues.BackgroundColor = Color.White;
            }
        }
    }
}
