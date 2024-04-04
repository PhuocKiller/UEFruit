using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
   
    [Header("Data")]
    [SerializeField] public FruitType fruitType;
    public static Action <Fruit, Fruit> onCollissionWithFruit;
    public delegate IEnumerator FruitDelegate (Fruit fruita, Fruit fruitb);
    public static FruitDelegate fruitDelegate;
    public int numCurrentFruit; int numNextFruit;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
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
            StartCoroutine(fruitDelegate(this, otherFruit));
        }
    }
    public void SetupFruit(int numIndexFruit)
    {
        this.numCurrentFruit = numIndexFruit;
        
    }

}
