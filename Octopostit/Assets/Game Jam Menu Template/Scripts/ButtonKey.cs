using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]

public class ButtonKey : MonoBehaviour
{

    public KeyCode key;
    public int timer;
    
    public bool pressing;
    public bool played;
    public AudioClip impact;
    AudioSource audio1;
    
    Graphic targetGraphic;
    Color normalColor;


    void Start()
    {
        audio1 = GetComponent<AudioSource>();
       
        played = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (pressing)
        {
            timer++;
        }
        if (timer > 100)
        {
            Audio2();
           
            
        }
        if (Input.GetKeyDown(key))
        {
            pressing = true;
           
            

            
        }
        else if (Input.GetKeyUp(key))
        {
            pressing = false;

timer = 0;
            
            
        }
    }

   
    void Audio2()
    {
        if (played == false)
        {
            audio1.PlayOneShot(impact, 0.7F);
            played = true;
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        
    }

   

  
}
