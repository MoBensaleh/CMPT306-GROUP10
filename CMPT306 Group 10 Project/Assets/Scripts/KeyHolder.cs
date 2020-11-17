using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    public static int amountOfPressurePlatesActivated;
    public static int amountOfStatuesActivated;
    [SerializeField] int amountOfStatues;
    [SerializeField] int amountOfPressurePlates;
    [SerializeField] int amountOfKeys;

    private void Awake() {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType){
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType){
        Debug.Log("Removed Key: " + keyType);
        keyList.Remove(keyType);
    }

    public bool ContainsAllKeys(){
        if (keyList.Count == amountOfKeys) {
            Debug.Log("All Keys contained");
            return true;
        } else {
            Debug.Log("Missing keys");
            return false;
        }
    }

    public bool allPressurePlatesActive(){
        if (amountOfPressurePlates == amountOfPressurePlatesActivated){
            return true;
        } else {
            Debug.Log("Missing pressure plates");
            return false;
        }
    }

    public bool allStatuesActivated(){
        if (amountOfStatues <= amountOfStatuesActivated){
            return true;
        } else {
            Debug.Log("Missing statues");
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Key key = collider.GetComponent<Key>();
        if (key != null) {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null){
            if (ContainsAllKeys() && allPressurePlatesActive() && allStatuesActivated()){
                //Opens Door if all keys are obtained
                keyDoor.OpenDoor();
            }
        }
    }
}
