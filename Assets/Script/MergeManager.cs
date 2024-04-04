using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    [Header("Settings")]
    Fruit lastSender;
    [Header("Action")]
    public static Action<FruitType, Vector2> onMergeProCess;
    private void Awake()
    {
        Fruit.onCollissionWithFruit += CollissionBetweenFruitCallBack;
    }
    void Start()
    {
        
    }
    private void OnDestroy()
    {
        Fruit.onCollissionWithFruit -= CollissionBetweenFruitCallBack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CollissionBetweenFruitCallBack(Fruit sender, Fruit otherFruit)
    {
        if (lastSender!=null)
        {
            return;
        }
        lastSender = sender;
        ProcessMerge(sender,otherFruit);
        Debug.Log("Collision detected by:" + sender.name);
    }
    void ProcessMerge(Fruit sender, Fruit otherFruit)
    {
        FruitType mergeFruitType= sender.GetFruitType();
        mergeFruitType++;
        Vector2 fruitSpawnPos= (sender.transform.position + otherFruit.transform.position)/2;
        Destroy(sender.gameObject);
        Destroy(otherFruit.gameObject);
        StartCoroutine(ResetLastSenderCo());
        //tiến hành sinh Fruit mới
        onMergeProCess?.Invoke(mergeFruitType, fruitSpawnPos);
    }
    IEnumerator ResetLastSenderCo ()
    {
        yield return new WaitForEndOfFrame();
        lastSender = null;
    }
}
