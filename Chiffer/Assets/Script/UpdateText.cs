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

    // Start is called before the first frame update
    private void Awake()
    {
        myText = gameObject.GetComponent<TextMeshProUGUI>();
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
}