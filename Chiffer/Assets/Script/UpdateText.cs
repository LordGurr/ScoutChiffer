using System.Collections;
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
        bakgrund.sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
    }

    public void FontUpdated(int index)
    {
        myText.font = myFonts[index];
        currentFont = index;
        //if(currentFont == 2)
        //{
        //    myText.characterSpacing = -15;
        //}
        TextUpdated(inputText);
    }
}