Prac 4 -
A. Adding Images
No code

#B. Button
Create a legacy button


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class legacy : MonoBehaviour
{
    public Button button1;
    void Start()
    {
        button1.onClick.AddListener(ButtonClicked);
    }

    public void ButtonClicked()
    {
        Debug.Log("Button is Clicked");
    }
    void Update()
    {

    }
}


#C. Toggle
using UnityEngine;
using UnityEngine.UI;

public class toggle1 : MonoBehaviour
{
    public Toggle toggle;
    void Start()
    {

    }

    public void UserValueChanged(bool value)
    {
        Debug.Log("Toggle Value Changes: " + value);
    }
}


#D. Slider

using UnityEngine;

public class slide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void SliderValueChanged(float value)
    {
        Debug.Log("Slider Value Changed: " + value);
    }
}
