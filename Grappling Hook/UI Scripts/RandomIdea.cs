using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdea : MonoBehaviour
{
    public TextAsset genreText;
    public TextAsset settingText;

    public string[] genres;
    public string[] locations;

    private void Start()
    {
        foreach (string i in locations)
        {
            if (i.Contains(":"))
            {
                i.Replace(":", "");
            }
        }

        genres = genreText.text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.None);
        locations = settingText.text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
    }
}
