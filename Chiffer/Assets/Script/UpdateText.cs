using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    private TextMeshProUGUI myText;

    [SerializeField] private RectTransform bakgrund;

    // Start is called before the first frame update
    private void Start()
    {
        myText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
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