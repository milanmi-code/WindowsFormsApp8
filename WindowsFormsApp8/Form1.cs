using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        int index;
        databasehendler db;
        public Form1()
        {
            InitializeComponent();
            start();
        }
        public void start() {
            db = new databasehendler();
            db.readdb();
            foreach (bakery item in bakery.products)
            {
                listBox1.Items.Add($"{item.id}.   {item.name}.  mennyiseg{item.amount}.  ar{item.price}");
            }
            listBox1.SelectedIndexChanged += (s, e) => {
                index = listBox1.SelectedIndex;
            };

            button1.Click += (s, e) => {
                bakery oneproduct = new bakery();
                oneproduct.name = textBox1.Text;
                oneproduct.amount = Convert.ToInt32(textBox2.Text);
                oneproduct.price = Convert.ToInt32(textBox3.Text);
                db.writedb(oneproduct);
                update();
                
                
            };
            button2.Click += (s, e) => {
                db.deletdb(bakery.products[index]);
               
                listBox1.Items.RemoveAt(index);
            };
            
        }
        public void update()
        {
            
            db = new databasehendler();
            db.readdb();
            listBox1.Items.Add($"{textBox1.Text}.  mennyiseg{textBox2.Text}.  ar{textBox3.Text}");
            
            

        }
    }
}
