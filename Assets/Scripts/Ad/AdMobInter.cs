using GoogleMobileAds.Api;
using UnityEngine;
using System;

public class AdMobInter : MonoBehaviour
{
    public InterstitialAd interstitial;

    private void Start()
    {
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        //string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        string adUnitId = "ca-app-pub-9035565607629166/5848713004";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    public void ShowAd()
    {
        Debug.Log("inter");
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
        Time.timeScale = 0;
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        Time.timeScale = 1;
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");

        Time.timeScale = 1;
    }


}
