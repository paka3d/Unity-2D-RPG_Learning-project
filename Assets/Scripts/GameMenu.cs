using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    public GameObject theMenu;
    public GameObject[] windows;

    private CharStats[] playerStats;

    public Text[] nameText, hpText, mpText, lvlText, expText;
    public Slider[] expSlider;
    public Image[] charImage;
    public GameObject[] charStatHolder;

    public GameObject[] statusButtons;

    public Text statusName, statusHP, statusMP, statusLvl, statusStr, statusDef, statusWpnEqpd, statusWpnPwr, statusArmrPwr, statusArmrEqpd, statusExp;
    public Image statusImage;


    // Start is called before the first frame update
    void Start()
    {
         UpdateMainStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (theMenu.activeInHierarchy)
            {
                //theMenu.SetActive(false);
                //GameManager.instance.GameMenuOpen = false;
                CloseMenu();
            }
            else
            {
                theMenu.SetActive(true);
                UpdateMainStats();
                GameManager.instance.GameMenuOpen = true;
            }
        }
    }


    public void UpdateMainStats()
    {
        playerStats = GameManager.instance.playerStats;

        for (int i = 0; i < playerStats.Length; i++)
        {
            if(playerStats[i].gameObject.activeInHierarchy)
            {
                charStatHolder[i].SetActive(true);

                nameText[i].text = playerStats[i].charName;
                hpText[i].text = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
                mpText[i].text = "MP: " + playerStats[i].currentMP + "/" + playerStats[i].maxMP;
                lvlText[i].text = "Lvl: " + playerStats[i].playerLevel;
                
                expText[i].text = "" + playerStats[i].currentEXP + "/" + playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].value = playerStats[i].currentEXP;
                charImage[i].sprite = playerStats[i].charImage;


            }
            else
            {
                charStatHolder[i].SetActive(false);
            }
        }
    }

    public void ToggleWindow(int windowNumber)
    {
        UpdateMainStats();

        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void CloseMenu()
    {
        for(int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }

        theMenu.SetActive(false);

        GameManager.instance.GameMenuOpen = false;
    }

    public void OpenStatus()
    {
        //UpdateMainStats();
        StatusChar(0);
        for (int i =0; i < statusButtons.Length; i++)
        {
            statusButtons[i].SetActive(playerStats[i].gameObject.activeInHierarchy);
            statusButtons[i].GetComponentInChildren<Text>().text = playerStats[i].charName;
        }
    }

    public void StatusChar(int selected)
    {
        statusName.text = "Name: " + playerStats[selected].charName;
        statusHP.text = "HP: " + playerStats[selected].currentHP + "/" + playerStats[selected].maxHP;
        statusMP.text = "MP: " + playerStats[selected].currentMP + "/" + playerStats[selected].maxMP;
        statusLvl.text = "Level: " + playerStats[selected].playerLevel;
        statusStr.text = "Strength: " + playerStats[selected].strength.ToString();
        statusDef.text = "Defence: " + playerStats[selected].defence.ToString();

        if (playerStats[selected].equippedWpn != "")
        {
            statusWpnEqpd.text = "Equipped Weapon: " + playerStats[selected].equippedWpn;
        }
        statusWpnPwr.text = "Weapon Power: " + playerStats[selected].wpnPwr.ToString();
        if (playerStats[selected].equippedArmr != "")
        {
            statusArmrEqpd.text = "Equipped Armour: " + playerStats[selected].equippedArmr;
        }
        statusArmrPwr.text = "Armour Power: " + playerStats[selected].armrPwr.ToString();
        statusExp.text = "EXP To Next Level: " + (playerStats[selected].expToNextLevel[playerStats[selected].playerLevel] - playerStats[selected].currentEXP).ToString();
        statusImage.sprite = playerStats[selected].charImage;
    }

}
