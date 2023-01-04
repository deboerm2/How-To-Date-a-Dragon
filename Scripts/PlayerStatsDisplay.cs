using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsDisplay : MonoBehaviour
{

    private Cards cardScript;
    private Slider displaySlider;

    public bool cute;
    public bool scary;
    public bool tough;
    public bool elegant;

    // Start is called before the first frame update
    void Start()
    {
        cardScript = GameObject.FindObjectOfType<Cards>();
        displaySlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cute && scary)
        {
            displaySlider.value = cardScript.cuteTotal - cardScript.scaryTotal;
        }
        else if (tough && elegant)
        {
            displaySlider.value = cardScript.toughTotal - cardScript.elegantTotal;
        }
    }
}
