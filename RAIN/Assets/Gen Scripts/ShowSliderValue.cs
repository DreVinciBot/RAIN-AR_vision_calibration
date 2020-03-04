using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSliderValue : MonoBehaviour
{
    public Text value;
  
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
    }

    public void TextUpdate(float newValue)
    {
        value.text = newValue.ToString();
    }
}
