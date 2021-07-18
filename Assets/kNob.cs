using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kNob : MonoBehaviour
{
    public float Score;
    public float jumpForce;
    public string curColoring;
    private Rigidbody2D rb;
    private SpriteRenderer renderer;
    private int index;

    [SerializeField] private Text scoreText;
    [SerializeField] private Color Cyan;
    [SerializeField] private Color Yellow;
    [SerializeField] private Color Pink;
    [SerializeField] private Color Purple;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        Colorize();
    }

    public void Colorize()
    {
        index = Random.RandomRange(0, 3);

        switch (index)
        {
            case 0:
                curColoring = "Cyan";
                renderer.color = Cyan;
                break;
            case 1:
                curColoring = "Yellow";
                renderer.color = Yellow;
                break;
            case 2:
                curColoring = "Pink";
                renderer.color = Pink;
                break;
            case 3:
                curColoring = "Purple";
                renderer.color = Purple;
                break;
        }
    }

    private void Update()
    {
        scoreText.text = Score.ToString();

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);

        if (collision.tag != curColoring)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else if (collision.tag == curColoring)
        {
            Score++;
        }
    }
}
