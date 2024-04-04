using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public bool canMerge;
    public static int numMergeFruit;
    public static Vector2 posMergeFruit;
    // Start is called before the first frame update
    void Start()
    {
       Fruit.fruitDelegate += CollissionBetweenFruitCallBack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator CollissionBetweenFruitCallBack(Fruit sender, Fruit otherFruit)
    {
        yield return new WaitForSeconds(0.1f);
        if (sender.fruitType==otherFruit.fruitType)
        {
            posMergeFruit = sender.transform.position;
            numMergeFruit = sender.numCurrentFruit;
            Destroy(sender.gameObject);
            canMerge = true;
        }
    }
}
