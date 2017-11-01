using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadHelper : MonoBehaviour {

    public float health;
    public Image healthLine;
    public Image stomachLine;
    public Text textHealth;
    public Text textPoints;
    public Text textGameOver;
    public Toggle toggleEat;

    private float maxHealth;
    private int countPoints;
    private short countCharactersInStomach;
    private bool isEnd;

    // Use this for initialization
    void Start () {
        isEnd = false;
        countPoints = 0;
        countCharactersInStomach = 0;
        maxHealth = health;
        InvokeRepeating("Digestion", 0, 2);
    }
	
	// Update is called once per frame
	void Update () {
        if (countCharactersInStomach == 5)
        {
            GameOver();
            health = 0;
        }
    }

    private void UpdateStomach(short count)
    {
        if(count > 3)
        {
            stomachLine.color = Color.yellow;
            if(count > 4)
            {
                stomachLine.color = Color.red;
            }
        }
        stomachLine.rectTransform.localScale = new Vector3(1, count * 0.2f, 1);
    }

    private void UpdateHealthAndPoint(int healthPoints)
    {
        if (!isEnd)
        {
            if (GetComponent<Animator>().GetBool("isClose"))
            {
                TakeDamage(healthPoints);
            }
            else
            {
                Healing(healthPoints);
            }
            float ratio = health / maxHealth;
            healthLine.rectTransform.localScale = new Vector3(ratio, 1, 1);
            textHealth.text = (ratio*100).ToString() + "%";
            CreateColorForHealth(ratio);
            textPoints.text = "Points: " + countPoints;
        }
    }

    private void TakeDamage(int healthPoints)
    {
        health -= healthPoints;
        if (health <= 0)
        {
            health = 0;
            GameOver();
        }
    }

    private void Healing(int healthPoints)
    {
        health += healthPoints;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        countPoints++;
        if (countCharactersInStomach <= 5)
        {
            countCharactersInStomach++;
        }
        UpdateStomach(countCharactersInStomach);
    }

    private void CreateColorForHealth(float _ratio)
    {
        if (_ratio >= 0.5 && _ratio <= 1)
        {
            healthLine.color = new Color(1 - MapValues(1f, 0.5f, _ratio), 1f, 0f);
        }
        if (_ratio < 0.5)
        {
            healthLine.color = new Color(1f,MapValues(0.5f, 0f, _ratio), 0f);
        }
    }

    private float MapValues(float minValue, float maxValue, float n)
    {
        if(minValue == maxValue)
        {
            return 0;
        }
        return (n-maxValue) / (minValue - maxValue);
    }

    private void Digestion()
    {
        if (isEnd)
        {
            return;
        }

        if (countCharactersInStomach != 0)
        {
            countCharactersInStomach--;
            UpdateStomach(countCharactersInStomach);
        }

        Debug.Log(countCharactersInStomach);

        if (stomachLine.rectTransform.localScale.y == 1)
        {
            GameOver();
            health = 0;
        }
    }

    private void GameOver()
    {
        textGameOver.text = "Game over";
        isEnd = true;
        toggleEat.enabled = false;
        healthLine.rectTransform.localScale = new Vector3(0, 1, 1);
        textHealth.text = "0%";
    }

    public void AnimOpenCloseMouth(bool isClose)
    {
        if (isClose)
        {
            GetComponent<Animator>().SetBool("isClose", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isClose", false);
        }
    }
}
