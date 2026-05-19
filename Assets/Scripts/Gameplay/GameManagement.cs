using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance { get; private set; }

    private pooling pooling;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float fixedY;

    private Vector3 spawnpoint1;
    private float spawntime;
    private float nextspawn;

    private int score;
    [SerializeField] private TextMeshProUGUI scoretext;

    private int life;

    [SerializeField] private GameObject GameOverPanel;

    [SerializeField] private Image collectblue_fill;
    [SerializeField] private Image collectred_fill;
    [SerializeField] private Image collectgreen_fill;
    private float fillamount;

    private bool gotblue;
    private bool gotred;
    private bool gotgreen;
    private bool panicover;

    [SerializeField] private GameObject CollectPart;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);

        }
        Instance = this;

        pooling = GetComponent<pooling>();
        GameOverPanel.SetActive(false);
        CollectPart.SetActive(false);
    }

    private void Start()
    {
        nextspawn = 0 + spawntime;
        score = 0;
        life = 0;
        collectblue_fill.fillAmount = 0;
        collectgreen_fill.fillAmount = 0;
        collectred_fill.fillAmount= 0;
        gotblue = false;
        gotgreen = false;
        gotred = false;
        panicover = false;

        AudioManagement.Instance.PlayBackgroundMusic();
    }


    void Update()
    {
        float randomX = Random.Range(minX, maxX);

        spawnpoint1 = new Vector3(randomX, fixedY, 0);
        spawntime = Random.Range(1.1f, 1.6f);

        if (Time.time >= nextspawn)
        {

            GameObject obj = pooling.GetFromPool();
            if (obj != null)
            {
                obj.transform.position = spawnpoint1;


            }

            nextspawn = Time.time + spawntime;
        }

    }

    public void UpdateGUI(int scr)
    {

        score += scr;
        scoretext.text = $"Score : {score}";
    }
    public void UpdateLife()
    {

        life++;

       /* if (life == 1) { fillamount = .350f; }
        else if (life == 2) { fillamount = .650f; }
        else if (life == 3) { fillamount = 1; }

        lifebar_fill.fillAmount = fillamount;*/

        if (life >= 1)
        {

            GameOver();
        }


    }
    private void GameOver()
    {

        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);
        AudioManagement.Instance.PlayGameOver();

    }

    public bool PanicModeControl(string color)
    {

        if (color == "red") { gotred = true; collectred_fill.fillAmount = 1; }

        if (color == "blue") { gotblue = true; collectblue_fill.fillAmount = 1; }

        if (color == "green") { gotgreen = true; collectgreen_fill.fillAmount = 1; }

        if (gotgreen && gotblue && gotred)
        {

            panicover = true;

        }

        return panicover;
    }
    public void PanicReset()
    {

        gotred = false;
        gotblue = false;
        gotgreen = false;
        collectblue_fill.fillAmount = 0;
        collectgreen_fill.fillAmount = 0;
        collectred_fill.fillAmount = 0;
        panicover = false;

        CollectPart.SetActive(false);

    }
    public void PanicMode()
    {

        CollectPart.SetActive(true);
    }
}