using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    // Start is called before the first frame update
    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;
    private Vector2 trajectoryOrigin;
    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;
    //menentukan gaya awal yang diberikan pada bola
    public float gaya = 50;

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }

    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;
 
        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float y = Random.Range(-yInitialForce, yInitialForce);

        //komponen x gaya dorong adalah hasil perhitungan vektor dari kuadrat besar gaya yang ingin diberikan dikurangi kuadrat besar gaya komponen y
        float x = Mathf.Sqrt(gaya*gaya - y*y);

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

        // Jika nilainya di bawah 1, bola bergerak ke kiri. 
        // Jika tidak, bola bergerak ke kanan.
        if (randomDirection < 1.0f)
        {
            // Gunakan gaya untuk menggerakkan bola ini.
            rigidBody2D.AddForce(new Vector2(-x, y));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(x, y));
        }
    }

    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();
 
        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
 
        // Mulai game
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
