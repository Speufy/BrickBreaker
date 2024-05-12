using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public int health;
    public SpriteRenderer spriteRenderer;
    public Sprite[] states;
    public bool unbreakable;

    public int points = 100;

    // Start is called before the first frame update
    void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Start()
    {
        if (!this.unbreakable)
        {
            this.health = this.states.Length;
            this.spriteRenderer.sprite = this.states[this.health - 1];
        }
    }
    private void Hit()
    {
        if (this.unbreakable)
        {
            return;
        }
        this.health--;
        if (this.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.spriteRenderer.sprite = this.states[this.health - 1];
        }
        FindObjectOfType<GameManager>().Hit(this);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }
}
