using UnityEngine;
using System.Collections;

public interface IStateMachine {
	
	void SMUpdate ();
	void SetCurrentState(IState CurrentState);
	void ChangeState(IState pNewState);
}
