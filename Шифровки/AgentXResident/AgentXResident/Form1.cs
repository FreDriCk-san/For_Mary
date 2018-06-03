using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AgentXResident
{
    public partial class Form1 : Form
    {
        private Dictionary<char, char> alphabetFinal = new Dictionary<char, char>();
        private List<char> alphabetOrig = new List<char>();
        private int alphabetPower;
        private string stringKey;
        private byte[] encodedText;

        public Form1()
        {
            InitializeComponent();
        }

        //Загрузка текста
        private void button5_Click(object sender, EventArgs e)
        {
            Stream loadStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Clear();

                try
                {
                    if ((loadStream = openFileDialog1.OpenFile()) != null) {  }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("ОШИБКА: Не удалось считать файл. Проблема: " + exception.Message);
                }
            }

            textBox1.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);

        }                   

        //Шифровка простой заменой
        private void button1_Click(object sender, EventArgs e)
        {
            //Шифровка
            if (radioButton1.Checked)
            {
                if (null != textBox1.Text && 0 != textBox1.Text.Length)
                {
                    textBox2.Clear();
                    alphabetFinal.Clear();

                    Random random = new Random();
                    List<char> cloneOfOrig = new List<char>(alphabetOrig);
                    List<char> alphabetCoded = new List<char>();
                    List<char> encodedText = new List<char>();


                    while (cloneOfOrig.Count > 0)
                    {
                        int index = random.Next(cloneOfOrig.Count);
                        alphabetCoded.Add(cloneOfOrig[index]);
                        cloneOfOrig.RemoveAt(index);
                    }

                    //Добавление полученных результатов в словарь (Пример: [А, 1041]...)
                    for (int i = 0; i < alphabetCoded.Count; ++i)
                    {
                        char currentKey = alphabetOrig.ElementAt(i);
                        alphabetFinal.Add(currentKey, (char)alphabetCoded.ElementAt(i));
                    }

                    //Шифровка текста
                    for (int i = 0; i < textBox1.Text.Length; ++i)
                    {
                        char position = textBox1.Text.ElementAt(i);
                        if (coincidence(alphabetFinal, position))
                        {
                            encodedText.Add((char)alphabetFinal[position]);                                 //Обращение по ключу к значению списка
                        }
                        else
                        {
                            encodedText.Add(position);
                        }
                    }

                    textBox2.Text = String.Join("", encodedText);                                               //Вывод шифрованного текста
                    textBox2.Text += Environment.NewLine + String.Join(Environment.NewLine, alphabetFinal);    //Вывод ключей

                }

            }

            //Дешифровка
            else if (radioButton2.Checked)
            {

                List<char> decodedText = new List<char>();

                textBox2.Clear();
                var firstElement = alphabetFinal.Keys.First();
                var lastElement = alphabetFinal.Keys.Last();

                for (int i = 0; i < textBox1.Text.Length; ++i)
                {
                    char position = textBox1.Text.ElementAt(i);
                    if (coincidence(alphabetFinal, position))
                    {
                        var getKey = alphabetFinal.FirstOrDefault(x => x.Value == position).Key;
                        decodedText.Add(getKey);
                    }
                    else
                    {
                        decodedText.Add(position);
                    }

                }

                textBox2.Text = String.Join("", decodedText);

            }

            else
            {
                MessageBox.Show("Системная ошибка!");
            }


        }     

        //Сохранение текста
        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            File.WriteAllText (saveFileDialog1.FileName + ".txt", textBox2.Text, Encoding.Default);
        }

        //Очистка textBox1
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        //Очистка textBox2
        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        //Шифровка методом Цезаря
        private void button3_Click(object sender, EventArgs e)
        {
            int key;
            try
            {
                key = Convert.ToInt32(stringKey);
            }
            catch
            {
                MessageBox.Show("Введёный ключ - не число! По умолчанию ставится 2");
                key = 2;
            }

            if (radioButton1.Checked)
            {
                //Шифровка
                textBox2.Clear();
                alphabetFinal.Clear();

                Random random = new Random();
                List<char> cloneOfOrig = new List<char>(alphabetOrig);
                List<char> alphabetCoded = new List<char>();
                List<char> encodedText = new List<char>();

                
                for (int i = 0; i < cloneOfOrig.Count; ++i)
                {
                    char position = cloneOfOrig.ElementAt(i);
                    int encoded = (position + key);
                    alphabetCoded.Add((char)encoded);
                }

                for (int i = 0; i < alphabetCoded.Count; ++i)
                {
                    char currentKey = alphabetOrig.ElementAt(i);
                    alphabetFinal.Add(currentKey, (char)alphabetCoded.ElementAt(i));
                }

                for (int i = 0; i < textBox1.Text.Length; ++i)
                {
                    char position = textBox1.Text.ElementAt(i);
                    if (coincidence(alphabetFinal, position))
                    {
                        encodedText.Add((char)alphabetFinal[position]);
                    }
                    else
                    {
                        encodedText.Add(position);
                    }
                }

                textBox2.Text = String.Join("", encodedText);
                textBox2.Text += Environment.NewLine + String.Join(Environment.NewLine, alphabetFinal);
            }

            else if (radioButton2.Checked)
            {
                //Дешифровка
                List<char> decodedText = new List<char>();

                textBox2.Clear();
                var firstElement = alphabetFinal.First().Value;
                var lastElement = alphabetFinal.Last().Value;

                for (int i = 0; i < textBox1.Text.Length; ++i)
                {
                    char position = textBox1.Text.ElementAt(i);
                    if (coincidence(alphabetFinal, position))
                    {
                        var getKey = alphabetFinal.FirstOrDefault(x => x.Value == position).Key;
                        decodedText.Add(getKey);
                    }
                    else
                    {
                        decodedText.Add(position);
                    }

                }

                textBox2.Text = String.Join("", decodedText);
            }

            else
            {
                MessageBox.Show("СИСТЕМНАЯ ОШИБКА!!!");
            }

        }

        //Блочная шифровка
        private void button2_Click(object sender, EventArgs e)
        {
            int key;
            try
            {
                key = Convert.ToInt32(stringKey);
            }
            catch
            {
                MessageBox.Show("Введёный ключ - не число! По умолчанию ставится 2");
                key = 2;
            }
            
            
            //Шифровка
            if (radioButton1.Checked)
            {
                textBox2.Clear();
                alphabetFinal.Clear();

                Random random = new Random();
                List<string> listOfStrings = new List<string>();
                string originalText = textBox1.Text;
                string temp = "";
                
                while (originalText.Length % key != 0)
                {
                    originalText += "#";
                }

                originalText += " ";

                for (int i = 0; i < originalText.Length; ++i)
                {
                    char position = originalText.ElementAt(i);
                    if (i % key == 0 && i != 0)
                    {
                        listOfStrings.Add(temp);
                        temp = "";
                    }
                    temp += position;
                }

                List<string> shuffledList = new List<string>();

                while (listOfStrings.Count > 0)
                {
                    int index = random.Next(listOfStrings.Count);
                    shuffledList.Add(listOfStrings[index]);
                    listOfStrings.RemoveAt(index);
                }

                textBox2.Text = String.Join("||", shuffledList);

            }

            //Дешифровка
            else if (radioButton2.Checked)
            {

            }

            else
            {
                MessageBox.Show("СИСТЕМНАЯ ОШИБКА!!!");
            }

        }

        //Заполнение алфавитом
        private void button9_Click(object sender, EventArgs e)
        {
            alphabetFinal.Clear();

            for (int i = 0; i < textBox3.Text.Length; ++i)
            {
                char position = textBox3.Text.ElementAt(i);
                if (position.Equals(' ')) continue;
                alphabetOrig.Add(position);
                alphabetPower++;
            }
        }

        private void endAlphabet()
        {
            label2.Visible = true;
            button5.Visible = true;
            button7.Visible = true;
            textBox1.Visible = true;
            label3.Visible = true;
            button6.Visible = true;
            button8.Visible = true;
            textBox2.Visible = true;
            button10.Visible = true;
        }

        private void startAlphabet()
        {
            label5.Visible = true;
            textBox3.Visible = true;
            button9.Visible = true;
            label2.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            textBox1.Visible = false;
            label3.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            textBox2.Visible = false;

        }

        private void enableButtons()
        {
            button1.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
        }

        private void disableButtons()
        {
            button1.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
        }

        private bool coincidence(Dictionary<char, char> searchDic, char element)
        {
            for (int i = 0; i < searchDic.Count; ++i)
            {
                char position = searchDic.Keys.ElementAt(i);
                if (position.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        private byte[] encodeXOR (string sText, string sKey)
        {
            byte[] txt = Encoding.Default.GetBytes(sText);
            byte[] key = Encoding.Default.GetBytes(sKey);
            byte[] res = new byte[sText.Length];

            for(int i = 0; i < txt.Length; ++i)
            {
                res[i] = (byte)(txt[i] ^ key[i % key.Length]);
            }

            return res;
        }

        private string decodeXOR (byte[] sText, string sKey)
        {
            byte[] res = new byte[sText.Length];
            byte[] key = Encoding.Default.GetBytes(sKey);

            for(int i = 0; i < sText.Length; ++i)
            {
                res[i] = (byte)(sText[i] ^ key[i % key.Length]);
            }

            return Encoding.Default.GetString(res);
        }

        //Шифровка XOR
        private void button4_Click(object sender, EventArgs e)
        {

            //Шифровка
            if (radioButton1.Checked && null != stringKey)
            {
                encodedText = encodeXOR(textBox1.Text, stringKey);
                textBox2.Text = String.Join(" ", Encoding.UTF8.GetString(encodedText));
            }

            //Дешифровка
            else if (radioButton2.Checked)
            {
                textBox2.Text = String.Join(" ", decodeXOR(encodedText, stringKey));
            }

            else
            {
                MessageBox.Show("СИСТЕМНАЯ ОШИБКА!!!");
            }

        }

        //Ввод ключа
        private void button11_Click(object sender, EventArgs e)
        {
            stringKey = textBox4.Text;
            enableButtons();
            endAlphabet();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = textBox2.Text;
            textBox2.Clear();
        }
    }
}
