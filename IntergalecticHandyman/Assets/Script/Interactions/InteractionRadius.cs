using TMPro;
using UnityEngine;  


public class InteractionRadius : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshPro interactionText;
    [SerializeField] private float radius;
    
    private void Update()
    {
        InRadius();
    }

    private void InRadius()
    {
        var distanceToTarget = Vector3.Distance(interactionText.transform.position, player.position);

        var targetAlpha = distanceToTarget < radius ? 255 : 0;
        interactionText.color = new Color(255, 255, 255, targetAlpha);
    }
}
