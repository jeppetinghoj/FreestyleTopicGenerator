using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Champen2019Generator
{
    public partial class Form1 : Form
    {
        private List<string> emner;
        Timer t = new Timer();

        public Form1()
        {
            InitializeComponent();
            t.Interval = 10000;
            t.Tick += new EventHandler(t_Tick);
            emner = new List<string>();
            AddToList("Mit eget politiske parti",
"En farlig fasan",
"Verdens dårligste orm",
"Forrådt af sin egen skygge",
"Ingen fest uden hest",
"Sidder fast i en Alphabeat sang",
"Samfundets sundhedsproblem",
"Johnny Madsen er min far",
"Nemmere end Nem-ID",
"Det gyldne håndtryk",
"No Nut november",
"Danmarks dårligste kroki-model",
"Uoverlagt børneporno",
"Laktoseintolerant",
"I et forhold med sig selv",
"At male fanden på væggen",
"Verdens første mammut-fælde",
"Bagbundet og forladt",
"Mors lille mobbeoffer",
"Arveløs",
"Kaste perler for svinene",
"Favorit sexstilling",
"Kongens efterfølger",
"Det der gør mig allermest vred",
"Konspirationsteorier",
"Evnen til at kunne tale med dyr",
"Drukne i sit eget pis",
"Den sjette sans",
"Det jeg smugler over grænsen",
"Mænd i natur, kvinder i bur",
"Internetkriger",
"Drikker kun dame-drinks",
"Da Jesus gik på vandet",
"Leger med Lars Von Trier",
"Nutidens Robin Hood",
"Mig og min boreplatform",
"Matchfixing",
"Nasserøv",
"Kunstig intelligens",
"Frossen som en istap",
"Hjemmelavet gryderet",
"Clean sheet",
"Hvis jeg regerede i Danmark",
"Champagnebrunch i Skagen",
"Fra våde kys til hardcore anal",
"Date mig nøgen",
"Syltede perleløg",
"I Isbil med ISIS",
"Morfars aflagte tøj",
"Faceplante på video",
"Skål for Champen",
"Strandet hval i Vejle ",
"Hvad der gemmer sig på bunden af en brønd",
"Colombiansk doping",
"Kødscooter (Aka. en hest)",
"Forvandlet til ruiner",
"Parkeringsvagt",
"Kødfrie burgers",
"Hemmelig webbrowser",
"Evig pubertet",
"Numse-operation (Butt-lift)",
"Posedame i Netto",
"Det italienske køkken ",
"Se verden gennem VR-briller",
"Genbrugs snus",
"Barber min bæver",
"Vandflyver ",
"Jurassic Park",
"Gå ned som Titanic",
"Disney-fan",
"For grim til at komme ind",
"Ansat hos Transportministeriet",
"De tre små Bukke Bruse",
"Det gamle testamente",
"Nikotinfri smøger",
"Vegansk Cheeseburger",
"Den dårligste på fodboldholdet",
"Fake facebookprofil ",
"I krig med min lanse",
"Livet er for kort til….",
"Usoigneret Urokse",
"De gule veste",
"Satellit i kredsløb",
"Bandeleder på flugt",
"Marvels filmunivers",
"Det hvide hus er min hybel",
"Vanvittig Skilsmisse",
"En skildpadde uden skjold",
"Barn fundet i blespand",
"Skattegæld",
"Lars Larsens aflagte seng",
"Bjergbestiger",
"Rottebøf",
"Voldtaget af en nonne",
"Presset til at være nøgen",
"Leaset Berlingo",
"Bogaktuelle Bendtner",
"Greta Thunberg",
"Skærpede Grænser",
"Intimkirurgi",
"Overvåget samfund",
"Ædegilde",
"Kørt over af en robotstøvsuger");

            listView1.View = View.Tile;
            PubListView();
            listView1.Visible = false;

        }

        void AddToList(params string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                emner.Add(list[i]);
            }
        }

        void PubListView()
        {
            foreach(string s in emner)
            {
                listView1.Items.Add(s);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StartScroll()
        {
            listView1.timer.Start();
        }

        private void StopScroll()
        {
            listView1.timer.Stop();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                t.Interval = Convert.ToInt32(textBox1.Text)*1000;
            }
            else
            {
                t.Interval = 5*1000;
            }
            listView1.Visible = true;
            label1.Visible = false;

            t.Start();
            StartScroll();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            StopScroll();
            t.Stop();
            listView1.Visible = false;
            var random = new Random();
            int index = random.Next(emner.Count);
            label1.Text = emner[index];
            label1.Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            runde1Timer = 60;
            label4.Text = runde1Timer.ToString();
            label4.Visible = true;
            t1 = new Timer();
            t1.Tick += new EventHandler(OnTimedEvent);
            t1.Interval = 1000;
            t1.Start();
        }
        Timer t1;
        private int runde1Timer;
        private void OnTimedEvent(object sender, EventArgs e)
        {
            runde1Timer--;
            label4.Text = runde1Timer.ToString();
            if(runde1Timer == 0) { t1.Stop(); button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            runde1Timer = 120;
            label4.Text = runde1Timer.ToString();  
            label4.Visible = true;
            t1 = new Timer();
            t1.Tick += new EventHandler(OnTimedEvent);
            t1.Interval = 1000;
            t1.Start();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
            label4.Visible = false;
            t1.Stop();
            t1 = null;
        }
    }
}
