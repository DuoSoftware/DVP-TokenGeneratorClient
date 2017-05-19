using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;


namespace FacetoneTenantTokenGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.ToString() != null)
            {
                var dateAndTime = DateTime.Now;
                int year = dateAndTime.Year;
                string month = DateTime.Now.ToString("MMMM"); 
                int day = dateAndTime.Day;
                
                string pass = "DuoS123412341234";
                string enctrptedText = textBox1.Text.ToString(); //+ day + month + year;                
                string iv = "0123456789@#$%&*";

                byte[] inputBytes = ASCIIEncoding.UTF8.GetBytes(enctrptedText);
                byte[] keyBytes = ASCIIEncoding.UTF8.GetBytes(pass);
                byte[] ivArr = ASCIIEncoding.UTF8.GetBytes(iv);


                /*
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] result = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    sb.Append(result[i].ToString("X2"));
                }

                Console.WriteLine(sb.ToString());
                */


                // Initialize AES CTR (counter) mode cipher from the BouncyCastle cryptography library
                IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CTR/NoPadding");

                cipher.Init(true, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("AES", keyBytes), ivArr));

                byte[] encryptedBytes = cipher.DoFinal(inputBytes);

                textBox2.Text = BitConverter.ToString(encryptedBytes).Replace("-", "").ToLower();
            }


        }

        
        
    }
}
