using UnityEngine;

public class HeroSelect : MonoBehaviour
{
    private UISprite selectedHero;
    private UILabel selectedHeroName;

    private void Awake()
    {
        selectedHero = transform.parent.Find("Hero0").GetComponent<UISprite>();
        selectedHeroName = transform.parent.Find("HeroName").GetComponent<UILabel>();
    }

    private string[] heroNames =
    {
        "法爷",
        "猎人",
        "圣骑",
        "MT",
        "小德",
        "古尔丹",
        "萨满",
        "牧爷",
        "盗贼"
    };

    private void OnClick()
    {
        string heroname = this.gameObject.name;
        selectedHero.spriteName = heroname.ToLower();
        int heroIndex = heroname[heroname.Length - 1] - '0';
        selectedHeroName.text = heroNames[heroIndex - 1];
    }
}