using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public static GameManager instance;
    public CharStats[] playerStats;

    public bool GameMenuOpen, DialogActive, fadingBetweenAreas;
   



    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMenuOpen || DialogActive || fadingBetweenAreas)     // || = OR //
        {
            PlayerControl.instance.canMove = false;

        }
        else
        {
            PlayerControl.instance.canMove = true;
        }
    }
}
