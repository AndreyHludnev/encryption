using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.ReadOnly = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            if (radioButton1.Checked)
            {
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                int c1 = 0;
                int c2 = 0;
                int d = st.Length;
                int[] n1 = new int[d];
                int min = d;
                for (int i = 1; i < d; i++)
                {
                    if (d % i == 0)
                    {
                        n1[i] = i + (d / i);
                        if (n1[i] < min)
                            min = n1[i];
                    }
                }

                for (int i = 1; i < d; i++)
                {
                    if (n1[i] == min)
                    {
                        if ((min - i) > (min - d / i))
                        {
                            c1 = min - i;
                            c2 = min - d / i;
                        }
                        else
                        {
                            c1 = min - d / i;
                            c2 = min - i;
                        }
                    }
                }
                char[,] c = new char[c1, c2];
                int f = 0;
                for (int i = 0; i < c1; i++)
                    for (int j = 0; j < c2; j++)
                    {
                        c[i, j] = st[f];
                        f++;
                    }

                for (int i = 0; i < c2; i++)
                    for (int j = 0; j < c1; j++)
                    {
                        textBox3.Text += c[j, i];
                    }

            }
            else if (radioButton2.Checked)
            {

                int c1 = 0;
                int c2 = 0;
                int d = textBox1.Text.Trim().Length;
                int[] n1 = new int[d];
                int min = d;
                for (int i = 1; i < d; i++)
                {
                    if (d % i == 0)
                    {
                        n1[i] = i + (d / i);
                        if (n1[i] < min)
                            min = n1[i];
                    }
                }

                for (int i = 1; i < d; i++)
                {
                    if (n1[i] == min)
                    {
                        if ((min - i) > (min - d / i))
                        {
                            c1 = min - i;
                            c2 = min - d / i;
                        }
                        else
                        {
                            c1 = min - d / i;
                            c2 = min - i;
                        }
                    }
                }
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                Crypter crypter = new Crypter(c2, c1, textBox2.Text.ToLower());
                string crypted = crypter.Encode(st);
                textBox3.Text = crypted.ToString();

            }
            else if (radioButton3.Checked)
            {
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                int c1 = 0;
                int c2 = 0;
                int d = st.Length;
                int[] n1 = new int[d];
                int min = d;
                for (int i = 1; i < d; i++)
                {
                    if (d % i == 0)
                    {
                        n1[i] = i + (d / i);
                        if (n1[i] < min)
                            min = n1[i];
                    }
                }

                for (int i = 1; i < d; i++)
                {
                    if (n1[i] == min)
                    {
                        if ((min - i) > (min - d / i))
                        {
                            c1 = min - i;
                            c2 = min - d / i;
                        }
                        else
                        {
                            c1 = min - d / i;
                            c2 = min - i;
                        }
                    }
                }
                char[,] c = new char[c1, c2];
                int f = 0;
                String[] words = textBox2.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                char[] x1 = words[0].ToCharArray();
                char[] y1 = words[1].ToCharArray();
                int[] x2 = new int[x1.Length];
                int[] y2 = new int[y1.Length];

                for (int i = 0; i < x1.Length; i++)
                {
                    x2[i] = Convert.ToInt32(Convert.ToString(x1[i]));
                }

                for (int i = 0; i < y1.Length; i++)
                {
                    y2[i] = Convert.ToInt32(Convert.ToString(y1[i]));
                }

                char[,] ct = new char[c2, c1];
                for (int i = 0; i < c2; i++)
                    for (int j = 0; j < c1; j++)
                    {
                        ct[i, j] = st[f];
                        f++;
                    }
                char[,] ct1 = new char[c2 + 1, c1 + 1];
                for (int i = 1; i < c1 + 1; i++)
                    ct1[0, i] = x1[i - 1];

                for (int i = 1; i < c2 + 1; i++)
                    ct1[i, 0] = y1[i - 1];

                for (int i = 1; i < c2 + 1; i++)
                    for (int j = 1; j < c1 + 1; j++)
                    {
                        ct1[i, j] = ct[i - 1, j - 1];
                    }

                int temp;
                for (int i = 0; i < x2.Length - 1; i++)
                {
                    for (int j = i + 1; j < x2.Length; j++)
                    {
                        if (x2[i] > x2[j])
                        {
                            temp = x2[i];
                            x2[i] = x2[j];
                            x2[j] = temp;
                        }
                    }
                }
                temp = 0;
                for (int i = 0; i < y2.Length - 1; i++)
                {
                    for (int j = i + 1; j < y2.Length; j++)
                    {
                        if (y2[i] > y2[j])
                        {
                            temp = y2[i];
                            y2[i] = y2[j];
                            y2[j] = temp;
                        }
                    }
                }

                char temp1;
                for (int i = 1; i < c2 + 1; i++)
                    for (int j = 1; j < c1 + 1; j++)
                    {
                        if (x2[j - 1] != Convert.ToInt32(Convert.ToString(ct1[0, j])))
                        {
                            for (int w = 1; w < c1 + 1; w++)
                            {
                                if (x2[j - 1] == Convert.ToInt32(Convert.ToString(ct1[0, w])))
                                {
                                    for (int z = 0; z < c2 + 1; z++)
                                    {
                                        temp1 = ct1[z, j];
                                        ct1[z, j] = ct1[z, w];
                                        ct1[z, w] = temp1;
                                    }
                                }
                            }
                        }
                    }

                for (int i = 1; i < c2 + 1; i++)
                    for (int j = 1; j < c1 + 1; j++)
                    {
                        if (y2[i - 1] != Convert.ToInt32(Convert.ToString(ct1[i, 0])))
                        {
                            for (int w = 1; w < c2 + 1; w++)
                            {
                                if (y2[i - 1] == Convert.ToInt32(Convert.ToString(ct1[w, 0])))
                                {
                                    for (int z = 0; z < c1 + 1; z++)
                                    {
                                        temp1 = ct1[i, z];
                                        ct1[i, z] = ct1[w, z];
                                        ct1[w, z] = temp1;
                                    }
                                }
                            }
                        }
                    }

                for (int i = 1; i < c2 + 1; i++)
                    for (int j = 1; j < c1 + 1; j++)
                    {
                        textBox3.Text += ct1[i, j];
                    }
            }
            else if (radioButton4.Checked)
            {
                string st = textBox1.Text.ToLower();
                int c1 = 0;
                int c2 = 0;
                int d = st.Length;
                int[] n1 = new int[d];
                int min = d;
                for (int i = 1; i < d; i++)
                {
                    if (d % i == 0)
                    {
                        n1[i] = i + (d / i);
                        if (n1[i] < min)
                            min = n1[i];
                    }
                }

                for (int i = 1; i < d; i++)
                {
                    if (n1[i] == min)
                    {
                        if ((min - i) > (min - d / i))
                        {
                            c1 = min - i;
                            c2 = min - d / i;
                        }
                        else
                        {
                            c1 = min - d / i;
                            c2 = min - i;
                        }
                    }
                }
                char[] st1 = st.ToCharArray();
                String[] words = textBox2.Text.Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int[,] r = new int[c2, c1];
                int f = 0;
                for (int i = 0; i < c2; i++)
                    for (int j = 0; j < c1; j++)
                    {
                        r[i, j] = Convert.ToInt32(words[f]);
                        f++;
                    }
                char[,] res = new char[c2, c1];
                for (int i = 0; i < c2; i++)
                    for (int j = 0; j < c1; j++)
                    {
                        res[i, j] = st1[r[i, j] - 1];
                    }
                for (int i = 0; i < c2; i++)
                    for (int j = 0; j < c1; j++)
                    {
                        textBox3.Text += res[i, j];
                    }

            }
            else if (radioButton5.Checked)
            {
                Dictionary<int, char> alf1 = Class1.DDK();
                Dictionary<char, int> alf2 = Class1.DDD();
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                char[] ch = st.ToCharArray();
                int k = Convert.ToInt32(textBox2.Text);
                st = "";
                for (int i = 0; i < ch.Length; i++)
                {
                    if (alf2[ch[i]] + k > 33)
                        ch[i] = alf1[(alf2[ch[i]] + k) - 33];
                    else
                        ch[i] = alf1[alf2[ch[i]] + k];
                    st += ch[i];
                }
                textBox3.Text = st;

            }
            else if (radioButton6.Checked)
            {
                Dictionary<int, char> alf1 = Class1.DDK();
                Dictionary<char, int> alf2 = Class1.DDD();
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                char[] ch = st.ToCharArray();
                int k1 = Convert.ToInt32(textBox2.Text.Substring(0, 1));
                int k2 = Convert.ToInt32(textBox2.Text.Substring(2, 1));
                st = "";
                for (int i = 0; i < ch.Length; i++)
                {
                    ch[i] = alf1[(((alf2[ch[i]] - 1) * k1 + k2) % 33) + 1];
                    st += ch[i];
                }
                textBox3.Text = st;
            }
            else if (radioButton7.Checked)
            {
                Dictionary<int, char> alf1 = Class1.DDK();
                Dictionary<char, int> alf2 = Class1.DDD();
                Dictionary<int, char> alf3 = new Dictionary<int, char>();
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                char[] ch = st.ToCharArray();
                int k1 = Convert.ToInt32(textBox2.Text.Substring(0, 1)) + 1;
                char[] k2 = new char[textBox2.Text.Remove(0, 2).Length];
                string st1;
                st1 = string.Concat(textBox2.Text.Distinct());
                st1 = st1.ToLower();
                k2 = st1.Remove(0, 2).ToCharArray();
                int i = 1;
                int z = 0;
                int t = k1;
                while (i <= 33)
                {
                    if (t > 33)
                        t = 1;
                    if (t < k1 + k2.Length - 1 && z == 0)
                        while (t < k1 + k2.Length)
                        {
                            alf3.Add(t, k2[z]);
                            z++;
                            t++;
                        }
                    if (!k2.Contains(alf1[i]))
                    {
                        alf3.Add(t, alf1[i]);
                        t++;
                    }
                    i++;
                }
                st = "";
                for (int j = 0; j < ch.Length; j++)
                {
                    ch[j] = alf3[alf2[ch[j]]];
                    st += ch[j];
                }
                textBox3.Text = st;
            }
            else if (radioButton8.Checked)
            {
                Dictionary<int, char> alf1 = Class1.DDK1();
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                int c1 = 4;
                int c2 = 8;
                char[,] sch = new char[c1, c2];
                char[] ch = st.ToCharArray();
                char[] ch2 = new char[textBox2.Text.Length];
                string st1;
                st1 = string.Concat(textBox2.Text.Distinct());
                st1 = st1.ToLower();
                ch2 = st1.ToCharArray();
                int z = 1;
                int t = 0;
                bool h = false;
                for (int i = 0; i < c1; i++)
                    for (int j = 0; j < c2; j++)
                    {
                        if (t < st1.Length)
                        {
                            sch[i, j] = ch2[t];
                            t++;
                        }
                        else
                        {
                            while (true)
                            {
                                if (!ch2.Contains(alf1[z]))
                                {
                                    sch[i, j] = alf1[z];
                                    z++;
                                    break;
                                }
                                else
                                    z++;
                            }
                        }

                    }
                z = 0;

                for (int g = 0; g < st.Length; g++)
                {
                    for (int i = 0; i < c1; i++)
                        for (int j = 0; j < c2; j++)
                        {
                            if ((ch[g] == sch[i, j]) && !h)
                            {
                                if (i < c1 - 1)
                                    ch[g] = sch[i + 1, j];
                                else
                                    ch[g] = sch[0, j];
                                h = true;
                            }
                        }
                    h = false;
                }

                for (int i = 0; i < st.Length; i++)
                    textBox3.Text += ch[i];
            }
            else
            {
                MessageBox.Show("Выберите метод", "Информация");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            if (radioButton1.Checked)
            {
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                textBox3.Text = "";
                int c1 = 0;
                int c2 = 0;
                int d = st.Length;
                int[] n1 = new int[d];
                int min = d;
                for (int i = 1; i < d; i++)
                {
                    if (d % i == 0)
                    {
                        n1[i] = i + (d / i);
                        if (n1[i] < min)
                            min = n1[i];
                    }
                }

                for (int i = 1; i < d; i++)
                {
                    if (n1[i] == min)
                    {
                        if ((min - i) > (min - d / i))
                        {
                            c1 = min - i;
                            c2 = min - d / i;
                        }
                        else
                        {
                            c1 = min - d / i;
                            c2 = min - i;
                        }
                    }
                }

                char[,] c = new char[c2, c1];
                int f = 0;
                for (int i = 0; i < c2; i++)
                    for (int j = 0; j < c1; j++)
                    {
                        c[i, j] = st[f];
                        f++;
                    }

                for (int i = 0; i < c1; i++)
                    for (int j = 0; j < c2; j++)
                    {
                        textBox3.Text += c[j, i];
                    }
            }
            else if (radioButton2.Checked)
            {
                int c1 = 0;
                int c2 = 0;
                int d = textBox1.Text.Replace(" ", "").Length;
                int[] n1 = new int[d];
                int min = d;
                for (int i = 1; i < d; i++)
                {
                    if (d % i == 0)
                    {
                        n1[i] = i + (d / i);
                        if (n1[i] < min)
                            min = n1[i];
                    }
                }

                for (int i = 1; i < d; i++)
                {
                    if (n1[i] == min)
                    {
                        if ((min - i) > (min - d / i))
                        {
                            c1 = min - i;
                            c2 = min - d / i;
                        }
                        else
                        {
                            c1 = min - d / i;
                            c2 = min - i;
                        }
                    }
                }
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                Crypter crypter = new Crypter(c2, c1, textBox2.Text.ToLower());
                string crypted = crypter.Decode(st);
                textBox3.Text = crypted.ToString();
            }
            else if (radioButton3.Checked)
            {
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                int c1 = 0;
                int c2 = 0;
                int d = st.Length;
                int[] n1 = new int[d];
                int min = d;
                for (int i = 1; i < d; i++)
                {
                    if (d % i == 0)
                    {
                        n1[i] = i + (d / i);
                        if (n1[i] < min)
                            min = n1[i];
                    }
                }

                for (int i = 1; i < d; i++)
                {
                    if (n1[i] == min)
                    {
                        if ((min - i) > (min - d / i))
                        {
                            c1 = min - i;
                            c2 = min - d / i;
                        }
                        else
                        {
                            c1 = min - d / i;
                            c2 = min - i;
                        }
                    }
                }

                int f = 0;
                String[] words = textBox2.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                char[] x1 = words[0].ToCharArray();
                char[] y1 = words[1].ToCharArray();
                int[] x2 = new int[x1.Length];
                int[] y2 = new int[y1.Length];

                for (int i = 0; i < x1.Length; i++)
                {
                    x2[i] = Convert.ToInt32(Convert.ToString(x1[i]));
                }

                for (int i = 0; i < y1.Length; i++)
                {
                    y2[i] = Convert.ToInt32(Convert.ToString(y1[i]));
                }
                int[] x21 = new int[x1.Length];
                int[] y21 = new int[y1.Length];
                x2.CopyTo(x21, 0);
                y2.CopyTo(y21, 0);
                int temp;
                for (int i = 0; i < x21.Length - 1; i++)
                {
                    for (int j = i + 1; j < x21.Length; j++)
                    {
                        if (x21[i] > x21[j])
                        {
                            temp = x21[i];
                            x21[i] = x21[j];
                            x21[j] = temp;
                        }
                    }
                }
                temp = 0;
                for (int i = 0; i < y21.Length - 1; i++)
                {
                    for (int j = i + 1; j < y21.Length; j++)
                    {
                        if (y21[i] > y21[j])
                        {
                            temp = y21[i];
                            y21[i] = y21[j];
                            y21[j] = temp;
                        }
                    }
                }

                char[,] ct = new char[c2, c1];
                for (int i = 0; i < c2; i++)
                    for (int j = 0; j < c1; j++)
                    {
                        ct[i, j] = st[f];
                        f++;
                    }
                char[,] ct1 = new char[c2 + 1, c1 + 1];
                for (int i = 1; i < c1 + 1; i++)
                    ct1[0, i] = Convert.ToChar(Convert.ToString(x21[i - 1]));

                for (int i = 1; i < c2 + 1; i++)
                    ct1[i, 0] = Convert.ToChar(Convert.ToString(y21[i - 1]));

                for (int i = 1; i < c2 + 1; i++)
                    for (int j = 1; j < c1 + 1; j++)
                    {
                        ct1[i, j] = ct[i - 1, j - 1];
                    }

                char temp1;
                for (int i = 1; i < c2 + 1; i++)
                    for (int j = 1; j < c1 + 1; j++)
                    {
                        if (x2[j - 1] != Convert.ToInt32((Convert.ToString(ct1[0, j]))))
                        {
                            for (int w = 1; w < c1 + 1; w++)
                            {
                                if (x2[j - 1] == Convert.ToInt32((Convert.ToString(ct1[0, w]))))
                                {
                                    for (int z = 0; z < c2 + 1; z++)
                                    {
                                        temp1 = ct1[z, j];
                                        ct1[z, j] = ct1[z, w];
                                        ct1[z, w] = temp1;
                                    }
                                }
                            }
                        }
                    }

                for (int i = 1; i < c2 + 1; i++)
                    for (int j = 1; j < c1 + 1; j++)
                    {
                        if (y2[i - 1] != Convert.ToInt32((Convert.ToString(ct1[i, 0]))))
                        {
                            for (int w = 1; w < c2 + 1; w++)
                            {
                                if (y2[i - 1] == Convert.ToInt32((Convert.ToString(ct1[w, 0]))))
                                {
                                    for (int z = 0; z < c1 + 1; z++)
                                    {
                                        temp1 = ct1[i, z];
                                        ct1[i, z] = ct1[w, z];
                                        ct1[w, z] = temp1;
                                    }
                                }
                            }
                        }
                    }

                for (int i = 1; i < c2 + 1; i++)
                    for (int j = 1; j < c1 + 1; j++)
                    {
                        textBox3.Text += ct1[i, j];
                    }
            }
            else if (radioButton4.Checked)
            {
                string st = textBox1.Text.ToLower();
                int d = st.Length;
                char[] st1 = st.ToCharArray();
                String[] words = textBox2.Text.Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int[] r = new int[st.Length];
                for (int i = 0; i < r.Length; i++)
                    r[i] = Convert.ToInt32(words[i]);
                char temp;
                int temp1;
                for (int i = 0; i < st1.Length; i++)
                    for (int j = 0; j < st1.Length; j++)
                    {
                        if (r[i] < r[j])
                        {
                            temp = st1[i];
                            st1[i] = st1[j];
                            st1[j] = temp;
                            temp1 = r[i];
                            r[i] = r[j];
                            r[j] = temp1;
                        }
                    }
                for (int i = 0; i < st1.Length; i++)
                    textBox3.Text += st1[i];
            }
            else if (radioButton5.Checked)
            {
                Dictionary<int, char> alf1 = Class1.DDK();
                Dictionary<char, int> alf2 = Class1.DDD();
                string st = textBox1.Text.ToLower();
                string stt = "";
                for (int u = 0; u < st.Length; u++)
                    if (!st[u].Equals('.') && !st[u].Equals(',') && !st[u].Equals('!') && !st[u].Equals('?') && !st[u].Equals(';') && !st[u].Equals(':') && !st[u].Equals('-') && !st[u].Equals(' '))
                        stt += st[u];
                char[] ch = stt.ToCharArray();
                int k = Convert.ToInt32(textBox2.Text);
                st = "";
                for (int i = 0; i < ch.Length; i++)
                {
                    if (alf2[ch[i]] - k < 1)
                        ch[i] = alf1[(alf2[ch[i]] - k) + 33];
                    else
                        ch[i] = alf1[alf2[ch[i]] - k];
                    st += ch[i];
                }
                textBox3.Text = st;

            }
            else if (radioButton6.Checked)
            {
                Dictionary<int, char> alf1 = Class1.DDK();
                Dictionary<char, int> alf2 = Class1.DDD();
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                char[] ch = st.ToCharArray();
                int k1 = Convert.ToInt32(textBox2.Text.Substring(0, 1));
                int k2 = Convert.ToInt32(textBox2.Text.Substring(2, 1));
                int invk1 = 0;
                bool g = true;
                while (g)
                {
                    if ((invk1 * k1) % 33 == 1)
                        g = false;
                    else
                        invk1++;
                }
                st = "";
                for (int i = 0; i < ch.Length; i++)
                {
                    ch[i] = alf1[(invk1 * ((alf2[ch[i]] - 1) + 33 - k2) % 33) + 1];
                    st += ch[i];
                }

                textBox3.Text = st;
            }
            else if (radioButton7.Checked)
            {
                Dictionary<int, char> alf1 = Class1.DDK();
                Dictionary<char, int> alf2 = Class1.DDD();
                Dictionary<char, int> alf3 = new Dictionary<char, int>();
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                char[] ch = st.ToCharArray();
                int k1 = Convert.ToInt32(textBox2.Text.Substring(0, 1)) + 1;
                char[] k2 = new char[textBox2.Text.Remove(0, 2).Length];
                string st1;
                st1 = string.Concat(textBox2.Text.ToLower().Distinct());
                k2 = st1.Remove(0, 2).ToCharArray();
                int i = 1;
                int z = 0;
                int t = k1;
                while (i <= 33)
                {
                    if (t > 33)
                        t = 1;
                    if (t < k1 + k2.Length - 1 && z == 0)
                        while (t < k1 + k2.Length)
                        {
                            alf3.Add(k2[z], t);
                            z++;
                            t++;
                        }
                    if (!k2.Contains(alf1[i]))
                    {
                        alf3.Add(alf1[i], t);
                        t++;
                    }
                    i++;
                }
                st = "";

                for (int j = 0; j < ch.Length; j++)
                {
                    ch[j] = alf1[alf3[ch[j]]];
                    st += ch[j];
                }
                textBox3.Text = st;
            }
            else if (radioButton8.Checked)
            {
                Dictionary<int, char> alf1 = Class1.DDK1();
                string st = textBox1.Text.ToLower().Trim(textBox1.Text.Where(x => !char.IsLetter(x)).ToArray());
                int c1 = 4;
                int c2 = 8;
                char[,] sch = new char[c1, c2];
                char[] ch = st.ToCharArray();
                char[] ch2 = new char[textBox2.Text.Length];
                string st1;
                st1 = string.Concat(textBox2.Text.Distinct());
                st1 = st1.ToLower();
                ch2 = st1.ToCharArray();
                int z = 1;
                int t = 0;
                bool h = false;
                for (int i = 0; i < c1; i++)
                    for (int j = 0; j < c2; j++)
                    {
                        if (t < st1.Length)
                        {
                            sch[i, j] = ch2[t];
                            t++;
                        }
                        else
                        {
                            while (true)
                            {
                                if (!ch2.Contains(alf1[z]))
                                {
                                    sch[i, j] = alf1[z];
                                    z++;
                                    break;
                                }
                                else
                                    z++;
                            }
                        }
                    }
                z = 0;
                for (int g = 0; g < st.Length; g++)
                {
                    for (int i = 0; i < c1; i++)
                        for (int j = 0; j < c2; j++)
                        {
                            if ((ch[g] == sch[i, j]) && !h)
                            {
                                if (i == 0)
                                    ch[g] = sch[c1 - 1, j];
                                else
                                    ch[g] = sch[i - 1, j];
                                h = true;
                            }
                        }
                    h = false;
                }

                for (int i = 0; i < st.Length; i++)
                    textBox3.Text += ch[i];
            }
            else
            {
                MessageBox.Show("Выберите метод", "Информация");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SetMod(object sender, EventArgs e)
        {

            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked || radioButton6.Checked || radioButton7.Checked || radioButton8.Checked)
            {
                textBox3.Clear();

            }
            if (radioButton4.Checked)
            {

                textBox2.Multiline = true;
                textBox2.Height = 59;
            }
            else
                textBox2.Height = 20;
            textBox2.ReadOnly = radioButton1.Checked;


        }

        private void radioButton1_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                MessageBox.Show("При использовании данного метода следует ввести сообщение. Ключ вводить не требуется", "Инструкция");

            }

            else if (radioButton2.Checked)
            {
                MessageBox.Show("При использовании данного метода следует ввести сообщение и ключ в виде слова. \r\nПример: лето", "Инструкция");
            }
            else if (radioButton3.Checked)
            {
                MessageBox.Show("При использовании данного метода следует ввести сообщение и ключ представляющий собой два числа (разделять пробелом) которые представляют из себя номера строк и столбцов. \r\nПример: 4132 3142", "Инструкция");
            }

            else if (radioButton4.Checked)
            {
                MessageBox.Show("При использовании данного метода следует ввести сообщение и ключ в виде массива чисел. \r\nВНИМАНИЕ: Количество чисел в массиве должно быть равно количеству символов (включая пробелы) в сообщении. \r\n Каждый символ следует разделять пробелом, для перехода на новую строку используйте 'Enter'", "Инструкция");
            }

            else if (radioButton5.Checked)
            {
                MessageBox.Show("При использовании данного метода следует ввести сообщение и ключ в виде числа (ключ в данном методе определяет на сколько символов сдвинется алфавит)", "Инструкция");
            }

            else if (radioButton6.Checked)
            {
                MessageBox.Show("При использовании данного метода следует ввести сообщение и ключ, представляющий собой два числа разделенные пробелом.\r\nПример: 5 3", "Инструкция");
            }

            else if (radioButton7.Checked)
            {
                MessageBox.Show("При использовании данного метода следует ввести сообщение и ключ, представляющий собой число и слово, разделенные пробелом.\r\nПример: 3 зима", "Инструкция");
            }

            else if (radioButton8.Checked)
            {
                MessageBox.Show("При использовании данного метода следует ввести сообщение и ключ в виде слова", "Инструкция");
            }
            else
            {
                MessageBox.Show("Выберите метод", "Инструкция");
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
