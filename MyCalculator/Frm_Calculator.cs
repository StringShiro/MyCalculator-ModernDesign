using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Frm_MyCalculator : Form
    {
        public Frm_MyCalculator()
        {
            InitializeComponent();
        }

        //khai bao bien
        //private string giaTriManHinh = "";
        //private string phepToan = "";
        //private string toanHang1 = "";
        Double result = 0;
        string operation = string.Empty;
        string fstNum, secNum;
        bool enterValue = false;

        public void XyLyPhepToan(object sender, EventArgs e)
        {
            if (result != 0) btn_equal.PerformClick();
            else result = Double.Parse(txt_show.Text);

            Button btn = sender as Button;
            operation = btn.Text;
            enterValue = true;
            if (txt_show.Text != "0")
            {
                txt_contains.Text = fstNum = $"{result}{operation}";
                txt_show.Text = string.Empty;
            }

            //Button btn = sender as Button;
            //toanHang1 = giaTriManHinh;
            //phepToan = btn.Text;
            //giaTriManHinh = "";

            //txt_show.Text = giaTriManHinh;
            //txt_contains.Text = txt_show.Text;
            //if (phepToan == "")
            //{
            //    toanHang1 = giaTriManHinh;
            //}
        }
        public void XyLyBang (object sender, EventArgs e)
        {
            secNum = txt_show.Text;
            txt_contains.Text = $"{txt_contains.Text}{txt_show.Text} =";
            if (txt_show.Text != string.Empty)
            {
                if (txt_show.Text == "0") txt_contains.Text = string.Empty;
                switch (operation)
                {
                    case "+": txt_show.Text = (result + Double.Parse(txt_show.Text)).ToString();
                        txt_history.AppendText($"{fstNum}{secNum} = {txt_show.Text}\n");
                        break;
                    case "-":
                        txt_show.Text = (result - Double.Parse(txt_show.Text)).ToString();
                        txt_history.AppendText($"{fstNum}{secNum} = {txt_show.Text}\n");
                        break;
                    case "*":
                        txt_show.Text = (result * Double.Parse(txt_show.Text)).ToString();
                        txt_history.AppendText($"{fstNum}{secNum} = {txt_show.Text}\n");
                        break;
                    case "/":
                        txt_show.Text = (result / Double.Parse(txt_show.Text)).ToString();
                        txt_history.AppendText($"{fstNum}{secNum} = {txt_show.Text}\n");
                        break;

                    default: txt_contains.Text = $"{txt_show.Text} = "; break;
                }
                result = Double.Parse(txt_show.Text);
                operation = string.Empty;
                txt_show.Text = "0";
                txt_contains.Text = "";
            }
            //double ketqua = 0;
            //var toanHang2 = giaTriManHinh;
            //switch (phepToan)
            //{
            //    case "+": ketqua = double.Parse(toanHang1) + double.Parse(toanHang2);
            //        txt_contains.AppendText($"{toanHang1} { phepToan}");
            //        txt_history.AppendText($"{toanHang1}{phepToan}{toanHang2} = {txt_show.Text}\n");
            //        break;
            //    case "-": ketqua = double.Parse(toanHang1) - double.Parse(toanHang2);
            //        txt_history.AppendText($"{toanHang1}{phepToan}{toanHang2} = {txt_show.Text}\n"); break;
            //    case "/": ketqua = double.Parse(toanHang1) / double.Parse(toanHang2); txt_history.AppendText($"{toanHang1}{phepToan}{toanHang2} = {txt_show.Text}\n"); break;
            //    case "*": ketqua = double.Parse(toanHang1) * double.Parse(toanHang2); txt_history.AppendText($"{toanHang1}{phepToan}{toanHang2} = {txt_show.Text}\n"); break;
            //}
            //giaTriManHinh = ketqua.ToString();
            //txt_show.Text = giaTriManHinh;
            //txt_contains.Text = ($"{toanHang1}{phepToan}{toanHang2} =\n");
        }
        public void XyLyBamPhimSo (object sender, EventArgs e)
        {
            //Button btn = sender as Button;
            //if(btn.Text == "0" && giaTriManHinh == "0")
            //{
            //    return;
            //}
            //if (btn.Text != "0" && giaTriManHinh == "0")
            //{
            //    giaTriManHinh = btn.Text;
            //}
            //else { 
            //    giaTriManHinh += btn.Text;
            //}
            //txt_show.Text = giaTriManHinh;
            enterValue = false;
            Button btn = sender as Button;
            if (btn.Text == "0" && txt_show.Text == "0")
            {
                return;
            }

            if (btn.Text == ".")
            {
                if (!txt_show.Text.Contains(".")) txt_show.Text = txt_show.Text + btn.Text;   
            }
            else
                txt_show.Text = btn.Text;
        }
        private void ClearHistory(object sender, EventArgs e)
        {
            txt_history.Clear();
            if (txt_history.Text == string.Empty)
                txt_history.Text = "there's no history yet!";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_maximize_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState |= FormWindowState.Minimized;
        }
        private void Frm_MyCalculator_Load(object sender, EventArgs e)
        {
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_show.Text = "0";
            txt_contains.Text = string.Empty;
            result = 0;
        }
        private void btn_CE_Click(object sender, EventArgs e)
        {
            txt_show.Text = "0";
        }
        private void btn_OperationLClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            operation = btn.Text;
            switch (operation){
                case "√x":
                    txt_contains.Text = $"√({txt_show.Text})";
                    txt_show.Text = Convert.ToString(Math.Sqrt(Double.Parse(txt_show.Text)));
                    break;
                case "χ2":
                    txt_contains.Text = $"({txt_show.Text}) 2";
                    txt_show.Text = Convert.ToString(Double.Parse(txt_show.Text)* Double.Parse(txt_show.Text));
                    break;
                case "1/x":
                    txt_contains.Text = $"1/({txt_show.Text})";
                    txt_show.Text = Convert.ToString(1 /Double.Parse(txt_show.Text));
                    break;
                case "%":
                    txt_contains.Text = $"({txt_show.Text})%";
                    //txt_show.Text = Convert.ToString(Convert.ToDouble(txt_show.Text)/Convert.ToDouble(100));
                    txt_show.Text = Convert.ToString(Double.Parse(txt_show.Text)/100);
                    break;
                case "mod":
                    txt_contains.Text = $"√({txt_show.Text})";
                    txt_show.Text = Convert.ToString(Math.DivRem(int.Parse(fstNum),int.Parse(secNum), out int result));
                    break;
                case "| x |":
                    txt_contains.Text = $"| ({txt_show.Text}) |";
                    txt_show.Text = Convert.ToString(Math.Abs(Double.Parse(txt_show.Text)));
                    break;
                case "x^y":
                    txt_contains.Text = $"({txt_show.Text})";
                    txt_show.Text = Convert.ToString(Math.Pow(Double.Parse(fstNum), Double.Parse(secNum)));
                    break;
                case "+/-":
                    txt_show.Text = Convert.ToString(-1 * Double.Parse(txt_show.Text));
                    break;
            }
            if (txt_show.Text.Contains("x^y") || txt_show.Text.Contains("mod"))
            {
                txt_history.AppendText($"{fstNum}{operation}{secNum} = {txt_show.Text}\n");
            }
            else
            {
                txt_history.AppendText($"{txt_contains.Text} = {txt_show.Text}\n");
            }
            //txt_history.AppendText($"{txt_contains.Text} = {txt_show.Text}\n");
            txt_contains.Text = "";
            txt_show.Text = "0";
        }
        private void button21_Click(object sender, EventArgs e)
        {
            if(txt_show.Text.Length > 0)
            {
                txt_show.Text = txt_show.Text.Remove(txt_show.Text.Length - 1,1);
            }
            if (txt_show.Text == string.Empty) txt_show.Text = "0";
        }
       }
}
