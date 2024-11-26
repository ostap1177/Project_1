using Shop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestImage : MonoBehaviour
{
    [SerializeField] private Image _image;

    void Start()
    {
        StartCoroutine(YandexPurchaseSpriteHolder.Get(SetImage));

    }

    private void SetImage(Sprite image)
    {
        _image.sprite = image;
        Debug.Log(image);
    }
}
