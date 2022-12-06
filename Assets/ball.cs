using UnityEngine;
using TMPro;
public class ball : MonoBehaviour
{
    [SerializeField, Range(0.5f, 50)]
    float speed = 3;
    float cachedSpeed;
    Vector3 dir = new Vector3(1, 0, 0);

    TextMeshProUGUI scoreText;

    int player1Goals = 0;
    int player2Goals = 0;

    // Start is called before the first frame update
    void Start()
    {

        cachedSpeed = speed;
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        int x = Random.Range(0, 2);

        if (x == 0)
        {
            x = -1;
        }

        dir = new Vector3(x, Random.Range(-1, 2), 0);
    }
   
        
private void ResetBall()
    {
        speed = cachedSpeed;
        transform.position = new Vector3(0, 0, 0);
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            x = -1;
        }
        dir = new Vector3(x, Random.Range(-1, 2), 0);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        #region Movement



        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
        }
        speed = Mathf.Clamp(speed, 1, 20);
        transform.position += dir * speed * Time.deltaTime;

        #endregion


        scoreText.text = player1Goals + "-" + player2Goals;
        if (transform.position.x > 10.9f)
        {
            print("Player 1 mål");
            ResetBall();
            player1Goals += 1;
        }
        if (transform.position.x < -10.9f)
        {
            print("Player 2 mål");
            ResetBall();
            player2Goals += 1;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed *= 1.02f;

        if (collision.gameObject.tag == "Player")
        {
            
            dir.x *= -1;
            if (transform.position.y > collision.transform.position.y + 0.5f)
            {
                dir.y = 1;
            }
            else if (transform.position.y < collision.transform.position.y - 0.5f)
            {
                dir.y = -1;
            }
            else
            {
                dir.y = 0;
            }
            
            
        }
        else
        {
            dir.y *= -1;
        }




    }
}
