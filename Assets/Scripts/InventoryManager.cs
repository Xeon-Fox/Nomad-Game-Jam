using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIPanel;                   
    public Transform inventory_Panel;           
    public List<InventorySlot> slots = new List<InventorySlot>();
    private Camera MainCamera;
    public bool is_open;                        
    public float ReachDistance = 2000f;             

    void Start()
    {
        MainCamera = Camera.main;

        
        for (int i = 0; i < inventory_Panel.childCount; i++)
        {
            InventorySlot slot = inventory_Panel.GetChild(i).GetComponent<InventorySlot>();
            if (slot != null)
            {
                slots.Add(slot);
            }
        }

        UIPanel.SetActive(false);
    }

    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.M))
        {
            is_open = !is_open;
            UIPanel.SetActive(is_open);
        }

        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, ReachDistance))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Item itemComponent = hit.collider.gameObject.GetComponent<Item>();
            if (itemComponent != null)
            {
                AddItem(itemComponent.itemScriptableobject, itemComponent.amount);
                Destroy(hit.collider.gameObject);
            }
            }
            Debug.DrawRay(ray.origin, ray.direction * ReachDistance, Color.green);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * ReachDistance, Color.green);
        }
    }

    
    private void AddItem(ItemScriptableobject _item, int _amount)
    {
        
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                slot.amount += _amount;
                return;
            }
        }

       
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.SetIcon(_item.icon);
                return;
            }
        }
    }
}
