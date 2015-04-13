using UnityEngine;
using System.Collections;

/**
 * Desmond 
 * state machine controlling robot state switching
 * */

public class StateMachine<T>{

	//entity
	private T m_pOwner;
	
	private State<T> m_pCurrentState;
	private State<T> m_pPreviousState;
	private State<T> m_pGlobalState;

	public StateMachine(T owner)
	{
		m_pOwner = owner;
		m_pCurrentState = null;
		m_pPreviousState = null;
		m_pGlobalState = null;
	}

	public void GlobalStateEnter()
	{
		m_pGlobalState.Enter(m_pOwner);
	}

	public void SetGlobalStateState<T>(State<T> GlobalState)
	{
		m_pGlobalState = GlobalState;
		m_pGlobalState.Target = m_pOwner;
		m_pGlobalState.Enter(m_pOwner);
	}

	public void SetCurrentState<T>(State<T> CurrentState)
	{
		m_pCurrentState = CurrentState;
		m_pCurrentState.Target = m_pOwner;
		m_pCurrentState.Enter(m_pOwner);
	}
	public void SMUpdate ()
	{
        //global state
		if (m_pGlobalState != null)
			m_pGlobalState.Execute (m_pOwner);
		
		//normal state
		if (m_pCurrentState != null)
			m_pCurrentState.Execute (m_pOwner);
	}
	
	public void ChangeState<T>(State<T> pNewState)
	{
		if (pNewState == null) {
			
			Debug.LogError ("该状态不存在");
		}
		
		//quit previous state
		m_pCurrentState.Exit(m_pOwner);
		//save previous state
		m_pPreviousState = m_pCurrentState;
		//set current state
		m_pCurrentState = pNewState;
		m_pCurrentState.Target = m_pOwner;
		//enter current state
		m_pCurrentState.Enter (m_pOwner);
	}
	
	public void RevertToPreviousState ()
	{
		ChangeState (m_pPreviousState);
		
	}

	public State<T> CurrentState ()
	{
		return m_pCurrentState;
	}
	public State<T> GlobalState ()
	{
		return m_pGlobalState;
	}
	public State<T> PreviousState ()
	{
		return m_pPreviousState;
	}
	
//	public bool HandleMessage (Telegram msg)
//	{
//		//the message
//		if (m_pCurrentState!=null && m_pCurrentState.OnMessage (m_pOwner, msg)) {
//			return true;
//		}
//		// message to the global state
//		if (m_pGlobalState!=null && m_pGlobalState.OnMessage (m_pOwner, msg)) {
//			return true;
//		}
//		
//		return false;
//	}
}
