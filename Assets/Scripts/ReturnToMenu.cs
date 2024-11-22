using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void RestartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
