using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
   
    [Header("Data")]
    [SerializeField] FruitType fruitType;
    public static Action <Fruit, Fruit> onCollissionWithFruit;
   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnablePhysic()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    public void MoveTo (Vector2 targetPosition)
    {
        transform.position = targetPosition;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out Fruit otherFruit))
        {
            onCollissionWithFruit?.Invoke(this, otherFruit);
        }
    }
}
