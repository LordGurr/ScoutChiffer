using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class ChifferTillText : MonoBehaviour
{
    [SerializeField] private TextAsset[] ordListor;

    private string[] ord;
    private string nuvarandeOrd;
    private int nuvarandeOrdlista = 0;

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private UpdateText previousWord;
    [SerializeField] private UpdateText currentWord;

    // Start is called before the first frame update
    private void Start()
    {
        ord = ordListor[nuvarandeOrdlista].text.Split('\n');
        SetNewWord();
    }

    private void SetNewWord()
    {
        nuvarandeOrd = ord[UnityEngine.Random.Range(0, ord.Length)];
        if (nuvarandeOrd[nuvarandeOrd.Length - 1] == '\r')
        {
            nuvarandeOrd = nuvarandeOrd.Remove(nuvarandeOrd.Length - 1);
        }
        if (currentWord.isActiveAndEnabled)
        {
            currentWord.TextUpdated(nuvarandeOrd);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private string SetWordColour(string input)
    {
        input = input.Replace("<color=green>", string.Empty);
        input = input.Replace("<color=red>", string.Empty);
        input = input.Replace("</color>", string.Empty);

        string temp = string.Empty;
        for (int i = 0; i < input.Length || i < nuvarandeOrd.Length; i++)
        {
            if (i < nuvarandeOrd.Length && i < input.Length && input[i] == nuvarandeOrd[i])
            {
                temp += "<color=green>" + nuvarandeOrd[i] + "</color>";
            }
            else if (i < nuvarandeOrd.Length)
            {
                temp += "<color=red>" + nuvarandeOrd[i] + "</color>";
            }
            else if (i < input.Length)
            {
                temp += "<color=#65616D>" + input[i] + "</color>";
            }
        }
        return temp;
    }

    public void SetWordList(int list)
    {
        if (list != nuvarandeOrdlista)
        {
            nuvarandeOrdlista = list;
            ord = ordListor[nuvarandeOrdlista].text.Split('\n');
            SetNewWord();
        }
    }

    public void CheckWord()
    {
        previousWord.TextUpdated(SetWordColour(inputField.text));
        inputField.text = string.Empty;
        SetNewWord();
    }

    public void UpdateOnLoad()
    {
        currentWord.TextUpdated(nuvarandeOrd);
    }
}