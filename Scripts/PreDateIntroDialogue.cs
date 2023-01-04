using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PreDateIntroDialogue : MonoBehaviour
{
    private int dialogueProgress = 1;

    [Header("Visual")]
    public Image imageGO;
    public Sprite narratorBox;
    public Sprite scaryBox;
    public Sprite toughBox;
    public Sprite elegantBox;
    public Sprite chadBox;
    public GameObject scaryDragon;
    public GameObject toughDragon;
    public GameObject elegantDragon;
    public GameObject chadDragon;
    [Header("Text")]
    public TextMeshProUGUI tmpText;
    public GameObject choice1Box;
    public GameObject choice2Box;
    private TextMeshProUGUI choice1Text;
    private TextMeshProUGUI choice2Text;
    private bool choice1 = false;
    private bool choice2 = false;

    public AudioClip myAudioClip;
    public AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        choice1Text = choice1Box.GetComponentInChildren<TextMeshProUGUI>();
        choice2Text = choice2Box.GetComponentInChildren<TextMeshProUGUI>();
        choice1Box.SetActive(false);
        choice2Box.SetActive(false);
        scaryDragon.SetActive(false);
        toughDragon.SetActive(false);
        elegantDragon.SetActive(false);
        chadDragon.SetActive(false);
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayback>().PlayCards();

        if (FeedbackScreen.cuteWin && FeedbackScreen.scaryWin && FeedbackScreen.toughWin && FeedbackScreen.elegantWin)
        {
            FeedbackScreen.secretChad = true;
            Debug.LogError("Chad enabled PDD");
        }
    }

    public void ProgressDialogue()
    {
        if (GoToDateButton.currentDate < 4)
        {
            switch (GoToDateButton.dateOrder[GoToDateButton.currentDate])
            {
                //scary
                case 2:
                    switch (dialogueProgress)
                    {
                        case 1:
                            imageGO.sprite = narratorBox;
                            tmpText.text = "*Bumps into something. You turn around to see the most horrifying thing you have ever laid your eyes on*";
                            dialogueProgress++;
                            break;
                        case 2:
                            scaryDragon.SetActive(true);
                            imageGO.sprite = scaryBox;
                            tmpText.text = " I am so sorry I usually am pretty clumsy. I tend to bump into things. Are you okay? " +
                                "I hope you don’t have any scratches on yourself. I’m Scarlett.";
                            choice1Box.SetActive(true);
                            choice2Box.SetActive(true);
                            choice1Text.text = "Introduce yourself";
                            choice2Text.text = "Stand there";
                            break;
                        case 3:
                            myAudioSource.PlayOneShot(myAudioClip);
                            choice1Text.text = "Accept her offer";
                            choice2Text.text = "Decline";
                            tmpText.text = " I am surprised you are still here. Other Dragons usually run away by now. " +
                                "Well since you haven’t run away by now I have these coupons to the restaurant on the island. " +
                                "Would you like to go with me? Not as a date… unless you want it to be one.";
                            break;
                        case 4:
                            if (choice1)
                            {
                                myAudioSource.PlayOneShot(myAudioClip);
                                //card collecting scene
                                SceneManager.LoadScene(5);
                            }
                            else if (choice2)
                            {
                                GoToDateButton.currentDate++;
                                    //reload scene
                                 if (GoToDateButton.currentDate < 4)
                                    SceneManager.LoadScene(9);
                                else
                                {
                                    if (FeedbackScreen.secretChad)
                                    {
                                        SceneManager.LoadScene(9);
                                    }
                                    else
                                    { //load end screen
                                        SceneManager.LoadScene(8);
                                    }
                                }
                            }
                            break;
                    }
                    break;
                //tough
                case 3:
                    switch (dialogueProgress)
                    {
                        case 1:
                            imageGO.sprite = narratorBox;
                            tmpText.text = "*Bumps into a large mass. You think it's a rock but you turn around and…*";
                            dialogueProgress++;
                            break;
                        case 2:
                            toughDragon.SetActive(true);
                            imageGO.sprite = toughBox;
                            tmpText.text = " CAN YOU MOVE OUT OF THE … *coughs* Can you move please.";
                            choice1Box.SetActive(true);
                            choice2Box.SetActive(true);
                            choice1Text.text = "Move to the side";
                            choice2Text.text = "Stand there";
                            break;
                        case 3:
                            tmpText.text = " Oh I am sorry I must have not seen you over my large dragon muscles. " +
                                "I actually hit the gym every day. Wow you look very… weak… but cute… but also very weak.";
                            choice1Box.SetActive(false);
                            choice2Box.SetActive(false);
                            dialogueProgress++;
                            break;
                        case 4:
                            choice1Box.SetActive(true);
                            choice2Box.SetActive(true);
                            choice1Text.text = "Accept her offer";
                            choice2Text.text = "Decline";
                            tmpText.text = " Anywho my name is Tilly and I have been looking for a workout buddy. Would you like to get to know each other better?" +
                                " Just to make sure we are both ready to get ripped!";
                            break;
                        case 5:
                            if (choice1)
                            {
                                //will go to chad after ending screen
                                //card collecting scene
                                SceneManager.LoadScene(5);
                            }
                            else if (choice2)
                            {
                                GoToDateButton.currentDate++;
                                    //reload scene
                                if (GoToDateButton.currentDate < 4)
                                    SceneManager.LoadScene(9);
                                else
                                {
                                    if (FeedbackScreen.secretChad)
                                    {
                                        SceneManager.LoadScene(9);
                                    }
                                    else
                                    { //load end screen
                                        SceneManager.LoadScene(8);
                                    }
                                }
                            }
                            break;

                    }
                    break;
                //elegant
                case 4:
                    switch (dialogueProgress)
                    {
                        case 1:
                            imageGO.sprite = narratorBox;
                            tmpText.text = "*Bumps into something and you hear a thud.*";
                            dialogueProgress++;
                            break;
                        case 2:
                            elegantDragon.SetActive(true);
                            imageGO.sprite = elegantBox;
                            tmpText.text = " Why does everyone forget their manners when we are all of a sudden away from the mainland. Ewww and who are you…?";
                            choice1Box.SetActive(true);
                            choice2Box.SetActive(true);
                            choice1Text.text = "Introduce yourself";
                            choice2Text.text = "Stand there";
                            break;
                        case 3:
                            tmpText.text = "Do you have any decency and pick me up off the ground?";
                            choice1Box.SetActive(false);
                            choice2Box.SetActive(false);
                            dialogueProgress++;
                            break;
                        case 4:
                            imageGO.sprite = narratorBox;
                            tmpText.text = "*You pick her up*";
                            dialogueProgress++;
                            break;
                        case 5:
                            choice1Box.SetActive(true);
                            choice2Box.SetActive(true);
                            choice1Text.text = "Accept her offer";
                            choice2Text.text = "Decline";
                            tmpText.text = " Thank you. At least you know how to follow instructions. I’m Eleanor. Hmmm you know what. " +
                                "For my inconvenience you should take me out.. " +
                                "As uh … As compensation for pushing me. How about that restaurant everyone is raving about.";
                            imageGO.sprite = elegantBox;
                            break;
                        case 6:
                            if (choice1)
                            {
                                //card collecting scene
                                SceneManager.LoadScene(5);
                            }
                            else if (choice2)
                            {
                                GoToDateButton.currentDate++;
                                //reload scene
                                if (GoToDateButton.currentDate < 4)
                                    SceneManager.LoadScene(9);
                                else
                                {
                                    if (FeedbackScreen.secretChad)
                                    {
                                        SceneManager.LoadScene(9);
                                    }
                                    else
                                    { //load end screen
                                        SceneManager.LoadScene(8);
                                    }
                                }
                            }
                            break;
                    }
                    break;
                default:
                    if (FeedbackScreen.secretChad)
                        SecretChadDialogue();
                    break;
            }
        }
        else
        {
            if (FeedbackScreen.secretChad)
                SecretChadDialogue();
        }
        
    }

    public void ProgressDialogueButton1()
    {
        choice1 = true;
        choice2 = false;
        dialogueProgress++;
        ProgressDialogue();
    }

    public void ProgressDialogueButton2()
    {
        choice1 = false;
        choice2 = true;
        dialogueProgress++;
        ProgressDialogue();
    }

    public void SecretChadDialogue()
    {
        switch(dialogueProgress)
        {
            case 1:
                imageGO.sprite = chadBox;
                tmpText.text = "Okay you weird but handsome but cringe dragon I need to tell you something.";
                chadDragon.SetActive(true);
                dialogueProgress++;
                break;
            case 2:
                imageGO.sprite = narratorBox;
                tmpText.text = "*You stand there confused on what is happening*";
                dialogueProgress++;
                break;
            case 3:
                imageGO.sprite = chadBox;
                tmpText.text = " I think now is the best time to confess. I haven’t been completely honest with you. I didn’t want all the dragon babes. I wanted you.";
                dialogueProgress++;
                break;
            case 4:
                imageGO.sprite = narratorBox;
                tmpText.text = "*You are even more confused*";
                dialogueProgress++;
                break;
            case 5:
                imageGO.sprite = chadBox;
                tmpText.text = "This entire time I have been watching you from afar since I am in love with you." +
                    " I have been taking away your aesthetic cards because I didn’t want those other dragons to fall in love with you. I kinda have a jealousy problem…";
                dialogueProgress++;
                break;
            case 6:
                imageGO.sprite = narratorBox;
                tmpText.text = "*You look around questioning if this is a prank*";
                dialogueProgress++;
                break;
            case 7:
                imageGO.sprite = chadBox;
                tmpText.text = "Please give me a chance! I would love for the opportunity to get to be with you. " +
                    "You don’t have to reject the other dragons, I just want to be yours! ";
                choice1Box.SetActive(true);
                choice2Box.SetActive(true);
                choice1Text.text = "Forgive chad and accept his love";
                choice2Text.text = "Reject him";
                break;
            case 8:
                choice1Box.SetActive(false);
                choice2Box.SetActive(false);
                if (choice1)
                {
                    FeedbackScreen.chadWin = true;
                    SceneManager.LoadScene(8);
                }
                else if(choice2)
                {
                    imageGO.sprite = chadBox;
                    tmpText.text = "Am I not your type? Am I not good enough for you? What can I do to make you love me?";
                    dialogueProgress++;
                }
                break;
            case 9:
                imageGO.sprite = narratorBox;
                tmpText.text = "*You walk away cool dragon style off to meet all your lovely dragons*";
                choice1Box.SetActive(true);
                choice1Text.text = "Continue";
                break;
            case 10:
                FeedbackScreen.chadWin = false;
                SceneManager.LoadScene(8);
                break;
        }
    }
}
