﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    private TextMeshProUGUI myText;

    [SerializeField] private RectTransform bakgrund;

    [SerializeField] private pagod myPagod;

    [SerializeField] private Förskjutning myFörskjutning;

    [SerializeField] private TMP_FontAsset[] myFonts;

    private int currentFont = 0;

    private string inputText = string.Empty;

    // Start is called before the first frame update
    private void Awake()
    {
        myText = gameObject.GetComponent<TextMeshProUGUI>();
        inputText = myText.text;
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
        inputText = input;
        if (currentFont == 2)
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
            myText.text = input;
        }
        else if (currentFont == 3)
        {
            myText.text = myText.text.ToLower();
        }
        if (myFörskjutning != null)
        {
            myText.text = myFörskjutning.UpdateFörskjut(input);
        }
        else
        {
            myText.text = input;
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
        else
        {
            myText.fontSize = 80;
        }
        TextUpdated(inputText);
    }
}