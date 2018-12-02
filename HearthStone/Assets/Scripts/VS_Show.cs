using UnityEngine;

public class VS_Show : MonoBehaviour
{
    public static VS_Show _instance;
    public TweenScale vsScale;
    public TweenPosition playHeroPos;
    public TweenPosition aiPlayerPos;

    // Use this for initialization
    private void Awake()
    {
        _instance = this;
        this.gameObject.SetActive(false);

        //GameObject aiObj = GameObject.Find("AIHero");
        //aiPlayerPos = GameObject.Find("AIHero").GetComponent<TweenPosition>();
        //playHeroPos = GameObject.Find("VS/PlayerHero").GetComponent<TweenPosition>();
        //vsScale = GameObject.Find("vesus").GetComponent<TweenScale>();
        
    }

    private void Start()
    {
        //Show("Hero1", "Hero3");
    }

    public void Show(string playHeroName, string aiHeroName)
    {
        PlayerPrefs.SetString("PlayerHero", playHeroName);
        PlayerPrefs.SetString("AIhero", aiHeroName);

        Debug.Log(aiHeroName);
        this.gameObject.SetActive(true);
        BlackMask._instance.Show();

        playHeroPos.GetComponent<UISprite>().spriteName = playHeroName;
        aiPlayerPos.GetComponent<UISprite>().spriteName = aiHeroName;

        vsScale.PlayForward();
        playHeroPos.PlayForward();
        aiPlayerPos.PlayForward();
    }

}