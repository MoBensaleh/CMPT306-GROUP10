using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public Sprite apple;
    public Sprite fish_cooked;
    public Sprite ore_ruby;
    public Sprite sword_silver;
    public Sprite keyBlue;
    public Sprite keyGreen;
    public Sprite keyRed;
    public Sprite keyYellow;

}
