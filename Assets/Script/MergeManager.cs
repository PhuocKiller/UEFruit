using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
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
        Debug.Log("Collision detected by:" + sender.name);
    }
}
