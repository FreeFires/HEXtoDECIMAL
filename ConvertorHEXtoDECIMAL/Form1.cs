using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ConvertorHEXtoDECIMAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click_1(object sender, EventArgs e)
        {
            string hexValue = tbHex.Text;
            long decValue = Int64.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
            tbDecimal.Text = Convert.ToString(decValue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(tbDecimal.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)  
        {
            this.Close();
        }

        private SerialPort serialPort = new SerialPort("COM2", 2400, Parity.None, 8, StopBits.One);

        private void BtnOpenCom_Click(object sender, EventArgs e)
        {
            //SerialPort serialPort = new SerialPort("COM2", 2400, Parity.None, 8, StopBits.One);
            serialPort.Open();
            bool _open = true;
            
            if(serialPort.IsOpen)
            {
                lbChekComPort.Text = "COM2 відкритий";
                while (_open)
                {
                    try
                    {
                        string massege = serialPort.ReadLine();
                        int mass = serialPort.GetHashCode();
                        //tbHex.Text = massege;
                        tbHex.Text = Convert.ToString(mass);
                    }
                    catch(TimeoutException)
                    {

                    }
                    finally
                    {
                        _open = false;
                    }   
                }
            }
            else
            {
                lbChekComPort.Text = "COM2 закритий";
            }
        }

        private void BtnCloseCom_Click(object sender, EventArgs e)
        {
            serialPort.Close();
        }


        /*private void tbHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if (l < 'A' || l > 'Z' && l != ',' && l != ' ')
            {
                e.Handled = true;
            }
        }*/

    }
}
