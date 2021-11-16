using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class SceneLoader2 : MonoBehaviour
{
    public void EndlessRuns()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}