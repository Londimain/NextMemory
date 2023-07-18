//https://youtu.be/lgy1hvb2xqQ
using UnityEngine;
public class MoveObject : MonoBehaviour
{
    public float speed = 3f;
private void Update()
    {
        transform.Translate (Vector2.right * speed * Time.deltaTime);
    }
}
