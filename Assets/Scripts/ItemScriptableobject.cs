using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum Item_Type {Default, Special}
public class ItemScriptableobject : ScriptableObject
{
    public Item_Type item_Type;
    public string Item_Name;
    public GameObject itemPrefab;
    public Sprite icon;
    public int Maximum_Amount;
    public string Item_Description;

}
