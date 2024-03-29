﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pagod : MonoBehaviour
{
    public int indexAvDelEtt = -1;
    public int indexAvDelTvå = -1;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SetIndexEtt(int indexDeltEtt)
    {
        indexAvDelEtt = indexDeltEtt;
    }

    public void SetIndexTvå(int indexDelTvå)
    {
        indexAvDelTvå = indexDelTvå;
    }

    public char GetLetterPagod()
    {
        if (indexAvDelTvå < 0 || indexAvDelEtt < 0)
        {
            Debug.LogError(("Kunde inte skriva bokstav då: indexAvDelEtt = {0}, indexAvDelTvå = {1}", indexAvDelEtt, indexAvDelTvå));
            return (char)0;
        }
        //indexAvDelTvå *= (indexAvDelEtt + 1);
        indexAvDelTvå += 65 + (indexAvDelEtt * 9);
        if (indexAvDelEtt == 0)
        {
            return (char)indexAvDelTvå;
        }
        else if (indexAvDelEtt == 1)
        {
            if (indexAvDelTvå < 81)
            {
                return (char)indexAvDelTvå;
            }
            else
            {
                return (char)(indexAvDelTvå + 1);
            }
        }
        else if (indexAvDelEtt == 2)
        {
            if (indexAvDelTvå < 86)
            {
                return (char)(indexAvDelTvå + 1);
            }
            else if (indexAvDelTvå > 88)
            {
                if (indexAvDelTvå == 89)
                {
                    return 'Å';
                }
                else if (indexAvDelTvå == 90)
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
                return (char)(indexAvDelTvå + 2);
            }
        }
        return (char)0;
    }

    public char GetLetterScout()
    {
        if (indexAvDelTvå < 0 || indexAvDelEtt < 0)
        {
            Debug.LogError(("Kunde inte skriva bokstav då: indexAvDelEtt = {0}, indexAvDelTvå = {1}", indexAvDelEtt, indexAvDelTvå));
            return (char)0;
        }
        int temp = (indexAvDelTvå * 5 + indexAvDelEtt + 65);
        //if (temp > 88)
        //{
        //    return (char)(temp + 3);
        //}
        if (temp > 86)
        {
            if (temp == 87)
            {
                return 'Å';
            }
            if (temp == 88)
            {
                return 'Ä';
            }
            else
            {
                return 'Ö';
            }
        }
        if (temp > 85)
        {
            return (char)(temp + 3);
        }
        if (temp > 80)
        {
            return (char)(temp + 1);
        }
        return (char)temp;
    }
}