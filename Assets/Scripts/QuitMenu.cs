using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitMenu : MonoBehaviour
{
    public void QuitGame()
    {
        print ("Game Quit");
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        else 
        { 
            Application.Quit();
        }
    }
}
