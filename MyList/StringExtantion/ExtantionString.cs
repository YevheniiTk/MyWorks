namespace StringExtantion
{
    public static class ExtantionString
    {
        public static List.List GetListIntegers(this string inputString)
        {
            List.List result = new List.List();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] >= '0' && inputString[i] <= '9')
                {
                    result.Add((int)inputString[i]);
                }
            }
            return result;
        }

    }
}
