using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour3 : MonoBehaviour
{
    private float movespeed = 7f;
    private Rigidbody2D rb;
    private SpriteRenderer spriterenderer;
    private SpriteRenderer sprite;
    Color blobcolor;
    string blob_colorname;
    Color part_color;

    Dictionary<string, Color> colorDict = new Dictionary<string, Color>()
{
    { "blue", new Color(0f, 0.6613998f, 1f, 1f) },
    { "green", new Color(0f,1f,0.3267074f) },
    { "white", new Color(81f, 255f, 83f) },
    { "red", new Color(0.6754716f, 0.1065255f, 0f, 1f) }
};
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();     
        spriterenderer.color = colorDict["green"];
        
    }
    private void OnEnable()
    {
        sprite = GetComponent<SpriteRenderer>();
        part_color = sprite.color;
    }
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        rb.linearVelocityX = movespeed*-1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriterenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            blobcolor = spriterenderer.color;

            foreach (var kvp in colorDict)
            {
                if (Mathf.Approximately(kvp.Value.r, spriterenderer.color.r) &&
                    Mathf.Approximately(kvp.Value.g, spriterenderer.color.g) &&
                    Mathf.Approximately(kvp.Value.b, spriterenderer.color.b))
                {
                    blob_colorname = kvp.Key;
                    break;
                }
            }

            Color complementary;
            Color detrimental;
            switch (blob_colorname)
            {

                case "blue":
                    complementary = colorDict["red"];
                    detrimental = colorDict["green"];
                    break;

                case "green":
                    complementary = colorDict["blue"];
                    detrimental = colorDict["red"];
                    break;

                case "red":
                    complementary = colorDict["green"];
                    detrimental = colorDict["blue"];
                    break;

                default:
                    complementary = colorDict["white"];
                    detrimental = colorDict["white"];
                    break;


            }
            if (blobcolor != colorDict["white"])
            {

                if (part_color == blobcolor)
                {

                    GameManagement.Instance.UpdateGUI(1);
                    AudioManagement.Instance.PlayCollect();

                }

                else if (part_color == complementary)
                {

                    GameManagement.Instance.UpdateGUI(2);
                    AudioManagement.Instance.PlayBonus();
                    spriterenderer.color = complementary;

                }

                else if (part_color == detrimental)
                {

                    GameManagement.Instance.UpdateGUI(-2);
                    spriterenderer.color = colorDict["white"];
                    GameManagement.Instance.PanicMode();
                    AudioManagement.Instance.PlayHit();
                }

                else if (part_color == colorDict["white"])
                {

                    GameManagement.Instance.UpdateGUI(-5);
                    spriterenderer.color = colorDict["white"];
                    GameManagement.Instance.PanicMode();
                    AudioManagement.Instance.PlayBigHit();
                }

            }

            else {
                bool panicover = false;

                if (part_color == colorDict["white"])
                {
                    GameManagement.Instance.UpdateLife();
                }
                else if (part_color == colorDict["red"]) {

                    panicover = GameManagement.Instance.PanicModeControl("red");
                
                }
                else if (part_color == colorDict["blue"])
                {

                    panicover = GameManagement.Instance.PanicModeControl("blue");

                }
                else if (part_color == colorDict["green"])
                {

                    panicover=GameManagement.Instance.PanicModeControl("green");

                }

                if (panicover) { 
                    spriterenderer.color = sprite.color;
                    GameManagement.Instance.PanicReset();


                }
            }
        }
        



            if (!collision.CompareTag("particle"))
        {

            gameObject.SetActive(false);
        }
    }
    
}
