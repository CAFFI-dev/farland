using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{
    public int howManySongs;
    public bool isPlaying = false;
    public AudioSource[] audios;
    public AudioSource currentTrack;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (!isPlaying)
        {
            isPlaying = true;
            currentTrack = audios[Random.Range(0, audios.Length)];
            currentTrack.Play();
            //toadd: отображение имени песни через функцию
            Wait();
        }
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            isPlaying = false;
            currentTrack.Stop();
        }
    }
    public void Wait()
    {
        if (!currentTrack.isPlaying)
        {
            isPlaying = false; //и щелкнуть переключатель назад
        }
    }
}
