using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 状态机接口
 * */
public interface IStateMachine {
	
	void SMUpdate ();
	void SetCurrentState(IState CurrentState);
	void ChangeState(IState pNewState);
}
