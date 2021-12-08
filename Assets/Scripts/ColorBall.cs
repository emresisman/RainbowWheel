using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rainbowwheel
{
    enum Colors
    {
        Violet,
        Indigo,
        Blue,
        Green,
        Yellow,
        Orange,
        Red
    }

    public class ColorBall : MonoBehaviour
    {
        [SerializeField] private Colors ballColor;

        public void OnCollisionEnter2D(Collision2D col)
        {
            
            Debug.Log(col.gameObject.name);
            transform.position = new Vector3(0f, 4f, 0f);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
