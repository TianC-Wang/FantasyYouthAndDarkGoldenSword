using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Diagnostics;

public class TextBox : MonoBehaviour
{
    public Text TextBoxT;
    public int count = 0;
    public float tsUserInput;
    private float timeCount = 0f;
    private string temps;
    string ostring = "";

    // Start is called before the first frame update
    void Start()
    {
        temps = TextBoxT.text;
        //需要更改(cs:19)
        TextBoxT.text = "";
    }

    void FuncCheckAndPrint(string istring, ref int i)
    {
        int nowCur = i % istring.Length;
        switch (istring[nowCur])
        {
            case '<':
                string option = "";
                
                for(; istring[nowCur]!='>'; i++)
                {
                    nowCur = i % istring.Length;
                    option += istring[nowCur];
                }
                Debug.Log(option.ToString());

                switch (option)
                {
                    case "<Click>":
                        if (!Input.GetMouseButton(0))
                            i -= 8;
                        else
                            i--;//防止检测后count++(cs:70)
                        Debug.Log(istring[i % istring.Length]);
                        break;
                    case "<Clear>":
                        ostring = "";
                        break;
                    default:
                        break;
                }
                break;
            default:
                ostring += istring[i % istring.Length];
                break;
        }
        
        TextBoxT.text = ostring;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= tsUserInput)
        {
            timeCount = timeCount - tsUserInput;
            FuncCheckAndPrint(temps, ref count);
            count++;
        }
        else
        {
            
        }
        //Debug.Log(timeCount.ToString() + "    " + tsUserInput.ToString());
    }
}
