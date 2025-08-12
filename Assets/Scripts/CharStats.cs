using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int baseEXP = 1000;
    public int[] expToNextLevel;
    public int maxLevel = 100;


    public int currentHP;
    public int maxHP = 100;
    public int[] mpLvlBonus;
    public int currentMP;
    public int maxMP;
    public int strength;
    public int defence;
    public int wpnPwr;
    public int armrPwr;
    public string equippedWpn;
    public string equippedArmr;
    public Sprite charImage;

    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];                      
        expToNextLevel[1] = baseEXP;

        for(int i = 2; i < expToNextLevel .Length; i++)                                  //// FOR LOOP BABY ////
        {
            //Debug.Log(i);
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);          // rounds of the number//
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))             // DEV trick to test level progress curve //
        {
            AddExp(1000);
        }
    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;

        if (playerLevel < maxLevel)
        {



            if (currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];
                playerLevel++;

                // determine whether to ad to str or def based on odd or even
                if (playerLevel % 2 == 0)     // Maduallo//
                {
                    strength++;
                }
                else
                {
                    defence++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                maxMP += mpLvlBonus[playerLevel];
                currentMP = maxMP;



            }
        }
        if(playerLevel >= maxLevel )
        {
            currentEXP = 0;
        }
    }
}
