using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    Texture2D blk;
    public bool fade;
    public float alph;

    void Start()
    {
        //make a tiny black texture
        blk = new Texture2D(1, 1);
        blk.SetPixel(0, 0, new Color(0, 0, 0, 0));
        blk.Apply();
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blk);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 1, -10);
    }

    public void FadeToBlack()
    {
        if (alph > 0)
        {
            alph -= Time.deltaTime * .2f;
            if (alph < 0) { alph = 0f; }
            blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
            blk.Apply();
        }
    }

    public void BlacktoGame()
    {
        if (fade)
        {
            if (alph < 1)
            {
                alph += Time.deltaTime * .2f;
                if (alph > 1) { alph = 1f; }
                blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
                blk.Apply();
            }
        }
    }
}
