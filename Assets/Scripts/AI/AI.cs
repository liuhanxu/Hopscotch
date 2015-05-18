using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour 
{
    public float[] xMargin = {-0.4f,0.4f};
    public float[] yMargin = { -0.04f, 0.06f };
    public float[] zMargin = { -0.1f, 0.1f };

    Animator animator = null;
    Vector3 direction = Vector3.one;
    float k = 0.01f;

    float timeMachine = 0;
    float timeClock = 3;

	// Use this for initialization
	void Start () 
    {
        animator = gameObject.GetComponent<Animator>();
        //Play("fly");
	}
	
	// Update is called once per frame
	void Update () 
    {
        timeMachine += Time.deltaTime;
        if (timeMachine > timeClock)
        {
            timeClock = Random.Range(1, 3);
            float dx = Random.Range(-1,1);
            float dy = Random.Range(-1,1);
            float dz = Random.Range(-1,1);
            //direction += new Vector3(dx, dy, dz)*k; 
        }
        Move();
	}

    /// <summary>
    /// 移动
    /// </summary>
    void Move()
    {
        if (transform.position.x < xMargin[0] || transform.position.x > xMargin[1])
        {
            direction = new Vector3(-direction.x, direction.y, direction.z);
        }

        if (transform.position.y < yMargin[0] || transform.position.y > yMargin[1])
        {
            direction = new Vector3(direction.x, -direction.y, direction.z);
        }

        if (transform.position.z < zMargin[0] || transform.position.z > zMargin[1])
        {
            direction = new Vector3(direction.x, direction.y, -direction.z);
        }
        transform.LookAt(direction);
        transform.Translate(direction * Time.deltaTime*k);
    }

    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="animation"></param>
    void Play(string animation)
    {
        if (animator)
        {
            animator.Play(animation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("name:" + other.name);
        direction = -direction;
    }
}
