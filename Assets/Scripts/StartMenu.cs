using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject FirstLetter;
    public GameObject SecondLetter;
    public GameObject SecondLetter2;
    public AudioSource openLetterSound;
    public GameObject menuCanvas;
    public GameObject introCanvas;
    public GameObject thirdScreen;
    public GameObject menuFadeToBlack;

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        menuFadeToBlack.SetActive(true);
        Invoke("openNextScene", 1f);
    }

    void openNextScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenLetter()
    {
        openLetterSound.Play();
        FirstLetter.SetActive(false);
        SecondLetter.SetActive(true);
        SecondLetter2.SetActive(true);
    }

    public void ContinueLetter()
    {
        thirdScreen.SetActive(true);
        Invoke("openRegularMenu", 4f);
    }

    void openRegularMenu()
    {
        introCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }
}
