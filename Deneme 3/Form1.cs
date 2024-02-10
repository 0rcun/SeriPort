using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Deneme_3
{
    public partial class Form1 : Form
    {
        string[] portlar = SerialPort.GetPortNames();
        public Form1()
        {
            InitializeComponent();
            serialPort1.BaudRate = 9600;
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
            serialPort1.Open();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(string port in portlar)
            {
                comboBox1.Items.Add(port);
                comboBox1.SelectedIndex = 0;
            }
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data;
            string[] splitted_data;
            data = serialPort1.ReadLine();
            splitted_data = data.Split('*');
      
            
            textBox1.Text = splitted_data[0];
            textBox2.Text = splitted_data[1];
            textBox3.Text = splitted_data[2];

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            serialPort1.Write("0");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            serialPort1.Write("1");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            serialPort1.Write("2");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
