using System;
using System.Numerics;
using System.IO;
using System.Windows.Forms;

namespace lab61
{
    public partial class Form1 : Form
    {
        private static uint p = 0;
        private static uint q = 0;
        private const string CHOOSE_FILE = "Файл ... ";
        private const string CHOOSE_DIRECTORY = "Каталог ... ";
        private static string fileName = "";
        private static string directoryName = "";
        private static string decodeKeys = "";

        public Form1()
        {
            InitializeComponent();
            label8.Text = CHOOSE_FILE;
            label10.Text = CHOOSE_DIRECTORY;
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox1.Items[0];
            radioButton2.Checked = true; 
            radioButton3.Checked = true; 
            radioButton5.Checked = true;
            label11.Text = "";
            label12.Text = "";
            button1.Enabled = false;
            button4.Enabled = false;
            label8.Text = CHOOSE_FILE;
            label10.Text = CHOOSE_DIRECTORY;
        }

        // Ввод p автоматически
        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random(DateTime.Now.GetHashCode());

            if (comboBox1.SelectedItem == comboBox1.Items[0]) // если размер числа 8 бит
            {
                do
                {
                    p = (uint)rnd.Next(1, 256);
                }
                while (!CheckSimple(p));
            }
            else 
            {
                if (comboBox1.SelectedItem == comboBox1.Items[1]) // если размер числа 16 бит
                {
                    do
                    {
                        p = (uint)rnd.Next(1, 65000);
                    }
                    while (!CheckSimple(p));
                }
                else // если размер числа 32 бит
                {
                    do
                    {
                        p = (uint)rnd.Next(1, 429496729);
                        p = p >> 1;
                    }
                    while (!CheckSimple(p));
                }
            }
            label11.Text = p.ToString();
        }

        // Проверка числа на простоту
        private bool CheckSimple(uint num)
        {
            double temp = Math.Sqrt(num);
            double i = 2;

            while (i <= temp)
            {
                if (num % i == 0)
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        // Ввод q автоматически
        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random(DateTime.Now.GetHashCode());

            if (comboBox2.SelectedItem == comboBox1.Items[0]) // если размер числа 8 бит
            {
                do
                {
                    q = (uint)rnd.Next(1, 256);
                }
                while (!CheckSimple(q));
            }
            else
            {
                if (comboBox2.SelectedItem == comboBox1.Items[1]) // если размер числа 16 бит
                {
                    do
                    {
                        q = (uint)rnd.Next(1, 65000);
                    }
                    while (!CheckSimple(q));
                }
                else // если размер числа 32 бит
                {
                    do
                    {
                        q = (uint)rnd.Next(1, 429496729);
                        q = q >> 1;
                    }
                    while (!CheckSimple(q));
                }
            }
            label12.Text = q.ToString();
        }

        // Ввод p из файла
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы |*.txt";
            OPF.Title = "Выбрать файл";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                StreamReader fin = new StreamReader(OPF.FileName);
                if (comboBox1.SelectedItem == comboBox1.Items[0]) // если размер числа 8 бит
                {
                    try
                    {
                        p = Convert.ToByte(fin.ReadLine(), 2);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка ввода p!");
                        label11.Text = "";
                        p = 0;
                        fin.Close();
                        return;
                    }
                }
                else
                {
                    if (comboBox1.SelectedItem == comboBox1.Items[1]) // если размер числа 16 бит
                    {
                        try
                        {
                            p = Convert.ToUInt16(fin.ReadLine(), 2);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка ввода p!");
                            label11.Text = "";
                            p = 0;
                            fin.Close();
                            return;
                        }
                    }
                    else // если размер числа 32 бит
                    {
                        try
                        {
                            p = Convert.ToUInt32(fin.ReadLine(), 2);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка ввода p!");
                            p = 0;
                            label11.Text = "";
                            fin.Close();
                            return;
                        }
                    }
                }
                if(CheckSimple(p))
                {
                    label11.Text = p.ToString();
                }
                else
                {
                    MessageBox.Show("Ошибка! Число p не простое!");
                    p = 0;
                    label11.Text = "";
                }
                fin.Close();
            }
        }

        // Ввод q из файла
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы |*.txt";
            OPF.Title = "Выбрать файл";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                StreamReader fin = new StreamReader(OPF.FileName);
                if (comboBox1.SelectedItem == comboBox1.Items[0]) // если размер числа 8 бит
                {
                    try
                    {
                        q = Convert.ToByte(fin.ReadLine(), 2);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка ввода q!");
                        label12.Text = "";
                        q = 0;
                        fin.Close();
                        return;
                    }
                }
                else
                {
                    if (comboBox1.SelectedItem == comboBox1.Items[1]) // если размер числа 16 бит
                    {
                        try
                        {
                            q = Convert.ToUInt16(fin.ReadLine(), 2);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка ввода q!");
                            label12.Text = "";
                            q = 0;
                            fin.Close();
                            return;
                        }
                    }
                    else // если размер числа 32 бит
                    {
                        try
                        {
                            q = Convert.ToUInt32(fin.ReadLine(), 2);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка ввода q!");
                            q = 0;
                            label12.Text = "";
                            fin.Close();
                            return;
                        }
                    }
                }
                if(CheckSimple(q))
                {
                    label12.Text = q.ToString();
                }
                else
                {
                    MessageBox.Show("Ошибка! Число q не простое!");
                    q = 0;
                    label12.Text = "";
                }
                fin.Close();
            }
        }

        // Если изменили ввод p
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = true;
            }
        }

        // Если изменили ввод q
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                button4.Enabled = true;
                button3.Enabled = false;
            }
            else
            {
                button4.Enabled = false;
                button3.Enabled = true;
            }
        }

        // Выбор файла шифрования/дешифрования
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы |";
            OPF.Title = "Выбрать файл";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                fileName = OPF.FileName;
                label8.Text = fileName;
            }
        }

        // Выбор каталога сохранения результатов
        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Выбрать директорию";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                directoryName = FBD.SelectedPath;
                label10.Text = directoryName;
            }
        }

        //обычный алгоритм Евклида через остатки
        ulong Nod(ulong a, ulong b)
        {
            while ((a > 0) && (b > 0))
                if (a >= b)
                    a %= b;
                else
                    b %= a;
            return a | b;
        }

        // Алгоритм быстрого возведения в степень
        private static ulong Power(BigInteger x, BigInteger y, ulong mod)
        {
            BigInteger count = 1;
            if (y == 0) return 1;
            while (y > 0)
            {
                if (y % 2 == 0)
                {
                    y /= 2;
                    x *= x;
                    x %= mod;
                }
                else
                {
                    y--;
                    count *= x;
                    count %= mod;
                }
            }
            return (ulong)(count % mod);
        }

        // Расширенныйы алгоритм Евклида - поиск мультипликативного обратного
        long gcdExtended(long a, long b, out long x, out long y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }

            long x1, y1; // Для сохранения результатов рекурсивного вызова
            long gcd = gcdExtended(b % a, a, out x1, out y1);

            x = y1 - (b / a) * x1;
            y = x1;
            return gcd;
        }

        //функция получения расширения файла
        private string GetExtension(string name)
        {
            int i;
            for (i = name.Length - 1; i >= 0; i--)
            {
                if (name[i] == '.')
                    break;
            }
            string extension = "";
            for (int j = i + 1; j < name.Length; j++)
            {
                extension += name[j];
            }
            return extension;
        }

        // Начало процесса 
        private void button7_Click(object sender, EventArgs ea)
        {
            if(((decodeKeys == "") && (radioButton6.Checked)) || (label8.Text == CHOOSE_FILE) || (label10.Text == CHOOSE_DIRECTORY))
            {
                MessageBox.Show("Ошибка! Не заданы все файлы для дешифрования!");
                return;
            }
            if(radioButton5.Checked)
            {
                if ((p == 0) || (q == 0) || (label8.Text == CHOOSE_FILE) || (label10.Text == CHOOSE_DIRECTORY))
                {
                    MessageBox.Show("Ошибка! Введены все данные!");
                    return;
                }
            }
            if (radioButton5.Checked) // шифрование 
            {
                ulong n = (ulong)p * (ulong)q;
                ulong fi = ((ulong)p - 1) * ((ulong)q - 1);
                ulong e;
                var r = new Random();
                var b = new byte[sizeof(ulong)];

                while (true)
                {
                    r.NextBytes(b);
                    e = BitConverter.ToUInt64(b, 0);
                    e >>= 5; // иначе переполнение
                    if (Nod(e, fi) == 1)
                        break;
                }
                long x, y;
                ulong d=0;

                gcdExtended( (long)e, (long)fi, out x, out y);
               // d =(ulong)((x %(long)fi + (long)fi) % (long)fi);
                d =(ulong)x;
                using (StreamWriter foutt = new StreamWriter(directoryName + "/Открытый ключ (для шифрования).txt"))
                {
                    foutt.WriteLine(Convert.ToString((long)e, 2));
                    foutt.WriteLine(Convert.ToString((long)n, 2));
                    foutt.Close();
                }
                using (StreamWriter foutt = new StreamWriter(directoryName + "/Закрытый ключ (для дешифрования).txt"))
                {
                    foutt.WriteLine(Convert.ToString((long)d, 2));
                    foutt.WriteLine(Convert.ToString((long)n, 2));
                    foutt.Close();
                }
                //открываем входной файл
                FileStream fstream = new FileStream(fileName, FileMode.Open);
                byte[] file = new byte[fstream.Length];
                fstream.Read(file, 0, file.Length);
                // создаём выходной файл
                FileStream fout = new FileStream(directoryName + "/зашифрованный файл", FileMode.Create);
                string extension = GetExtension(fileName); // вычисление расширения файла
                byte[] temp = new byte[1];
                temp[0] = (byte)extension.Length; 
                fout.Write(temp, 0, temp.Length); // записываем количество символов расширения
                // Записываем сами символы расширения
                for(int i=0; i < extension.Length; i++)
                {
                    temp[0] = (byte)extension[i];
                    fout.Write(temp, 0, temp.Length);
                }
                for (int i = 0; i < file.Length; i++)
                {
                    //ulong c = Power(file[i], e, n) % n;
                    ulong c = Power(file[i], e, n) % n;
                    byte[] bytes = BitConverter.GetBytes(c);
                    fout.Write(bytes, 0, bytes.Length);
                }
                fout.Close();
                fstream.Close();
                MessageBox.Show("Успех!");
                return;
            }
            else // дешифрование
            {
                ulong d, n;
                using (StreamReader fin = new StreamReader(decodeKeys))
                {
                    // Считываем d
                    try
                    {
                        string temp;
                        temp = fin.ReadLine();
                        d = Convert.ToUInt64(temp, 2);
                    }
                    catch
                    {
                        MessageBox.Show("Проблема при считывании ключа из файла!");
                        return;
                    }
                    // Считываем n
                    try
                    {
                        string temp;
                        temp = fin.ReadLine();
                        n = Convert.ToUInt64(temp, 2);
                    }
                    catch
                    {
                        MessageBox.Show("Проблема при считывании ключа из файла!");
                        return;
                    }
                    fin.Close();
                }
                FileStream fstream = new FileStream(fileName, FileMode.Open);
                byte[] file = new byte[fstream.Length];
                fstream.Read(file, 0, file.Length);
                fstream.Close();
                // Получаем расширение исходного файла
                byte extensionLength = file[0];
                string extension = "";

                for(int i=1; i<=extensionLength; i++)
                {
                    extension += (char)file[i];
                }

                FileStream fout = new FileStream(directoryName + "/расшифрованный файл." + extension, FileMode.Create);

                for (int i= extensionLength + 1; i < file.Length; i+=8)
                {
                    // Считываем число ulong из файла (оно занимает 8 байт)
                    byte[] bytes = new byte[8];
                    for(int j=0; j<8; j++)
                    {
                        bytes[j] = file[j + i];
                    }
                    ulong c =(ulong) BitConverter.ToInt64(bytes, 0);
                    ulong m = Power(c, d, n) % n;
                    byte[] outp = new byte[1];
                    outp[0] = (byte)m;
                    fout.Write(outp, 0, 1);
                }
                fout.Close();
            }
            MessageBox.Show("Успех!");
        }

        // Если изменили действие
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                OpenFileDialog OPF = new OpenFileDialog();
                OPF.Filter = "Файлы |*.txt";
                OPF.Title = "Файл к ключом дешифрования";
                if (OPF.ShowDialog() == DialogResult.OK)
                {
                    decodeKeys = OPF.FileName;
                }
            }
            else
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
            }
        }
    }
}
