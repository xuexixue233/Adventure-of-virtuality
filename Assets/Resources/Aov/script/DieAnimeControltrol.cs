using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieAnimeControltrol : MonoBehaviour
{
    public GameObject DieAnime;
    public GameObject dieImage;
    public GameObject UI;
    public float diePictureSpeed;
    public Transform movePos;
    public float waittime = 0;
    public float timer = 0;
    private bool gogogo=false;
    private bool workingstatus = true;
    private bool IsPressR = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            IsPressR = true;
        }
        if (PlayerHealth.isDie)
        {
            GoDieAnime();
            if (IsPressR)
            {
                SceneManager.LoadScene(0);
                GameController.isGameAlive = true;
                GameController.isInvincible = false;
                DieAnime.SetActive(false);
                Destroy(UI);
            }
        }

    }

    void GoDieAnime()
    {
        if (workingstatus)
        {
            timer += Time.deltaTime;
            if (timer > waittime)
            {
                gogogo = true;
            }
            if (timer > waittime)
            {
                workingstatus = false;
            }
        }
        if (gogogo)
        {
            dieImage.transform.position = Vector2.MoveTowards(dieImage.transform.position, movePos.position, diePictureSpeed * Time.deltaTime);
        }
    }
}
