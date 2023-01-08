using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ExplainInfo
{
    public ExplainInfo(string text, float startTime, float currentTime, int priority)
    {
        this.text = text;
        this.startTime = startTime;
        this.currentShowTime = currentTime;
        this.priority = priority;
    }

    public float startTime;
    public string text;
    public float currentShowTime;
    public int priority;
}
