using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;


[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    private TouchInputs _input;

    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void CanceledTouchEvent(Vector2 position, float time);
    public event CanceledTouchEvent OnCanceledTouch;
    public delegate void PerformedTouchEvent(Vector2 position, float time);
    public event PerformedTouchEvent OnPerformedTouch;

    private void Awake()
    {
        _input= new TouchInputs();
    }

    private void OnEnable()
    {
        _input.Enable();
        //EnhancedTouchSupport.Enable();
        //TouchSimulation.Enable();

        //UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
    }
    private void OnDisable()
    {
        _input.Disable();
        //EnhancedTouchSupport.Disable();
        //TouchSimulation.Disable();

        //UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }


    //private void FingerDown(Finger finger)
    //{
    //    Debug.Log("Finger down");
    //    if (OnStartTouch != null) OnStartTouch(finger.screenPosition, Time.time);
    //}

    private void Start()
    {
        _input.Player.Fire.started += ctx => StartTouch(ctx);
        _input.Player.Fire.canceled += ctx => CanceledTouch(ctx);
        _input.Player.Move.performed +=ctx => PerformedTouch(ctx);

    }

    private void PerformedTouch(InputAction.CallbackContext ctx)
    {
        Debug.Log("Performed touch " + _input.Player.Move.ReadValue<Vector2>());
        if (OnPerformedTouch != null) OnPerformedTouch(_input.Player.Move.ReadValue<Vector2>(), (float)ctx.time);
    }

    private void StartTouch(InputAction.CallbackContext ctx)
    {
        Debug.Log("Start touch " + _input.Player.Move.ReadValue<Vector2>());
        if (OnStartTouch != null) OnStartTouch(_input.Player.Move.ReadValue<Vector2>(), (float)ctx.startTime);
    }
    private void CanceledTouch(InputAction.CallbackContext ctx)
    {
        Debug.Log("Touch canceled");
        if (OnCanceledTouch != null) OnCanceledTouch(_input.Player.Move.ReadValue<Vector2>(), (float)ctx.time);
    }

    private void Update()
    {
        //Debug.Log(UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches);
        //foreach(UnityEngine.InputSystem.EnhancedTouch.Touch touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        //{
        //    Debug.Log(touch.phase == UnityEngine.InputSystem.TouchPhase.Began);
        //}
    }
}
