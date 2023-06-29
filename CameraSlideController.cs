//OUTDATED

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSlideController : MonoBehaviour
{
    /*
    public GameObject[] slides;
    private string[] urls;
    private int index;
    private int maxIndex;
    private ImageStreamController imageStreamController;
    public ControlPanelController controlPanelController;

    // Start is called before the first frame update
    void Start()
    {
        urls = new string[slides.Length];
        for (int i = 0; i < slides.Length; i++)
        {
            urls[i] = slides[i].GetComponent<ImageStreamController>().GetUrl();
        }
        imageStreamController = GetComponent<ImageStreamController>();
        maxIndex = urls.Length - 1;
        // Start at 0
        imageStreamController.SetVideo(urls[0]);
        imageStreamController.SetIndex(0);
    }

    public void NextSlide()
    {
        index = imageStreamController.GetIndex();
        Debug.Log("Start Index: " + index);
        // Increment index
        if (index == maxIndex)
        {
            index = 0;
        } else
        {
            index++;
        }
        // Set new video
        //imageStreamController.SetVideo(urls[index], index);
        controlPanelController.SetBigPanelVideo(urls[index]);
        controlPanelController.SetBigPanelIndex(index);
        //imageStreamController.SetVideo(urls[index]);
        //imageStreamController.SetIndex(index);
        Debug.Log("Final Index: " + index);
    }

    public void PreviousSlide()
    {
        index = imageStreamController.GetIndex();
        Debug.Log("Start Index: " + index);
        // Decrement index
        if (index == 0)
        {
            index = maxIndex;
        } else
        {
            index--;
        }
        // Set new video
        //imageStreamController.SetVideo(urls[index], index);
        controlPanelController.SetBigPanelVideo(urls[index]);
        controlPanelController.SetBigPanelIndex(index);
        //imageStreamController.SetVideo(urls[index]);
        //imageStreamController.SetIndex(index);
        Debug.Log("Final Index: " + index);
    }
    */
}
