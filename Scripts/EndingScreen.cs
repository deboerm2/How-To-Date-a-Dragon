using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScreen : MonoBehaviour
{
    public GameObject cuteDragon;
    public GameObject scaryDragon;
    public GameObject toughDragon;
    public GameObject elegantDragon;
    public GameObject chadDragon;

    // Start is called before the first frame update
    void Start()
    {
        cuteDragon.SetActive(false);
        scaryDragon.SetActive(false);
        toughDragon.SetActive(false);
        elegantDragon.SetActive(false);
        chadDragon.SetActive(false);

        if (FeedbackScreen.cuteWin)
            cuteDragon.SetActive(true);
        if (FeedbackScreen.scaryWin)
            scaryDragon.SetActive(true);
        if (FeedbackScreen.toughWin)
            toughDragon.SetActive(true);
        if (FeedbackScreen.elegantWin)
            elegantDragon.SetActive(true);
        if (FeedbackScreen.chadWin)
            chadDragon.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
