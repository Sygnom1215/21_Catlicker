//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SoleEffect : MonoBehaviour
//{
//    SpriteRenderer sprite;
//    Vector2 direction;
//    [SerializeField]
//    private float speed = 0.1f;
//    [SerializeField]
//    private float sizeSpeed = 1f;
//    [SerializeField]
//    private float colorSpeed=1f;
//    [SerializeField]
//    private Color[] color;

//    private float minSize = 0.1f;
//    private float maxSize = 0.3f;



//    void Start()
//    {
//        sprite = GetComponent<SpriteRenderer>();
//        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
//        float size = Random.Range(minSize, maxSize);
//        transform.localScale = new Vector2(size, size);
//        sprite.color = color[Random.Range(0, color.Length)];
//    }

//    void Update()
//    {
//        transform.Translate(direction * speed);
//        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.deltaTime * sizeSpeed);

//        Color color = sprite.color;
//        color.a = Mathf.Lerp(sprite.color.a, 0, Time.deltaTime * colorSpeed);
//        sprite.color = color;

//        if (sprite.color.a <= 0.01f)
//        {
//            Destroy(gameObject);
//        }
//    }
//}
