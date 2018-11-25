using UnityEngine;

public class StartManager : MonoBehaviour
{
    public MovieTexture startFilm;

    private bool filmIsPlaying = true;
    public bool messageShown = false;

    // Use this for initialization
    private void Start()
    {
        startFilm.loop = false;
        startFilm.Play();
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
        
    }
}