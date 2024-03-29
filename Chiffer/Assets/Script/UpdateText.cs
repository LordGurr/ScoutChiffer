﻿using System.Collections;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    private TextMeshProUGUI myText;

    [SerializeField] private RectTransform bakgrund;

    [SerializeField] private pagod myPagod;

    [SerializeField] private Förskjutning myFörskjutning;

    [SerializeField] private TMP_FontAsset[] myFonts;

    private int currentFont = 0;

    private string inputText = string.Empty;

    private RectTransform rect;

    private char[] beorhtricRunes = new char[]
    {
        'ᚪ',//a
        'ᛒ',//b
        'ᚳ',//c
        'ᛞ',//d
        'ᛖ',//e
        'ᚠ',//f
        'ᚸ',//g
        'ᚻ',//h
        'ᛁ',//i
        'ᛄ',//j
        'ᛸ',//k
        'ᛚ',//l
        'ᛗ',//m
        'ᚾ',//n
        'ᚩ',//o
        'ᚹ',//p
        'ᚱ',//r
        'ᛋ',//s
        'ᛏ',//t
        'ᚢ',//u
        'ᛢ',//v
        'ᚣ',//y
        'ᛠ',//å
        'ᚫ',//ä
        'ᛟ',//ö
    };

    private char[] beorhtricAlphabet = new char[]
    {
        'a',//a
        'b',//b
        'c',//c
        'd',//d
        'e',//e
        'f',//f
        'g',//g
        'h',//h
        'i',//i
        'j',//j
        'k',//k
        'l',//l
        'm',//m
        'n',//n
        'o',//o
        'p',//p
        'r',//r
        's',//s
        't',//t
        'u',//u
        'v',//v
        'y',//y
        'å',//å
        'ä',//ä
        'ö',//ö
    };

    private string[] futharkRunes = new string[]
    {
        "ᚹ",//th
        "ᛅ",//a
        "ᛒ",//b
        "ᛋ",//c
        "ᛏ",//d
        "ᛁ",//e
        "ᚠ",//f
        "ᛋ",//g
        "ᛄ",//h
        "ᛁ",//i
        "ᛁ",//j
        "ᛋ",//k
        "ᛚ",//l
        "ᛉ",//m
        "ᚾ",//n
        "ᚢ",//o
        "ᛒ",//p
        "ᚱ",//r
        "ᛋ",//s
        "ᛏ",//t
        "ᚢ",//u
        "ᚢ",//v
        "ᛣ",//y
        "ᛅᛅ",//å
        "ᚫ",//ä
        "ᚢ",//ö
    };

    private string[] futharkAlphabet = new string[]
    {
        "th",//th
        "a",//a
        "b",//b
        "c",//c
        "d",//d
        "e",//e
        "f",//f
        "g",//g
        "h",//h
        "i",//i
        "j",//j
        "k",//k
        "l",//l
        "m",//m
        "n",//n
        "o",//o
        "p",//p
        "r",//r
        "s",//s
        "t",//t
        "u",//u
        "v",//v
        "y",//y
        "å",//å
        "ä",//ä
        "ö",//ö
    };

    private string[] oghamAlphabetFörkortning = new string[]
    {
        "ae",//ae
        "ia",//ia
        "ui",//ui
        "oi",//oi
        "ea",//ea
        "ng",//ng
        " ",//space
    };

    private string[] oghamRunesFörkortning = new string[]
    {
        "ᚙ",//ae
        "ᚘ",//ia
        "ᚗ",//ui
        "ᚖ",//oi
        "ᚕ",//ea
        "ᚍ",//ng
        " ",//space
    };

    private char[] oghamSpecial = new char[]
    {
        '᚛',//start
        '᚜',//slut
    };

    private char[] oghamAlphabet = new char[]
    {
        'a',//a
        'b',//b
        'c',//c
        'd',//d
        'e',//e
        'f',//f
        'g',//g
        'h',//h
        'i',//i
        'l',//l
        'm',//m
        'n',//n
        'o',//o
        'p',//p
        'q',//q
        'r',//r
        's',//s
        't',//t
        'u',//u
        'z',//z
        'å',//å
        'ä',//ä
        'ö',//ö
    };

    private char[] oghamRunes = new char[]
    {
        'ᚐ',//a
        'ᚁ',//b
        'ᚈ',//c
        'ᚇ',//d
        'ᚓ',//e
        'ᚃ',//f
        'ᚌ',//g
        'ᚆ',//h
        'ᚔ',//i
        'ᚂ',//l
        'ᚋ',//m
        'ᚅ',//n
        'ᚑ',//o
        'ᚚ',//p
        'ᚊ',//q
        'ᚏ',//r
        'ᚄ',//s
        'ᚈ',//t
        'ᚒ',//u
        'ᚎ',//z
        'ᚘ',//å
        'ᚙ',//ä
        'ᚖ',//ö
    };

    // Start is called before the first frame update
    private void Awake()
    {
        myText = gameObject.GetComponent<TextMeshProUGUI>();
        inputText = myText.text;
        rect = gameObject.GetComponent<RectTransform>();
    }

    public void AddCharPagod()
    {
        char temp = myPagod.GetLetterPagod();
        if (temp != (char)0)
        {
            myText.text += temp;
            StartCoroutine(UppdateraNästaFrame());
        }
        myPagod.indexAvDelEtt = -1;
        myPagod.indexAvDelTvå = -1;
    }

    public void AddCharScout()
    {
        char temp = myPagod.GetLetterScout();
        if (temp != (char)0)
        {
            myText.text += temp;
            StartCoroutine(UppdateraNästaFrame());
        }
        myPagod.indexAvDelEtt = -1;
        myPagod.indexAvDelTvå = -1;
    }

    public void AddSpace()
    {
        myText.text += ' ';
        StartCoroutine(UppdateraNästaFrame());
    }

    public void AddBackspace()
    {
        myText.text = myText.text.Remove(myText.text.Length - 1);
        StartCoroutine(UppdateraNästaFrame());
    }

    public void TextUpdated(string input)
    {
        input = input.ToLower();
        inputText = input;
        if (currentFont == 2 && input.Length > 0)
        {
            int index = 1;
            input = input.ToLower();
            while (index > 0)
            {
                index = input.IndexOf(' ');
                if (index > 0)
                {
                    input = input.Substring(0, index - 1) + input[index - 1].ToString().ToUpper() + "|" + input.Substring(index + 1);
                }
            }
            input = input.Substring(0, input.Length - 1) + input[input.Length - 1].ToString().ToUpper();
            myText.text = input;
        }
        else if (currentFont == 3)
        {
            myText.text = myText.text.ToLower();
        }
        if (myFörskjutning != null)
        {
            myText.text = myFörskjutning.UpdateFörskjut(input);
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, myText.preferredHeight);
            StartCoroutine(UppdateraNästaFrame());
            return;
        }
        if (currentFont == 4)
        {
            string temp = input.ToLower();
            for (int i = 0; i < beorhtricAlphabet.Length; i++)
            {
                temp = temp.Replace(beorhtricAlphabet[i], beorhtricRunes[i]);
            }
            myText.text = temp;
        }
        else if (currentFont == 5)
        {
            string temp = input.ToLower();
            temp = oghamSpecial[0] + temp + oghamSpecial[oghamSpecial.Length - 1];
            for (int i = 0; i < oghamAlphabetFörkortning.Length; i++)
            {
                temp = temp.Replace(oghamAlphabetFörkortning[i], oghamRunesFörkortning[i]);
            }
            for (int i = 0; i < oghamAlphabet.Length; i++)
            {
                temp = temp.Replace(oghamAlphabet[i], oghamRunes[i]);
            }
            myText.text = temp;
        }
        else if (currentFont == 6)
        {
            string temp = input.ToLower();
            for (int i = 0; i < futharkAlphabet.Length; i++)
            {
                temp = temp.Replace(futharkAlphabet[i], futharkRunes[i]);
            }
            myText.text = temp;
        }
        else
        {
            myText.text = input;
        }
        if (currentFont == 2)
        {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, myText.preferredHeight + 50);
        }
        else
        {
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, myText.preferredHeight);
        }
        StartCoroutine(UppdateraNästaFrame());
    }

    private IEnumerator UppdateraNästaFrame()
    {
        yield return null;
        if (currentFont == 3)
        {
            bakgrund.sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y - 60);
        }
        else
        {
            bakgrund.sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
        }
    }

    public void FontUpdated(int index)
    {
        myText.font = myFonts[index];
        currentFont = index;
        if (currentFont == 2 || currentFont == 3 || currentFont == 0)
        {
            myText.fontStyle = FontStyles.Bold;
        }
        else
        {
            myText.fontStyle = FontStyles.Normal;
        }
        if (currentFont == 3)
        {
            myText.fontSize = 100;
        }
        else if (currentFont == 5)
        {
            myText.fontSize = 120;
        }
        else
        {
            myText.fontSize = 80;
        }
        if (currentFont == 4 || currentFont == 5 || currentFont == 6)
        {
            myText.characterSpacing = 0;
        }
        else
        {
            myText.characterSpacing = -25;
        }
        //if (currentFont == 5)
        //{
        //    myText.lineSpacing = -25;
        //}
        //else
        //{
        //    myText.lineSpacing = 0;
        //}
        TextUpdated(inputText);
    }
}