using UnityEngine;
using System.Collections;

public class NetFramework {

	// will calling when a package is coming
    public void onMessageReceived(){}
	
	// when connected will calling
	public void onConnected(){}
	
	// when connect time out will calling
	public void onConnectTimeout(){}
	
	// on disconnected will call
	public void onDisconnected(){}

	// set target address
	public void setInetAddress(){}
	
	// the time out of connecting
	public void setSoTimeout(float fSoTimeout){}
	
	// get the time out value
	public float getSoTimeout(){
		return 0;
	}
	
	// send package to target address
	public void send(){}
	
	// check the net status
	public bool isConnected(){
		return false;
	}
	
	// close the socket
	public void close(){}
	
	// connect to target address
	public bool connect(){
		return false;
	}
	
	// disconnect as close for now
	public void disconnect(){}
}
