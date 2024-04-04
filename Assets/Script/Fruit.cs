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
    [Header("Elements")]
    [SerializeField] SpriteRenderer spriteRenderer;
    bool hascollided;
    bool canMerged;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("AllowMerge", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnablePhysic()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = true;
    }
    public void MoveTo (Vector2 targetPosition)
    {
        transform.position = targetPosition;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        ManageCollision(other);
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        ManageCollision(other);
    }
    public FruitType GetFruitType()
    {
        return fruitType;
    }
    void ManageCollision(Collision2D other)
    {
        hascollided = true;
        if (!canMerged)
        {
            return;
        }
        if (other.collider.TryGetComponent(out Fruit otherFruit))
        {
            if (otherFruit.GetFruitType() != fruitType)
            { return; }
            if (!otherFruit.canMerged)
            {
                return;
            }
            onCollissionWithFruit?.Invoke(this, otherFruit);
        }
    }
    public Sprite GetSprite()
    {
        return spriteRenderer.sprite;
    }
    public bool Hascollided()
    {
        return hascollided;
    }
    public bool CanbeMerged()
    {
        return canMerged;
    }
    void AllowMerge()
    {
        canMerged = true;
    }
}
