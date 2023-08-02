using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour
{
    MainScript mainScript;
    public Button prefab;
    public List<char> actSign = new List<char>();//Объявление списка знаков действия
    void Start()
    {
        for (int i = 0; i < 8; i++)//Блок инициализации кнопок 1-9
        {
            Button clone = Instantiate(prefab);
            clone.transform.SetParent(this.gameObject.transform.GetChild(0), false);
            clone.name = (i + 2).ToString();
            clone.transform.GetChild(0).GetComponent<Text>().text = (i + 2).ToString();
            if (i == 7)//Проверка условия, что кнопки 1-9 сделались
            {
                //Создание кнопки 0
                clone = Instantiate(prefab);
                clone.transform.SetParent(this.gameObject.transform.GetChild(0), false);
                clone.name = (0).ToString();
                clone.transform.GetChild(0).GetComponent<Text>().text = (0).ToString();
            }
        }
        foreach(var sign in actSign)//Проход по листу знаков действия
        {
            Button cloneAct = Instantiate(prefab);
            cloneAct.transform.SetParent(this.gameObject.transform.GetChild(0), false);
            cloneAct.name = (sign).ToString();
            cloneAct.transform.GetChild(0).GetComponent<Text>().text = (sign).ToString();
        }
    }
    public void buttonClick(Button button)//Метод передающий значение кнопки в MainScript
    {
        mainScript = gameObject.transform.GetComponent<MainScript>();
        string a = button.transform.GetChild(0).GetComponent<Text>().text;
        bool b = int.TryParse(a, out int c);//Проверка является ли нажатая кнопка числом
        if(b == true)
        {
            mainScript.inputValue(a);
        }
        else if(a == "C")
        {
            mainScript.clear();
        }
        else if(a == "=")
        {
            mainScript.rezult();
        }
        else
        {
            mainScript.acting(a);
        }
    }
}
