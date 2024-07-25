using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarSlot : MonoBehaviour
{
    [SerializeField] private Transform position;
    [SerializeField] private Item item;

    [SerializeField] private bool isSelected = false;
    public GameObject SlotActiveUI;
}