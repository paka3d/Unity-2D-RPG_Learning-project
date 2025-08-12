using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public bool isItem;
    public bool isWeapon;
    public bool isArmour;

    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Details")]                      // nice way to view in editor //
    public int amountToChange;
    public bool affectHP, affectMP, affectStr;  // add more if needed//

    public int weaponStrength;

    public int armourStrength;

    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
