using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalAppLib
{
    public class TimeFieldsClass
    {
        public bool IsRightTime(string entryText)
        {
            string reg = @"^[0-2][0-9]\:[0-5][0-9]$";
            if (Regex.IsMatch(entryText, reg))
            {
                if (Regex.IsMatch(entryText, @"^2[0-9]\:[0-5][0-9]$"))
                {
                    if (Regex.IsMatch(entryText, @"^2[0-3]\:[0-5][0-9]$"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        
        public bool IsRightDuration(string entryText)
        {
            string reg = @"^[1-6][0-9]$";
            if (Regex.IsMatch(entryText, reg) || Regex.IsMatch(entryText, @"^[0-9]$"))
            {
                if (Regex.IsMatch(entryText, @"^6[1-9]$"))
                {
                    return false;
                }
                return true;

            }
            return false;
        }
        
    }

}
