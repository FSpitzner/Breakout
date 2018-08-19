using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePanel : MonoBehaviour {

    public Sprite newSprite;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void UpdateSprite(Object obj)
    {
        image.sprite = newSprite;
    }
}
