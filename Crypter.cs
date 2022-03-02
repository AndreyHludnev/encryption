using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    class Crypter
    {
        int width;
        int height;
        int[] permutation;

        public Crypter(int height, int width, string keyword)
        {
            this.width = width;
            this.height = height;
            permutation = new int[keyword.Length];
            for (int i = 0; i < permutation.Length; i++)
                permutation[i] = i;
            Array.Sort(keyword.ToCharArray(), permutation);
        }

        public string Encode(string src)
        {
            char[] res = new char[src.Length];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    res[i * width + j] = src[permutation[j] * height + i];
            return new string(res);

        }
        public string Decode(string src)
        {
            char[] res = new char[src.Length];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    res[permutation[i] * height + j] = src[j * width + i];
            return new string(res);
        }
    }
}
