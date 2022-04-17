using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System.IO;
using System;
using Random = UnityEngine.Random;

public class reklamlar : MonoBehaviour
{
    int oyunhakk;
    //public static reklamlar instance;
    public GameObject baslatbutonu;
    public GameObject isimobje;
    public Text isim;
    public Text isimvarsayaz;
    public GameObject isimvarsayazobje;
    string adUnitId;
    public Text oyunhak;
    public Text para;
    public GameObject reklamuyariiyazisi;
    public GameObject reklamuyariikaresii;
    private RewardedAd rewardedAd;
    int hangireklam = 0, pararastgele = 0, oankipara;
    //private RewardBasedVideoAd revardBasedVideoAd;
    //private string adUnitId = "ca-app-pub-7834627773947316~7148204305";
    //private string _rewardedAdID = "ca-app-pub-7834627773947316/3951195321";
    //private RewardBasedVideoAd _rewardBasedVideoAd;
    private InterstitialAd interstitial;
    // Start is called before the first frame update
    void Start()
    {
        adUnitId = "ca-app-pub-7834627773947316/3951195321";
        string path = Application.persistentDataPath + "/HorseRunisim.hrs";
       /* if (File.Exists(path))
        {
            //isim.text = System.Convert.ToString(ziplamakod.isimyukle());
            isimvarsayazobje.SetActive(true);
            isimobje.SetActive(false);
            isimvarsayaz.text = System.Convert.ToString(ziplamakod.isimyukle());
        }
        else
        {
            oyunhak.text = "2";
            isimvarsayazobje.SetActive(false);
            isimobje.SetActive(true);
        }*/
        oyunhak.text = System.Convert.ToString(ziplamakod.oyunhakkiyukle());
        //MobileAds.Initialize(adUnitId);
        MobileAds.Initialize(initStatus => { });
        //revardBasedVideoAd = RewardBasedVideoAd.Instance;
        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        //this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest adRequest = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(adRequest);
    }
    void reklamyukle()
    {
        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        //this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest adRequest = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(adRequest);
    }
    /*void requestRewardedAd()
    {
        Debug.Log("butonabasildi3");
        this._rewardBasedVideoAd = RewardBasedVideoAd.Instance;

        AdRequest adRequest = new AdRequest.Builder().Build();

        this._rewardBasedVideoAd.LoadAd(adRequest, _rewardedAdID);
    }*/
   /* void showRewardedAd()
    {
        Debug.Log("butonabasildi2");
        requestRewardedAd();
        if (this._rewardBasedVideoAd.IsLoaded())
        {
            Debug.Log("butonabasildi4");
            this._rewardBasedVideoAd.Show();
        }
        else
        {
            Debug.Log("Rewarded reklamımız daha yüklenmedi!!");
        }
    }*/
    void Update()
    {
         if (System.Convert.ToInt32(oyunhak.text) > 0)
         {
            baslatbutonu.SetActive(true);
            reklamuyariiyazisi.SetActive(false);
            reklamuyariikaresii.SetActive(false);
        }
         if (System.Convert.ToInt32(oyunhak.text) == 0)
         {
            baslatbutonu.SetActive(false);
            reklamuyariiyazisi.SetActive(true);
            reklamuyariikaresii.SetActive(true);
        }
    }
    public void reklambtn()
    {
        Debug.Log("butonabasildi");
        hangireklam = 1;
        UserChoseToWatchAd();
        //LoadRewardBaseAd();
        // showRewardedAd();
    }
    public void reklambtnparakazan()
    {
        pararastgele = Random.Range(3, 9);
        Debug.Log("butonabasildi");
        hangireklam = 2;
        UserChoseToWatchAd();

    }
    private void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
    /* private void LoadRewardBaseAd()
     {
         /*string rewardedAdid = "ca-app-pub-7834627773947316/3951195321";
         rewardedAd = new RewardedAd(rewardedAdid);
         AdRequest request = new AdRequest.Builder().Build();
         rewardedAd.LoadAd(request);
         if (rewardedAd.IsLoaded())
         {
             rewardedAd.Show();
         }
         rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;*/

    /* string adunityid = "a-app-pub-7834627773947316/3951195321";
     revardBasedVideoAd.LoadAd(new AdRequest.Builder().Build(), adunityid);
     revardBasedVideoAd.Show();
 }
 public void HandleUserEarnedReward(object sender, Reward args)
 {
     oyunhak.text = System.Convert.ToString(System.Convert.ToInt32(oyunhak.text) + 1);
     Debug.Log("reklam");
     /*string type = args.Type;
     double amount = args.Amount;
     MonoBehaviour.print(
         "HandleRewardedAdRewarded event received for "
                     + amount.ToString() + " " + type);
 }*/
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    /*public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }
    */
    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        reklamyukle();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        if (hangireklam == 1)
        {
            oyunhakk = System.Convert.ToInt32(oyunhak.text);
            oyunhakk = oyunhakk + 2;
            oyunhak.text = System.Convert.ToString(oyunhakk);
            ziplamakod.oyunhakkikayit(oyunhakk);
            hangireklam = 0;
        }
        if(hangireklam == 2)
        {
            oankipara = System.Convert.ToInt32(para.text);
            oankipara = oankipara + pararastgele;
            para.text = System.Convert.ToString(oankipara);
            ziplamakod.parakayit(oankipara);
            hangireklam = 0;
            parakodu.sapkalariac();
        }
    }
    public void oyunhakkiniarttir()
    {
        oyunhakk = System.Convert.ToInt32(oyunhak.text);
        oyunhakk = oyunhakk + Random.Range(2,3);
        oyunhak.text = System.Convert.ToString(oyunhakk);
    }
}
