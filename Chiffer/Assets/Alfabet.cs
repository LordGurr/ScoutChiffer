using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alfabet : MonoBehaviour
{
    [SerializeField] private GameObject[] Alphabets;

    private int activeAlphabet = 0;

    [SerializeField] private GameObject page1Morse;

    [SerializeField] private GameObject page2Morse;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SetAlphabet(int dropdown)
    {
        Alphabets[dropdown].SetActive(true);
        Alphabets[activeAlphabet].SetActive(false);
        activeAlphabet = dropdown;
    }

    public void NextMorse()
    {
        page1Morse.SetActive(!page1Morse.activeSelf);
        page2Morse.SetActive(!page2Morse.activeSelf);
    }
}