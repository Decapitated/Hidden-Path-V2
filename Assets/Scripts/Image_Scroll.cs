using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Scroll : MonoBehaviour {

    public Image[] back;
    
    [Range(0.0f,10.0f)]
    public float speed;

    private int stackIndex = 0;

    private Vector3 b1;
    private Vector3 b2;
    private Vector3 b3;



    // Use this for initialization
    void Start () {
        back[0].transform.localPosition = new Vector3(0, -419);
        back[1].transform.localPosition = new Vector3(0, 661);
        back[2].transform.localPosition = new Vector3(0, 1741);
    }
	
	// Update is called once per frames
	void Update () {
        MoveBackground(back);

    }
    
    void MoveBackground(Image[] images)
    {
        for(int i = 0; i < 3; i++)
        {
            images[i].transform.localPosition = new Vector3(0, images[i].transform.localPosition.y - (speed * 100) * Time.deltaTime);
            if(i == 0)
            {
                b1 = images[i].transform.localPosition;
            }else if(i == 1)
            {
                b2 = images[i].transform.localPosition;
            }else if(i == 2)
            {
                b3 = images[i].transform.localPosition;

            }


        }
        if (images[stackIndex].transform.localPosition.y < -1500)
        {
            if(stackIndex == 0)
            {
                images[0].transform.localPosition = new Vector3(0, b3.y + 1080);
            }else if(stackIndex == 1)
            {
                images[1].transform.localPosition = new Vector3(0, b1.y + 1080);
            }else if(stackIndex == 2)
            {
                images[2].transform.localPosition = new Vector3(0, b2.y + 1080);
            }
            
        }
        stackIndex++;
        if (stackIndex > 2)
        {
            stackIndex = 0;
        }
    }
}