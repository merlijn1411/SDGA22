using UnityEngine;  


public class InteractionRadius : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] interactionText;
    [SerializeField] private float radius;
    
    private void Update()
    {
        InRadius();
    }

    private void InRadius()
    {
        foreach (var Text in interactionText)
        {
            var distanceToTarget = Vector3.Distance(Text.transform.position, player.position);

            var inRange = distanceToTarget < radius ? true : false;
            
            Text.SetActive(inRange);
        }
    }
}
