using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateCardEffects : Selectable
{
    private Vector3 endPosition;
    private Vector3 startPosition;
    private Vector3 revCurrentPosition;
    private float lerpDuration = 0.3f;
    private float elapsedTime;
    private float reverseTime;
    private float percentComplete;
    private float reverseComplete;
    private RectTransform rectTransform;

    private EventCard eventCard;
    private DateDialouge dateDialougeScript;
    private DateEmotions dateEmotions;
    public int event1Effect;
    public int event2Effect;
    public int event3Effect;
    public int event4Effect;
    public int event5Effect;
    public int event6Effect;
    public string responseText = "Default text";

    public static int effectAmount;


    [HideInInspector]
    public bool isPressed = false;
    [HideInInspector]
    public bool inTrigger = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        startPosition = rectTransform.localPosition;
        endPosition = new Vector3(rectTransform.localPosition.x, 0, 0);

        eventCard = GameObject.FindObjectOfType<EventCard>();
        dateDialougeScript = GameObject.FindObjectOfType<DateDialouge>();
        dateEmotions = GameObject.FindObjectOfType<DateEmotions>();
    }

    // Update is called once per frame
    void Update()
    {
        isPressed = IsPressed();
        if (inTrigger == false)
        {
            if (IsHighlighted() == true)
            {

                elapsedTime += Time.deltaTime;

                rectTransform.localPosition = Vector3.Lerp(startPosition, endPosition, percentComplete);

                percentComplete += elapsedTime / lerpDuration;

                reverseComplete = 0;
                reverseTime = 0;
            }
            else if (IsHighlighted() == false)
            {

                reverseTime += Time.deltaTime;

                rectTransform.localPosition = Vector3.Lerp(endPosition, startPosition, reverseComplete);

                reverseComplete += reverseTime / lerpDuration;

                percentComplete = 0;
                elapsedTime = 0;
            }
        }

        if(IsPressed() == true)
        {
            rectTransform.position = Input.mousePosition;
        }

        if(eventCard != null && gameObject != eventCard.occupier && eventCard.occupier != null)
        {
            inTrigger = false;
        }

    }
    //cold
    public void Event1()
    {
        GoToDateButton.datePoints += event1Effect;
        GoToDateButton.eventPoints += event1Effect;
        DateCardEffects.effectAmount = event1Effect;
        switch (GoToDateButton.dateOrder[GoToDateButton.currentDate - 1])
        {
            //cute
            case 1:
                switch (event1Effect)
                {
                    case 1:
                        responseText = "Oh. I mean I am definitely warmer… I guess…";
                        dateEmotions.Neutral();
                        dateDialougeScript.cold3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "Wow this is so cozy. My neck has certainly become more warm. Thank you so much!";
                        dateEmotions.Excited();
                        dateDialougeScript.cold3d.Find("Scarf").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "Wow this is perfect. I feel so warm right now. You’re so thoughtful!";
                        dateEmotions.Flushed();
                        dateDialougeScript.cold3d.Find("Jackets").gameObject.SetActive(true);
                        break;
                    default:
                        responseText = "Alright I guess I can deal with the cold…by myself…";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
            //scary
            case 2:
                switch (event1Effect)
                {
                    case 1:
                        responseText = "What an interesting method to keep me warm. I like the gesture. How can I say no to such warm air flowing my way!";
                        dateEmotions.Neutral();
                        dateDialougeScript.cold3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "Oooo this is so cute. I’d love to borrow this. Anything is appreciated!";
                        dateEmotions.Excited();
                        dateDialougeScript.cold3d.Find("Scarf").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "I have never been offered a jacket before. I usually just am on my own. Glad to know you care for my well being.";
                        dateEmotions.Flushed();
                        dateDialougeScript.cold3d.Find("Jackets").gameObject.SetActive(true);
                        break;
                    default:
                        responseText = "*She shivers and smiles at you* Is it chilly or is it just me? It must be just me.";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
            //tough
            case 3:
                switch (event1Effect)
                {
                    case 1:
                        responseText = "I HATE TO SPEAK OVER THE HAIRDRYER BUT I WANT TO LET YOU KNOW I AM MORE WARM…KINDA..OKAY YOU CAN STOP NOW.";
                        dateEmotions.Neutral();
                        dateDialougeScript.cold3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "Hehe this feels like a necklace but I enjoy the thought. You’re super sweet you know.";
                        dateEmotions.Excited();
                        dateDialougeScript.cold3d.Find("Scarf").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "This may be a little small but I instantly feel more cozy. Thanks for the jacket cutie!";
                        dateEmotions.Flushed();
                        dateDialougeScript.cold3d.Find("Jackets").gameObject.SetActive(true);
                        break;
                    default:
                        responseText = "*She continues to slightly shiver but she starts doing push ups and gets her dragon blood flowing* " +
                            "Sorry, I kinda had to resort to my own method.";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
            //elegant
            case 4:
                switch (event1Effect)
                {
                    case 1:
                        responseText = "I didn’t know those could be used for being more warm overall. Thank you I guess.";
                        dateEmotions.Neutral();
                        dateDialougeScript.cold3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "What an interesting pattern. Since it is such a kind gesture I shall wear it. *She smiles* Thanks.";
                        dateEmotions.Excited();
                        dateDialougeScript.cold3d.Find("Scarf").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "This jacket fits perfectly. I definitely feel more warm even if this jacket isn’t pure sheepskin.";
                        dateEmotions.Flushed();
                        dateDialougeScript.cold3d.Find("Jackets").gameObject.SetActive(true);
                        break;
                    default:
                        responseText = "*She glares at you and scoffs* So you have nothing to give me. Alright then.";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
        }
    }
    //wine
    public void Event2()
    {
        GoToDateButton.datePoints += event2Effect;
        GoToDateButton.eventPoints += event2Effect;
        DateCardEffects.effectAmount = event2Effect;
        switch (GoToDateButton.dateOrder[GoToDateButton.currentDate - 1])
        {
            //cute
            case 1:
                switch (event2Effect)
                {
                    case 1:
                        responseText = "I think you just pushed all the wine onto the floor with air but I mean solutions are solutions.";
                        dateEmotions.Neutral();
                        dateDialougeScript.wine3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "I didn’t know this would absorb so well. Smart thinking!";
                        dateEmotions.Excited();
                        dateDialougeScript.wine3d.Find("Scarf").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "This is great. You’re so kind and now it's all cleaned up. What a gentledragon.";
                        dateEmotions.Flushed();
                        dateDialougeScript.wine3d.Find("Napkin").gameObject.SetActive(false);
                        break;
                    default:
                        responseText = "Oh boy I can’t wait to stare at this wine puddle for the rest of our date. Oh look, it's starting to drip on me…";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
                //scary
            case 2:
                switch (event2Effect)
                {
                    case 1:
                        responseText = "*You pull out the hair dryer and spray all the wine all over the place* " +
                            "I knew there would be a mess. But don’t worry it's not a big issue, we can clean it up in a bit.";
                        dateEmotions.Neutral();
                        dateDialougeScript.wine3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "Are you sure you want to get your scarf dirty? This must be too much for you but I am extremely grateful!";
                        dateEmotions.Excited();
                        dateDialougeScript.wine3d.Find("Scarf").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "I must have forgotten my napkin. Thank you for letting me use yours.";
                        dateEmotions.Flushed();
                        dateDialougeScript.wine3d.Find("Napkin").gameObject.SetActive(false);
                        break;
                    default:
                        responseText = "*You both look at the puddle of wine and look back at each other.* Ahhh… nevermind.";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
            //tough
            case 3:
                switch (event2Effect)
                {
                    case 1:
                        responseText = "How resourceful using the air to clean up spilled wine. I knew you had big muscles and a big brain.";
                        dateEmotions.Neutral();
                        dateDialougeScript.wine3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "I knew that tiny cloth thingy would come in handy! Oh that's not a cloth… its a scarf… Hehe, that's embarrassing.";
                        dateEmotions.Excited();
                        dateDialougeScript.wine3d.Find("Scarf").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "Why thank you cutie. I was worried it would get everywhere. Why don’t we order more wine? WAITERRRRRR";
                        dateEmotions.Flushed();
                        dateDialougeScript.wine3d.Find("Napkin").gameObject.SetActive(false);
                        break;
                    default:
                        responseText = "I hate to talk about bad things on a date but this wine is all over my claws. Ewww its sticky";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
            //elegant
            case 4:
                switch (event2Effect)
                {
                    case 1:
                        responseText = "*You reveal the hairdryer and she begins to have a panicked look* " +
                            "You aren’t going to actually use that? At least point it away from me!";
                        dateEmotions.Neutral();
                        dateDialougeScript.wine3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "Oh are you using that dirty rag of yours. How cute of you. At least the spill is gone.";
                        dateEmotions.Excited();
                        dateDialougeScript.wine3d.Find("Scarf").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "How resourceful. I wouldn’t dare touch a mess so I am thankful you’re here.";
                        dateEmotions.Flushed();
                        dateDialougeScript.wine3d.Find("Napkin").gameObject.SetActive(false);
                        break;
                    default:
                        responseText = "How about we switch spots. I have a thing about unresponsive dragons not helping beautiful dragons like myself.";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
        }
    }
    //fork
    public void Event3()
    {
        GoToDateButton.datePoints += event3Effect;
        GoToDateButton.eventPoints += event3Effect;
        DateCardEffects.effectAmount = event3Effect;
        switch (GoToDateButton.dateOrder[GoToDateButton.currentDate - 1])
        {
            //cute
            case 1:
                switch (event3Effect)
                {
                    case 1:
                        responseText = "*The hair dryer is perfectly placed on the floor and blows the fork back onto the table* How did you perfectly plan that? Haha I mean thank you!";
                        dateEmotions.Neutral();
                        dateDialougeScript.utensil3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "Oh you want to feed me…? I mean that's kinda romantic… sure go on ahead!";
                        dateEmotions.Excited();
                        dateDialougeScript.utensil3d.Find("Hand").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "Ahhh I needed a new fork. Thank you now I won’t have to get my claws dirty!";
                        dateEmotions.Flushed();
                        dateDialougeScript.utensil3d.Find("Fork").gameObject.SetActive(false);
                        break;
                    default:
                        responseText = "I guess I’ll eat with my hands. So much for my maniclaw.";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
                //scary
            case 2:
                switch (event3Effect)
                {
                    case 1:
                        responseText = "*The hair dryer is perfectly placed on the floor and blows the fork back onto the table* " +
                            "I mean that is quite impressive. I can say I did not see that coming.";
                        dateEmotions.Neutral();
                        dateDialougeScript.utensil3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "Do dragons usually hand feed each other? I mean I don’t go out much but I'm sure you can feed me.";
                        dateEmotions.Excited();
                        dateDialougeScript.utensil3d.Find("Hand").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "We could have asked the waiter for a new one but thank you!";
                        dateEmotions.Flushed();
                        dateDialougeScript.utensil3d.Find("Fork").gameObject.SetActive(false);
                        break;
                    default:
                        responseText = "You know what dragons say. Are you really having a good meal if you aren’t eating with your own claws? Aha ha ha…";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
            //tough
            case 3:
                switch (event3Effect)
                {
                    case 1:
                        responseText = "*The hair dryer is perfectly placed on the floor and blows the fork back onto the table* " +
                            "How did you perfectly plan that? Haha I mean thank you!";
                        dateEmotions.Neutral();
                        dateDialougeScript.utensil3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "Oh you just want to hand feed me. I think that this is kinda a genius idea. Actually toss it to me I bet I can catch it!";
                        dateEmotions.Excited();
                        dateDialougeScript.utensil3d.Find("Hand").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "This is perfect. I needed a new fork. You are so kind and thoughtful you cutie.";
                        dateEmotions.Flushed();
                        dateDialougeScript.utensil3d.Find("Fork").gameObject.SetActive(false);
                        break;
                    default:
                        responseText = "I guess I’ll eat with my hands. Nothing like getting a little food in between your claws. ";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
            //elegant
            case 4:
                switch (event3Effect)
                {
                    case 1:
                        responseText = "*The hair dryer is perfectly placed on the floor and blows the fork back onto the table* " +
                            "Did you know that was going to happen? Also why do you even have a hairdryer with you?";
                        dateEmotions.Neutral();
                        dateDialougeScript.utensil3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "Please get your hand away from my food. *You hold your hand out insisting* Fine, JUST this once.";
                        dateEmotions.Excited();
                        dateDialougeScript.utensil3d.Find("Hand").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "Oh thank goodness I was worried I was going to have to eat like an animal. Thank you.";
                        dateEmotions.Flushed();
                        dateDialougeScript.utensil3d.Find("Fork").gameObject.SetActive(false);
                        break;
                    default:
                        responseText = "I am not eating this without another utensil. No please eat before me. It's not like that's impolite.";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
        }
    }
    //Wants something
    public void Event4()
    {
        GoToDateButton.datePoints += event4Effect;
        GoToDateButton.eventPoints += event4Effect;
        DateCardEffects.effectAmount = event4Effect;
        switch(GoToDateButton.dateOrder[GoToDateButton.currentDate - 1])
        {
            //cute
            case 1:
                switch (event4Effect)
                {
                    case 1:
                        responseText = "Oh…is this a gift? Thanks this is… weir- I mean I can’t wait to give this a go back to my cave.";
                        dateEmotions.Neutral();
                        dateDialougeScript.gift3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "*She blushes and smiles as you hold each others hands* I think you just made my heart flutter a bit!";
                        dateEmotions.Excited();
                        dateDialougeScript.gift3d.Find("Hand").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "Ahhh I love new gifts! This is so lovely. You picked out the perfect gift!";
                        dateEmotions.Flushed();
                        if(gameObject.name.Contains("Gift"))
                            dateDialougeScript.gift3d.Find("Gift").gameObject.SetActive(true);
                        else if(gameObject.name.Contains("Flower"))
                            dateDialougeScript.gift3d.Find("Rose").gameObject.SetActive(true);
                        break;
                    default:
                        responseText = "*She stares blankly at you. She looks sad and sighs*";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
                //scary
            case 2:
                switch (event4Effect)
                {
                    case 1:
                        responseText = "I have always wanted one of these. Even though I have no hair I would love to use this for something!";
                        dateEmotions.Neutral();
                        dateDialougeScript.gift3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "*She blushes and smiles as you hold each others hands* I think I am dying and my heart won’t stop racing.";
                        dateEmotions.Excited();
                        dateDialougeScript.gift3d.Find("Hand").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "I didn’t know this even existed. This is such a beautiful color. Thank you for showing me something so beautiful!";
                        dateEmotions.Flushed();
                        if (gameObject.name.Contains("Gift"))
                            dateDialougeScript.gift3d.Find("Gift").gameObject.SetActive(true);
                        else if (gameObject.name.Contains("Flower"))
                            dateDialougeScript.gift3d.Find("Rose").gameObject.SetActive(true);
                        break;
                    default:
                        responseText = "*She stares and you still smiling but you notice her smile slightly drop*";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
                //tough
            case 3:
                switch (event4Effect)
                {
                    case 1:
                        responseText = "You know a Dragon away has to accept others' treasure. Thank you for this. I can’t wait to blow hot air sometime.";
                        dateEmotions.Neutral();
                        dateDialougeScript.gift3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "*She blushes and smiles as you hold each others hands* Wow your hand is soooo small. But very cute!";
                        dateEmotions.Excited();
                        dateDialougeScript.gift3d.Find("Hand").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "Oh my goodness I was looking for something new to put in my cave. I can’t wait to put this next to my mirror while I flex at home!";
                        dateEmotions.Flushed();
                        if (gameObject.name.Contains("Gift"))
                            dateDialougeScript.gift3d.Find("Gift").gameObject.SetActive(true);
                        else if (gameObject.name.Contains("Flower"))
                            dateDialougeScript.gift3d.Find("Rose").gameObject.SetActive(true);
                        break;
                    default:
                        responseText = "*She stares blankly at you. She looks sad and sighs*";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
                //elegant
            case 4:
                switch (event4Effect)
                {
                    case 1:
                        responseText = "I actually have 10 of these already but hey what's one more to the collection. " +
                            "Even though I am pretty sure all of mine are much better quality.";
                        dateEmotions.Neutral();
                        dateDialougeScript.gift3d.Find("Hairdryer").gameObject.SetActive(true);
                        break;
                    case 2:
                        responseText = "*She blushes and smiles as you hold each others hands* I didn’t expect you to be so forward. " +
                            "I am used to taking the lead but I am a dragon for change.";
                        dateEmotions.Excited();
                        dateDialougeScript.gift3d.Find("Hand").gameObject.SetActive(true);
                        break;
                    case 3:
                        responseText = "I just adore this. This is something I really love. I think you are so kind.";
                        dateEmotions.Flushed();
                        if (gameObject.name.Contains("Gift"))
                            dateDialougeScript.gift3d.Find("Gift").gameObject.SetActive(true);
                        else if (gameObject.name.Contains("Flower"))
                            dateDialougeScript.gift3d.Find("Rose").gameObject.SetActive(true);
                        break;
                    default:
                        responseText = "*She stares blankly at you. She looks sad and sighs*";
                        dateEmotions.Unhappy();
                        break;
                }
                break;
        }
        
    }
    //theses event have the text set in the DateDialogue script
    //personal interests
    public void Event5()
    {
        GoToDateButton.datePoints += event5Effect;
        GoToDateButton.eventPoints += event5Effect;
        DateCardEffects.effectAmount = event5Effect;
    }
    //order food
    public void Event6()
    {
        GoToDateButton.datePoints += event6Effect;
        GoToDateButton.eventPoints += event6Effect;
        DateCardEffects.effectAmount = event6Effect;
    }
}
