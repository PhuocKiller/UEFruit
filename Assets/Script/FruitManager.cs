using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] GameObject fruitPrefab;
    [Header("Settings")]
    [SerializeField] float fruitYPosition;
    private bool isClick = false;
    GameObject fruitIns;
    Rigidbody2D fruitRigidIns;
    Vector2 posFruit;
    [SerializeField] GameObject line;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClick = true;
            ManagerPlayerInput();
        }
        if (isClick)
        {
            posFruit = new Vector2(GetClickedWorldPosition().x, fruitYPosition);
            fruitRigidIns.transform.position = posFruit;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClick = false;
            fruitRigidIns.gravityScale = 1f;
            

        }
    }
    public Vector2 GetClickedWorldPosition ()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void  ManagerPlayerInput()
    {
            posFruit = new Vector2(GetClickedWorldPosition().x, fruitYPosition);
            fruitIns=Instantiate(fruitPrefab, posFruit, Quaternion.identity);
            fruitRigidIns=fruitIns.GetComponent<Rigidbody2D>();
            fruitRigidIns.gravityScale = 0f;
    }
    
}
