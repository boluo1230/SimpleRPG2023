using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{

    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;

    //item ≥ı ºªØ
    public void InitItem(Sprite iconSprite, string name, string type)
    {
        iconImage.sprite = iconSprite;
        nameText.text = name;
        typeText.text = type;
    }

}
