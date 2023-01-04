using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonAppearance : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite cuteSprite;
    public Sprite scarySprite;
    public Sprite toughSprite;
    public Sprite elegantSprite;

    public int[] partStats = new int[4];

    private Cards cardScript;
    private Image goImage;

    // Start is called before the first frame update
    void Start()
    {
        cardScript = GameObject.FindObjectOfType<Cards>();
        goImage = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    public void ChangeAppearance()
    {
        if (gameObject.name == "Head")
        {
            Head();
        }
        if (gameObject.name == "Spine")
        {
            Spine();
        }
        if (gameObject.name == "Wings")
        {
            Wing();
        }
        if (gameObject.name == "Tail")
        {
            Tail();
        }
    }

    private void Head()
    {
        partStats[0] = cardScript.cuteHead;
        partStats[1] = cardScript.scaryHead;
        partStats[2] = cardScript.toughHead;
        partStats[3] = cardScript.elegantHead;

        if (Mathf.Max(partStats) == 0)
        {
            return;
        }
        else if (Mathf.Max(partStats) == partStats[0])
        {
            goImage.sprite = cuteSprite;
        }
        else if (Mathf.Max(partStats) == partStats[1])
        {
            goImage.sprite = scarySprite;
        }
        else if (Mathf.Max(partStats) == partStats[2])
        {
            goImage.sprite = toughSprite;
        }
        else if (Mathf.Max(partStats) == partStats[3])
        {
            goImage.sprite = elegantSprite;
        }
    }
    private void Spine()
    {
        partStats[0] = cardScript.cuteBody;
        partStats[1] = cardScript.scaryBody;
        partStats[2] = cardScript.toughBody;
        partStats[3] = cardScript.elegantBody;

        if (Mathf.Max(partStats) == 0)
        {
            return;
        }
        else if (Mathf.Max(partStats) == partStats[0])
        {
            goImage.sprite = cuteSprite;
        }
        else if (Mathf.Max(partStats) == partStats[1])
        {
            goImage.sprite = scarySprite;
        }
        else if (Mathf.Max(partStats) == partStats[2])
        {
            goImage.sprite = toughSprite;
        }
        else if (Mathf.Max(partStats) == partStats[3])
        {
            goImage.sprite = elegantSprite;
        }
    }
    private void Wing()
    {
        partStats[0] = cardScript.cuteWing;
        partStats[1] = cardScript.scaryWing;
        partStats[2] = cardScript.toughWing;
        partStats[3] = cardScript.elegantWing;

        if (Mathf.Max(partStats) == 0)
        {
            return;
        }
        else if (Mathf.Max(partStats) == partStats[0])
        {
            goImage.sprite = cuteSprite;
        }
        else if (Mathf.Max(partStats) == partStats[1])
        {
            goImage.sprite = scarySprite;
        }
        else if (Mathf.Max(partStats) == partStats[2])
        {
            goImage.sprite = toughSprite;
        }
        else if (Mathf.Max(partStats) == partStats[3])
        {
            goImage.sprite = elegantSprite;
        }
    }
    private void Tail()
    {
        partStats[0] = cardScript.cuteTail;
        partStats[1] = cardScript.scaryTail;
        partStats[2] = cardScript.toughTail;
        partStats[3] = cardScript.elegantTail;

        if (Mathf.Max(partStats) == 0)
        {
            return;
        }
        else if (Mathf.Max(partStats) == partStats[0])
        {
            goImage.sprite = cuteSprite;
        }
        else if (Mathf.Max(partStats) == partStats[1])
        {
            goImage.sprite = scarySprite;
        }
        else if (Mathf.Max(partStats) == partStats[2])
        {
            goImage.sprite = toughSprite;
        }
        else if (Mathf.Max(partStats) == partStats[3])
        {
            goImage.sprite = elegantSprite;
        }
    }
}
