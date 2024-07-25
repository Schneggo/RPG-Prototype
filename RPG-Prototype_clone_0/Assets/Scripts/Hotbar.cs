using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hotbar : MonoBehaviour
{
    public HotbarSlot[] Slots = new HotbarSlot[8];

    public Vector2 mouseScroll;
    private Vector2 pos = new Vector2(0, 0);

    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    private int currentSlot = 0;
    private int slotMax = 0;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Hotbar.Enable();
        slotMax = Slots.Length - 1;

        SetFirstSlotActive();
    }

    public void Update()
    {
        mouseScroll = playerInputActions.Hotbar.Scroll.ReadValue<Vector2>();
        if (mouseScroll.y > pos.y)
        {
            Debug.Log("Scrolled Up");
            ScrollUp();
        }
        else if (mouseScroll.y < pos.y)
        {
            Debug.Log("Scrolled Back");
            ScrollBack();
        }
    }

    private void ScrollUp()
    {
        var oldpos = currentSlot;
        currentSlot = currentSlot + 1;

        if (currentSlot > slotMax)
            currentSlot = 0;

        Slots[oldpos].SlotActiveUI.SetActive(false);
        Slots[currentSlot].SlotActiveUI.SetActive(true);
    }

    private void ScrollBack()
    {
        var oldpos = currentSlot;
        currentSlot = currentSlot - 1;

        if (currentSlot == -1)
            currentSlot = slotMax;

        Slots[oldpos].SlotActiveUI.SetActive(false);
        Slots[currentSlot].SlotActiveUI.SetActive(true);
    }

    private void SetFirstSlotActive()
    {
        Slots.First().SlotActiveUI.SetActive(true);
        currentSlot = 0;
    }
}