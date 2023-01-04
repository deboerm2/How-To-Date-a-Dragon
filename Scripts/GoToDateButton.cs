using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToDateButton : MonoBehaviour
{
    //possible way to load date scenes in one script
    private int[] dateScenes = { 1, 2, 3, 4 };
    public static int[] dateOrder = new int[4];
    public static int currentDate = 0;
    public static int datePoints;
    public static int aestheticPoints;
    public static int eventPoints;
    private int tempInt;
    private int rnd = 2;
    private bool cardsComplete;
    private Cards cardScript;

    public GameObject goButton;

    // Start is called before the first frame update
    void Start()
    {
        cardScript = GameObject.FindObjectOfType<Cards>();

        goButton.SetActive(false);

        if (GoToDateButton.dateOrder[0] == 0)
        {
            for (int i = 1; i < dateScenes.Length; i++)
            {

                rnd = Random.Range(1, dateScenes.Length);
                tempInt = dateScenes[rnd];
                dateScenes[rnd] = dateScenes[i];
                dateScenes[i] = tempInt;
 
            }
            for (int i = 0; i < 4; i++)
            {
                GoToDateButton.dateOrder[i] = dateScenes[i];
            }
        }
        GameObject.FindObjectOfType<NextDateSymbols>().ShowNextDate();
    }

    void Update()
    {
       
        cardsComplete = true;
        foreach (GameObject card in cardScript.allCards)
        {
            if (card.activeSelf != false)
            {
                cardsComplete = false;
                break;
            }
            
        }
        if (cardsComplete)
            goButton.SetActive(true);
    }

    public void GoToDate()
    {
        GoToDateButton.datePoints = 0;
        GoToDateButton.aestheticPoints = 0;
        GoToDateButton.eventPoints = 0;
        switch (GoToDateButton.dateOrder[GoToDateButton.currentDate])
        {
            //cuteDate
            case 1:
                GoToDateButton.datePoints = cardScript.cuteTotal - cardScript.scaryTotal;
                GoToDateButton.aestheticPoints = cardScript.cuteTotal - cardScript.scaryTotal;
                break;
            //scaryDate
            case 2:
                GoToDateButton.datePoints = cardScript.scaryTotal - cardScript.cuteTotal;
                GoToDateButton.aestheticPoints = cardScript.scaryTotal - cardScript.cuteTotal;
                break;
            //toughDate
            case 3:
                GoToDateButton.datePoints = cardScript.toughTotal - cardScript.elegantTotal;
                GoToDateButton.aestheticPoints = cardScript.toughTotal - cardScript.elegantTotal;
                break;
            //elegantDate
            case 4:
                GoToDateButton.datePoints = cardScript.elegantTotal - cardScript.toughTotal;
                GoToDateButton.aestheticPoints = cardScript.elegantTotal - cardScript.toughTotal;
                break;
        }
        GoToDateButton.currentDate++;
        SceneManager.LoadScene(GoToDateButton.dateOrder[GoToDateButton.currentDate - 1]);

    }
}

