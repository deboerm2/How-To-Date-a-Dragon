using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroDialogue : MonoBehaviour
{
    private TextMeshProUGUI TMPcomponent;
    private int dialougeProgress = 1;
    private Image imageGO;

    public Sprite narratorBox;
    public Sprite chadBox;
    public GameObject chadDragon;
    public GameObject cuteDragon;
    public Sprite cuteBox;
    public GameObject choice1Box;
    public GameObject choice2Box;
    private TextMeshProUGUI choice1Text;
    private TextMeshProUGUI choice2Text;
    private bool choice1 = false;
    private bool choice2 = false;

    public AudioSource myAudioSource;
    public AudioClip myAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        TMPcomponent = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        imageGO = gameObject.GetComponent<Image>();
        choice1Text = choice1Box.GetComponentInChildren<TextMeshProUGUI>();
        choice2Text = choice2Box.GetComponentInChildren<TextMeshProUGUI>();
        choice1Box.SetActive(false);
        choice2Box.SetActive(false);
        chadDragon.SetActive(false);
        cuteDragon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "IntroScene")
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayback>().PlayCards();
        }
    }

    public void IntroDialogueBox()
    {
        switch (dialougeProgress)
        {
            
               
            case 1:
                imageGO.sprite = chadBox;
                chadDragon.SetActive(true);
                TMPcomponent.text = "Excuse me where can I find all the Dragon babes?";
                dialougeProgress++;
                break;
            case 2:
                imageGO.sprite = narratorBox;
                TMPcomponent.text = "This is Chad. He will be a fellow Dragon competing with you to win the hearts of the dashing Dragons on the island.";
                dialougeProgress++;
                break;
            case 3:
                imageGO.sprite = chadBox;
                TMPcomponent.text = "Ewww who is this dull and stale wannabe Dragon?";
                choice1Box.SetActive(true);
                choice2Box.SetActive(true);
                choice1Text.text = "Introduce yourself";
                choice2Text.text = "Don't say anything";
                break;
            case 4:
                myAudioSource.PlayOneShot(myAudioClip);
                TMPcomponent.text = " Oh wow you're my competition. How amusing. They made this game too easy. I will collect all the Dragon Babes," +
                                     " you common looking reptile. Don’t think I will make this game easy for you!";
                choice1Box.SetActive(false);
                choice2Box.SetActive(false);
                dialougeProgress++;
                break;
            case 5:
                imageGO.sprite = narratorBox;
                chadDragon.SetActive(false);
                TMPcomponent.text = "*You turn away confused but weirdly you feel a slight flutter in your heart* \n* BUMP *";
                dialougeProgress++;
                break;
            case 6:
                imageGO.sprite = cuteBox;
                cuteDragon.SetActive(true);
                TMPcomponent.text = "Oh excuse me. I am sorry I didn’t mean to bump into you. My name is Cora !" +
                    " You must be one of the male contestants. It's nice to meet you.";
                choice1Box.SetActive(true);
                choice2Box.SetActive(true);
                choice1Text.text = "Introduce yourself";
                choice2Text.text = "Stare into her eyes not saying a word";
                break;
            case 7:
                myAudioSource.PlayOneShot(myAudioClip);
                TMPcomponent.text = "Hey since you're new around here why don’t I show you around later on. We should talk more at dinner if you would like!";
                choice1Text.text = "Accept her offer";
                choice2Text.text = "Decline";
                break;
            case 8:
                if (choice2)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    myAudioSource.PlayOneShot(myAudioClip);
                    TMPcomponent.text = " I am looking forward to talking with you more. Hopefully I can introduce you to everyone else!";
                    choice1Box.SetActive(false);
                    choice2Box.SetActive(false);
                    dialougeProgress++;
                }
                break;
            case 9:
                imageGO.sprite = narratorBox;
                cuteDragon.SetActive(false);
                TMPcomponent.text = "*You feel your excitement grow for the date.*";
                dialougeProgress++;
                break;
            case 10:
                imageGO.sprite = narratorBox;
                TMPcomponent.text = " Excuse me but you can’t go on the date looking like the bare Dragon you are. " +
                    "If you want to make it out of the Dragon friend zone you need to step up your game and prepare.";
                choice1Box.SetActive(true);
                choice1Text.text = "Prepare for Date!";
                break;
            default:
                SceneManager.LoadScene(5);
                break;
        }
    }

    public void ProgressDialogueButton1()
    {
        choice1 = true;
        choice2 = false;
        dialougeProgress++;
        IntroDialogueBox();
    }

    public void ProgressDialogueButton2()
    {
        choice1 = false;
        choice2 = true;
        dialougeProgress++;
        IntroDialogueBox();
    }
}
