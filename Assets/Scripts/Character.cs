using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum CharacterState { 
        WALKING_UP, WALKING_DOWN,WALKING_LEFT,WALKING_RIGHT,
        FACING_UP, FACING_DOWN, FACING_LEFT, FACING_RIGHT
    }

    public CharacterState currentState = CharacterState.FACING_DOWN;
    private Animator animator;
    public float speed = 40;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = CharacterState.FACING_DOWN;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.W)) {
            currentState = CharacterState.WALKING_UP;
            moveCharacter(currentState, transform, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentState = CharacterState.WALKING_DOWN;
            moveCharacter(currentState, transform, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentState = CharacterState.WALKING_LEFT;
            moveCharacter(currentState, transform, speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentState = CharacterState.WALKING_RIGHT;
            moveCharacter(currentState, transform, speed);
        }


        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
            currentState = 
                currentState == CharacterState.WALKING_UP ? CharacterState.FACING_UP :
                currentState == CharacterState.WALKING_DOWN ? CharacterState.FACING_DOWN :
                currentState == CharacterState.WALKING_LEFT ? CharacterState.FACING_LEFT :
                currentState == CharacterState.WALKING_RIGHT ? CharacterState.FACING_RIGHT : currentState;
        }
        print(currentState);

        animator.SetInteger("CharacterState", (int) currentState);
    }
    public static void moveCharacter(CharacterState currentState, Transform transform, float speed) {
        Vector3 pos = transform.position;
        pos =
                currentState == CharacterState.WALKING_UP ? new Vector3(pos.x, pos.y + speed * Time.deltaTime, pos.z) :
                currentState == CharacterState.WALKING_DOWN ? new Vector3(pos.x, pos.y - speed * Time.deltaTime, pos.z) :
                currentState == CharacterState.WALKING_LEFT ? new Vector3(pos.x - speed * Time.deltaTime, pos.y, pos.z) :
                currentState == CharacterState.WALKING_RIGHT ? new Vector3(pos.x + speed * Time.deltaTime, pos.y, pos.z) : Vector3.zero;
        transform.position = pos;
    }
}
