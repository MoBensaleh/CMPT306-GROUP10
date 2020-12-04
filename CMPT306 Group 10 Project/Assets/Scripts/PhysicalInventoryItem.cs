
using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;
    public GameObject inventoryPanel;
    // Start is called before the first frame update


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddItemToInventory();
            Destroy(this.gameObject);
            if (inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(false);
                inventoryPanel.SetActive(true);

            }
           
            
        }
    }

    void AddItemToInventory()
    {
        if(playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                
                thisItem.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }
}
