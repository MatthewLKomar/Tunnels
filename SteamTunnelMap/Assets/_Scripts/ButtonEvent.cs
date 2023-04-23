using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public Image image;
    public TMPro.TMP_Text text; 
    bool clicked = false; 
   
    public void OnClick()
    {
        if (clicked)
        {
            clicked = false;
            image.color = Color.white;
            text.color = Color.black;
        }
        else
        {
            image.color = Color.black;
            text.color = Color.white;
            clicked = true;
            
        }
    }
}
