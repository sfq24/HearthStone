using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrystal : MonoBehaviour {

    public int availableNumber = 1;
    public int totalNumber = 1;
    const int maxNumber = 10;
    public UISprite[] crystalImages;
    private UILabel crystalLabel;

    private void Awake()
    {
        crystalLabel = GetComponent<UILabel>();
    }
    // Update is called once per frame
    void Update () {
        UpdateCrystalShow();

    }

    void UpdateCrystalShow()
    {
        crystalLabel.text = availableNumber + @"/" + totalNumber;
        for(int i = totalNumber; i < maxNumber; i++)
        {
            crystalImages[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < totalNumber; i++)
        {
            crystalImages[i].gameObject.SetActive(true);
        }
        for (int i = availableNumber; i < totalNumber; i++)
        {
            crystalImages[i].spriteName = "TextInlineImages_normal";
        }
        for(int i = 0; i<availableNumber; i++)
        {
            if(i == 9)
            {
                crystalImages[i].spriteName = "TextInlineImages_10";
            }
            else
            {
                crystalImages[i].spriteName = "TextInlineImages_0" + (i +1).ToString();
            }
            
        }
    }
}
