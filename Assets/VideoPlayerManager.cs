using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public List<GameObject> VideoList = new List<GameObject>();

    public Sprite Mute;
    public Sprite UnMute;

    public GameObject MuteButton;

    private int _currentPlayer = 0;

    void Start()
    {
        for (int i = _currentPlayer + 1; i < VideoList.Count; i++)
        {
            VideoList[i].SetActive(false);
        }
    }

    public void Play()
    {
        VideoList[_currentPlayer].GetComponent<VideoPlayer>().Play();
    }

    public void Pause()
    {
        VideoList[_currentPlayer].GetComponent<VideoPlayer>().Pause();
    }

    public void MuteUnMute()
    {
        if (VideoList[_currentPlayer].GetComponent<VideoPlayer>().GetDirectAudioMute(0))
        {
            VideoList[_currentPlayer].GetComponent<VideoPlayer>().SetDirectAudioMute(0, false);
            MuteButton.GetComponent<Image>().sprite = UnMute;
        }
        else
        {
            VideoList[_currentPlayer].GetComponent<VideoPlayer>().SetDirectAudioMute(0, true);
            MuteButton.GetComponent<Image>().sprite = Mute;
        }
    }

    public void Next()
    {
        int prevPlayerID;
        prevPlayerID = _currentPlayer;

        _currentPlayer++;

        if (_currentPlayer == VideoList.Count)
        {
            _currentPlayer = 0;
        }

        VideoList[prevPlayerID].SetActive(false);
        VideoList[_currentPlayer].SetActive(true);

        Play();
    }

    public void Prev()
    {
        int prevPlayerID;
        prevPlayerID = _currentPlayer;

        _currentPlayer--;

        if (_currentPlayer < 0)
        {
            _currentPlayer = VideoList.Count - 1;
        }

        VideoList[prevPlayerID].SetActive(false);
        VideoList[_currentPlayer].SetActive(true);

        Play();
    }
}
