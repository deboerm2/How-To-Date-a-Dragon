using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DateDialouge : MonoBehaviour
{
    private TextMeshProUGUI TMPcomponent;
    private int dialougeProgress = 1;
    private EventCard eventCardScript;
    private DateEmotions dateEmotions;

    private string[] allEvents = new string[] {"Event1","Event2","Event3","Event4","Event5","Event6" };
    private string[] chosenEvents = new string[3];
    private string tempString;
    private int rndmText;

    public static int foodEventResult;
    public static int firstEventResult;
    public static int secondEventResult;
    public static int thirdEventResult;

    private GameObject curOccupier;

    public GameObject endDateButton;
    private Image goImage;
    private Sprite dateTextBox;
    public Sprite narTextBox;
    public GameObject itemCards;
    public GameObject knowledgeCards;
    [Header("Dynamic Scene Objects")]
    public Transform food3d;
    public Transform cold3d;
    public Transform wine3d;
    public Transform utensil3d;
    public Transform gift3d;
    [Header("Food Selection")]
    public GameObject wineFood;
    public GameObject sheepsteakFood;
    public GameObject berryFood;
    public GameObject fishFood;
    private bool wine;
    private bool sheepsteak;
    private bool berry;
    private bool fish;

    // Start is called before the first frame update
    void Start()
    {
        TMPcomponent = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        eventCardScript = GameObject.FindObjectOfType<EventCard>();
        dateEmotions = GameObject.FindObjectOfType<DateEmotions>();
        endDateButton.SetActive(false);
        goImage = gameObject.GetComponent<Image>();
        dateTextBox = goImage.sprite;

        knowledgeCards.SetActive(false);
        wineFood.SetActive(false);
        sheepsteakFood.SetActive(false);
        berryFood.SetActive(false);
        fishFood.SetActive(false);

        eventCardScript.gameObject.SetActive(false);

        //randomize events
        for (int i = 0; i < 2; i++)
        {
            int rnd = Random.Range(0, 4);
            tempString = allEvents[rnd];
            allEvents[rnd] = allEvents[i];
            allEvents[i] = tempString; 

        }
        for(int i = 0; i < 2; i++)
        {
            chosenEvents[i] = allEvents[i];
        }
        chosenEvents[2] = allEvents[Random.Range(4, 6)];
        //randomize first text
        rndmText = Random.Range(0, 4);
    }

    void Update()
    {
        if(curOccupier != null)
        {
            goImage.sprite = dateTextBox;
            TMPcomponent.text = curOccupier.GetComponent<DateCardEffects>().responseText;
            Invoke("DestroyOccupier", 0.1f);
        }
    }

    public void CuteDateDialogue()
    {
        switch (dialougeProgress)
        {
            case 1:
                switch (rndmText)
                {
                    case 0:
                        TMPcomponent.text = "I can’t wait to dive into this food. It looks sooo good! Oh boy I want to sink my teeth in now!";
                        break;
                    case 1:
                        TMPcomponent.text = "This wine is lovely. It almost reminds me of going to my family vineyard.";
                        break;
                    case 2:
                        TMPcomponent.text = "It is so nice to finally meet other Dragons after Clawvid-19. I can finally stretch my wings and meet nice Dragons like yourself!";
                        break;
                    case 3:
                        TMPcomponent.text = "I think you look great. I myself spent a couple hours getting my coat shining and ready for our date.";
                        break;
                    default:
                        TMPcomponent.text = "I can’t wait to dive into this food. It looks sooo good! Oh boy I want to sink my teeth in now!";
                        break;
                }
                
                dialougeProgress++;
                break;
            case 2:
                StartCoroutine("EventFood");
                break;
            case 3:
                goImage.sprite = dateTextBox;
                wineFood.SetActive(false);
                sheepsteakFood.SetActive(false);
                berryFood.SetActive(false);
                fishFood.SetActive(false);
                if (wine)
                {
                    TMPcomponent.text = "Ahhhh I love wine, this is sooooo good! Not as good as my homemade wine though. You should definitely try some sometime.";
                    DateDialouge.foodEventResult = 2;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Excited();
                    food3d.Find("WineAll").gameObject.SetActive(true);
                }
                else if (sheepsteak)
                { 
                    TMPcomponent.text = "… You know I don’t eat meat right? Geez, that is kinda insensitive…";
                    DateDialouge.foodEventResult = 0;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Unhappy();
                    food3d.Find("LambSteakAll").gameObject.SetActive(true);
                }
                else if (berry)
                {
                    TMPcomponent.text = "Oh my I love berries. Wait, do we have the same diet? Wow, we are so similar!";
                    DateDialouge.foodEventResult = 2;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Excited();
                    food3d.Find("BerriesAll").gameObject.SetActive(true);
                }
                else if(fish)
                {
                    TMPcomponent.text = "Oh fish, you know not my favorite but I am always open to giving new things a try.";
                    DateDialouge.foodEventResult = 1;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Neutral();
                    food3d.Find("FishAll").gameObject.SetActive(true);
                }
                dialougeProgress++;
                break;
            case 4:
                StartCoroutine(chosenEvents[0]);
                dialougeProgress++;
                break;
            case 5:
                //first Event results
                if (eventCardScript.occupier != null)
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[0], 0.0f);
                    DateDialouge.firstEventResult = DateCardEffects.effectAmount;
                }
                else
                {
                    TMPcomponent.text = "Akward Silence";
                    eventCardScript.gameObject.SetActive(false);
                    dateEmotions.Unhappy();
                    DateDialouge.firstEventResult += 0;
                }
                dialougeProgress++;
                break;
            case 6:
                StartCoroutine(chosenEvents[1]);
                dialougeProgress++;
                break;
            case 7:
                if (eventCardScript.occupier != null)
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[1], 0.0f);
                    DateDialouge.secondEventResult = DateCardEffects.effectAmount;
                }
                else
                {
                    TMPcomponent.text = "Akward Silence";
                    eventCardScript.gameObject.SetActive(false);
                    dateEmotions.Unhappy();
                    DateDialouge.secondEventResult += 0;
                }
                dialougeProgress++;
                break;
            case 8:
                StartCoroutine(chosenEvents[2]);
                itemCards.SetActive(false);
                knowledgeCards.SetActive(true);
                dialougeProgress++;
                break;
            case 9:
                if (eventCardScript.occupier != null && eventCardScript.occupier.name.Contains("Cute"))
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[2], 0.0f);
                    curOccupier.GetComponent<DateCardEffects>().responseText = "Wait you know how to properly braid dragon fur and bedazzle it." +
                                                                        "We should bedazzle my fur sometime together!";

                    goImage.sprite = dateTextBox;
                    dateEmotions.Excited();
                    DateDialouge.thirdEventResult = DateCardEffects.effectAmount;
                }
                else if(eventCardScript.occupier == null)
                {
                    TMPcomponent.text = "Akward Silence";
                    dateEmotions.Unhappy();
                    eventCardScript.gameObject.SetActive(false);
                    DateDialouge.thirdEventResult += 0;
                }
                else
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[2], 0.0f);
                    curOccupier.GetComponent<DateCardEffects>().responseText = "Oh… I mean… ugh… that is quite controversial… let's just act like you didn’t say that.";
                    goImage.sprite = dateTextBox;
                    dateEmotions.Unhappy();
                    DateDialouge.thirdEventResult = DateCardEffects.effectAmount;
                }
                dialougeProgress++;
                break;
            default:
                goImage.sprite = dateTextBox;
                if (GoToDateButton.datePoints >= 13)
                    TMPcomponent.text = "Wow this was amazing not only do we both look soooo cute but we have a lot in common. I’d love to go on another date with you!";
                else
                {
                    TMPcomponent.text = "This went… I mean the date definitely went… maybe we should see other Dragons.";
                    goImage.sprite = dateTextBox;
                }
                endDateButton.SetActive(true);
                break;
        }
    }
    public void ScaryDateDialogue()
    {
        switch (dialougeProgress)
        {
            case 1:
                switch (rndmText)
                {
                    case 0:
                        TMPcomponent.text = "My parents wouldn’t let me go out much so I am still blown away by this place. It’s also nice to have company.";
                        break;
                    case 1:
                        TMPcomponent.text = "I haven’t talked to anyone on the island yet but it's a pleasure to get to talk with you first!";
                        break;
                    case 2:
                        TMPcomponent.text = "It’s nice to get to know you rather than worry about what people think about me.";
                        break;
                    case 3:
                        TMPcomponent.text = "I usually only go out on nights but it's fun to see everyone out before the sunsets. I also get to admire you too.";
                        break;
                    default:
                        TMPcomponent.text = "My parents wouldn’t let me go out much so I am still blown away by this place. It’s also nice to have company.";
                        break;
                }
                dialougeProgress++;
                break;
            case 2:
                StartCoroutine("EventFood");
                break;
            case 3:
                goImage.sprite = dateTextBox;
                wineFood.SetActive(false);
                sheepsteakFood.SetActive(false);
                berryFood.SetActive(false);
                fishFood.SetActive(false);
                if (wine)
                {
                    TMPcomponent.text = "Oooo I am a sucker for wine. It reminds me of the blood of cows I would drink on Friday nights. Too much? Sorry!";
                    DateDialouge.foodEventResult = 2;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Excited();
                    food3d.Find("WineAll").gameObject.SetActive(true);
                }
                else if (sheepsteak)
                {
                    TMPcomponent.text = "Wow, I love sheepsteak. You have such a similar taste to me! Why don’t we dig in!";
                    DateDialouge.foodEventResult = 2;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Excited();
                    food3d.Find("LambSteakAll").gameObject.SetActive(true);
                }
                else if (berry)
                {
                    TMPcomponent.text = "As much as berries aren’t my first pick I do really like a good juicy berry. But let's make sure to order multiple times!";
                    DateDialouge.foodEventResult = 1;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Neutral();
                    food3d.Find("BerriesAll").gameObject.SetActive(true);
                }
                else if (fish)
                {
                    TMPcomponent.text = "Actually I hate to be a bother but I am allergic to fish. I usually avoid it but please enjoy yours. I am happy to just watch it, I guess.";
                    DateDialouge.foodEventResult = 0;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Unhappy();
                    food3d.Find("FishAll").gameObject.SetActive(true);
                }
                dialougeProgress++;
                break;
            case 4:
                StartCoroutine(chosenEvents[0]);
                dialougeProgress++;
                break;
            case 5:
                //first Event results
                if (eventCardScript.occupier != null)
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[0], 0.0f);
                    DateDialouge.firstEventResult = DateCardEffects.effectAmount;
                }
                else
                {
                    TMPcomponent.text = "Akward Silence";
                    eventCardScript.gameObject.SetActive(false);
                    dateEmotions.Unhappy();
                    DateDialouge.firstEventResult += 0;
                }
                dialougeProgress++;
                break;
            case 6:
                StartCoroutine(chosenEvents[1]);
                dialougeProgress++;
                break;
            case 7:
                if (eventCardScript.occupier != null)
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[1], 0.0f);
                    DateDialouge.secondEventResult = DateCardEffects.effectAmount;
                }
                else
                {
                    TMPcomponent.text = "Akward Silence";
                    eventCardScript.gameObject.SetActive(false);
                    dateEmotions.Unhappy();
                    DateDialouge.secondEventResult += 0;
                }
                dialougeProgress++;
                break;
            case 8:
                StartCoroutine(chosenEvents[2]);
                itemCards.SetActive(false);
                knowledgeCards.SetActive(true);
                dialougeProgress++;
                break;
            case 9:
                if (eventCardScript.occupier != null && eventCardScript.occupier.name.Contains("Scary"))
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[2], 0.0f);
                    curOccupier.GetComponent<DateCardEffects>().responseText = "I didn’t know that other dragons enjoyed flying at night. " +
                        "Some say that it's too dark but if you fly over the perfect area the moon serves as a perfect light. I would love to do a night fly with you!";

                    goImage.sprite = dateTextBox;
                    dateEmotions.Excited();
                    DateDialouge.thirdEventResult = DateCardEffects.effectAmount;
                }
                else if (eventCardScript.occupier == null)
                {
                    TMPcomponent.text = "Akward Silence";
                    dateEmotions.Unhappy();
                    eventCardScript.gameObject.SetActive(false);
                    DateDialouge.thirdEventResult += 0;
                }
                else
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[2], 0.0f);
                    curOccupier.GetComponent<DateCardEffects>().responseText = "Sorry I don’t really understand what you mean. " +
                        "Some dragons would say that I live under a rock so I can’t relate. Sorry.";
                    goImage.sprite = dateTextBox;
                    dateEmotions.Unhappy();
                    DateDialouge.thirdEventResult = DateCardEffects.effectAmount;
                }
                dialougeProgress++;
                break;
            default:
                goImage.sprite = dateTextBox;
                if (GoToDateButton.datePoints >= 13)
                    TMPcomponent.text = "I have never connected with anyone so well. Well I haven’t really connected with anyone but I would love to go on another date with you if given the chance.";
                else
                {
                    TMPcomponent.text = "I may not be wanted by a lot of dragons… okay maybe all but at least I can still keep up my standards.";
                    goImage.sprite = dateTextBox;
                }
                endDateButton.SetActive(true);
                break;
        }
    }
    public void ToughDateDialogue()
    {
        switch (dialougeProgress)
        {
            case 1:
                switch (rndmText)
                {
                    case 0:
                        TMPcomponent.text = "I can’t believe I forgot my protein powder. I usually have one jug per meal. Thank goodness I get to look at such a tough snack like yourself.";
                        break;
                    case 1:
                        TMPcomponent.text = "You know sometimes I feel like other Dragons don’t understand how to get ripped like me. I love Dragons with dedication like yourself.";
                        break;
                    case 2:
                        TMPcomponent.text = "This place may be small but I think you picked the perfect place to eat at!";
                        break;
                    case 3:
                        TMPcomponent.text = "These candles remind me of my old night candles my mom used to turn on in our cave when I was younger. Ahhh good times.";
                        break;
                    default:
                        TMPcomponent.text = "I can’t believe I forgot my protein powder. I usually have one jug per meal. Thank goodness I get to look at such a tough snack like yourself.";
                        break;
                }
                dialougeProgress++;
                break;
            case 2:
                StartCoroutine("EventFood");
                break;
            case 3:
                goImage.sprite = dateTextBox;
                wineFood.SetActive(false);
                sheepsteakFood.SetActive(false);
                berryFood.SetActive(false);
                fishFood.SetActive(false);
                if (wine)
                {
                    TMPcomponent.text = "I heard alcohol is bad for working out but hey a little wine never hurt anyone. CHEE… *coughs* cheers!";
                    DateDialouge.foodEventResult = 1;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Neutral();
                    food3d.Find("WineAll").gameObject.SetActive(true);
                }
                else if (sheepsteak)
                {
                    TMPcomponent.text = "I LOVE PROTEIN. YOU READ MY MIND YOU CUTIE!";
                    DateDialouge.foodEventResult = 2;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Excited();
                    food3d.Find("LambSteakAll").gameObject.SetActive(true);
                }
                else if (berry)
                {
                    TMPcomponent.text = "I hate fruit. Please get that juice filled mush filled ball away from me. Healthy or not… It's like a texture thing.";
                    DateDialouge.foodEventResult = 0;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Unhappy();
                    food3d.Find("BerriesAll").gameObject.SetActive(true);
                }
                else if (fish)
                {
                    TMPcomponent.text = "You know, fish is my second go to meal. After a good pump sesh nothing like a little salmon. Thanks!";
                    DateDialouge.foodEventResult = 2;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Excited();
                    food3d.Find("FishAll").gameObject.SetActive(true);
                }
                dialougeProgress++;
                break;
            case 4:
                StartCoroutine(chosenEvents[0]);
                dialougeProgress++;
                break;
            case 5:
                //first Event results
                if (eventCardScript.occupier != null)
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[0], 0.0f);
                    DateDialouge.firstEventResult = DateCardEffects.effectAmount;
                }
                else
                {
                    TMPcomponent.text = "Akward Silence";
                    eventCardScript.gameObject.SetActive(false);
                    dateEmotions.Unhappy();
                    DateDialouge.firstEventResult += 0;
                }
                dialougeProgress++;
                break;
            case 6:
                StartCoroutine(chosenEvents[1]);
                dialougeProgress++;
                break;
            case 7:
                if (eventCardScript.occupier != null)
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[1], 0.0f);
                    DateDialouge.secondEventResult = DateCardEffects.effectAmount;
                }
                else
                {
                    TMPcomponent.text = "Akward Silence";
                    eventCardScript.gameObject.SetActive(false);
                    dateEmotions.Unhappy();
                    DateDialouge.secondEventResult += 0;
                }
                dialougeProgress++;
                break;
            case 8:
                StartCoroutine(chosenEvents[2]);
                itemCards.SetActive(false);
                knowledgeCards.SetActive(true);
                dialougeProgress++;
                break;
            case 9:
                if (eventCardScript.occupier != null && eventCardScript.occupier.name.Contains("Tough"))
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[2], 0.0f);
                    curOccupier.GetComponent<DateCardEffects>().responseText = "No way. You use the Dragon enhancer grow bigger and louder protein powder too??? I love that brand." +
                        " We should share other protein recommendations. ";

                    goImage.sprite = dateTextBox;
                    dateEmotions.Excited();
                    DateDialouge.thirdEventResult = DateCardEffects.effectAmount;
                }
                else if (eventCardScript.occupier == null)
                {
                    TMPcomponent.text = "Akward Silence";
                    dateEmotions.Unhappy();
                    eventCardScript.gameObject.SetActive(false);
                    DateDialouge.thirdEventResult += 0;
                }
                else
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[2], 0.0f);
                    curOccupier.GetComponent<DateCardEffects>().responseText = "Sorry but I only talk about Dragon muscle building podcasts but hey I can attempt to pay " +
                        "attention to whatever you just said… Can you repeat it again?";
                    goImage.sprite = dateTextBox;
                    dateEmotions.Unhappy();
                    DateDialouge.thirdEventResult = DateCardEffects.effectAmount;
                }
                dialougeProgress++;
                break;
            default:
                goImage.sprite = dateTextBox;
                if (GoToDateButton.datePoints >= 13)
                    TMPcomponent.text = "This date went SOOOO WELL I THINK WE ARE *coughs* sorry I think we are a great match. I’d love to go on another date with you!.";
                else
                {
                    TMPcomponent.text = "How can I say this… but I think your muscles and my muscles are on two different levels and I am gonna need to not see you again.";
                    goImage.sprite = dateTextBox;
                }
                endDateButton.SetActive(true);
                break;
        }
    }
    public void ElegantDateDialogue()
    {
        switch (dialougeProgress)
        {
            case 1:
                switch (rndmText)
                {
                    case 0:
                        TMPcomponent.text = "Do you think they catch their fish fresh or just have freezer fish… actually an establishment like this they must catch… right?";
                        break;
                    case 1:
                        TMPcomponent.text = "Crazy to think that people grew up in caves and dungeons. I grew up as a castle Dragon. But it's nice to talk with someone like you.";
                        break;
                    case 2:
                        TMPcomponent.text = "I heard this place has great ratings for their food. Let's hope they don’t disappoint! I would hate for the food to ruin this date.";
                        break;
                    case 3:
                        TMPcomponent.text = "You know you look like just the gentledragons I follow on instawing. Tell me do you post or are you just this handsome and keeping it to yourself?";
                        break;
                    default:
                        TMPcomponent.text = "Do you think they catch their fish fresh or just have freezer fish… actually an establishment like this they must catch… right?";
                        break;
                }
                dialougeProgress++;
                break;
            case 2:
                StartCoroutine("EventFood");
                break;
            case 3:
                goImage.sprite = dateTextBox;
                wineFood.SetActive(false);
                sheepsteakFood.SetActive(false);
                berryFood.SetActive(false);
                fishFood.SetActive(false);
                if (wine)
                {
                    TMPcomponent.text = "Are you trying to get me drunk? Everyone knows an elegant Dragon like myself would never stoop so low. Just have your glass and I’ll starve.";
                    DateDialouge.foodEventResult = 0;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Unhappy();
                    food3d.Find("WineAll").gameObject.SetActive(true);
                }
                else if (sheepsteak)
                {
                    TMPcomponent.text = "As much as meat is not my favorite, I do love myself a little barbeque every once in a while. Why not now. ";
                    DateDialouge.foodEventResult = 1;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Neutral();
                    food3d.Find("LambSteakAll").gameObject.SetActive(true);
                }
                else if (berry)
                {
                    TMPcomponent.text = "Fun fact berries have been known to create shiny scales! I’d rather be dead than not have shiny scales. You’re so thoughtful.";
                    DateDialouge.foodEventResult = 2;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Excited();
                    food3d.Find("BerriesAll").gameObject.SetActive(true);
                }
                else if (fish)
                {
                    TMPcomponent.text = "Oooo my favorite. Usually my father imports them from another kingdom but I will settle for these. Thank you.";
                    DateDialouge.foodEventResult = 2;
                    GoToDateButton.eventPoints += DateDialouge.foodEventResult;
                    GoToDateButton.datePoints += DateDialouge.foodEventResult;
                    dateEmotions.Excited();
                    food3d.Find("FishAll").gameObject.SetActive(true);
                }
                dialougeProgress++;
                break;
            case 4:
                StartCoroutine(chosenEvents[0]);
                dialougeProgress++;
                break;
            case 5:
                //first Event results
                if (eventCardScript.occupier != null)
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[0], 0.0f);
                    DateDialouge.firstEventResult = DateCardEffects.effectAmount;
                }
                else
                {
                    TMPcomponent.text = "Akward Silence";
                    eventCardScript.gameObject.SetActive(false);
                    dateEmotions.Unhappy();
                    DateDialouge.firstEventResult += 0;
                }
                dialougeProgress++;
                break;
            case 6:
                StartCoroutine(chosenEvents[1]);
                dialougeProgress++;
                break;
            case 7:
                if (eventCardScript.occupier != null)
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[1], 0.0f);
                    DateDialouge.secondEventResult = DateCardEffects.effectAmount;
                }
                else
                {
                    TMPcomponent.text = "Akward Silence";
                    eventCardScript.gameObject.SetActive(false);
                    dateEmotions.Unhappy();
                    DateDialouge.secondEventResult += 0;
                }
                dialougeProgress++;
                break;
            case 8:
                StartCoroutine(chosenEvents[2]);
                itemCards.SetActive(false);
                knowledgeCards.SetActive(true);
                dialougeProgress++;
                break;
            case 9:
                if (eventCardScript.occupier != null && eventCardScript.occupier.name.Contains("Elegant"))
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[2], 0.0f);
                    curOccupier.GetComponent<DateCardEffects>().responseText = "You’re telling me that you went to the 3 kingdoms of the D clan. That is the most popular place to visit." +
                        " You must know someone. Please take me.";

                    goImage.sprite = dateTextBox;
                    dateEmotions.Excited();
                    DateDialouge.thirdEventResult = DateCardEffects.effectAmount;
                }
                else if (eventCardScript.occupier == null)
                {
                    TMPcomponent.text = "Akward Silence";
                    dateEmotions.Unhappy();
                    eventCardScript.gameObject.SetActive(false);
                    DateDialouge.thirdEventResult += 0;
                }
                else
                {
                    curOccupier = eventCardScript.occupier;
                    curOccupier.GetComponent<DateCardEffects>().Invoke(chosenEvents[2], 0.0f);
                    curOccupier.GetComponent<DateCardEffects>().responseText = "Can we talk about something actually relevant or do you want to keep wasting my time?";
                    goImage.sprite = dateTextBox;
                    dateEmotions.Unhappy();
                    DateDialouge.thirdEventResult = DateCardEffects.effectAmount;
                }
                dialougeProgress++;
                break;
            default:
                goImage.sprite = dateTextBox;
                if (GoToDateButton.datePoints >= 13)
                    TMPcomponent.text = " It seems that I can forgive your actions and allow you to take me out on another date. You will take me on another one!";
                 else
                {
                    TMPcomponent.text = " Bad manners outside and inside the date. How about you just stay away from me. Like extremely far away. Okay thanks!";
                    goImage.sprite = dateTextBox;
                }
                endDateButton.SetActive(true);
                break;
        }
    }

    void DestroyOccupier()
    {
        Destroy(curOccupier);
        eventCardScript.gameObject.SetActive(false);
    }

    public void WineSelection()
    {
        wine = true;
        dialougeProgress++;
    }
    public void SheepSelection()
    {
        sheepsteak = true;
        dialougeProgress++;
    }
    public void BerrySelection()
    {
        berry = true;
        dialougeProgress++;
    }
    public void FishSelection()
    {
        fish = true;
        dialougeProgress++;
    }

    //the Events themselves not the results
    //probably announced by narrator
    IEnumerator Event1()
    {
        goImage.sprite = narTextBox;
        TMPcomponent.text = "She feels cold";
        eventCardScript.gameObject.SetActive(true);
        return null;
    }
    IEnumerator Event2()
    {
        goImage.sprite = narTextBox;
        TMPcomponent.text = "She spilled her wine";
        eventCardScript.gameObject.SetActive(true);
        return null;
    }
    IEnumerator Event3()
    {
        goImage.sprite = narTextBox;
        TMPcomponent.text = "She dropped her fork";
        eventCardScript.gameObject.SetActive(true);
        return null;
    }
    IEnumerator Event4()
    {
        goImage.sprite = narTextBox;
        TMPcomponent.text = "She expects something from you";
        eventCardScript.gameObject.SetActive(true);
        return null;
    }
    IEnumerator Event5()
    {//if events have unique prompts use the switch statement in GoToDateButton.GoToDate() to differentiate
        goImage.sprite = narTextBox;
        TMPcomponent.text = "She asks for your thoughts on her hobbies";
        eventCardScript.gameObject.SetActive(true);
        return null;
    }
    IEnumerator Event6()
    {//if events have unique prompts use the switch statement in GoToDateButton.GoToDate() to differentiate
        goImage.sprite = narTextBox;
        TMPcomponent.text = "She asks for your thoughts on her hobbies";
        eventCardScript.gameObject.SetActive(true);
        return null;
    }
    IEnumerator EventFood()
    {
        goImage.sprite = narTextBox;
        TMPcomponent.text = "Order the food";
        wineFood.SetActive(true);
        sheepsteakFood.SetActive(true);
        berryFood.SetActive(true);
        fishFood.SetActive(true);
        return null;
    }
}
