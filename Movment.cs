using System.Collections;
using System.Collections.Generic;
using System.Xml;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Movment : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int AnimationStateFirstLife;
    private bool First_Life = true;
    private bool Second_Life = false;
    private bool Third_Life = false;
    private bool Fourth_Life= false;
    // [SerializeField] private bool FirstLife = true;
    // [SerializeField] private bool SecondLife = false;
    public Vector3 prev_pos , curr_pos;
    //Player animation states
    Animator _animation;
    string _CurrentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_RUN_LEFT = "Player_Run_Left";
    const string PLAYER_RUN_RIGHT = "Player_Run_Right";
    const string PLAYER_RUN_UP = "Player_Run_Up";
    // const string SECOND_PLAYER_RUN_DOWN = "Second_Player_Run_Down";
    const string SECOND_PLAYER_RUN_LEFT = "Second_Player_Run_Left";
    const string SECOND_PLAYER_RUN_RIGHT ="Second_Player_Run_Right";
    const string SECOND_PLAYER_IDLE = "Second_Player_Idle";
    const string THIRD_PLAYER_RUN_LEFT ="Third_Player_Run_Left";
    const string THIRD_PLAYER_RUN_RIGHT ="Third_Player_Run_Right";
    const string THIRD_LIFE_IDLE = "Third_Player_Idle";
    const string FOURTH_PLAYER_RUN_LEFT = "Fourth_Player_Run_Left";
    const string FOURTH_PLAYER_RUN_RIGHT ="Fourth_Player_Run_Right";
    const string FOURTH_PLAYER_IDLE = "Fourth_Player_Idle";

    void Start()
    {
         _animation = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        CaculateMovement();
     }
    void CaculateMovement(){
       float verticalInput = Input.GetAxis("Vertical");
       float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 Movment = new Vector3(horizontalInput, verticalInput, 0);
        
        transform.Translate(Movment * speed * Time.deltaTime);
        if(First_Life == true){
             if(Input.GetKey("a"))
         {
            ChangeAnimationState(PLAYER_RUN_LEFT);
        }
        else if(Input.GetKey("d"))
        {
            ChangeAnimationState(PLAYER_RUN_RIGHT);
        }
        else if(Input.GetKey("w"))
        {
            ChangeAnimationState(PLAYER_RUN_UP);
        }else{
            ChangeAnimationState(PLAYER_IDLE);
        }
        StartCoroutine(FirstLife());
          }
        if(Second_Life == true){
             if(Input.GetKey("a"))
         {
            ChangeAnimationState(SECOND_PLAYER_RUN_LEFT);
        }
        else if(Input.GetKey("d"))
        {
            ChangeAnimationState(SECOND_PLAYER_RUN_RIGHT);
        }
        else if(Input.GetKey("w"))
        {
            ChangeAnimationState(PLAYER_RUN_UP);
        }else{
            ChangeAnimationState(SECOND_PLAYER_IDLE);
        }
         StartCoroutine(SecondLife());
        }
        if(Third_Life == true){
               if(Input.GetKey("a"))
         {
            ChangeAnimationState(THIRD_PLAYER_RUN_LEFT);
        }
        else if(Input.GetKey("d"))
        {
            ChangeAnimationState(THIRD_PLAYER_RUN_RIGHT);
        }
        else if(Input.GetKey("w"))
        {
            ChangeAnimationState(PLAYER_RUN_UP);
        }else{
            ChangeAnimationState(THIRD_LIFE_IDLE);
        }
        StartCoroutine(ThirdLife());
        }
        if(Fourth_Life == true){
   if(Input.GetKey("a"))
         {
            ChangeAnimationState(FOURTH_PLAYER_RUN_LEFT);
        }
        else if(Input.GetKey("d"))
        {
            ChangeAnimationState(FOURTH_PLAYER_RUN_RIGHT);
        }
        else if(Input.GetKey("w"))
        {
            ChangeAnimationState(PLAYER_RUN_UP);
        }else{
            ChangeAnimationState(FOURTH_PLAYER_IDLE);
        }
        StartCoroutine(ThirdLife());
        }
    }
 IEnumerator FirstLife(){
        yield return new WaitForSeconds(5f);
         Second_Life = true;
         First_Life = false;
    }
    IEnumerator SecondLife(){
           yield return new WaitForSeconds(5f);
           Second_Life = false;
           Third_Life = true;
    }
    IEnumerator ThirdLife(){
             yield return new WaitForSeconds(5f);
           Third_Life = false;
           Fourth_Life = true;
    }

    private void ChangeAnimationState(string newState){
        if(newState == _CurrentState){
            return;
        }
        _animation.Play(newState);

        _CurrentState = newState;
    }

    bool IsAnimationPlaying(Animator _animation,string stateName){
        if(_animation.GetCurrentAnimatorStateInfo(0).IsName(stateName) && 
        _animation.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f){
            return true;
        }else{
            return false;
        }
    }
    // IEnumerator SecondLife(){
    //     yield return new WaitForSeconds(15f);
    //      if(Input.GetKey("a"))
    //      {
    //         ChangeAnimationState(SECOND_PLAYER_RUN_LEFT);
    //     }
    //     else if(Input.GetKey("d"))
    //     {
    //         ChangeAnimationState(SECOND_PLAYER_RUN_RIGHT);
    //     }
    //     else if(Input.GetKey("w"))
    //     {
    //         ChangeAnimationState(PLAYER_RUN_UP);
    //     }else{
    //         ChangeAnimationState(SECOND_PLAYER_IDLE);
    //     }
    // }
    // IEnumerator ThirdLife(){
    //     yield return new WaitForSeconds(15f);
    //      if(Input.GetKey("a"))
    //      {
    //         ChangeAnimationState(PLAYER_RUN_LEFT);
    //     }
    //     else if(Input.GetKey("d"))
    //     {
    //         ChangeAnimationState(PLAYER_RUN_RIGHT);
    //     }
    //     else if(Input.GetKey("w"))
    //     {
    //         ChangeAnimationState(PLAYER_RUN_UP);
    //     }else{
    //         ChangeAnimationState(PLAYER_IDLE);
    //     }
    // }
    // IEnumerator FourthLife(){
    //     yield return new WaitForSeconds(15f);
    //      if(Input.GetKey("a"))
    //      {
    //         ChangeAnimationState(PLAYER_RUN_LEFT);
    //     }
    //     else if(Input.GetKey("d"))
    //     {
    //         ChangeAnimationState(PLAYER_RUN_RIGHT);
    //     }
    //     else if(Input.GetKey("w"))
    //     {
    //         ChangeAnimationState(PLAYER_RUN_UP);
    //     }else{
    //         ChangeAnimationState(PLAYER_IDLE);
    //     }
    // }

}
