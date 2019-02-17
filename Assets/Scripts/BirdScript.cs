using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public static BirdScript instance;

    [SerializeField]
    private Rigidbody2D myRigidBody;

    [SerializeField]
    private Animator anim;

    private float fowardSpeed = 3f;

    private float bounceSpeed = 4f;

    private bool didFlag;

    public bool isAlive;

    public Button flapButton;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }
        isAlive = true;

        flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        flapButton.onClick.AddListener(()=> FlapTheBird());
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (isAlive) {
            Vector3 temp = transform.position;
            temp.x += fowardSpeed * Time.deltaTime;
            transform.position = temp;

            if (didFlag) {
                didFlag = false;
                myRigidBody.velocity = new Vector2(0, bounceSpeed);
                anim.SetTrigger("Flap");
            }
        }
    }

    public void FlapTheBird() => didFlag = true;
}
