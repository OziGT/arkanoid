using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{

    public static AdManager instance;
    public UnityAd unityAd;
    public AdMobInter interAd;
    public AdMobVideo adMobVideo;
    public int[] interAds;
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
#if UNITY_ANDROID
        string appId = "ca-app-pub-9035565607629166~8669365779";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif
        MobileAds.Initialize(appId);
    }

    public void PlayAd()
    {
        switch (Random.Range(0,2))
        {
            case 0:
                if(adMobVideo.VideoLoaded())
                {
                    adMobVideo.ShowVideoAd();
                }
                else
                {
                    unityAd.ShowAd();
                }
                break;
            case 1:
                unityAd.ShowAd();
                break;
        }
    }

    public void AdWasWatched()
    {
        GameManager.instance.ContinueLevel();
    }

    public void InterAd()
    {

        foreach (int level in interAds)
        {
            if (level == GameManager.instance.level)
            {
                
                interAd.ShowAd();
            }
        }

    }
}
