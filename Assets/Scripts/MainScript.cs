using System;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public Text rezultText;
    string number1;
    string signFunction;
    string number2;
    double rezultNumber;
    bool next = true;

    public void inputValue(string a)
    {
        switch (next)//����� �� ������� ������ ����������
        {
            case false:
                number2 += a;
                rezultText.text += a;
                break;
            case true:
                number1 += a;
                rezultText.text += a;
                break;
        }
    }
    public void acting(string sign)
    {
        if(sign == ",")
        {
            inputValue(sign);
        }
        else
        {
            signFunction = sign;//������������ ����� �������� � ������ ����������
            rezultText.text = "";
            next = false;
        }
    }
    public void rezult()
    {
        switch (signFunction)
        {
            case "+":
                rezultNumber = Convert.ToDouble(number1) + Convert.ToDouble(number2);
                break;
            case "-":
                rezultNumber = Convert.ToDouble(number1) - Convert.ToDouble(number2);
                break;
            case "/":
                rezultNumber = Convert.ToDouble(number1) / Convert.ToDouble(number2);
                break;
            case "*":
                rezultNumber = Convert.ToDouble(number1) * Convert.ToDouble(number2);
                break;
        }
        number1 = rezultNumber.ToString();//������������ ������ ���������� �������� ����������
        number2 = "";//��������� ������ ����������
        rezultText.text = rezultNumber.ToString();
    }
    public void clear()
    {
        number1 = "";
        signFunction = "";
        number2 = "";
        rezultNumber = 0;
        next = true;
        rezultText.text = "";
    }
}
