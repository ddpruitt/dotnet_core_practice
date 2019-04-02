namespace ReverseArray
{
    public class ReverseStrings{

        public string Reverse01(string toReverse){

            var result = string.Empty;

            for (int i = toReverse.Length-1; i >=0; i--)
            {
                result+= toReverse[i];
            }
            return result;
        }

        public string Reverse02(string toReverse){

            var result = new char[toReverse.Length];

            for (int i = 0, j=toReverse.Length-1; i < toReverse.Length-1; i++, j--)
            {
                result[i] = toReverse[j];
            }

            return string.Join("", result);
        }
    }
}