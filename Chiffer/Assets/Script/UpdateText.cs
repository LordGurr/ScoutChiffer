using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    private TextMeshProUGUI myText;

    [SerializeField] private RectTransform bakgrund;

    [SerializeField] private pagod myPagod;

    // Start is called before the first frame update
    private void Awake()
    {
        myText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void AddChar()
    {
        char temp = myPagod.GetLetter();
        if (temp != (char)0)
        {
            myText.text += temp;
        }
        myPagod.indexAvDelEtt = -1;
        myPagod.indexAvDelTvå = -1;
    }

    public void AddSpace()
    {
        myText.text += ' ';
    }

    public void AddBackspace()
    {
        myText.text = myText.text.Remove(myText.text.Length - 1);
    }

    public void TextUpdated(string input)
    {
        myText.text = input;
        StartCoroutine(UppdateraNästaFrame());
    }

    private IEnumerator UppdateraNästaFrame()
    {
        yield return null;
        bakgrund.sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
    }
}