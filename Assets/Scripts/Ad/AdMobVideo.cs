using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobVideo : MonoBehaviour
{
    
    RewardBasedVideoAd rewardBasedVideo;

    public void Start()
    {
        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        this.RequestRewardBasedVideo();
        
    }

    public void ShowVideoAd()
    {
        DebugText.instance.text += " S ";
        if (rewardBasedVideo.IsLoaded())
        {
            DebugText.instance.text += " L ";
            rewardBasedVideo.Show();
        }
    }

    public bool VideoLoaded()
    {
        return rewardBasedVideo.IsLoaded();
    }

    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        //string adUnitId = "ca-app-pub-3940256099942544/5224354917"; //dummy
        string adUnitId = "ca-app-pub-9035565607629166/6634067677";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
       

    }

    

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        DebugText.instance.text += " C ";
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        RequestRewardBasedVideo();
        AdManager.instance.AdWasWatched();
        DebugText.instance.text += " R ";
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }
}



