using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 5;
    public Text healthText;

    private void Update ()
    {
        healthText.text = "health: " + health;
    }

    public void Damage ()
    {
        if (health - 1 <= 0)
        {
        }
        
        health = Mathf.Max(0, health - 1);
    }
}
