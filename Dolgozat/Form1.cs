using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dolgozat
{
    
    public partial class Form1 : Form
    {
        databaseHandler db;
        int index;
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        public void Start()
        {
            db = new databaseHandler();
            db.readAll();
            foreach (pekaru item in pekaru.pekaruk)
            {
                listBox1.Items.Add($"{item.id}; {item.name}; {item.amount}; {item.price}");
            }
            listBox1.SelectedIndexChanged += (s, e) =>
            {
                index = listBox1.SelectedIndex;
            };
            button1.Click += (s, e) =>
            {
                pekaru OnePek = new pekaru();
                OnePek.name = textBox1.Text;
                OnePek.amount = Convert.ToInt32(textBox2.Text);
                OnePek.price = Convert.ToInt32(textBox3.Text);
                db.add(OnePek);
                update();

            };
            button2.Click += (s, e) =>
            {
                db.deleteOne(pekaru.pekaruk[index]);
                listBox1.Items.RemoveAt(index);
            };
            
        }
        
        public void update()
        {
            db = new databaseHandler();
            db.readAll();
            listBox1.Items.Add($"{textBox1.Text}; {textBox2.Text}; {textBox3.Text};");
            
        }
    }
}
