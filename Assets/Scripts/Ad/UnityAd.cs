using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class UnityAd : MonoBehaviour
{
    private string gameId = "2584383";

    void Start()
    {
        //---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, true);
        }
        //-------------------------------------------------------------------//
    }

    public void ShowAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Advertisement.Show(options);
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            AdManager.instance.AdWasWatched();
            Debug.Log("Video completed - Offer a reward to the player");

        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }
}
