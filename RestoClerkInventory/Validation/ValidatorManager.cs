using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;



namespace RestoClerkInventory.Validation
{
    public class ValidatorManager
    {
        public static bool IsValidId(string input)
        {
            if ((!Information.IsNumeric(input)))
            {
                return false;
            }

            return true;
        }

        //public static bool IsValidId(string input, int size)
        //{
        //    if ((!Information.IsNumeric(input)) || (input.Length != size))
        //    {
        //        return false;
        //    }

        //    return true;
        //}


        public static bool IsValidNumeric(string input)
        {
            if ((!Information.IsNumeric(input)))
            {
                return false;
            }
            

            return true;
        }

        public static bool IsValidName(string input)
        {
            if (input == "")
            {
                return false;
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if ((!Char.IsLetter(input[i])) && (!Char.IsWhiteSpace(input[i])))
                    {
                        return false;
                    }
                }

            }

            return true;
        }
    }
}