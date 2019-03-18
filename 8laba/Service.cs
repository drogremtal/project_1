using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8laba
{
    public class Service
    {
        public string TextToBin(string text)
        {

            string res_out = "";

            int[] input_n = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                if (Convert.ToString(text[i], 2).Length == 6)
                {
                    res_out += "00" + Convert.ToString(text[i], 2);
                }
                else
                if (Convert.ToString(text[i], 2).Length == 7)
                {
                    res_out += "0" + Convert.ToString(text[i], 2);
                }
                else
                {
                    res_out += Convert.ToString(text[i], 2);
                }
                input_n[i] = Convert.ToInt32(Convert.ToString(text[i], 2), 2);
            }

        return res_out;
        }

    }
}
