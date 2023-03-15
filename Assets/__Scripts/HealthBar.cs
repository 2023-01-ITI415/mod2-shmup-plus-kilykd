using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Canvas canvas;

    public Slider healthBarSlider;

    public Main main;

    public GameObject bossShield;       //reference to enemy4_shield_front child of Enemy_4
    public GameObject bossShieldLeft;   //reference to enemy4_shield_Left child of enemy4_shield_front
    public GameObject bossShieldRight;  //reference to enemy4_shield_Right child of enemy4_shield_front

    private bool enabledHealthBar = false;

    public float leftHealth; //health of bossShieldLeft
    public float rightHealth; //health of bossShieldRight

    public float currHealth; //current health (leftHealth + rightHealth)
    public float maxHealth; //maximum health


    // Start is called before the first frame update
    void Start()
    { 
       canvas.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if boss has spawned
        if(main.spawnedBoss == true && enabledHealthBar == false)
        {
            //enable the health bar
            canvas.GetComponent<Canvas>().enabled = true;

            //Get a reference to the enemy4_shield_front child of Enemy_4
            bossShield = main.bossEnemy.transform.GetChild(1).gameObject;
            //Get a reference to enemy4_shield_Left child of enemy4_shield_front
            bossShieldLeft = bossShield.transform.GetChild(0).gameObject;
            //Get a reference to enemy4_shield_Right child of enemy4_shield_front
            bossShieldRight = bossShield.transform.GetChild(1).gameObject;

            //get the health of bossShieldLeft/Right
            leftHealth = bossShieldLeft.GetComponent<EnemyShield>().health;
            rightHealth = bossShieldRight.GetComponent<EnemyShield>().health;

            //set the max health
            maxHealth = leftHealth + rightHealth;
            //Set the current health to max health
            currHealth = maxHealth;
            enabledHealthBar = true;
            //Update the health bar when the boss takes damage
            UpdateHealthBar();
        }
        //if health bar has been enabled already and the boss is spawned -> update the health bar
        else if(bossShield != null && main.spawnedBoss == true && enabledHealthBar == true)
        {
            UpdateHealthBar();
        }
        //if boss was spawned and has been destroyed -> delete the health bar 
        else if(main.spawnedBoss == true && bossShield == null)
        {
            Destroy(this.gameObject);
        }  
    
    }

    void UpdateHealthBar()
    {
        //Get the health of the left/right boss shields
        leftHealth = bossShieldLeft.GetComponent<EnemyShield>().health;
        rightHealth = bossShieldRight.GetComponent<EnemyShield>().health;
        //set currHealth to the current health of the boss shields
        currHealth = leftHealth + rightHealth;

        //update the healthbar 
        healthBarSlider.value = currHealth;
        healthBarSlider.maxValue = maxHealth;
    }
}
