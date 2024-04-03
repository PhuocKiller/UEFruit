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
        Fruit.onCollissionWithFruit += CollissionBetweenFruitCallBack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CollissionBetweenFruitCallBack(Fruit sender, Fruit otherFruit)
    {
        if (sender.fruitType==otherFruit.fruitType)
        {
            posMergeFruit = sender.transform.position;
            numMergeFruit = sender.numCurrentFruit;
            Destroy(sender.gameObject);
            canMerge = true;
        }
    }
}
