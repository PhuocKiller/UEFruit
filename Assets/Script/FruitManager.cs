using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] GameObject fruitPrefab;
    [Header("Settings")]
    [SerializeField] float fruitYPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ManagerPlayerInput();
        }
    }
    public Vector2 GetClickedWorldPosition ()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void  ManagerPlayerInput()
    {
        Vector2 pos = new Vector2(GetClickedWorldPosition().x, fruitYPosition);
        Instantiate(fruitPrefab, pos, Quaternion.identity);
    }
}
