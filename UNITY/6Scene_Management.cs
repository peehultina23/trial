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
