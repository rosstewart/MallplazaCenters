using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
//using Vimeo.Player;

public class VideoController : MonoBehaviour
{
    public TextAsset json;

    //public WebViewPrefab player;
    //public VimeoPlayer vimeo;
    public GameObject screen;

    public VideoPlayer videoPlayer;

    private string baseUrl = "https://player.vimeo.com/video/";
    private string videoId = "";
    private string autoplay = "?loop=false&background=true";
    private int timeAt = 0;
    private int maxTime = 0;
    private ApplicationController applicationController;
    private bool playing = true;

    public GameObject guidedSteps;

    public MultiplayerController multiplayerController;

    // Start is called before the first frame update
    void Start()
    {
        JSONNode jsonNode = JSONNode.Parse(json.text);
        Debug.Log(jsonNode["XRCMS"][0]["url"]);
        baseUrl = jsonNode["XRCMS"][0]["url"];

        applicationController = ApplicationController.GetInstance();
        //vimeo.vimeoVideo.uri = baseUrl;

        //videoId = applicationController.navigationController.GetCurrentView().GetBundleData<string>();
        //player.Visible = false;
        //player.Init();
        //player.Initialized += Player_Initialized;
    }

    public void ActivateVideo(VideoPlayer videoPlayer)
    {
        //if (videoPlayer == null) videoPlayer = this.videoPlayer;
        if (this.videoPlayer == null) this.videoPlayer = videoPlayer;
        multiplayerController.RPCActivateVideo();
        ApplyActivateVideo();
    }

    public void ApplyActivateVideo()
    {
        screen.SetActive(true);
        //vimeo.LoadVideo();
        //vimeo.Play();

        videoPlayer.Play();
    }

    public void DeactivateVideo(VideoPlayer videoPlayer)
    {
        //if (videoPlayer == null) videoPlayer = this.videoPlayer;
        if (this.videoPlayer == null) this.videoPlayer = videoPlayer;
        multiplayerController.RPCDeactivateVideo();
        ApplyDeactivateVideo();
    }

    public void ApplyDeactivateVideo()
    {
        videoPlayer.Stop();

        screen.SetActive(false);
    }

    private void GetVideoLength()
    {
        //player.WebView.ExecuteJavaScript("document.getElementsByClassName('vp-progress')[0].getElementsByClassName('focus-target')[0].getAttribute('aria-valuemax')", callbackMaxTime);
    }

    private void GetTimeAt()
    {
        //player.WebView.ExecuteJavaScript("document.getElementsByClassName('vp-progress')[0].getElementsByClassName('focus-target')[0].getAttribute('aria-valuenow')", callbackTimeAt);
    }

    private void callbackMaxTime(string obj)
    {
        maxTime = int.Parse(obj);
    }

    private void callbackTimeAt(string obj)
    {
        timeAt = int.Parse(obj);
    }

    private void Player_Initialized(object sender, System.EventArgs e)
    {
        //player.WebView.LoadUrl(baseUrl + videoId + autoplay);
        //player.Visible = true;
    }

    public void playPause(VideoPlayer videoPlayer)
    {
        if (this.videoPlayer == null) this.videoPlayer = videoPlayer;
        multiplayerController.RPCPlayPauseVideo();
        ApplyPlayPause();
    }

    public void ApplyPlayPause()
    {
        //if (videoPlayer == null) videoPlayer = this.videoPlayer;

        if (playing)
        {
            playing = false;
            pause(videoPlayer);
        }
        else
        {
            playing = true;
            play(videoPlayer);
        }
    }

    public void play(VideoPlayer videoPlayer)
    {
        if (videoPlayer == null) videoPlayer = this.videoPlayer;

        Debug.Log("VimeoController::play");
        //vimeo.Play();

        videoPlayer.aspectRatio = VideoAspectRatio.FitInside;
        videoPlayer.Play();
        //player.WebView.ExecuteJavaScript("document.getElementsByClassName('play rounded-box state-paused')[0].click()");

    }

    public void pause(VideoPlayer videoPlayer)
    {
        if (videoPlayer == null) videoPlayer = this.videoPlayer;

        Debug.Log("VimeoController::pause");
        //vimeo.Pause();

        videoPlayer.Pause();
        //player.WebView.ExecuteJavaScript("document.getElementsByClassName('play rounded-box state-playing')[0].click()");
    }

    public void rewind(VideoPlayer videoPlayer)
    {
        if (this.videoPlayer == null) this.videoPlayer = videoPlayer;
        multiplayerController.RPCRewindVideo();
        ApplyRewind();
    }

    public void ApplyRewind()
    {
        //if (videoPlayer == null) videoPlayer = this.videoPlayer;

        Debug.Log("rewind");
        //vimeo.SeekBackward(60);

        if (videoPlayer.time > 5)
        {
            videoPlayer.time = videoPlayer.time - 5;
        }
        else
        {
            videoPlayer.time = 0;
        }

    }

    public void forward(VideoPlayer videoPlayer)
    {
        if (this.videoPlayer == null) this.videoPlayer = videoPlayer;
        multiplayerController.RPCForwardVideo();
        ApplyForward();
    }

    public void ApplyForward()
    {
        //if (videoPlayer == null) videoPlayer = this.videoPlayer;

        Debug.Log("forward");
        //vimeo.SeekForward(60);

        videoPlayer.time = videoPlayer.time + 5;
    }



    public void TurnOnGuidedSteps() {
        multiplayerController.RPCTurnOnGuidedSteps();
        ApplyTurnOnGuidedSteps();
    }

    public void ApplyTurnOnGuidedSteps()
    {
        guidedSteps.SetActive(true);
    }

    public void TurnOffGuidedSteps()
    {
        multiplayerController.RPCTurnOffGuidedSteps();
        ApplyTurnOffGuidedSteps();
    }

    public void ApplyTurnOffGuidedSteps()
    {
        guidedSteps.SetActive(false);
    }

}
