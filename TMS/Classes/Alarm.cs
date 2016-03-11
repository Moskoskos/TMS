using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS
{
     
    class Alarm
    {
        int _myProperty = 0;


        public int MyProperty
        {
            get { return _myProperty; }
            set
            {
                _myProperty = value;
                if (_myProperty == 1)
                {
                    // DO SOMETHING HERE
                }
            }
        }
    }
}
