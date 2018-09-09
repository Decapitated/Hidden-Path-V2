using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectColor : MonoBehaviour {

    public bool rainbow;

    private Color rain;
    private byte red;
    private byte green;
    private byte blue;

    public bool cam;

    public Color color;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (rainbow)
        {
            rain = Rainbow();
            if (cam == true)
            {
                gameObject.GetComponent<Camera>().backgroundColor = rain;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = rain;
            }

        }
        else
        {
            if (cam == true)
            {
                gameObject.GetComponent<Camera>().backgroundColor = color;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = color;
            }
        }
    }
    Color32 Rainbow()
    {
        if (red == 255 && green < 255 && blue == 0)
        {
            green++;
        }
        else if (green == 255 && red <= 255 && red > 0 && blue == 0)
        {
            red--;
        }
        else if (green <= 255 && blue != 255 && red == 0)
        {
            blue++;
        }
        else if (blue == 255 && green <= 255 && green > 0 && red == 0)
        {
            green--;
        }
        else if (blue <= 255 && red != 255 && green == 0)
        {
            red++;
        }
        else if (red == 255 && blue <= 255 && blue > 0 && green == 0)
        {
            blue--;
        }
        return new Color32(red, green, blue, 255);
    }
}
