using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HNLiVendConfigurationAddon.Screen
{
    public enum UtilPopupType
    {
        PASSWORD,
        MESSAGE
    }
    public partial class UtilPopup : Form
    {
        string password = "";
        UtilPopupType UtilPopupType;

        public UtilPopup(UtilPopupType utilPopup)
        {
            InitializeComponent();

            switch (utilPopup)
            {
                case UtilPopupType.PASSWORD:

                    lbl_title.Text = "Contraseña";
                    lbl_text.Text = "Porfavor introducir contraseña.";

                    break;

                case UtilPopupType.MESSAGE:

                    txt_password.Visible = false;
                    btn_cancel.Visible = false;

                    break;

            }
        }

        public UtilPopup(UtilPopupType utilPopup, string message)
        {
            InitializeComponent();

            UtilPopupType = utilPopup;

            switch (UtilPopupType)
            {
                case UtilPopupType.PASSWORD:

                    lbl_title.Text = "Contraseña";
                    lbl_text.Text = "Porfavor introducir contraseña.";

                    break;

                case UtilPopupType.MESSAGE:
                    lbl_title.Text = "Información";
                    lbl_text.Text = message;
                    txt_password.Visible = false;

                    break;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (UtilPopupType == UtilPopupType.PASSWORD)
            {
                if (txt_password.Text != null)
                {
                    password = txt_password.Text;

                    if (password.Trim() != "ariselmandamas")
                    {
                        lbl_text.Text = "Contraseña incorrecta";
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            if (UtilPopupType == UtilPopupType.MESSAGE)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
