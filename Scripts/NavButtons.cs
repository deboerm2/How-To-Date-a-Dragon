using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavButtons : MonoBehaviour
{
    public GameObject creditsPage;
    public GameObject tutorialPage;

    [SerializeField]
    private GameObject page1, page2, page3, page4, page5;
    private int tutorialProgress = 1;

    public AudioSource myAudioSource;
    public AudioClip myAudioClip;

    void Start()
    {
        myAudioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayback>().myAudioSource;

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MainMenu")
        {
            creditsPage.SetActive(false);
            tutorialPage.SetActive(false);
            myAudioSource.Stop();
        }
        if (scene.name == "IntroScene")
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayback>().PlayCards();
        }
    }

    void Update()
    {
        if(tutorialPage != null && tutorialPage.activeInHierarchy)
        {
            switch (tutorialProgress)
            {
                case 1:
                    page2.SetActive(false);
                    page1.SetActive(true);
                    break;
                case 2:
                    page1.SetActive(false);
                    page3.SetActive(false);
                    page2.SetActive(true);
                    break;
                case 3:
                    page2.SetActive(false);
                    page4.SetActive(false);
                    page3.SetActive(true);
                    break;
                case 4:
                    page3.SetActive(false);
                    page5.SetActive(false);
                    page4.SetActive(true);
                    break;
                case 5:
                    page4.SetActive(false);
                    page5.SetActive(true);
                    break;
            }
        }
    }

    public void EndDate()
    {
        //load results screen
        SceneManager.LoadScene(7);
    }
    public void PrepareNextDate()
    {
        GoToDateButton.aestheticPoints = 0;
        GoToDateButton.eventPoints = 0;
        
        if (FeedbackScreen.secretChad == true)
        {
            SceneManager.LoadScene(9);
        }
        else
        {
            
            //load PreDateIntro if not last date
            if (GoToDateButton.currentDate < 4)
                SceneManager.LoadScene(9);
            else
            {
                //load end screen
                SceneManager.LoadScene(8);
            }
        }
    }

    public void StartGame()
    {
        myAudioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayback>().myAudioSource;
        myAudioSource.PlayOneShot(myAudioClip);
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayback>().PlayCards();
        GoToDateButton.dateOrder[0] = 0;
        GoToDateButton.currentDate = 0;
        //Intro scene
        SceneManager.LoadScene(6);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void CreditsPage()
    {
        creditsPage.SetActive(true);
        myAudioSource.PlayOneShot(myAudioClip);
    }
    public void EndCreditsPage()
    {
        creditsPage.SetActive(false);
        myAudioSource.PlayOneShot(myAudioClip);
    }

    public void TutorialPage()
    {
        tutorialPage.SetActive(true);
        myAudioSource.PlayOneShot(myAudioClip);
    }
    public void EndTutorialPage()
    {
        tutorialPage.SetActive(false);
        myAudioSource.PlayOneShot(myAudioClip);
    }
    public void NextPage()
    {
        tutorialProgress++;
    }
    public void PreviousPage()
    {
        tutorialProgress--;
    }
}
