using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public GameObject[] allCards;
    public List<GameObject> aiCards = new List<GameObject>();
    public  List<GameObject> playerCards = new List<GameObject>();
    public static List<int> dateCards = new List<int>();

    [Header("Total Stats")]
    public int cuteTotal = 0;
    public int scaryTotal = 0;
    public int toughTotal = 0;
    public int elegantTotal = 0;
    [Header("Head Stats")]
    public int cuteHead = 0;
    public int scaryHead = 0;
    public int toughHead = 0;
    public int elegantHead = 0;
    [Header("Body Stats")]
    public int cuteBody = 0;
    public int scaryBody = 0;
    public int toughBody = 0;
    public int elegantBody = 0;
    [Header("Wing Stats")]
    public int cuteWing= 0;
    public int scaryWing= 0;
    public int toughWing= 0;
    public int elegantWing= 0;
    [Header("Tail Stats")]
    public int cuteTail = 0;
    public int scaryTail= 0;
    public int toughTail= 0;
    public int elegantTail= 0;


    

    // Start is called before the first frame update
    void Awake()
    {

        //Might be easier to manually set the list for the actual game.
        allCards = GameObject.FindGameObjectsWithTag("Card");

    }
}
