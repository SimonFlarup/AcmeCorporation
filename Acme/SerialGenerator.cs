

using System;

namespace Acme
{
    public class SerialGenerator
    {

        private SerialGenerator()
        {
        }
        //Generates a serialnumber from the supplied movies number, release month and year prefixed with ACME# and postfixed with either W or R
        //Result passes regex: ACME+#[0-9]-(0[1-9]|1[0-2])[0-9]{2}-[WR]
        public static String[] Generate(Movie movie)
        {
            String[] ReturnString = new String[2];
            String num = movie.Number > 9 ? "" + movie.Number : "0" + movie.Number;
            String tempStr = "ACME#" + num + "-" + String.Format("{0:MMyy}", movie.ReleaseDate);
            ReturnString[0] = tempStr + "-W";
            ReturnString[1] = tempStr + "-R";
            return ReturnString;
        }
    }
}
