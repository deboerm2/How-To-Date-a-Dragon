using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeedbackScreen : MonoBehaviour
{
    public TextMeshProUGUI dragonName;
    public TextMeshProUGUI dragonType;
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI aestheticScore;
    public TextMeshProUGUI dateScore;
    public TextMeshProUGUI feedback;

    private string aestheticFeedback = "";
    private string eventFeedback = "";
    private string knowledgeFeedback = "";

    public static bool cuteWin = false;
    public static bool scaryWin = false;
    public static bool toughWin = false;
    public static bool elegantWin = false;
    public static bool secretChad = false;
    public static bool chadWin = false;

    // Start is called before the first frame update
    void Start()
    {
       //print(GoToDateButton.datePoints);
       //print(GoToDateButton.aestheticPoints);
       //print(GoToDateButton.eventPoints);

        if (GoToDateButton.aestheticPoints <= 5)
            aestheticFeedback = "Needs to work on their appearance \n\n";
        if (DateDialouge.firstEventResult <= 1 || DateDialouge.secondEventResult <= 1)
            eventFeedback = "Needs to be better prepared for unexpected problems \n\n";
        if (DateDialouge.thirdEventResult == 0)
            knowledgeFeedback = "I can't agree with their thoughts";

        if (FeedbackScreen.cuteWin && FeedbackScreen.scaryWin && FeedbackScreen.toughWin && FeedbackScreen.elegantWin)
        {
            FeedbackScreen.secretChad = true;
            Debug.LogError("Chad enabled Feedback");
        }

        switch (GoToDateButton.dateOrder[GoToDateButton.currentDate - 1])
        {
            //cute
            case 1:
                dragonName.text += "Cora";
                dragonType.text += "Cute";
                totalScore.text += GoToDateButton.datePoints.ToString();
                aestheticScore.text += GoToDateButton.aestheticPoints.ToString();
                dateScore.text += GoToDateButton.eventPoints.ToString();
                feedback.text = aestheticFeedback + eventFeedback + knowledgeFeedback;
                if (GoToDateButton.datePoints >= 13)
                    FeedbackScreen.cuteWin = true;
                break;
            //scary
            case 2:
                dragonName.text += "Scarlet";
                dragonType.text += "Scary";
                totalScore.text += GoToDateButton.datePoints.ToString();
                aestheticScore.text += GoToDateButton.aestheticPoints.ToString();
                dateScore.text += GoToDateButton.eventPoints.ToString();
                feedback.text = aestheticFeedback + eventFeedback + knowledgeFeedback;
                if (GoToDateButton.datePoints >= 13)
                    FeedbackScreen.scaryWin = true;
                break;
            //tough
            case 3:
                dragonName.text += "Tilly";
                dragonType.text += "Tough";
                totalScore.text += GoToDateButton.datePoints.ToString();
                aestheticScore.text += GoToDateButton.aestheticPoints.ToString();
                dateScore.text += GoToDateButton.eventPoints.ToString();
                feedback.text = aestheticFeedback + eventFeedback + knowledgeFeedback;
                if (GoToDateButton.datePoints >= 13)
                    FeedbackScreen.toughWin = true;
                break;
            //elegant
            case 4:
                dragonName.text += "Eleanor";
                dragonType.text += "Elegant";
                totalScore.text += GoToDateButton.datePoints.ToString();
                aestheticScore.text += GoToDateButton.aestheticPoints.ToString();
                dateScore.text += GoToDateButton.eventPoints.ToString();
                feedback.text = aestheticFeedback + eventFeedback + knowledgeFeedback;
                if (GoToDateButton.datePoints >= 13)
                    FeedbackScreen.elegantWin = true;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
