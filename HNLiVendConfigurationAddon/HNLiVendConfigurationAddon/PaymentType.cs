using CXS.Retail.UIComponents;
using CXS.SubSystem.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNLiVendConfigurationAddon
{
    class PaymentType : PaymentTypeSearchView
    {
        public void PaymentType2()
        {
            CXS.SubSystem.Payment.PaymentType payment = CXS.SubSystem.Payment.PaymentTypeSubSystem.Instance.Create();

            CXS.SubSystem.Payment.PaymentTypeAttribute paymentTypeAttribute = CXS.SubSystem.Payment.PaymentTypeAttributeSubSystem.Instance.Create();

            paymentTypeAttribute.Id = "contrato";
            paymentTypeAttribute.Description = "contrato del club de mercancia";
            paymentTypeAttribute.Type = CXS.SubSystem.Payment.PaymentTypeAttributeType.String;
            paymentTypeAttribute.IsRequired = true;
            paymentTypeAttribute.MinimumStringLength = 1;

            payment.PaymentTypeAttributeList.Add(paymentTypeAttribute);

            CXS.SubSystem.Payment.PaymentTypeSubSystem.Instance.Commit(payment);
        }
    }
}
