using UnityEngine;

public class MapBorders : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 newPosition = other.transform.position;
            newPosition.x = Mathf.Clamp(newPosition.x, transform.position.x - 0.5f, transform.position.x + 0.5f);
            newPosition.y = Mathf.Clamp(newPosition.y, transform.position.y - 0.5f, transform.position.y + 0.5f);
            other.transform.position = newPosition;
        }
    }
}