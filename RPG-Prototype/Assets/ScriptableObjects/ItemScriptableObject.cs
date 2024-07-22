using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Item/New Item")]
public class ItemScriptableObject : ScriptableObject
{
    public int ID;
    public Rarity ItemRarity;
    public string ItemName;
    public GameObject ItemPrefab;
    public Sprite ItemSprite;
}