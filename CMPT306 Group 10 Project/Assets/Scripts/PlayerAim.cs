using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] private FieldOfView fov;
    private float rotateZ;
    [SerializeField] private Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    public GameObject Player;
    public GameObject throwOrigin;
    Transform transform;

    private void Awake()
    {
        transform = Player.GetComponent<Transform>();
        spriteRenderer = Player.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Aim();
        
        // Debug.Log(rotateZ);
    }

  
    private void Aim()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();

        rotateZ = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        throwOrigin.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        

        spriteRotation();
        fov.SetAimDirection(direction);
        
        

    }

    private void spriteRotation()
    {

        Vector3 localScale = Vector3.one;
        // Front Facing Left
        if (rotateZ >= 160f && 180f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[5];
            //Debug.Log("Dir Changed 1");
        }
        // More-Left Facing
        else if (rotateZ >= -105f && -85f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[2];
            //Debug.Log("Dir Changed 2");
        }
        // Directly Left Facing
        else if (rotateZ >= -85f && -10f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[3];
            //Debug.Log("Dir Changed 3");
        }
        else if (rotateZ >= 95f && 115f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[6];
        }
        // Back Left 
        else if (rotateZ >= -9f && 15f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[4];
        }
        else if (rotateZ >= -140f && -106f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (rotateZ >= 90f && 120f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[0];
        }
        // Back Right
        else if (rotateZ >= 16f && 30f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[8];
            //localScale.x = -1;
            //transform.localScale = localScale;
        }
        // Directly Right
        else if (rotateZ >= 80f && 100f >= rotateZ)
        {
            spriteRenderer.sprite = sprites[7];
        }
        // More Right Facing

    }
}
