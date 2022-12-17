using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alfabet : MonoBehaviour
{
    [SerializeField] private GameObject[] Alphabets;

    private int activeAlphabet = 0;

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
}