using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitManagerUI : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] Image nextFruitImage;
    FruitManager fruitManager;
    // Start is called before the first frame update
    private void Awake()
    {
        fruitManager=GetComponent<FruitManager>();
        FruitManager.onNextFruitIndexSet += NextFruitIndexCallback;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NextFruitIndexCallback()
    {
        nextFruitImage.sprite=fruitManager.GetNextFruitSprite();
    }
}
