using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFullscreen : MonoBehaviour
{
    [SerializeField] private bool fullscreen;

    // Start is called before the first frame update
    private void Start()
    {
        Screen.fullScreen = fullscreen;
    }
}