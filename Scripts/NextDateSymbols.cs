using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDateSymbols : MonoBehaviour
{
    public Image cuteImage;
    public Image scaryImage;
    public Image toughImage;
    public Image elegantImage;

    // Start is called before the first frame update
    public void ShowNextDate()
    {
        switch(GoToDateButton.dateOrder[GoToDateButton.currentDate])
        {
            case 1:
                //cute
                cuteImage.color = new Color(225, 225, 225, 255);
                break;
            case 2:
                //scary
                scaryImage.color = new Color(225, 225, 225, 255);
                break;
            case 3:
                //tough
                toughImage.color = new Color(225, 225, 225, 255);
                break;
            case 4:
                //elegant
                elegantImage.color = new Color(225, 225, 225, 255);
                break;
        }
    }
}
