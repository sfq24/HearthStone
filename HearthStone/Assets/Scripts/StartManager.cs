using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public MovieTexture startFilm;
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
        logoTweenScale.AddOnFinished(OnLogoTweenFinished);
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

    private void OnGUI()
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
        string AIHeroName = "hero" + (int)Random.Range(1, 10);
        print("AI hero name generated: " + AIHeroName);
        VS_Show._instance.Show(playerHero.spriteName,AIHeroName);

        //wait for animation finish before go to next scene
        StartCoroutine(LoadPlayScene());
    }

    IEnumerator LoadPlayScene()
    {
        yield return new WaitForSeconds(3);
        //Application.LoadLevel(1);
        SceneManager.LoadScene(1);
    }

}