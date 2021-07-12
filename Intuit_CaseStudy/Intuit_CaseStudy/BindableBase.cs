using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Intuit_CaseStudy
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Sets the property value and notify the subscribers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T param, T value, [CallerMemberName]string propertyName = null)
        {
            bool isChanged = false;
            if (!object.Equals(param, value))
            {
                param = value;
                isChanged = true;
                Notify(propertyName);
            }
            return isChanged;
        }

        /// <summary>
        /// Notify
        /// </summary>
        /// <param name="propertyName"></param>
        protected void Notify(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
