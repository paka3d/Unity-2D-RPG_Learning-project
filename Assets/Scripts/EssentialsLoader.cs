using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIscreen;
    public GameObject PlayerMain;
    public GameObject gameMan;
   // public Camera myCam;

    
    
    // Start is called before the first frame update
    void Start()
    {
        if(Fade.instance == null)
        {
            Fade.instance = Instantiate(UIscreen).GetComponent<Fade>();
        
        }
        if(PlayerControl.instance == null)
        {
            PlayerControl clone = Instantiate(PlayerMain).GetComponent<PlayerControl>();
            PlayerControl.instance = clone;
        }

        
        if(PlayerControl.instance == null)
        {
            Instantiate(gameMan);
        }
        
        //if (CamaraController.instance == null)
        //{
        //    Instantiate(myCam);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
