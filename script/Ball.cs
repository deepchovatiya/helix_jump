using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Ball : MonoBehaviour
{
    Rigidbody body;
    bool istouch = false;
    int score;
    public Text scorebox;
    public GameObject gameover,nextgame;
    int levelno;
    public Material[] mats;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        gameover.SetActive(false);
        nextgame.SetActive(false);
        levelno = PlayerPrefs.GetInt("levelno",1);
        int r = Random.Range(0,mats.Length);    
        RenderSettings.skybox = mats[r];
    }

    void Update()
    {
        if (istouch)
        {
            jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        istouch = true;
        if (collision.gameObject.CompareTag("danger"))
        {
            Time.timeScale = 0;
            gameover.SetActive(true);
        }
        if (collision.gameObject.CompareTag("win"))
        {
            Time.timeScale = 0;
            nextgame.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            score++;
            scorebox.text = "Score " + score;
        }
    }

    void jump()
    {
        if (istouch)
        {
            istouch = false;
            body.velocity = Vector3.zero;
            body.AddForce(Vector3.up * 200);
        }
    }

    public void BtnRetry()
    {
        Time.timeScale = 1;
        gameover.SetActive(false);
        PlayerPrefs.SetInt("levelno",levelno);
        SceneManager.LoadScene("Levelno "+levelno);
    }
    public void BtnNext()
    {
        Time.timeScale = 1;
        nextgame.SetActive(false);
        levelno++;  // Increment level
        PlayerPrefs.SetInt("levelno", levelno);
        PlayerPrefs.Save(); // Save PlayerPrefs to ensure it's stored
        SceneManager.LoadScene("Levelno " + levelno);
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="coin")
        {
            Transform par =other.transform.parent.transform;
            if (par != null)
            {
                foreach(Transform ch in par)
                {
                    ch.GetComponent<MeshCollider>().convex = true;
                    ch.GetComponent<Rigidbody>().isKinematic = false;
                    Destroy(ch.gameObject, 0.5f);
                }
            }
        }
    }
}
