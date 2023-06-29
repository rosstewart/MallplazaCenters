using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ControlPanelController : MonoBehaviour
{
    public GameObject[] panels = new GameObject[9];
    public MultiplayerController multiplayerController;

    public void PausePlay(int index)
    {
        multiplayerController.RPCPausePlayCamera(index);
        ApplyPausePlay(index);
    }

    public void ApplyPausePlay(int index)
    {
        panels[index].GetComponent<ImageStreamController>().PausePlay();
        panels[8].GetComponent<ImageStreamController>().SetIndex(index);
        panels[8].GetComponent<VideoPlayer>().clip = panels[index].GetComponent<VideoPlayer>().clip;
        panels[8].GetComponent<RawImage>().texture = panels[index].GetComponent<VideoPlayer>().targetTexture;
    }
    
    public void SetBigPanelVideo(string url)
    {
        //multiplayerController.RPCSetBigPanelVideo(url);
        //panels[8].GetComponent<ImageStreamController>().SetVideo(url);
    }

    public void SetBigPanelIndex(int index)
    {
        //multiplayerController.RPCSetBigPanelIndex(index);
        //panels[8].GetComponent<ImageStreamController>().SetIndex(index);
    }
    
}
