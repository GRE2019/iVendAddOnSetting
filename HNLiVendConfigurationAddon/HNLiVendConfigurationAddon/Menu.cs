using CXS.Retail.Extensibility;
using CXS.Retail.Extensibility.Menu;
using CXS.Retail.ManagementUIComponents;
using HNLiVendConfigurationAddon.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HNLiVendConfigurationAddon
{
    public class MenuAddOnConfiguration : ConsoleMenuItemCommandBase
    {
        public MenuAddOnConfiguration() : base()
        {
            Id = "Configuration AddOn";
            Caption = "Configuration AddOn";
            Position = 1;
            IsVisible = true;
            IsEnabled = true;
            Category = ConsoleMenuCategory.ApplicationSetupGroup;
            ToolTip = "AddOn de Configuración";
        }

        public override void Execute()
        {
            try
            {
                UtilPopup utilPopup = new UtilPopup(UtilPopupType.PASSWORD);

                utilPopup.ShowDialog();

                if (utilPopup.DialogResult == DialogResult.OK)
                {
                    ConfigurationList form = new ConfigurationList();
                    ConsoleViewManager.Instance.Push(form);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
