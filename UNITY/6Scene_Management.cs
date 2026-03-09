1. Load Scene — ScriptManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ScriptManager : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Sample Scene");
    }
}

2. Load Additive Scene — LoadAdditive.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadAdditive : MonoBehaviour
{
    public void LoadSceneAdd()
    {
        SceneManager.LoadScene("Sample Scene", LoadSceneMode.Additive);
    }
}

3. Unload Scene — Unload.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class Unload : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.UnloadSceneAsync("surface");
    }
}

4. Load Async Scene — LoadA.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class LoadA : MonoBehaviour
{
    public void LoadScene()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("surface");
        while (!operation.isDone)
        {
            Debug.Log("Loading: " + (operation.progress * 100) + "%");
            yield return null;
        }
    }
}

#scene management steps
1. Create a new scene and name it "surface".
2. Create a new C# script and name it "ScriptManager". Attach this script to an empty GameObject in the main scene.
3. In the ScriptManager script, implement the LoadScene method to load the "surface" scene when a button is clicked.
4. Create a UI Button in the main scene and set its OnClick event to call the LoadScene method from the ScriptManager script.
5. Create another C# script named "LoadAdditive" and implement the LoadSceneAdd method to load the "surface" scene additively.
6. Create a UI Button in the main scene and set its OnClick event to call the LoadSceneAdd method from the LoadAdditive script.
7. Create a C# script named "Unload" and implement the LoadScene method to unload the "surface" scene when a button is clicked.
8. Create a UI Button in the main scene and set its OnClick event to call the LoadScene method from the Unload script.
9. Create a C# script named "LoadA" and implement the LoadScene method to load the "surface" scene asynchronously.
10. Create a UI Button in the main scene and set its OnClick event to call the LoadScene method from the LoadA script.
11. Press the Play button to run the scene and test the functionality of loading, unloading, and loading asynchronously the "surface" scene using the respective buttons.
