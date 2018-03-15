public static class ExtensionUtils
    {
        public static byte[] GetBytes(this string src)
        {
            return Encoding.UTF8.GetBytes(src);
        }
        public static string GetMd5(this string src)
        {
            var md = MD5.Create();
            var md5Byte = md.ComputeHash(src.GetBytes());
            return md5Byte.ToHex();
        }

        #region hexstring bytes convert copy from https://stackoverflow.com/questions/623104/byte-to-hex-string/5919521#5919521
        public static string ToHex(this byte[] data)
        {
            return ToHex(data, "");
        }
        public static string ToHex(this byte[] data, string prefix)
        {
            char[] lookup = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            int i = 0, p = prefix.Length, l = data.Length;
            char[] c = new char[l * 2 + p];
            byte d;
            for (; i < p; ++i) c[i] = prefix[i];
            i = -1;
            --l;
            --p;
            while (i < l)
            {
                d = data[++i];
                c[++p] = lookup[d >> 4];
                c[++p] = lookup[d & 0xF];
            }
            return new string(c, 0, c.Length);
        }
        public static byte[] FromHex(this string str)
        {
            return FromHex(str, 0, 0, 0);
        }
        public static byte[] FromHex(this string str, int offset, int step)
        {
            return FromHex(str, offset, step, 0);
        }
        public static byte[] FromHex(this string str, int offset, int step, int tail)
        {
            byte[] b = new byte[(str.Length - offset - tail + step) / (2 + step)];
            byte c1, c2;
            int l = str.Length - tail;
            int s = step + 1;
            for (int y = 0, x = offset; x < l; ++y, x += s)
            {
                c1 = (byte)str[x];
                if (c1 > 0x60) c1 -= 0x57;
                else if (c1 > 0x40) c1 -= 0x37;
                else c1 -= 0x30;
                c2 = (byte)str[++x];
                if (c2 > 0x60) c2 -= 0x57;
                else if (c2 > 0x40) c2 -= 0x37;
                else c2 -= 0x30;
                b[y] = (byte)((c1 << 4) + c2);
            }
            return b;
        }
        #end region


        #region 获取整数的某一位，设置整数的某一位  
        /// <summary>  
        /// 取整数的某一位  
        /// </summary>  
        /// <param name="_Resource">要取某一位的整数</param>  
        /// <param name="_Mask">要取的位置索引，自右至左为0-7</param>  
        /// <returns>返回某一位的值（0或者1）</returns>  
        public static int getIntegerSomeBit(int _Resource, int _Mask)  
        {  
            return _Resource >> _Mask & 1;  
        }  
  
  
        /// <summary>  
        /// 将整数的某位置为0或1  
        /// </summary>  
        /// <param name="_Mask">整数的某位</param>  
        /// <param name="a">整数</param>  
        /// <param name="flag">是否置1，TURE表示置1，FALSE表示置0</param>  
        /// <returns>返回修改过的值</returns>  
        public static int setIntegerSomeBit(int _Mask, int a, bool flag)  
        {  
            if (flag)  
            {  
                a |= (0x1 << _Mask);  
            }  
            else  
            {  
                a &= ~(0x1 << _Mask);  
            }  
            return a;  
        }  
#endregion  
        
    }