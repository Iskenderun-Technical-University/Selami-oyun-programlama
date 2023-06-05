using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyunskor : MonoBehaviour
{
    Text skortext;

    int skor;

    public int Skor
    {
        get
        {
            return this.skor;

        }
        set
        {
            this.skor = value;
            Updateskortext();
        }
    }

    void Start()
    {
        skortext = GetComponent<Text> ();
    }

    void Updateskortext()
    {
        string skorStr = string.Format("{0:0000000}", skor);
        skortext.text = skorStr;
    }


}
