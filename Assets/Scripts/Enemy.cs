using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public GameObject explosionPrefab;

    void Update()
    {
        if (transform.position.y < -7f)
        {
            DestroyMe();
        }
        
        transform.Translate(Vector2.down * (Time.deltaTime * speed));
    }

    private void DestroyMe ()
    {
        Destroy(gameObject);
        GameObject fx = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(fx, 0.433f);
        SendMessageUpwards("ChildDestroyed");     
    }
    
    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.collider.GetComponent<Health>().Damage();
        }
        
        DestroyMe();
    }
}

