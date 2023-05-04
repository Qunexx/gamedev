using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Image bar;

    public float fill;
    public Text healthText;
    
    // Start is called before the first frame update
    void Start()
    {
        fill = 1f;
        healthText.text = Mathf.RoundToInt(fill * 100f).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        fill = Mathf.Clamp01(fill);
        bar.fillAmount = fill;
        healthText.text = Mathf.RoundToInt(fill * 100f).ToString();
        /*if (fill > 100)
            fill = 100;
        if (fill < 0)
            fill = 0;*/
    }
}
