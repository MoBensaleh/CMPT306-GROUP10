using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    public static int amountOfPressurePlatesActivated;
    [SerializeField] int amountOfKeys;
    [SerializeField] int amountOfPressurePlates;

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
            return false;
        }
    }

    public bool allPressurePlatesActive(){
        if (amountOfPressurePlates == amountOfPressurePlatesActivated){
            return true;
        } else {
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
            if (ContainsAllKeys() && allPressurePlatesActive()){
                //Opens Door if all keys are obtained
                keyDoor.OpenDoor();
            }
        }
    }
}
