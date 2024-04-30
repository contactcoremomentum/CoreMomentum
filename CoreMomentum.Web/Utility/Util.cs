namespace CoreMomentum.Web.Utility
{
    public static class Util
    {
        public static string GenerateStudentNumber(int topID)
        {
            DateTime moment = DateTime.Now;
            string year = moment.Year.ToString();
            string value = string.Empty;
            topID = topID + 1;
            if (topID <= 9)
            {
                value = "00" + value + topID.ToString();
            }
            else if (topID <= 99)
            {
                value = "0" + value + topID.ToString();
            }
            else if (topID <= 999)
            {
                //value = "00" + value + IDindex.ToString();
                value = value + topID.ToString();
            }
            else if (topID <= 9999)
            {
                value = "0" + topID.ToString();
            }

            return "CMV" + year + value;
        }
    }
}
