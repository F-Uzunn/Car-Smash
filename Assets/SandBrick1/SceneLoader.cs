using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LevelRuns()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
}