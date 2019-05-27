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
using HNLCore;
using HNLiVend;
using CXS.Retail.ManagementUIComponents;
using CXS.Framework.Core;
namespace HNLiVendConfigurationAddon.Screen
{
    public partial class ConfigurationList : BaseConsoleCustomView
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

        List<Configuration> configurations = new List<Configuration>();

        long configurationKey = -1;

        public ConfigurationList()
        {
            InitializeComponent();

            Title = "Lista de Configuraciones";

            m_Button1.Visible = true;
            m_Button1.Text = "Editar";
            m_Button1.Click += M_Button1_Click;

            m_Button2.Visible = true;
            m_Button2.Text = "Añadir Configuración";
            m_Button2.Click += M_Button2_Click;

            m_Button3.Visible = true;
            m_Button3.Text = "Eliminar Configuración";
            m_Button3.Click += M_Button3_Click;


            m_Button11.Visible = true;
            m_Button11.Text = "Aceptar";
            m_Button11.Click += M_Button11_Click;
            m_Button11.BackColor = Color.DarkSeaGreen;
            m_Button11.ForeColor = Color.White;

            m_Button12.Visible = true;
            m_Button12.Text = "Cancelar";
            m_Button12.Click += M_Button12_Click;
            m_Button11.BackColor = Color.IndianRed;
            m_Button11.ForeColor = Color.White;

            dataGridView.Columns.Add("key", "Llave");
            dataGridView.Columns.Add("value", "U_AludraPortal");
            dataGridView.Columns.Add("active", "Activo");

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.Dock = DockStyle.Fill;
            Controls.Add(dataGridView);
            dataGridView.BringToFront();
            dataGridView.BackgroundColor = Color.White;

            dataGridView.CellClick += DataGridView_CellClick;
            dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;

            LoadGridUDF(dataGridView);

            SetGridStyle(dataGridView);
        }

        private void M_Button3_Click(object sender, EventArgs e)
        {
            if (configurationKey != -1)
            {
                UtilPopup utilPopup = new UtilPopup(UtilPopupType.MESSAGE, "¿Está seguro de eliminar la configuración?");

                utilPopup.ShowDialog();

                if (utilPopup.DialogResult == DialogResult.OK)
                {
                    Connection.Instance.DeleteAddOnConfiguration(configurationKey);

                    dataGridView.Rows.Clear();
                    LoadGridUDF(dataGridView);
                    SetGridStyle(dataGridView);
                }
            }
            else
            {
                UtilPopup utilPopup = new UtilPopup(UtilPopupType.MESSAGE, "Ninguna configuración seleccionada.");
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                configurationKey = Convert.ToInt64(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (e.ColumnIndex ==2)
                {
                    bool value = Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());

                    if (value == false)
                    {
                        Connection.Instance.UpdateActive(configurationKey, true);
                    }
                    else if (value == true)
                    {
                        Connection.Instance.UpdateActive(configurationKey, false);
                    } 

                    dataGridView.Rows.Clear();
                    LoadGridUDF(dataGridView);
                    SetGridStyle(dataGridView);
                }
            }
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                configurationKey = Convert.ToInt64(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

                ConfigurationView configurationView = new ConfigurationView(configurationKey);

                ConsoleViewManager.Instance.Push(configurationView);
            }
        }

        private void M_Button12_Click(object sender, EventArgs e)
        {
            ConsoleViewManager.Instance.Pop();
        }

        private void M_Button11_Click(object sender, EventArgs e)
        {
            ConsoleViewManager.Instance.Pop();
        }

        private void M_Button2_Click(object sender, EventArgs e)
        {
            ConfigurationView configurationView = new ConfigurationView(0);

            ConsoleViewManager.Instance.Push(configurationView);
        }

        private void M_Button1_Click(object sender, EventArgs e)
        {
            if (configurationKey != -1)
            {
                ConfigurationView configurationView = new ConfigurationView(configurationKey);

                ConsoleViewManager.Instance.Push(configurationView);
            }
            else
            {
                if (dataGridView.Rows.Count > 1)
                {
                    configurationKey = Convert.ToInt64(dataGridView.Rows[0].Cells[0].Value.ToString());

                    ConfigurationView configurationView = new ConfigurationView(configurationKey);

                    ConsoleViewManager.Instance.Push(configurationView);
                }
            }
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

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.ColumnHeadersVisible = true;

            //gridInvoice.RowTemplate.Height = 30;
            foreach (DataGridViewColumn c in dataGridView.Columns) { c.SortMode = DataGridViewColumnSortMode.NotSortable; }

            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.RowsDefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
        }

        public void LoadGrid(DataGridView dtg)
        {
            configurations = Connection.Instance.ConfigurationList();

            configurations = configurations.OrderBy(o => o.configurationKey).ToList();

            foreach (var field in configurations)
            {
                dtg.Rows.Add(field.configurationKey, field.AludraPortal, field.isActive);
            }

            for (int i = 0; i < configurations.Count; i++)
            {
                DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();

                dtg.Rows[i].Cells[2] = checkBoxCell;

                dtg.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtg.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (configurations[i].isActive != true && configurations[i].isActive!= false)
                {
                    dtg.Rows[i].Cells[2].Value = false;
                }
                else
                {
                    dtg.Rows[i].Cells[2].Value = configurations[i].isActive;
                }
            }
        }

        public void LoadGridUDF(DataGridView dtg)
        {
            var configurations = Connection.Instance.GetValuesConfigurationUDF();

            configurations = configurations.OrderBy(o => o.Key).ToList();

            foreach (var field in configurations)
            {
                dtg.Rows.Add(field.Key, field.UserDefinedFields["U_AludraPortal"].ToString(), field.UserDefinedFields["U_IsActive"].ToString());
            }

            for (int i = 0; i < configurations.Count; i++)
            {
                DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();

                dtg.Rows[i].Cells[2] = checkBoxCell;

                dtg.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtg.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                var v = configurations[i].UserDefinedFields["U_IsActive"].ToString();

                if (v.Equals(""))
                {
                    dtg.Rows[i].Cells[2].Value = false;
                }
                else
                {
                    dtg.Rows[i].Cells[2].Value = Convert.ToBoolean(configurations[i].UserDefinedFields["U_IsActive"].ToString());
                }
            }
        }
    }
}
