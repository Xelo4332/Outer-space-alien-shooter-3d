using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Animator animator;
    public Animation animation;

    public void StartGame()
    {
        animation.Play();
        SceneManager.LoadScene("GameScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
