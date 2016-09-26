using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[RequireComponent(typeof(Button))]
public class Players : MonoBehaviour {
    public Text countText;
    public int count;
    public int timer;
    public bool pressing;
    public KeyCode key;
	// Use this for initialization
	void Start () {
        count = 2;
	}
	
	// Update is called once per frame
	void Update () {
        SetCountText();
         if (pressing)
        {
            timer++;
        }
       
        if (Input.GetKeyDown(key))
        {
            pressing = true;
           
            

            
        }
        else if (Input.GetKeyUp(key))
        {
            pressing = false;
            if (timer < 100)
            {
                count++;
            }
            timer = 0;
        }
	}

    void SetCountText()
    {
        countText.text = "Players: " + count.ToString();
        if (count >= 6)
        {
            count = 2;
        }
    }

}
