using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDSluotion.Global_Classes
{
    public class ClsFormat
    {
     public static   string FormatDate(DateTime dateTime)
        {
            return dateTime.ToString("dd/MMM/yyy");
        }
    }
}
