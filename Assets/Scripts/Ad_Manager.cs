using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Ad_Manager : MonoBehaviour
{

    private BannerView bannerView;
    [SerializeField] float BannerAdWaitTime = 60f;


    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        StartCoroutine(RefreshBannerAd());
    }

    

    IEnumerator RefreshBannerAd()
    {

        ShowBannerAd();
        yield return new WaitForSeconds(BannerAdWaitTime);

        DestroyBanner();

        yield return new WaitForSeconds(5f);

        RestartAd();
    }


    private void ShowBannerAd()
    {
        RequestBanner();
        LoadBanner();
    }


    private void RequestBanner()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-4265126177729958/8156101351";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-4265126177729958/8156101351";
#else
            string adUnitId = "unexpected_platform";
#endif

        AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        bannerView = new BannerView(adUnitId, adaptiveSize , AdPosition.Top);
    }

    private void LoadBanner()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }


    void RestartAd()
    {
        StartCoroutine(RefreshBannerAd());
    }

    private void DestroyBanner()
    {
        bannerView.Destroy();
    }




    //All Above are Banner AD Functions

}

