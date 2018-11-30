using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMask : MonoBehaviour {

    public static BlackMask _instance;

    private void Awake()
    {
        _instance = this;
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
