using UnityEngine;
using System.Collections;

public class GameNetManagement : NetFramework {
	protected bool _selfDisConnect;

	protected short _svrid;//向哪个服务器登录
		
		//平台预留接口
	protected long _tokenId;//用户ID
	protected string _tokenKey;//口令

	protected string _ticketKey;//发送加密明钥
		
	protected long _lastNetTickTime;//上次发送心跳时间
	protected int _netdelay;
	protected long _serverTime;
		
	protected long _connectSuccessTime;
	protected bool _bLoginSuccess;

		//    string _DevID;
		//    string _deviceOSVision;
		//    string _deviceType;
		//    string _channel;
		//    string _idfa;
		//    string _imei;
		//    string _macAdd;
		//    string _uid;

    protected void sendTick(){}
		
	protected void reConnect(){}
		//解析系统协议
	protected void secretKeyResponse(){}//密钥获得
	protected void svrTickResponse(){}//接受tick 心跳包
	protected void LoginSuccessResponse(){}//登陆成功
	protected void serverCloseResponse(){}//服务器关闭，收到后需要客户端主动去关闭
	protected void serverUnusualResponse(){}///服务端发生未知异常
	protected void svrNeedTick(){}//服务端告知已经很久没有收到客户端的tick
	protected void svrverClassResponse(){}//获得服务器类结构

	public void update(float dt){}
		
	public static GameNetManagement sharedDelegate(){
		     if(s_Management==null){
			      s_Management=new GameNetManagement();
		     }

		     return s_Management;
	}

	public static void DestroyInStance(){}
		
	public void onMessageReceived(){}
	public void onConnected(){}
	public void onConnectTimeout(){}
	public void onDisconnected(){}
	public void onExceptionCaught(){}
		
	public void send(){}
	public void setDeviceID(string aID){}
	public void setTicketKey(string value){}
	public void setTokenId(long value){}
	public void setTokenKey(string value){}
	public void setSvrid(short value){}
		
	public long getServerTime(){
		return 0;
	}
	public long getServerTimeSecond(){
		return 0;
	}
	public int getLocalTime(){
		return 0;
	}//Desmond 获取本地时间
		
	public const string GAME_NETRECONNECT="";
	public const string GAME_NETLOGIN="";
	public const string GAME_NETDISCONNECT="";
	public const string GAME_CONNECTTIMEOUT="";

    private static GameNetManagement s_Management=null;
	private GameNetManagement(){}
}
