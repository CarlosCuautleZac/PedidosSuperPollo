using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PedidosSuperPollo.Helpers
{
    class TimeToLabelConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime ahora = (DateTime)value;
            
            if (ahora.Hour >= 6 && ahora.Hour <= 12)
                return "Buenos dias";

            else if (ahora.Hour > 12 && ahora.Hour < 19)
                return "Buenas tardes";

            else
                return "Buenas noches";


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
