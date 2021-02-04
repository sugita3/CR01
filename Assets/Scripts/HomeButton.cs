using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public void ReplayGame()
    {
        if (!GameManager.CanChangeToTitle) return;
        SceneManager.LoadScene("Title");
    }
}
