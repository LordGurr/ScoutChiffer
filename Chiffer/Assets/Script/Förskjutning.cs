using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

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
        int index = (int)letter - 97;
        int temp;
        if (!Char.IsLetter(letter))
        {
            return letter;
        }
        if (AnyEqual(letter, 'å', 'ä', 'ö'))
        {
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
            //temp = ((index + indexAvDelEtt + 29) % 29);
            //if(temp == 0)
        }
        temp = (index + indexAvDelEtt + 29) % 29 + 97;
        if (temp > 122)
        {
            if (temp == 123)
            {
                return 'å';
            }
            if (temp == 124)
            {
                return 'ä';
            }
            if (temp == 125)
            {
                return 'ö';
            }
        }
        return (char)(temp);
        //indexAvDelTvå *= (indexAvDelEtt + 1);
    }

    public static bool AnyEqual<T>(params T[] values)
    {
        if (values == null || values.Length == 0)
            return true;
        return values.Any(v => v.Equals(values[0]));
    }
}