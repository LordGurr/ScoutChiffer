using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pagod : MonoBehaviour
{
    public int indexAvDelEtt = -1;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SetIndex(int indexDeltEtt)
    {
        indexAvDelEtt = indexDeltEtt;
    }

    public char GetLetter(int indexDelTvå)
    {
        if (indexAvDelEtt == 0)
        {
            return (char)indexDelTvå;
        }
        else if (indexAvDelEtt == 1)
        {
            if (indexDelTvå < 81)
            {
                return (char)indexDelTvå;
            }
            else
            {
                return (char)(indexDelTvå + 1);
            }
        }
        else if (indexAvDelEtt == 2)
        {
            if (indexDelTvå < 86)
            {
                return (char)(indexDelTvå + 1);
            }
            else if (indexDelTvå > 88)
            {
                if (indexDelTvå == 89)
                {
                    return 'Å';
                }
                else if (indexDelTvå == 90)
                {
                    return 'Ä';
                }
                else
                {
                    return 'Ö';
                }
            }
            else
            {
                return (char)(indexDelTvå + 2);
            }
        }
        return (char)0;
    }
}