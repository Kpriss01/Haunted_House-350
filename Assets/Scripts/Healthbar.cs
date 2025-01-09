using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider healthbar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void SetMaxHealth(float health)
    {
        healthbar.maxValue = health;
        healthbar.value = health;
    }
    public void SetHealth(float hp)
    {
        healthbar.value = hp;
    }
}
