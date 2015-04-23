using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 
 * base robot state
 * */
public interface IState{

	//进入状态  
	void Enter<T> (T entityType) where T:BaseRobot;
	
	//状态正常执行
	void Execute<T> (T entityType) where T:BaseRobot;
	
	//退出状态
	void Exit<T> (T entityType) where T:BaseRobot;

}
