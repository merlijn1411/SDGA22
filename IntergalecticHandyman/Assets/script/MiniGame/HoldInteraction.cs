using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class HoldInteraction : MonoBehaviour
{
    public float interactionRadius = 3f;

    public Transform playerTransform;

    public TextMeshProUGUI interactionText;

    public Image progressBar;

    public float progressBarWidth = 1000; 

    public Image BackgroundProgressBar;

    public AudioSource Audio;

    public GameObject SignWorking;



    private bool isInRange = false;
    private bool isHoldingInteraction = false;
    private bool isInteractionComplete = false;

    private float interactionHoldTime = 0f;
    private const float requiredHoldTime = 10f;

    public event System.Action OnInteractionComplete;

    private void Start()
    {
        interactionText.gameObject.SetActive(false);
        progressBar.gameObject.SetActive(false);
        BackgroundProgressBar.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isInteractionComplete)
        {
            // Interaction has already been completed, no further interaction allowed
            interactionText.gameObject.SetActive(false);
            progressBar.gameObject.SetActive(false);
            BackgroundProgressBar.gameObject.SetActive(false);
            
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= interactionRadius)
        {
            // Player is within range
            if (!isInRange)
            {
                // Entered interaction range
                isInRange = true;
                interactionText.text = "E";
                interactionText.gameObject.SetActive(true);
                
            }

            if (Input.GetKey(KeyCode.E))
            {
                // Player is holding 'E'
                isHoldingInteraction = true;
                interactionHoldTime += Time.deltaTime;
                BackgroundProgressBar.gameObject.SetActive(true);
                if (!Audio.isPlaying)
                {
                    Audio.Play();
                }
                

                if (interactionHoldTime >= requiredHoldTime)
                {
                    // Interaction held for 10 seconds
                    CompleteInteraction();
                    Audio.Stop();
                    SignWorking.SetActive(false);
                }
                
            }
            else
            {
                // Player released 'E'
                isHoldingInteraction = false;
                interactionHoldTime = 0f;
                BackgroundProgressBar.gameObject.SetActive(false);
                Audio.Stop();
            }
            

            float progress = Mathf.Clamp01(interactionHoldTime / requiredHoldTime);
            float progressBarWidthDelta = progressBarWidth * progress;
            progressBar.rectTransform.sizeDelta = new Vector2(progressBarWidthDelta, progressBar.rectTransform.sizeDelta.y);
            progressBar.rectTransform.localPosition = new Vector3(-progressBarWidth / 2f + progressBarWidthDelta / 2f, 0f, 0f);
            progressBar.gameObject.SetActive(isHoldingInteraction);
        }
        
        else
        {
            // Player is outside range
            if (isInRange)
            {
                // Exited interaction range
                isInRange = false;
                interactionText.gameObject.SetActive(false);
                progressBar.gameObject.SetActive(false);
                BackgroundProgressBar.gameObject.SetActive(false);
            }
        }
        
    }

    private void CompleteInteraction()
    {
        isInteractionComplete = true;
        OnInteractionComplete?.Invoke();
        Debug.Log("Interaction complete!");
    }
}
