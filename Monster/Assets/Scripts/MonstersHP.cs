using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonstersHP : MonoBehaviour {

    public float health;
    public Image healthLine;
    public Text textHealth;
    public Text textPoints;

    private float maxHealth;
    private float ratio;
    private int countPoints;


    // Use this for initialization
    void Start () {
        countPoints = 0;
        maxHealth = health;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateHealth()
    {
        ratio = health / maxHealth;
        Debug.Log(health + "/" + maxHealth + "=" + (health / maxHealth));
        healthLine.rectTransform.localScale = new Vector3(ratio, 1, 1);
        textHealth.text = (ratio*100).ToString() + "%";
        textPoints.text = "Points: " + countPoints;
    }

    private void TakeDamage(int healthPoints)
    {
        health -= healthPoints;
        if (health < 0)
        {
            health = 0;
        }
        UpdateHealth();
    }

    private void Healing(int healthPoints)
    {
        health += healthPoints;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        countPoints++;
        UpdateHealth();
    }
}
