using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSVLV1RB
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer t;
        private int sati;
        private int minute;
        private bool alarmIsSet = false;
        private bool alarmIsInvoked = false;
         public Form1()
         {
             InitializeComponent();
             //Kreiranje timer-a s periodom od 1000 ms
             t = new System.Timers.Timer(1000);

             //Dodavanje događaja timer-u; izvršava se periodno
             t.Elapsed += new System.Timers.ElapsedEventHandler(vrijeme);
             t.Start();
             this.btn_start_stop.Click += new System.EventHandler(this.btn_set_alarm);
             btn_start_stop.Text = "Postavi alarm";
             label2.Text = "Sati:";
             label3.Text = "Minute:";
             label4.Text = "";

         }

         private void vrijeme(object s, EventArgs e)
         {
             Invoke((MethodInvoker)delegate //Anonimna metoda
             {

                 label1.Text = DateTime.Now.ToLongTimeString();

                 if (alarmIsSet && alarmIsInvoked== false)
                 {
                     if (DateTime.Now.Hour== sati && DateTime.Now.Minute== minute)
                     {
                         Console.Beep(500,5000);
                         //MessageBox.Show("Alarm triggered!");
                         label4.Text = "";
                         alarmIsInvoked = true;
                         //alarmIsSet = false;
                     }
                 }
             });
         }

         private void btn_set_alarm(object sender, EventArgs e)
         {
             sati = (int)numericUpDown1.Value;
             minute = (int)numericUpDown2.Value;
             label4.Text = "Alarm je postavljen u " + sati + " : " + minute;
             alarmIsSet = true;
             alarmIsInvoked = false;
         }

    }
}
