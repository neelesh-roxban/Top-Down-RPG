using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float time;
    void Update()
    {
        time += Time.deltaTime;
        timer.text = time.ToString();
    }
}
