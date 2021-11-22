using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _1101calculatorAPP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        int Ans = 0;    //答案
        string count = "";    //單一數字
        string sign = "";    //運算符號
        ArrayList formula = new ArrayList();

        //click_number(): 按數字
        void click_number(object sender, EventArgs e)
        {
            count = count + (sender as Button).Text.ToString();
            put.Text = put.Text + (sender as Button).Text.ToString();
        }

        //click_operand(): 按運算符號
        void click_operand(object sender, EventArgs e)
        {
            sign = (sender as Button).Text.ToString();
            put.Text = put.Text + sign;

            //如果是 a + b，count 已經有 a，先把 a 加到 formula
            if (count != "")
                formula.Add(count);
            //如果是 0 + b，先把 0 加到 formula
            else
                formula.Add(0);

            count = "";
        }
        //click_calculate(): 按等於(計算)
        void click_calculate(object sender, EventArgs e)
        {
            formula.Add(count);

            if (sign.Equals("+"))
                Ans = int.Parse(formula[0].ToString()) + int.Parse(formula[1].ToString());
            else if (sign.Equals("-"))
                Ans = int.Parse(formula[0].ToString()) - int.Parse(formula[1].ToString());
            else if (sign.Equals("*"))
                Ans = int.Parse(formula[0].ToString()) * int.Parse(formula[1].ToString());
            else if (sign.Equals("/"))
                Ans = int.Parse(formula[0].ToString()) / int.Parse(formula[1].ToString());
            
            
            put.Text = Ans.ToString();
            formula[0] = Ans.ToString(); //計算結果放入 formula，供下一次計算使用
            formula.RemoveAt(1);
            count = "";

        }
        //click_allclear(): 清空
        void click_allclear(object sender, EventArgs e)
        {
            formula.Clear();
            count = "";
            sign = "";
            put.Text = "";
            Ans = 0;
        }
    }
}
