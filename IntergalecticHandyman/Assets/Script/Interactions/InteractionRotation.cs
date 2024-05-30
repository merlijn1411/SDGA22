using UnityEngine;

public class InteractionRotation : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Update()
    {
        TextMeshRotation();
    }

    private void TextMeshRotation()
    {
        Vector3 direction =  transform.position - player.position ;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
