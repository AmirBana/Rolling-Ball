using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobManager : MonoBehaviour
{
    private BannerView bannerView;
    private string bannerAdId = "ca-app-pub-3940256099942544/6300978111";
    private InterstitialAd interstitial;
    private string interstitialAdId = "ca-app-pub-3940256099942544/1033173712";
    public UiManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatue => { });
        RequestBanner();
        RequestInterstitial();
    }
    private void RequestBanner()
    {
        this.bannerView = new BannerView(bannerAdId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }
    private void RequestInterstitial()
    {
        this.interstitial = new InterstitialAd(interstitialAdId);
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }
    public void ShowInterstitial()
    {
        if(this.interstitial.IsLoaded())
        {
            uiManager.FadePanel();
            this.interstitial.Show();
        }
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        print("HandleAdClosed event received");
        this.interstitial.Destroy();
        this.bannerView.Destroy();
        uiManager.GameOver();
    }
}
