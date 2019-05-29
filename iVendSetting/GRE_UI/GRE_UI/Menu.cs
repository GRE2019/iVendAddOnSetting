using CXS.Retail.Extensibility;
using CXS.Retail.Extensibility.Menu;
using CXS.Retail.ManagementUIComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageView;
using GRE_UI.Views;
using System.Windows.Forms;

namespace GRE_UI
{
    public class Menu : ConsoleMenuItemCommandBase
    {
        public Menu() : base()
        {
            Id = "GRE Configuration";
            Caption = "GRE Configuration";
            Position = 1;
            IsVisible = true;
            IsEnabled = true;
            Category = ConsoleMenuCategory.ApplicationSetupGroup;
            ToolTip = "GRE AddOn de Configuración";
        }

        public override void Execute()
        {
            MessageScreenView messageScreenView = new MessageScreenView(MessageType.SUCCESS, "Iniciando Addon de Configuración...");
            messageScreenView.ShowDialog();

            if (messageScreenView.DialogResult == DialogResult.OK)
            {
                SettingListView settingListView = new SettingListView();
                ConsoleViewManager.Instance.Push(settingListView, true);
            }
            else
            {
                MessageScreenView messageScreenView2 = new MessageScreenView(MessageType.ERROR, "AddOn de Configuración no iniciado.");
                messageScreenView2.Show();
            }
        }
    }
}
