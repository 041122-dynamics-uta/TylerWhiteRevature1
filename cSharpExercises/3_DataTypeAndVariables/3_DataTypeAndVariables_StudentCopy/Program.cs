using System;

namespace _3_DataTypeAndVariablesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //
            //
            // Insert code here.
            //
            //
        }

        /// <summary>
        /// This method has an 'object' type parameter. 
        /// 1. Create a switch statement that evaluates for the data type of the parameter
        /// 2. You will need to get the data type of the parameter in the 'case' part of the switch statement
        /// 3. For each data type, return a string of exactly format, "Data type => <type>" 
        /// 4. For example, an 'int' data type will return ,"Data type => int",
        /// 5. A 'ulong' data type will return "Data type => ulong",
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string PrintValues(object obj)
        {
            string s = "";
            switch (Type.GetTypeCode(obj.GetType()))
            {
                // public enum TypeCode - Specifies the type of an object.
                case TypeCode.String:
                    s = "Data type => string";
                    return s;
                case TypeCode.Int32:
                    s = "Data type => int";
                    return s;
                case TypeCode.UInt64:
                    s = "Data type => ulong";
                    return s;
                case TypeCode.Byte:
                    s = "Data type => byte";
                    return s;
                case TypeCode.SByte:
                    s = "Data type => sbyte";
                    return s;
                case TypeCode.UInt32:
                    s = "Data type => uint";
                    return s;
                case TypeCode.Int16:
                    s = "Data type => short";
                    return s;
                case TypeCode.UInt16:
                    s = "Data type => ushort";
                    return s;
                case TypeCode.Int64:
                    s = "Data type => long";
                    return s;
                case TypeCode.Single:
                    s = "Data type => float";
                    return s;
                case TypeCode.Double:
                    s = "Data type => double";
                    return s;
                case TypeCode.Decimal:
                    s = "Data type => decimal";
                    return s;
                case TypeCode.Char:
                    s = "Data type => char";
                    return s;
                case TypeCode.Boolean:
                    s = "Data type => bool";
                    return s;
                case TypeCode.Object:
                    s = "Data type => object";
                    return s;
                default:
                    break;
             }
            return s;        }

        /// <summary>
        /// THis method has a string parameter.
        /// 1. Use the .TryParse() method of the Int32 class (Int32.TryParse()) to convert the string parameter to an integer. 
        /// 2. You'll need to investigate how .TryParse() and 'out' parameters work to implement the body of StringToInt().
        /// 3. If the string cannot be converted to a integer, return 'null'. 
        /// 4. Investigate how to use '?' to make non-nullable types nullable.
        /// </summary>
        /// <param name="numString"></param>
        /// <returns></returns>
        public static int? StringToInt(string numString)
        {
            int i;
            bool mybool = Int32.TryParse(numString, out i);

            if (mybool)
            {
                return i;
            }
            else  
            {
                return null;
            }
        }
    }// end of class
}// End of Namespace
