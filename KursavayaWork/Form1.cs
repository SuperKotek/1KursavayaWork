using KursavayaWork.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace KursavayaWork
{
    public partial class Form1 : Form
    {
        List<(int, string, string, int)> GeneralMassive = new List<(int, string, string, int)>();
        List<(int, string, string, int)> RememberMassive = new List<(int, string, string, int)>();
        List<Panel> Pnls = new List<Panel> ();

        public Form1()
        {
            InitializeComponent();

            GeneralMassive = Massive.FileStartReading(0, Massive.ChooseAFile(0, Massive.WhodAFile(Pnl8_DataGriv1)));
            RememberMassive = GeneralMassive;

            Panel[] pop = { Panel1FindElement, Panel2AddFileB, Panel3RemoveFile, Panel4NameSort,
            Panel5MaxCountFiles, Panel6DataInPeriod, Panel7ViborkaSimbols, Panel8AddFileA, Panel9SaveDoc};
            Pnls.AddRange(pop);

            ChangeCountList();
            ChangePanel(Pnls, 0);

            for (int i = 0; i < GeneralMassive.Count; i++)
            { DataGrivGeneral.Rows.Add(GeneralMassive[i].Item1, GeneralMassive[i].Item2, GeneralMassive[i].Item3, GeneralMassive[i].Item4); }

            string[] addvar = { "После элемента", "Перед элементом", "В начале списка" };
            Pnl2_ComBox1.Items.AddRange(addvar);

            string[] month = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", 
            "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            Pnl2_ComBox2.Items.AddRange(month);
            Pnl3_ComBox1.Items.AddRange(month);
            Pnl6_Combox1.Items.AddRange(month);
            Pnl6_Combox2.Items.AddRange(month);
        }

        public void ChangePanel(List<Panel> Pnls, int numbr)
        {
            for (int i = 0; i < Pnls.Count; i++)
            {
                if (i == numbr)
                { Pnls[i].Visible = true; }
                else
                { Pnls[i].Visible = false; }
            }
        }

        public void ChangeCountList()
        {
            Pnl1_Numero1.Maximum = GeneralMassive.Count;
            Pnl2_Numero1.Maximum = GeneralMassive.Count;
            Pnl5_Numero1.Maximum = GeneralMassive.Count;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {  }

        /*private void Form1_Resize(object sender, EventArgs e)
        {
            Pnl1_Label1.Font = TextRedactor.TxtRedactor(this.Width, this.Height, Pnl1_Label1.Font, 18f);
            Pnl1_Label1.Location = TextRedactor.LocationChange(Pnl1_Label1.Location.X, Pnl1_Label1.Location.Y, 100, 1, Width, Height);
            Pnl1_Label2.Font = TextRedactor.TxtRedactor(this.Width, this.Height, Pnl1_Label2.Font, 14f);
            Pnl1_Label2.Location = new Point(Pnl1_Label2.Location.X, Pnl1_Label2.Location.Y);
            Pnl1_Label3.Font = TextRedactor.TxtRedactor(this.Width, this.Height, Pnl1_Label2.Font, 14f);
            Pnl1_Label4.Font = TextRedactor.TxtRedactor(this.Width, this.Height, Pnl1_Label2.Font, 14f);
            Pnl1_Label5.Font = TextRedactor.TxtRedactor(this.Width, this.Height, Pnl1_Label2.Font, 14f);
            Pnl1_Numero1.Font = TextRedactor.TxtRedactor(this.Width, this.Height, Pnl1_Numero1.Font, 14f);
            Pnl1_TextBx1.Font = TextRedactor.TxtRedactor(this.Width, this.Height, Pnl1_Numero1.Font, 14f);
            Pnl1_TextBx2.Font = TextRedactor.TxtRedactor(this.Width, this.Height, Pnl1_Numero1.Font, 14f);
            Pnl1_TextBx3.Font = TextRedactor.TxtRedactor(this.Width, this.Height, Pnl1_Numero1.Font, 14f);
        }*/

        private void MenuButton0_Click(object sender, EventArgs e)
        { ChangePanel(Pnls, 0); }
        private void MenuButton1_Click(object sender, EventArgs e)
        { ChangePanel(Pnls, 1); }
        private void MenuButton2_Click(object sender, EventArgs e)
        { ChangePanel(Pnls, 2); }
        private void MenuButton3_Click(object sender, EventArgs e)
        { ChangePanel(Pnls, 3); }
        private void MenuButton4_Click(object sender, EventArgs e)
        { 
            ChangePanel(Pnls, 4);
            RememberMassive = GeneralMassive;
        }
        private void MenuButton5_Click(object sender, EventArgs e)
        { 
            ChangePanel(Pnls, 5);
            RememberMassive = GeneralMassive;
        }
        private void MenuButton6_Click(object sender, EventArgs e)
        { 
            ChangePanel(Pnls, 6);
            RememberMassive = GeneralMassive;
        }
        private void MenuButton7_Click(object sender, EventArgs e)
        { 
            ChangePanel(Pnls, 7);
            FileInfo[] AllFiles = Massive.WhodAFile(Pnl8_DataGriv1);
            Pnl8_Numero1.Maximum = AllFiles.Length;
        }
        private void MenuButton8_Click(object sender, EventArgs e)
        { 
            ChangePanel(Pnls, 8);
        }
        
        // Панель Первая
        private void Pnl1_Numero1_ValueChanged(object sender, EventArgs e)
        {
            int znach = (int)Pnl1_Numero1.Value-1;
            if (znach == -1)
            {
                Pnl1_TextBx1.Text = "-";
                Pnl1_TextBx2.Text = "-";
                Pnl1_TextBx3.Text = "-";
            }
            else
            {
                try
                {
                    Pnl1_TextBx1.Text = GeneralMassive[znach].Item2;
                    Pnl1_TextBx2.Text = GeneralMassive[znach].Item3;
                    Pnl1_TextBx3.Text = GeneralMassive[znach].Item4.ToString();
                }
                catch (Exception)
                {
                    Pnl1_TextBx1.Text = "Не получается найти файл";
                    Pnl1_TextBx2.Text = "";
                    Pnl1_TextBx3.Text = "";
                }
            }
        }

        //  Панель Вторая
        private void Pnl2_ComBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Pnl2_ComBox1.SelectedIndex == 2)
            { 
                Pnl2_Label3.Visible = false;
                Pnl2_Numero1.Visible = false;
            }
            else
            {
                Pnl2_Label3.Visible = true;
                Pnl2_Numero1.Visible = true;
            }
        }
        private void Pnl2_ComBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = Pnl2_ComBox2.SelectedIndex;
            if (a == 0 || a == 2 || a == 4 || a == 6 || a == 7 || a == 9 || a == 11)
            { Pnl2_Numero2.Maximum = 31; }
            else if (a == 3 || a == 5 || a == 8 || a == 10)
            { Pnl2_Numero2.Maximum = 30; }
            else
            {
                if (Pnl2_Numero3.Value % 4 == 0 && Pnl2_Numero3.Value % 100 != 0)
                { Pnl2_Numero2.Maximum = 29; }
                else
                { Pnl2_Numero2.Maximum = 28; }
            }
        }
        private void Pnl2_Numero3_ValueChanged(object sender, EventArgs e)
        {
            if (Pnl2_ComBox2.SelectedIndex == 1)
            {
                if (Pnl2_Numero3.Value % 4 == 0 && Pnl2_Numero3.Value % 100 != 0)
                { Pnl2_Numero2.Maximum = 29; }
                else
                { Pnl2_Numero2.Maximum = 28; }
            }
        }
        private void Pnl2_Button1_Click(object sender, EventArgs e)
        {
            string name = Pnl2_TextBx1.Text;
            string data = Pnl2_Numero2.Value.ToString() + "." + Pnl2_ComBox2.SelectedIndex + "." + Pnl2_Numero3.Value.ToString();
            int kolvo = (int)Pnl2_Numero4.Value;
            int flag = 1;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                {
                    flag = 0;
                }
            }
            if (flag == 0)
            { Pnl2_TextBx1.Text = "Имя не должно содержать пробелов"; }
            else
            {
                if (GeneralMassive.Count == 0)
                {
                    GeneralMassive.Add((1, name, data, kolvo));
                }
                else if (Pnl2_ComBox1.SelectedIndex == 2)
                { GeneralMassive = Massive.AddingFiles(GeneralMassive, 1, 1, name, data, kolvo); }
                else 
                {
                    int numind = (int)Pnl2_Numero1.Value;
                    GeneralMassive = Massive.AddingFiles(GeneralMassive, numind, Pnl2_ComBox1.SelectedIndex, name, data, kolvo);
                }
                DataGrivGeneral.Rows.Clear();
                for (int i = 0; i < GeneralMassive.Count; i++)
                { DataGrivGeneral.Rows.Add(GeneralMassive[i].Item1, GeneralMassive[i].Item2,
                GeneralMassive[i].Item3, GeneralMassive[i].Item4); }
            }
            ChangeCountList();
        }
        // Панель Третья
        private void Pnl3_Button1_Click(object sender, EventArgs e)
        {
            string data = Pnl3_Numero1.Value.ToString() + "." + Pnl3_ComBox1.SelectedIndex + "." + Pnl3_Numero2.Value.ToString();
            GeneralMassive = Massive.RemovingFilesForDato(GeneralMassive, data);
            DataGrivGeneral.Rows.Clear();
            for (int i = 0; i < GeneralMassive.Count; i++)
            { DataGrivGeneral.Rows.Add(GeneralMassive[i].Item1, GeneralMassive[i].Item2, 
            GeneralMassive[i].Item3, GeneralMassive[i].Item4); }
            ChangeCountList();
        }
        private void Pnl3_ComBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = Pnl3_ComBox1.SelectedIndex;
            if (a == 0 || a == 2 || a == 4 || a == 6 || a == 7 || a == 9 || a == 11)
            { Pnl3_Numero1.Maximum = 31; }
            else if (a == 3 || a == 5 || a == 8 || a == 10)
            { Pnl3_Numero1.Maximum = 30; }
            else
            {
                if (Pnl2_Numero3.Value % 4 == 0 && Pnl2_Numero3.Value % 100 != 0)
                { Pnl3_Numero1.Maximum = 29; }
                else
                { Pnl3_Numero1.Maximum = 28; }
            }
        }
        private void Pnl3_Numero2_ValueChanged(object sender, EventArgs e)
        {
            if (Pnl3_ComBox1.SelectedIndex == 1)
            {
                if (Pnl3_Numero2.Value % 4 == 0 && Pnl3_Numero2.Value % 100 != 0)
                { Pnl3_Numero1.Maximum = 29; }
                else
                { Pnl3_Numero1.Maximum = 28; }
            }
        }
        // Панель Четвертая
        private void Pnl4_Button1_Click(object sender, EventArgs e)
        {
            RememberMassive = GeneralMassive;
            GeneralMassive = Massive.FilesSortNames(GeneralMassive);
            DataGrivGeneral.Rows.Clear();
            for (int i = 0; i < GeneralMassive.Count; i++)
            { DataGrivGeneral.Rows.Add(GeneralMassive[i].Item1, GeneralMassive[i].Item2, 
            GeneralMassive[i].Item3, GeneralMassive[i].Item4); }
        }
        // Панель Пятая
        private void Pnl5_Button1_Click(object sender, EventArgs e)
        {
            int cnt = (int)Pnl5_Numero1.Value;
            GeneralMassive = Massive.FindManyFilesMaxCount(GeneralMassive, cnt);
            DataGrivGeneral.Rows.Clear();
            for (int i = 0; i < GeneralMassive.Count; i++)
            { DataGrivGeneral.Rows.Add(GeneralMassive[i].Item1, GeneralMassive[i].Item2,
            GeneralMassive[i].Item3, GeneralMassive[i].Item4); }
            ChangeCountList();
        }
        private void Pnl5_Button2_Click(object sender, EventArgs e)
        {
            RememberMassive = GeneralMassive;
            ChangeCountList();
        }
        private void Pnl5_Button3_Click(object sender, EventArgs e)
        {
            GeneralMassive = RememberMassive;
            DataGrivGeneral.Rows.Clear();
            for (int i = 0; i < GeneralMassive.Count; i++)
            { DataGrivGeneral.Rows.Add(GeneralMassive[i].Item1, GeneralMassive[i].Item2,
            GeneralMassive[i].Item3, GeneralMassive[i].Item4); }
            ChangeCountList();
        }
        // Панель Шестая
        private void Pnl6_Combox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = Pnl6_Combox1.SelectedIndex;
            if (a == 0 || a == 2 || a == 4 || a == 6 || a == 7 || a == 9 || a == 11)
            { Pnl6_Numero1.Maximum = 31; }
            else if (a == 3 || a == 5 || a == 8 || a == 10)
            { Pnl6_Numero1.Maximum = 30; }
            else
            {
                if (Pnl6_Numero2.Value % 4 == 0 && Pnl6_Numero2.Value % 100 != 0)
                { Pnl6_Numero1.Maximum = 29; }
                else
                { Pnl6_Numero1.Maximum = 28; }
            }
        }
        private void Pnl6_Numero2_ValueChanged(object sender, EventArgs e)
        {
            if (Pnl6_Combox1.SelectedIndex == 1)
            {
                if (Pnl6_Numero2.Value % 4 == 0 && Pnl6_Numero2.Value % 100 != 0)
                { Pnl6_Numero1.Maximum = 29; }
                else
                { Pnl6_Numero1.Maximum = 28; }
            }
        }
        private void Pnl6_Combox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = Pnl6_Combox2.SelectedIndex;
            if (a == 0 || a == 2 || a == 4 || a == 6 || a == 7 || a == 9 || a == 11)
            { Pnl6_Numero3.Maximum = 31; }
            else if (a == 3 || a == 5 || a == 8 || a == 10)
            { Pnl6_Numero3.Maximum = 30; }
            else
            {
                if (Pnl6_Numero4.Value % 4 == 0 && Pnl6_Numero4.Value % 100 != 0)
                { Pnl6_Numero3.Maximum = 29; }
                else
                { Pnl6_Numero3.Maximum = 28; }
            }
        }
        private void Pnl6_Numero4_ValueChanged(object sender, EventArgs e)
        {
            if (Pnl6_Combox2.SelectedIndex == 1)
            {
                if (Pnl6_Numero4.Value % 4 == 0 && Pnl6_Numero4.Value % 100 != 0)
                { Pnl6_Numero3.Maximum = 29; }
                else
                { Pnl6_Numero3.Maximum = 28; }
            }
        }
        private void Pnl6_Button1_Click(object sender, EventArgs e)
        {
            string data1 = Pnl6_Numero1.Value.ToString() + "." + Pnl6_Combox1.SelectedIndex + "." + Pnl6_Numero2.Value.ToString();
            string data2 = Pnl6_Numero3.Value.ToString() + "." + Pnl6_Combox2.SelectedIndex + "." + Pnl6_Numero4.Value.ToString();
            GeneralMassive = Massive.DataFromPeriod(GeneralMassive, data1, data2);
            DataGrivGeneral.Rows.Clear();
            for (int i = 0; i < GeneralMassive.Count; i++)
            { DataGrivGeneral.Rows.Add(GeneralMassive[i].Item1, GeneralMassive[i].Item2,
            GeneralMassive[i].Item3, GeneralMassive[i].Item4); }
            ChangeCountList();
        }
        private void Pnl6_Button2_Click(object sender, EventArgs e)
        {
            RememberMassive = GeneralMassive;
            ChangeCountList();
        }
        private void Pnl6_Button3_Click(object sender, EventArgs e)
        {
            GeneralMassive = RememberMassive;
            DataGrivGeneral.Rows.Clear();
            for (int i = 0; i < GeneralMassive.Count; i++)
            { DataGrivGeneral.Rows.Add(GeneralMassive[i].Item1, GeneralMassive[i].Item2,
            GeneralMassive[i].Item3, GeneralMassive[i].Item4); }
            ChangeCountList();
        }
        // Панель Седьмая
        private void Pnl7_Button1_Click(object sender, EventArgs e)
        {
            string name = Pnl7_TextBx1.Text;
            int flag = 1;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                { flag = 0; }
            }
            if (flag == 0)
            { Pnl7_TextBx1.Text = "Набор не должен содержать пробелов"; }
            else
            {
                try
                {
                    GeneralMassive = Massive.FindManyFilesOnLitter(GeneralMassive, name);
                    DataGrivGeneral.Rows.Clear();
                    for (int i = 0; i < GeneralMassive.Count; i++)
                    { DataGrivGeneral.Rows.Add(GeneralMassive[i].Item1, GeneralMassive[i].Item2,
                    GeneralMassive[i].Item3, GeneralMassive[i].Item4); }
                }
                catch (Exception)
                { DataGrivGeneral.Rows.Clear(); }
            }
            ChangeCountList();
        }
        private void Pnl7_Button2_Click(object sender, EventArgs e)
        {
            RememberMassive = GeneralMassive;
            ChangeCountList();
        }
        private void Pnl7_Button3_Click(object sender, EventArgs e)
        {
            GeneralMassive = RememberMassive;
            DataGrivGeneral.Rows.Clear();
            for (int i = 0; i < GeneralMassive.Count; i++)
            { DataGrivGeneral.Rows.Add(GeneralMassive[i].Item1, GeneralMassive[i].Item2,
            GeneralMassive[i].Item3, GeneralMassive[i].Item4); }
            ChangeCountList();
        }
        // Панель Восьмая
        private void Pnl8_Button1_Click(object sender, EventArgs e)
        {
            int filenumb = (int)Pnl8_Numero1.Value;
            GeneralMassive = Massive.FileAddingReading(GeneralMassive, Massive.ChooseAFile(filenumb, Massive.WhodAFile(Pnl8_DataGriv1)));
            DataGrivGeneral.Rows.Clear();
            for (int i = 0; i < GeneralMassive.Count; i++)
            { DataGrivGeneral.Rows.Add(GeneralMassive[i].Item1, GeneralMassive[i].Item2,
            GeneralMassive[i].Item3, GeneralMassive[i].Item4); }
            ChangeCountList();
        }
        // Панель Девятая
        private void Pnl9_Button1_Click(object sender, EventArgs e)
        {
            string name = Pnl9_TextBx1.Text;
            int flag = 1;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                { flag = 0; }
            }
            if (flag == 0)
            { Pnl9_TextBx1.Text = "Набор не должен содержать пробелов"; }
            else
            {
                try
                { Massive.FileWritting(GeneralMassive, name); }
                catch (Exception)
                { Pnl9_TextBx1.Text = "Не удалось создать файл"; }
            }
        }

        private void MenuButton9_Click(object sender, EventArgs e)
        {
            Form form = new NoteTip();
            form.ShowDialog();
        }
    }
}
