﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SetTextToSlider : MonoBehaviour
{
    private TextMeshProUGUI myText;
    [SerializeField] private Förskjutning myFörskjutning;
    [SerializeField] private UpdateText myUpdateText;
    [SerializeField] private TMP_InputField myInputText;

    // Start is called before the first frame update
    private void Start()
    {
        myText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void UpdateText(float input)
    {
        myText.text = Convert.ToString((int)input);
        myFörskjutning.indexAvDelEtt = (int)input;
        myUpdateText.TextUpdated(myInputText.text);
    }

    public void UpdateText()
    {
        myUpdateText.TextUpdated(myInputText.text);
    }
}