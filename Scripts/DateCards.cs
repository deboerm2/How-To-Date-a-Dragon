using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateCards : MonoBehaviour
{
    [SerializeField]
    private GameObject[] allDateCardsArray;
    //private SortedList<string, GameObject> allDateCards = new SortedList<string, GameObject>();
    private List<GameObject> itemCards = new List<GameObject>();
    private List<GameObject> knowledgeCards = new List<GameObject>();
    private int tempCounterItem = 0;
    private int tempCounterKnowledge = 0;

    // Start is called before the first frame update
    void Awake()
    {
        allDateCardsArray = GameObject.FindGameObjectsWithTag("Card");

        //Debug.LogError(allDateCardsArray.Length);
        for (int i = 0; i < allDateCardsArray.Length; i++)
        {
            allDateCardsArray[i].SetActive(false);
        }
    }

    void Start()
    {
        foreach (int i in Cards.dateCards)
        {
            foreach (GameObject GO in allDateCardsArray)
            {
                if (GO.name.Contains(i.ToString()) && GO.name.Contains("ItemCard") && i <=10)
                {
                    if (GO.name.Contains("10") && i != 10)
                    {
                        //no free hands
                    }
                    else
                    {
                        itemCards.Add(GO);
                    }
                }
                else if (GO.name.Contains(i.ToString()) && GO.name.Contains("KnowledgeCard") && i >10)
                {
                    knowledgeCards.Add(GO);
                }

            }
        }
        
        ItemCards();
        KnowledgeCards();
    }

    void ItemCards()
    {
        
        for(int i = 0; i < itemCards.Count; i++)
        {
            itemCards[i].SetActive(true);
            itemCards[i].GetComponent<RectTransform>().localPosition = new Vector3(i * 150 + 100, -100, 0);
            //tempCounterItem++;
            //Debug.LogError(itemCards[i] + "active item card");
        }
    }
    void KnowledgeCards()
    {
        for (int j = 0; j < knowledgeCards.Count; j++)
        {
            knowledgeCards[j].SetActive(true);
            knowledgeCards[j].GetComponent<RectTransform>().localPosition = new Vector3(j * 150 + 100, -100, 0);
            //tempCounterKnowledge++;
            //Debug.LogError(knowledgeCards[j] + "active knowledge card");
        }
    }

}
