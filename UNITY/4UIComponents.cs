Prac 4 -
A. Adding Images
No code
Steps:
Drag and drop img from your file downloads to the asset folder. >
select the image and check the inspector window. texture type > sprite.
>drag and drop the image to the main scene (then it will become sprite renderer) 

#B. Button
Create a legacy button
Steps:
Gameobject > UI > Legacy > Button
Change button text to submit > add and bind script to button >
Once you bind script there ll be button field which is empty > drag and drop your legacy button from hierarchy window > run


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
Steps:
Gameobject > UI > Toggle
Add script and bind > in inspector window > add toggle object (drag and drop from hierarchy window)
>inspector window > above the script part, On Value Changed section > 
Click on + > set your object(toggle)  > and your codes function


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
Steps:
Gameobject > UI > Slider
Add script and bind >inspector window > above the script part, On Value Changed section > 
Click on + > set your object(slider)  > and your codes function


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
