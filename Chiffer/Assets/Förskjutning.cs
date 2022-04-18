using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Förskjutning : MonoBehaviour
{
    public int indexAvDelEtt;
    //  [SerializeField]  private TextMeshProUGUI myText;
    //[SerializeField]    private TextMeshProUGUI myTranslatedText;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public string UpdateFörskjut(string input)
    {
        //    myTranslatedText.text = string.Empty;
        //for (int i = 0; i < myText.text.Length; i++)
        //{
        //    myTranslatedText.text += GetLetterFörskjut(myTranslatedText.text[i]);
        //}
        string temp = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            temp += GetLetterFörskjut(input[i]);
        }
        return temp;
    }

    public char GetLetterFörskjut(char letter)
    {
        letter = Char.ToLower(letter);
        int index = (int)letter - 52;
        if (letter == 'å')
        {
            index = 26;
        }
        else if (letter == 'ä')
        {
            index = 27;
        }
        else if (letter == 'ö')
        {
            index = 28;
        }

        return (char)((index + indexAvDelEtt + 29) % 29 + 52);
        //indexAvDelTvå *= (indexAvDelEtt + 1);
    }
}