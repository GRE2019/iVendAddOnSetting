using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CXS.Retail.UIComponents;
using GRE_Connection;
using GRE_Model;
using CXS.Retail.ManagementUIComponents;
using MessageView;

namespace GRE_UI.Views
{
    public partial class SettingView : BaseConsoleCustomView
    {
        #region Control Related Declarations

        DataGridViewCellStyle uCellStyle;
        DataGridViewCellStyle sCellStyle;

        //Alternate cell styles
        DataGridViewCellStyle uACellStyle;

        DataGridViewCellStyle upCellStyle;
        DataGridViewCellStyle uHeaderStyle;

        DataGridView dataGridView = new DataGridView();

        #endregion

        long configurationKey = 0;

        List<AddOnField> addOnFields = new List<AddOnField>();
        public SettingView(long configurationKey)
        {
            this.configurationKey = configurationKey;

            InitializeComponent();

            Title = "Datos de Configuración";

            m_Button1.Visible = true;
            m_Button1.Text = "Crear Nuevo";
            m_Button1.Click += M_Button1_Click;

            m_Button11.Visible = true;
            m_Button11.Text = "Aceptar";
            m_Button11.Click += M_Button11_Click;

            m_Button12.Visible = true;
            m_Button12.Text = "Cancelar";
            m_Button12.Click += M_Button12_Click;

            dataGridView.Columns.Add("field", "Campo");
            dataGridView.Columns.Add("value", "Valor");

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView.Columns[0].Width = 300;

            dataGridView.Dock = DockStyle.Fill;
            Controls.Add(dataGridView);
            dataGridView.BringToFront();
            dataGridView.BackgroundColor = Color.White;

            LoadGrid(dataGridView);
            SetGridStyle(dataGridView);
        }

        private void M_Button12_Click(object sender, EventArgs e)
        {
            ConsoleViewManager.Instance.Pop();
        }

        private void M_Button11_Click(object sender, EventArgs e)
        {
            MessageScreenView messageScreenView = new MessageScreenView(MessageType.INFORMATION, "¿Guardar configuración?");

            messageScreenView.ShowDialog();

            if (messageScreenView.DialogResult == DialogResult.OK)
            {
                List<AddOnField> listAddOnFields = new List<AddOnField>();

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    AddOnField addOnField = new AddOnField();

                    if (addOnFields[i].type == 8 || addOnFields[i].type == 2)
                    {
                        long value = 0;

                        if (long.TryParse(dataGridView.Rows[i].Cells[1].Value.ToString(), out value))
                        {
                            addOnField.columnName = dataGridView.Rows[i].Cells[0].Value.ToString();
                            addOnField.value = dataGridView.Rows[i].Cells[1].Value.ToString();
                        }
                        else
                        {
                            addOnField.columnName = dataGridView.Rows[i].Cells[0].Value.ToString();
                            addOnField.value = "0";
                        }
                    }
                    else
                    {
                        addOnField.columnName = dataGridView.Rows[i].Cells[0].Value.ToString();
                        addOnField.value = dataGridView.Rows[i].Cells[1].Value.ToString();
                    }

                    listAddOnFields.Add(addOnField);
                }

                if (configurationKey != 0)
                {
                    string result = Connection.Instance.UpdateAddOnConfiguration(listAddOnFields, configurationKey);
                }
                else
                {
                    string result = Connection.Instance.CreateAddOnConfiguration(listAddOnFields);
                }

                listAddOnFields.Clear();
                addOnFields.Clear();

                ConsoleViewManager.Instance.Pop();
            }
        }

        private void M_Button1_Click(object sender, EventArgs e)
        {
            ConsoleViewManager.Instance.Pop();
        }

        private void SetGridStyle(DataGridView dataGridView)
        {
            //iVend borra el estilo de los grid (?)                    

            uCellStyle = new DataGridViewCellStyle();
            //uCellStyle.Font = new Font("Tahoma", 9, FontStyle.Regular);
            uCellStyle.BackColor = Color.White;
            uCellStyle.ForeColor = Color.Black;

            sCellStyle = new DataGridViewCellStyle();
            //sCellStyle.Font = new Font("Tahoma", 9, FontStyle.Regular);
            sCellStyle.BackColor = Color.White;
            sCellStyle.ForeColor = Color.Black;

            uACellStyle = new DataGridViewCellStyle();
            //uACellStyle.Font = new Font("Tahoma", 9, FontStyle.Regular);
            uACellStyle.BackColor = Color.FromArgb(174, 221, 255);
            uACellStyle.ForeColor = Color.Black;

            upCellStyle = new DataGridViewCellStyle();
            //upCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
            upCellStyle.BackColor = Color.White;
            upCellStyle.ForeColor = Color.Black;

            uHeaderStyle = new DataGridViewCellStyle();
            //uHeaderStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            uHeaderStyle.BackColor = Color.LightGray;
            uHeaderStyle.ForeColor = Color.DarkBlue;
            uHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.RowsDefaultCellStyle = uCellStyle;
            //dataGridView.AlternatingRowsDefaultCellStyle = uACellStyle; //uACellStyle;
            dataGridView.ColumnHeadersDefaultCellStyle = uHeaderStyle;
            dataGridView.AllowUserToAddRows = false;

            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.ColumnHeadersVisible = false;

            //gridInvoice.RowTemplate.Height = 30;
            foreach (DataGridViewColumn c in dataGridView.Columns) { c.SortMode = DataGridViewColumnSortMode.NotSortable; }

            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.RowsDefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
        }

        public void LoadGrid(DataGridView dtg)
        {
            //configurationKey = Connection.Instance.SelectAddOnConfigurationKey();

            if (configurationKey == 0)
            {
                ShowWarning("La Tabla de Configuración esta vacía.");
            }

            addOnFields = Connection.Instance.GetRowName(configurationKey);

            addOnFields = addOnFields.OrderBy(o => o.columnName).ToList();

            foreach (var field in addOnFields)
            {
                dtg.Rows.Add(field.columnName, field.value);
            }

            for (int i = 0; i < addOnFields.Count; i++)
            {
                dtg.Rows[i].Cells[0].ToolTipText = addOnFields[i].columnDescription;

                switch (addOnFields[i].type)
                {

                    case 6:
                        DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();

                        List<ValidValue> validValues = Connection.Instance.GetValidValues(addOnFields[i].columnKey);

                        foreach (var value in validValues)
                        {
                            comboBoxCell.Items.Add(value.id);
                        }

                        dtg.Rows[i].Cells[1] = comboBoxCell;

                        if (addOnFields[i].value != null || addOnFields[i].value != "")
                        {
                            dtg.Rows[i].Cells[1].Value = addOnFields[i].value;
                        }
                        else
                        {
                            dtg.Rows[i].Cells[1].Value = "";
                        }

                        break;
                    case 9:
                        DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();

                        dtg.Rows[i].Cells[1] = checkBoxCell;

                        dtg.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        if (addOnFields[i].value.ToLower() != "true" && addOnFields[i].value.ToLower() != "false")
                        {
                            dtg.Rows[i].Cells[1].Value = false;
                        }
                        else
                        {
                            dtg.Rows[i].Cells[1].Value = addOnFields[i].value;
                        }

                        break;
                }
            }
        }

        //public void OpenDUF()
        //{
        //    AddFieldConfiguration addFieldConfiguration = new AddFieldConfiguration();

        //    addFieldConfiguration.ShowDialog();

        //    if (addFieldConfiguration.DialogResult == DialogResult.OK)
        //    {
        //        ConsoleViewManager.Instance.Pop();
        //    }
        //}
    }
}
