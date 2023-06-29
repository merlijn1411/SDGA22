using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed ;

    private AudioSource Audio;

    private void Start()
    {
        
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(input * Time.deltaTime * movementSpeed);

        StartCoroutine(LoopAudio());

    }
    IEnumerator LoopAudio()
    {
        Audio = GetComponent<AudioSource>();
        float length = Audio.clip.length;

        while (true)
        {
            Audio.Play();
            yield return new WaitForSeconds(length);
        }
    }
}
