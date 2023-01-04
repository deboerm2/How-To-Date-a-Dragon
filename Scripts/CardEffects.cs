using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
    private Cards cardScript;

    public int cute = 0;
    public int scary = 0;
    public int tough = 0;
    public int elegant = 0;

    public bool dateCard;
    public bool head;
    public bool body;
    public bool wing;
    public bool tail;
    public int dateCardNum;

    // Start is called before the first frame update
    void Start()
    {
        cardScript = GameObject.FindObjectOfType<Cards>();
    }

    void Update()
    {
        if(cardScript.playerCards.Contains(gameObject))
        {
            Effect();
            
            //the CardSelection script first disables the MeshRenderer
            gameObject.SetActive(false);
        }
        if(cardScript.aiCards.Contains(gameObject))
        {
            gameObject.SetActive(false);
        }
    }

    public void Effect()
    {

        cardScript.cuteTotal += cute;
        cardScript.scaryTotal += scary;
        cardScript.toughTotal += tough;
        cardScript.elegantTotal += elegant;

        if(dateCard)
        {
            Cards.dateCards.Add(dateCardNum);
        }
        if(head)
        {
            cardScript.cuteHead+= cute;
            cardScript.scaryHead += scary;
            cardScript.toughHead += tough;
            cardScript.elegantHead += elegant;
        }
        else if(body)
        {
            cardScript.cuteBody += cute;
            cardScript.scaryBody += scary;
            cardScript.toughBody += tough;
            cardScript.elegantBody += elegant;
        }
        else if(wing)
        {
            cardScript.cuteWing += cute;
            cardScript.scaryWing += scary;
            cardScript.toughWing += tough;
            cardScript.elegantWing += elegant;
        }
        else if(tail)
        {
            cardScript.cuteTail += cute;
            cardScript.scaryTail += scary;
            cardScript.toughTail += tough;
            cardScript.elegantTail += elegant;
        }
    }
}
