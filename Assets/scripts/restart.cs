using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("New Scene");
    }
}