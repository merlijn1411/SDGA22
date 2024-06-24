using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class HoldInteraction : MonoBehaviour
{
    [SerializeField] private Scrollbar progressBar;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private float chargeSpeed;
    [SerializeField] private AudioSource interactionSounds;

    private bool _isFilling = false;
    private float _chargeValue = 0f;

    public UnityEvent taskComplete;
    

    public void Interaction_started()
    {
        _isFilling = true; 
        interactionSounds.Play();
        progressBar.gameObject.SetActive(true);
    }

    public void Interaction_canceled()
    {
        interactionSounds.Stop();
        _isFilling = false; 
    }
    
    private void Update()
    {
        if(_isFilling)
        {
            Fill();
        }
        else
        {
            Empty();
        }

        UpdateProgressBar();
    }

    private void Fill()
    {
        _chargeValue += chargeSpeed * Time.deltaTime;
        if (_chargeValue > 1) 
        {
            progressBar.gameObject.SetActive(false);
            taskComplete.Invoke();
            _chargeValue = 1;
        }
    }

    private void Empty()
    {
        _chargeValue -= chargeSpeed * Time.deltaTime;
        if (_chargeValue < 0)
        {
            _chargeValue = 0;
        }
    }

    private void UpdateProgressBar()
    {
        progressBar.size = _chargeValue;
        progressText.text = (_chargeValue * 100).ToString("0.0") + "%";
    }
}
