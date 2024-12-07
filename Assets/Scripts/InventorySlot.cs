using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public ItemScriptableobject item;
    public int amount;             
    public bool isEmpty => item == null; 
    public GameObject iconGO;
    public TMP_Text itemAmount;

    private void Start()
    {
        iconGO = transform.GetChild(0).gameObject;
        itemAmount = transform.GetChild(1).GetComponent<TMP_Text>();
    }
    public void SetIcon(Sprite icon)
{
    if (iconGO == null)
    {
        Debug.LogError($"{name}: iconGO is not assigned!");
        return;
    }

    Image iconImage = iconGO.GetComponent<Image>();
    if (iconImage == null)
    {
        Debug.LogError($"{name}: Icon GameObject does not have an Image component!");
        return;
    }

    iconImage.color = new Color(1, 1, 1, 1);
    iconImage.sprite = icon;
}
}