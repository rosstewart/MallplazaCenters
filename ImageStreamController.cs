//OUTDATED

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MRTK;
using UnityEngine.Video;


//stream for image-based IP cameras

//Open Global IP's to try

//Busy Parking lot

//http://107.144.24.100:88/record/current.jpg?rand=509157

//Beach

//http://107.144.24.100/record/current.jpg?rand=291145


public class ImageStreamController : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseButton;
    private RawImage frame;
    private Texture2D texture;
    private int isOn = -1;
    private int index;

    private void Awake()
    {

        /*
        // Initializes "thumbnail" of video
        if (isOn == 1)
        {
            StopAllCoroutines();
            PausePlay(); // When switching slides, video goes to paused mode
        }
        isOn = -1;
        frame = GetComponent<RawImage>();
        texture = new Texture2D(2, 2);
        StartCoroutine(GetImage());
        */
    }
    /*
    private void CreateNewTexture()
    {
        if (isOn == 1)
        {
            // Create new texture for new frame
            texture = new Texture2D(2, 2);
            StartCoroutine(GetImage());
        }
    }

    IEnumerator GetImage()
    {
        yield return new WaitForEndOfFrame();
        using (WWW www = new WWW(url))
        {
            // Load Image
            yield return www;
            www.LoadImageIntoTexture(texture);
            frame.texture = texture;
            //GetComponent<MeshRenderer>().material.mainTexture = texture;
            CreateNewTexture();
        }
    }
    */
    public void PausePlay()
    {
        if (isOn == -1)
        {
            
            playButton.SetActive(false);
            pauseButton.SetActive(true);
            isOn *= -1;
            //CreateNewTexture();
            GetComponent<RawImage>().texture = GetComponent<VideoPlayer>().targetTexture;
            GetComponent<VideoPlayer>().Play();
        }
        else
        {
            playButton.SetActive(true);
            pauseButton.SetActive(false);
            isOn *= -1;
            GetComponent<VideoPlayer>().Pause();
        }

    }
    /*
    public void SetVideo(string newUrl)
    {
        url = newUrl;
        // Set thumbnail image
        Awake();
    }
    */
    public void SetIndex(int newIndex)
    {
        index = newIndex;
        PausePlay();
    }

    public int GetIndex()
    {
        return index;
    }
    /*
    public string GetUrl()
    {
        return url;
    }
    */
    public int IsOn()
    {
        return isOn;
    }
}
