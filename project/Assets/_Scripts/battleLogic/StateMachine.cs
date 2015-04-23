using UnityEngine;
using System.Collections;

/**
 * Desmond 
 * state machine controlling robot state switching
 * */

public class StateMachine<T> :IStateMachine where T : BaseRobot{

	//entity
	private T m_pOwner;
	
	private IState m_pCurrentState;
	private IState m_pPreviousState;
	private IState m_pGlobalState;

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

	public void SetGlobalStateState(IState GlobalState)
	{
		m_pGlobalState = GlobalState;
		m_pGlobalState.Enter(m_pOwner);
	}

	public void SetCurrentState(IState CurrentState)
	{
		m_pCurrentState = CurrentState;
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
	
	public void ChangeState(IState pNewState)
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
		//enter current state
		m_pCurrentState.Enter (m_pOwner);
	}
	
	public void RevertToPreviousState ()
	{
		ChangeState (m_pPreviousState);
		
	}

	public IState CurrentState ()
	{
		return m_pCurrentState;
	}
	public IState GlobalState ()
	{
		return m_pGlobalState;
	}
	public IState PreviousState ()
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
