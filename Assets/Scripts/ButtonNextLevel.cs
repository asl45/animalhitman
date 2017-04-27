using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ButtonNextLevel : MonoBehaviour
{
    //public GameObject SceneManager;
    public void NextLevelButton(int index)
    {
        //Application.LoadLevel(index);
        
    }

    public void NextLevelButton(string levelName)
    {
        //Application.LoadLevel(levelName);
        SceneManager.LoadScene(levelName);
    }
}