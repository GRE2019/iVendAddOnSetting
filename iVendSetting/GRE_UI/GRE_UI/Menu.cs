using CXS.Retail.Extensibility;
using CXS.Retail.Extensibility.Menu;
using CXS.Retail.ManagementUIComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageView;

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
            MessageScreenView messageScreenView = new MessageScreenView(MessageType.SUCCESS, "Iniciando Addon de Configuración.");
            messageScreenView.Show();
        }
    }
}
