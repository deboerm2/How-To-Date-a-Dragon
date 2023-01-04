using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    private Cards cardscript;
    private AICardSelection aiCSS;
    private GameObject tempGO;
    private GameObject cardBack;

    public Button row1Button;
    public Button row2Button;
    public Button row3Button;
    public Button column1Button;
    public Button column2Button;
    public Button column3Button;

    private GameObject[] grid = new GameObject[9];
    public GameObject[] cardsInGrid = new GameObject[9];

    private GameObject[] queue = new GameObject[3];
    private int queueSetNum = 9;
    [HideInInspector]
    public int choiceLock;
    [HideInInspector]
    public bool aiTurn = false;
    [HideInInspector]
    public bool emptyChoice = false;
    private bool gridEmpty = true;

    private GameObject[] row1 = new GameObject[3];
    private GameObject[] row2 = new GameObject[3];
    private GameObject[] row3 = new GameObject[3];
    private GameObject[] column1 = new GameObject[3];
    private GameObject[] column2 = new GameObject[3];
    private GameObject[] column3 = new GameObject[3];

    private Transform[] row1T;
    private Transform[] row2T;
    private Transform[] row3T;
    private Transform[] column1T;
    private Transform[] column2T;
    private Transform[] column3T;

    public AudioSource myAudioSource;
    public AudioClip myAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        Cards.dateCards.Clear();

        cardBack = GameObject.Find("CardBack");

        cardscript = GameObject.FindObjectOfType<Cards>();
        aiCSS = GameObject.FindObjectOfType<AICardSelection>();
        //grid = GameObject.FindGameObjectsWithTag("Spot");

        for(int i = 0; i < 9; i++)
        {
            int j = i + 1;
            grid[i] = GameObject.Find("Spot" + j.ToString());
            print(grid[i].name);
        }

        row1T = new Transform[] { grid[0].transform, grid[1].transform, grid[2].transform };
        row2T = new Transform[] { grid[3].transform, grid[4].transform, grid[5].transform };
        row3T = new Transform[] { grid[6].transform, grid[7].transform, grid[8].transform };
        column1T = new Transform[] { grid[0].transform, grid[3].transform, grid[6].transform };
        column2T = new Transform[] { grid[1].transform, grid[4].transform, grid[7].transform };
        column3T = new Transform[] { grid[2].transform, grid[5].transform, grid[8].transform };

        Shuffle();

        for(int i = 0; i < grid.Length; i++)
        {
            cardscript.allCards[i].transform.position = grid[i].transform.position;
            cardsInGrid[i] = cardscript.allCards[i]; 
        }
        for(int j = 0; j < queue.Length; j++)
        {
            queue[j] = cardscript.allCards[j + 9];
            queueSetNum++;
        }


    }

    void Update()
    {
        if(queue[0] == null)
        {
            cardBack.SetActive(false);
        }
        int emptyCards = 0;
        foreach (GameObject gridCard in cardsInGrid)
        {
            if(gridCard == null)
            {
                emptyCards++;
                if (emptyCards == 9)
                {
                    gridEmpty = true;
                    return;
                }
            }
            gridEmpty = false;
        }

        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayback>().PlayCards();
    }

    public void PlaySound()
    {
        myAudioSource.pitch = Random.Range(0.8f, 1.3f);
        myAudioSource.PlayOneShot(myAudioClip);
    }

    public void Row1ButtonPress()
    {
        if(choiceLock != 1)
        {
            StartCoroutine(Row1(0.5f));
            choiceLock = 1;
            if (aiTurn == true && gridEmpty == false)
                aiCSS.StartAITurn();
        }
    
    }

    public void Row2ButtonPress()
    {
        if (choiceLock != 2)
        {
            StartCoroutine(Row2(0.5f));
            choiceLock = 2;
            if (aiTurn == true && gridEmpty == false)
                aiCSS.StartAITurn();
        }
      
    }

    public void Row3ButtonPress()
    {
        if (choiceLock != 3)
        {
            StartCoroutine(Row3(0.5f));
            choiceLock = 3;
            if (aiTurn == true && gridEmpty == false)
                aiCSS.StartAITurn();
        }
      
    }

    public void Column1ButtonPress()
    {
        if (choiceLock != 4 )
        {
            StartCoroutine(Column1(0.5f));
            choiceLock = 4;
            if (aiTurn == true && gridEmpty == false)
                aiCSS.StartAITurn();
        }
        
    }

    public void Column2ButtonPress()
    {
        if (choiceLock != 5)
        {
            StartCoroutine(Column2(0.5f));
            choiceLock = 5;
            if (aiTurn == true && gridEmpty == false)
                aiCSS.StartAITurn();
        }
        
    }

    public void Column3ButtonPress()
    {
        if (choiceLock != 6)
        {
            StartCoroutine(Column3(0.5f));
            choiceLock = 6;
            if (aiTurn == true && gridEmpty == false)
                aiCSS.StartAITurn();
        }
        
    }

    public void DisableButtons()
    {
        row1Button.interactable = false;
        row2Button.interactable = false;
        row3Button.interactable = false;
        column1Button.interactable = false;
        column2Button.interactable = false;
        column3Button.interactable = false;
    }

    private void ReEnableButtons()
    {
        row1Button.interactable = true;
        row2Button.interactable = true;
        row3Button.interactable = true;
        column1Button.interactable = true;
        column2Button.interactable = true;
        column3Button.interactable = true;
    }

    void Shuffle()
    {
        for (int i = 0; i < cardscript.allCards.Length; i++)
        {
            int rnd = Random.Range(0, cardscript.allCards.Length);
            tempGO = cardscript.allCards[rnd];
            cardscript.allCards[rnd] = cardscript.allCards[i];
            cardscript.allCards[i] = tempGO;
        }
    }

    IEnumerator Row1(float delay)
    {
        row1[0] = cardsInGrid[0];
        row1[1] = cardsInGrid[1];
        row1[2] = cardsInGrid[2];

        //prevents selecting a completely empty row
        if (row1[0] == null && row1[1] == null && row1[2] == null)
        {
            emptyChoice = true;
            yield break;
        }
        else
        {
            emptyChoice = false;
            DisableButtons();
        }
        if (aiTurn == false)
        {
            cardscript.playerCards.Add(cardsInGrid[0]);
            cardscript.playerCards.Add(cardsInGrid[1]);
            cardscript.playerCards.Add(cardsInGrid[2]);
            aiTurn = true;
        }
        else if (aiTurn == true)
        {
            cardscript.aiCards.Add(cardsInGrid[0]);
            cardscript.aiCards.Add(cardsInGrid[1]);
            cardscript.aiCards.Add(cardsInGrid[2]);
            aiTurn = false;
        }

        //prevent errors when objects are null
        foreach (GameObject card in row1)
        {
            if (card != null)
            {
                card.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        PlaySound();

        yield return new WaitForSeconds(delay);

        cardsInGrid[0] = queue[0];
        cardsInGrid[1] = queue[1];
        cardsInGrid[2] = queue[2];

        row1[0] = cardsInGrid[0];
        row1[1] = cardsInGrid[1];
        row1[2] = cardsInGrid[2];

        //also prevents errors
        for (int i = 0; i< row1.Length; i++)
        {
            if (row1[i] != null)
            {
                row1[i].transform.position = row1T[i].position;
            }
        }
           
        for(int i = 0; i < queue.Length; i++)
        {
            if (queueSetNum < cardscript.allCards.Length)
            {
                queue[i] = cardscript.allCards[queueSetNum];
                queueSetNum++;
            }
            else
            {
                queue[i] = null;
            }
        }
        if (aiTurn == false)
        {
            ReEnableButtons();
            row1Button.interactable = false;
        }
    }

    IEnumerator Row2(float delay)
    {

        row2[0] = cardsInGrid[3];
        row2[1] = cardsInGrid[4];
        row2[2] = cardsInGrid[5];

        //prevents selecting a completely empty row
        if (row2[0] == null && row2[1] == null && row2[2] == null)
        {
            emptyChoice = true;
            yield break;
        }
        else
        {
            emptyChoice = false;
            DisableButtons();
        }
        if (aiTurn == false)
        {
            cardscript.playerCards.Add(cardsInGrid[3]);
            cardscript.playerCards.Add(cardsInGrid[4]);
            cardscript.playerCards.Add(cardsInGrid[5]);
            aiTurn = true;
        }
        else if (aiTurn == true)
        {
            cardscript.aiCards.Add(cardsInGrid[3]);
            cardscript.aiCards.Add(cardsInGrid[4]);
            cardscript.aiCards.Add(cardsInGrid[5]);
            aiTurn = false;
        }

        //prevent errors when objects are null
        foreach (GameObject card in row2)
        {
            if (card != null)
                card.GetComponent<MeshRenderer>().enabled = false;
        }

        PlaySound();

        yield return new WaitForSeconds(delay);

        cardsInGrid[3] = queue[0];
        cardsInGrid[4] = queue[1];
        cardsInGrid[5] = queue[2];

        row2[0] = cardsInGrid[3];
        row2[1] = cardsInGrid[4];
        row2[2] = cardsInGrid[5];
        
        //also prevents errors
        for (int i = 0; i < row2.Length; i++)
        {
            if (row2[i] != null)
                row2[i].transform.position = row2T[i].position;
        }

        for (int i = 0; i < queue.Length; i++)
        {
            if (queueSetNum < cardscript.allCards.Length)
            {
                queue[i] = cardscript.allCards[queueSetNum];
                queueSetNum++;
            }
            else
            {
                queue[i] = null;
            }
        }
        if (aiTurn == false)
        {
            ReEnableButtons();
            row2Button.interactable = false;
        }
    }

    IEnumerator Row3(float delay)
    {
        row3[0] = cardsInGrid[6];
        row3[1] = cardsInGrid[7];
        row3[2] = cardsInGrid[8];

        //prevents selecting a completely empty row
        if (row3[0] == null && row3[1] == null && row3[2] == null)
        {
            emptyChoice = true;
            yield break;
        }
        else
        {
            emptyChoice = false;
            DisableButtons();
        }
        if (aiTurn == false)
        {
            cardscript.playerCards.Add(cardsInGrid[6]);
            cardscript.playerCards.Add(cardsInGrid[7]);
            cardscript.playerCards.Add(cardsInGrid[8]);
            aiTurn = true;
        }
        else if (aiTurn == true)
        {
            cardscript.aiCards.Add(cardsInGrid[6]);
            cardscript.aiCards.Add(cardsInGrid[7]);
            cardscript.aiCards.Add(cardsInGrid[8]);
            aiTurn = false;
        }

        //prevent errors when objects are null
        foreach (GameObject card in row3)
        {
            if (card != null)
                card.GetComponent<MeshRenderer>().enabled = false;
        }

        PlaySound();

        yield return new WaitForSeconds(delay);

        cardsInGrid[6] = queue[0];
        cardsInGrid[7] = queue[1];
        cardsInGrid[8] = queue[2];

        row3[0] = cardsInGrid[6];
        row3[1] = cardsInGrid[7];
        row3[2] = cardsInGrid[8];

        //also prevents errors
        for (int i = 0; i < row3.Length; i++)
        {
            if (row3[i] != null)
                row3[i].transform.position = row3T[i].position;
        }

        for (int i = 0; i < queue.Length; i++)
        {
            if (queueSetNum < cardscript.allCards.Length)
            {
                queue[i] = cardscript.allCards[queueSetNum];
                queueSetNum++;
            }
            else
            {
                queue[i] = null;
            }
        }
        if (aiTurn == false)
        {
            ReEnableButtons();
            row3Button.interactable = false;
        }
    }

    IEnumerator Column1(float delay)
    {
        column1[0] = cardsInGrid[0];
        column1[1] = cardsInGrid[3];
        column1[2] = cardsInGrid[6];

        //prevents selecting a completely empty column
        if (column1[0] == null && column1[1] == null && column1[2] == null)
        {
            emptyChoice = true;
            yield break;
        }
        else
        {
            emptyChoice = false;
            DisableButtons();
        }
        if (aiTurn == false)
        {
            cardscript.playerCards.Add(cardsInGrid[0]);
            cardscript.playerCards.Add(cardsInGrid[3]);
            cardscript.playerCards.Add(cardsInGrid[6]);
            aiTurn = true;
        }
        else if (aiTurn == true)
        {
            cardscript.aiCards.Add(cardsInGrid[0]);
            cardscript.aiCards.Add(cardsInGrid[3]);
            cardscript.aiCards.Add(cardsInGrid[6]);
            aiTurn = false;
        }

        //prevent errors when objects are null
        foreach (GameObject card in column1)
        {
            if (card != null)
                card.GetComponent<MeshRenderer>().enabled = false;
        }

        PlaySound();

        yield return new WaitForSeconds(delay);

        cardsInGrid[0] = queue[0];
        cardsInGrid[3] = queue[1];
        cardsInGrid[6] = queue[2];

        column1[0] = cardsInGrid[0];
        column1[1] = cardsInGrid[3];
        column1[2] = cardsInGrid[6];

        //also prevents errors
        for (int i = 0; i < column1.Length; i++)
        {
            if (column1[i] != null)
                column1[i].transform.position = column1T[i].position;
        }

        for (int i = 0; i < queue.Length; i++)
        {
            if (queueSetNum < cardscript.allCards.Length)
            {
                queue[i] = cardscript.allCards[queueSetNum];
                queueSetNum++;
            }
            else
            {
                queue[i] = null;
            }
        }
        if (aiTurn == false)
        {
            ReEnableButtons();
            column1Button.interactable = false;
        }
    }

    IEnumerator Column2(float delay)
    {
        column2[0] = cardsInGrid[1];
        column2[1] = cardsInGrid[4];
        column2[2] = cardsInGrid[7];

        //prevents selecting a completely empty column
        if (column2[0] == null && column2[1] == null && column2[2] == null)
        {
            emptyChoice = true;
            yield break;
        }
        else
        {
            emptyChoice = false;
            DisableButtons();
        }
        if (aiTurn == false)
        {
            cardscript.playerCards.Add(cardsInGrid[1]);
            cardscript.playerCards.Add(cardsInGrid[4]);
            cardscript.playerCards.Add(cardsInGrid[7]);
            aiTurn = true;
        }
        else if (aiTurn == true)
        {
            cardscript.aiCards.Add(cardsInGrid[1]);
            cardscript.aiCards.Add(cardsInGrid[4]);
            cardscript.aiCards.Add(cardsInGrid[7]);
            aiTurn = false;
        }

        //prevent errors when objects are null
        foreach (GameObject card in column2)
        {
            if (card != null)
                card.GetComponent<MeshRenderer>().enabled = false;
        }

        PlaySound();

        yield return new WaitForSeconds(delay);

        cardsInGrid[1] = queue[0];
        cardsInGrid[4] = queue[1];
        cardsInGrid[7] = queue[2];

        column2[0] = cardsInGrid[1];
        column2[1] = cardsInGrid[4];
        column2[2] = cardsInGrid[7];

        //also prevents errors
        for (int i = 0; i < column2.Length; i++)
        {
            if (column2[i] != null)
                column2[i].transform.position = column2T[i].position;
        }

        for (int i = 0; i < queue.Length; i++)
        {
            if (queueSetNum < cardscript.allCards.Length)
            {
                queue[i] = cardscript.allCards[queueSetNum];
                queueSetNum++;
            }
            else
            {
                queue[i] = null;
            }
        }
        if (aiTurn == false)
        {
            ReEnableButtons();
            column2Button.interactable = false;
        }
    }

    IEnumerator Column3(float delay)
    {
        column3[0] = cardsInGrid[2];
        column3[1] = cardsInGrid[5];
        column3[2] = cardsInGrid[8];

        //prevents selecting a completely empty column
        if (column3[0] == null && column3[1] == null && column3[2] == null)
        {
            emptyChoice = true;
            yield break;
        }
        else
        {
            emptyChoice = false;
            DisableButtons();
        }
        if (aiTurn == false)
        {
            cardscript.playerCards.Add(cardsInGrid[2]);
            cardscript.playerCards.Add(cardsInGrid[5]);
            cardscript.playerCards.Add(cardsInGrid[8]);
            aiTurn = true;
        }
        else if (aiTurn == true)
        {
            cardscript.aiCards.Add(cardsInGrid[2]);
            cardscript.aiCards.Add(cardsInGrid[5]);
            cardscript.aiCards.Add(cardsInGrid[8]);
            aiTurn = false;
        }

        //prevent errors when objects are null
        foreach (GameObject card in column3)
        {
            if (card != null)
                card.GetComponent<MeshRenderer>().enabled = false;
        }

        PlaySound();

        yield return new WaitForSeconds(delay);

        cardsInGrid[2] = queue[0];
        cardsInGrid[5] = queue[1];
        cardsInGrid[8] = queue[2];

        column3[0] = cardsInGrid[2];
        column3[1] = cardsInGrid[5];
        column3[2] = cardsInGrid[8];

        //also prevents errors
        for (int i = 0; i < column3.Length; i++)
        {
            if (column3[i] != null)
                column3[i].transform.position = column3T[i].position;
        }

        for (int i = 0; i < queue.Length; i++)
        {
            if (queueSetNum < cardscript.allCards.Length)
            {
                queue[i] = cardscript.allCards[queueSetNum];
                queueSetNum++;
            }
            else
            {
                queue[i] = null;
            }
        }
        if (aiTurn == false)
        {
            ReEnableButtons();
            column3Button.interactable = false;
        }
    }
    
}
