using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public MovieTexture startFilm;
    /*
     * 此处本试图使用private member，然后在Start内通过GetComponent<>来查找相应对象
     * 然而在设计中，这几个对象被调整成费Active的，所以runtime找不到，会报错
     * 因此采用public，再在unity中拖拽对象
     */
    public TweenScale logoTweenScale;
    public TweenPosition selectPanelPos;
    public UISprite playerHero;

    private bool filmIsPlaying = true;
    public bool messageShown = false;

    private bool isReadyForSelection = false;
    

    // Use this for initialization
    private void Start()
    {
        startFilm.loop = false;
        startFilm.Play();
        logoTweenScale.AddOnFinished(OnLogoTweenFinished);       //Unity采用此种方式注册event，没有事件delegate，无法使用+=方式
       
    }

    // Update is called once per frame
    private void Update()
    {
        if (filmIsPlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!messageShown)
                {
                    messageShown = true;
                }
                else
                {
                    StopMoviePlaying();
                }
            }
        }

        if (!startFilm.isPlaying)
        {
            StopMoviePlaying();
        }

        if(isReadyForSelection && Input.GetMouseButtonDown(0))
        {
            //SHow Hero select 
            isReadyForSelection = false;
            selectPanelPos.PlayForward();
        }
    }

    private void OnGUI()                     //Unity 自带的flow
    {
        if (filmIsPlaying)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), startFilm);
            if (messageShown)
            {

                GUI.Label(new Rect((Screen.width / 2) - 100 , Screen.height / 2, 500, 40), "Click one more time to exit movie playing");

            }
        }
    }

    private void StopMoviePlaying()
    {
        startFilm.Stop();
        filmIsPlaying = false;

        logoTweenScale.PlayForward();
    }

    private void OnLogoTweenFinished()
    {
        isReadyForSelection = true;
    }

    public void OnPlayButtonClick()
    {
        BlackMask._instance.Show();
        string AIHeroName = "hero" + (int)Random.Range(1, 10);       //设置的素材名称与unity中游戏对象相同，并都适合调用
        print("AI hero name generated: " + AIHeroName);
        VS_Show._instance.Show(playerHero.spriteName,AIHeroName);    

        //wait for animation finish before go to next scene
        StartCoroutine(LoadPlayScene());                        //典型的处理方式！！！！！！！！！   携程
    }

    IEnumerator LoadPlayScene()
    {
        yield return new WaitForSeconds(3);
        //Application.LoadLevel(1);           //LoadScene 已经过期
        SceneManager.LoadScene(1);
    }

}