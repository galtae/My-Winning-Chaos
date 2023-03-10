using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using My_Winning_Chaos_Util;
using System.Threading;


namespace My_Winning_Chaos_Util
{

    public partial class Form1 : Form
    {
        int info=0;
        int x, y;
        bool state = false;
        hooking gkh = new hooking();
        SoundPlayer sp = new SoundPlayer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gkh.KeyDown += new KeyEventHandler( process_keydown);
            gkh.KeyUp += new KeyEventHandler(process_keyup);
            
        }

        void process_keyup(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        void process_keydown(object sender, KeyEventArgs e)
        {
         
            if (state == true)
            {

                if (radioButton3.Checked == false)
                {
                    if (e.KeyCode == Keys.Z)
                    {

                         do_portal();

                    }
                    if (e.KeyCode == gkh.n_change)
                    {
                        if (radioButton1.Checked)
                        {
                            radioButton1.Checked = false;
                            radioButton2.Checked = true;
                            sp.Stream = Properties.Resources.스콜지;
                            sp.Play();

                        }

                        else if(radioButton2.Checked)
                        {
                            radioButton1.Checked = true;
                            radioButton2.Checked = false;
                            sp.Stream = Properties.Resources.센티널;
                            sp.Play();
                        }

                        
                    }


                }

                           }
            e.Handled = true;
        }

        void do_portal()
        {

            if (radioButton1.Checked == true)
            {
               
                         
                switch (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width)
                        
                {
                    case 640:
                        x = 110;
                        y = 455;
                  
                        break;
                    case 800:
                        x = 137;
                        y = 569;

                        break;
                    case 1024:
                        x = 176;
                        y = 728;
                        break;

                    case 1152:
                        // 내를 위해 임시 조정
                        /*
                        x = 198;
                        y = 819;
                         */
                        x = 197;
                        y = 792;

                        break;

                    case 1280:
                    //    x = 220;
                        x = 219;
                        if(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height == 960)
                            y = 910;

                        if (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height == 1024)
                        //    y = 971;
                            y = 913;
                        break;

                    case 720 :
                        x = 124;
                        y = 546;
                        break;
                    default :

                        x = 220;
                         y = 758;
                   
                         break;

                }
 
            }

            else if (radioButton2.Checked == true)
            {

                switch (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width)
                {
                    case 640:
                        x = 18;
                        y = 385;
                        break;
                    case 800:
                        x = 22;
                        y = 481;

                        break;
                    case 1024:
                        x = 29;
                        y = 615;
                        break;

                    case 1152:
                        // 내를 위해 임시 조정
                        /*
                         * x = 32;
                        y = 693;
                        
                         */
                        x = 30;
                        y = 673;
                        break;

                    case 1280:
                        //x = 36;
                        x = 33;
                        if (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height == 960)
                        y = 770;

                        if (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height == 1024)
                            //y = 821;
                            y = 775;
                        break;

                    case 720:
                        x = 20;
                        y = 438;
                        break;

                    default:
                        x = 30;
                        y = 640;
                        break;
                        
                }
            }
        /*
            hooking.keybd_event((byte)Keys.Z, 0x00, 0, ref info);
            hooking.keybd_event((byte)Keys.Z, 0x00, 2, ref info);

            hooking.SetCursorPos(x, y);
            hooking.mouse_event((int)hooking.MouseEventFlags.LEFTDOWN, (uint)x, (uint)y, 0, 0);
            hooking.mouse_event((int)hooking.MouseEventFlags.LEFTUP, (uint)x, (uint)y, 0, 0);

            Thread.Sleep(10);
            hooking.mouse_event((int)hooking.MouseEventFlags.LEFTDOWN, (uint)x, (uint)y, 0, 0);
            hooking.mouse_event((int)hooking.MouseEventFlags.LEFTUP, (uint)x, (uint)y, 0, 0);
         * 
       */
          
           
            hooking.keybd_event((byte)Keys.Z, 0x00, 0, ref info);
            hooking.keybd_event((byte)Keys.Z, 0x00, 2, ref info);

            Thread.Sleep(1);
                hooking.SetCursorPos(x, y);
                hooking.mouse_event((int)hooking.MouseEventFlags.LEFTDOWN, (uint)x, (uint)y, 0, 0);
                hooking.mouse_event((int)hooking.MouseEventFlags.LEFTUP, (uint)x, (uint)y, 0, 0);

                hooking.SetCursorPos(x, y);
                hooking.mouse_event((int)hooking.MouseEventFlags.LEFTDOWN, (uint)x, (uint)y, 0, 0);
                hooking.mouse_event((int)hooking.MouseEventFlags.LEFTUP, (uint)x, (uint)y, 0, 0);


           

            
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            state = true;


            button3.Enabled = false;
            button4.Enabled = false;
            textBox3.Enabled = false;

            textBox_onoff.Enabled = false;
            b_onoff.Enabled = false;
            b_onoff_calcel.Enabled = false;

            b1.Enabled = false;
            b2.Enabled = false;
            b4.Enabled = false;
            b5.Enabled = false;
            b7.Enabled = false;
            b8.Enabled = false;
            cancel1.Enabled = false;
            cancel2.Enabled = false;
            cancel4.Enabled = false;
            cancel5.Enabled = false;
            cancel7.Enabled = false;
            cancel8.Enabled = false;

            gkh.state = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            state = false;

            b1.Enabled = true;
            b2.Enabled = true;
            b4.Enabled = true;
            b5.Enabled = true;
            b7.Enabled = true;
            b8.Enabled = true;

            button3.Enabled = true;
            button4.Enabled = true;
            textBox3.Enabled = true;


            textBox_onoff.Enabled = true;
            b_onoff.Enabled = true;
            b_onoff_calcel.Enabled = true;

            cancel1.Enabled = true;
            cancel2.Enabled = true;
            cancel4.Enabled = true;
            cancel5.Enabled = true;
            cancel7.Enabled = true;
            cancel8.Enabled = true;

            gkh.state = false;
        }

        private void b7_Click(object sender, EventArgs e)
        {
      
            gkh.KeyDown += new KeyEventHandler(set_key_7);
        }

      
        void set_key_7(object sender, KeyEventArgs e)
        {
            textBox7.Text = e.KeyCode.ToString();
            gkh.n7 = e.KeyCode;
            gkh.KeyDown -= new KeyEventHandler(set_key_7);
        }

        private void cancel7_Click(object sender, EventArgs e)
        {
            textBox7.Text = null;
            gkh.n7 = Keys.None;
        }

        private void b8_Click(object sender, EventArgs e)
        {
            gkh.KeyDown += new KeyEventHandler(set_key_8);

        }

        void set_key_8(object sender, KeyEventArgs e)
        {
            textBox8.Text = e.KeyCode.ToString();
            gkh.n8 = e.KeyCode;
            gkh.KeyDown -= new KeyEventHandler(set_key_8);
        }

        private void cancel8_Click(object sender, EventArgs e)
        {
            textBox8.Text = null;
            gkh.n8 = Keys.None;

        }

        private void b4_Click(object sender, EventArgs e)
        {
            gkh.KeyDown += new KeyEventHandler(set_key_4);
        }

        void set_key_4(object sender, KeyEventArgs e)
        {
            textBox4.Text = e.KeyCode.ToString();
            gkh.n4 = e.KeyCode;
            gkh.KeyDown -= new KeyEventHandler(set_key_4);
            //throw new NotImplementedException();
        }

        private void cancel4_Click(object sender, EventArgs e)
        {
            textBox4.Text = null;
            gkh.n4 = Keys.None;
        }

        private void b5_Click(object sender, EventArgs e)
        {
            gkh.KeyDown += new KeyEventHandler(set_key_5);
        }

        void set_key_5(object sender, KeyEventArgs e)
        {
            textBox5.Text = e.KeyCode.ToString();
            gkh.n5 = e.KeyCode;
            gkh.KeyDown -= new KeyEventHandler(set_key_5);
        }

        private void cancel5_Click(object sender, EventArgs e)
        {
            textBox5.Text = null;
            gkh.n5 = Keys.None;
        }

        private void b1_Click(object sender, EventArgs e)
        {
            gkh.KeyDown += new KeyEventHandler(set_key_1);
        }

        void set_key_1(object sender, KeyEventArgs e)
        {
            textBox1.Text = e.KeyCode.ToString();
            gkh.n1 = e.KeyCode;
            gkh.KeyDown -= new KeyEventHandler(set_key_1);
        }

        private void cancel1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            gkh.n1 = Keys.None;

        }

        private void b2_Click(object sender, EventArgs e)
        {
            gkh.KeyDown += new KeyEventHandler(set_key_2);
        }

        void set_key_2(object sender, KeyEventArgs e)
        {
            textBox2.Text = e.KeyCode.ToString();
            gkh.n2 = e.KeyCode;
            gkh.KeyDown -= new KeyEventHandler(set_key_2);
        }

        private void cancel2_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            gkh.n2 = Keys.None;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gkh.KeyDown += new KeyEventHandler(set_key_change);
        }

        void set_key_change(object sender, KeyEventArgs e)
        {
            textBox3.Text = e.KeyCode.ToString();
            gkh.n_change = e.KeyCode;
            gkh.KeyDown -= new KeyEventHandler(set_key_change);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = null;
            gkh.n_change = Keys.None;
        }

        private void b_onoff_Click(object sender, EventArgs e)
        {
            gkh.KeyDown += new KeyEventHandler(set_key_onoff);
        }

        void set_key_onoff(object sender, KeyEventArgs e)
        {
            textBox_onoff.Text = e.KeyCode.ToString();
            gkh.n_onoff = e.KeyCode;
            gkh.KeyDown -= new KeyEventHandler(set_key_onoff);
        }

        private void b_onoff_calcel_Click(object sender, EventArgs e)
        {
            textBox_onoff.Text = null;
            gkh.n_onoff = Keys.None;
        }

     
    }
}
