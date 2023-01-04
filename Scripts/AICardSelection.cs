using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICardSelection : MonoBehaviour
{
    private CardSelection cardSelectionScript;
    [Range(1,6)]
    private int aiSelection;

    // Start is called before the first frame update
    void Start()
    {
        cardSelectionScript = GameObject.FindObjectOfType<CardSelection>();
    }

   
    public void StartAITurn()
    {
        StartCoroutine(AIChoose(1.5f));
    }

    IEnumerator AIChoose(float delay)
    {
        if (cardSelectionScript.aiTurn == true)
        {
            aiSelection = Random.Range(1, 6);
            while (aiSelection == cardSelectionScript.choiceLock)
            {
                aiSelection = Random.Range(1, 6);
            }
        }

        if(cardSelectionScript.emptyChoice == false)
            yield return new WaitForSeconds(delay);

        switch (aiSelection)
        {
            case 1:
                cardSelectionScript.Row1ButtonPress();
                break;
            case 2:
                cardSelectionScript.Row2ButtonPress();
                break;
            case 3:
                cardSelectionScript.Row3ButtonPress();
                break;
            case 4:
                cardSelectionScript.Column1ButtonPress();
                break;
            case 5:
                cardSelectionScript.Column2ButtonPress();
                break;
            case 6:
                cardSelectionScript.Column3ButtonPress();
                break;
            default:
                break;
        }
        
    }
}
