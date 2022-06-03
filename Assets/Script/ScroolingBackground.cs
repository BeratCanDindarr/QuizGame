using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroolingBackground : MonoBehaviour
{
    public float YildizSpeed;
    public Renderer YildizRend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        YildizRend.material.mainTextureOffset += new Vector2(YildizSpeed * Time.deltaTime, 0f);    
    }
}
