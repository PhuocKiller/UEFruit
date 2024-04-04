using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Fruit[] fruitPrefabs;
    [SerializeField] LineRenderer fruitSpawnLine;

    Fruit currentFruit; Fruit nextFruit; Fruit mergeFruit;

    [Header("Settings")]
    [SerializeField] float fruitYSpawnPosition;
    public bool canManage;
    bool isControlling;
    int numCurrentFruit; int numNextFruit;

    void Start()
    {
        canManage = true;
        HideLine();
        SpawnNextFruit();
    }

    void Update()
    {
       if (canManage)
        {
            ManagePlayerInput();
        }
       if (FindObjectOfType<MergeManager>().canMerge == true)
        {
            FindObjectOfType<MergeManager>().canMerge = false;
            StartCoroutine(MergeFruit());
        }

    }
    void ManagePlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDownCallback();
        }
        else if (Input.GetMouseButton(0))
        {
            if (isControlling)
            {
                MouseDragCallback();
            }
            else MouseUpCallback();
        }
        if (Input.GetMouseButtonUp(0) && isControlling)
        {
            MouseUpCallback();
        }

    }

    void MouseDownCallback()
    {
        DisplayLine();
        PlaceLineAtClickedPosition();
        SpawnFruit();
        Destroy(nextFruit.gameObject);
        SpawnNextFruit();
        isControlling = true;
    }

    void MouseDragCallback()
    {
        PlaceLineAtClickedPosition();
        currentFruit.MoveTo(GetSpawnPosition());
    }

    void MouseUpCallback()
    {
        HideLine();
        currentFruit.EnablePhysic();
        canManage = false;
        isControlling = false;
        StartControlTimer();
        

    }
    void StartControlTimer ()
    {
        Invoke("StopControlTimer", 1f);
    }
    void StopControlTimer ()
    {
        canManage = true;
    }

    void PlaceLineAtClickedPosition()
    {
        fruitSpawnLine.SetPosition(0, GetSpawnPosition());
        fruitSpawnLine.SetPosition(1, GetSpawnPosition() + Vector2.down * 15);
    }

    // lấy tọa độ chuột trong game world
    Vector2 GetClickedWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    Vector2 GetSpawnPosition()
    {
        Vector2 pos = GetClickedWorldPosition();
        pos.y = fruitYSpawnPosition;
        return pos;
    }
    

    void SpawnFruit()
    {
        numCurrentFruit = numNextFruit;
        Vector2 pos = GetSpawnPosition();
        currentFruit = Instantiate(fruitPrefabs[numCurrentFruit], pos, Quaternion.identity);
        currentFruit.SetupFruit(numCurrentFruit);
    }
    void SpawnNextFruit()
    {
        numNextFruit = Random.Range(0, 5);

        nextFruit = Instantiate(fruitPrefabs[numNextFruit],new Vector2(2.5f,4.5f), Quaternion.identity);
        nextFruit.GetComponent<Animator>().enabled = false;
    }
    private IEnumerator MergeFruit ()
    {
        yield return new WaitForSeconds(0.5f);
        int x = MergeManager.numMergeFruit;
        FindObjectOfType<UIManager>().AddScore(x + 1);
        if (x != 8)
        {
            mergeFruit = Instantiate(fruitPrefabs[x + 1], MergeManager.posMergeFruit, Quaternion.identity);
            mergeFruit.SetupFruit(x + 1);
            mergeFruit.EnablePhysic();
        }
       

    }
    void HideLine()
    {
        fruitSpawnLine.enabled = false;
    }

    void DisplayLine()
    {
        fruitSpawnLine.enabled = true;
    }

}
