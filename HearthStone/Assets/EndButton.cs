using UnityEngine;

public class EndButton : MonoBehaviour
{
    private UILabel label;

    private void Awake()
    {
        label = transform.Find("EndLabel").GetComponent<UILabel>();
    }
    public void OnEndButtonClick()
    {
        if(label.text == "回合结束")
        {
            label.text = "对方回合";
        }
        
    }
}