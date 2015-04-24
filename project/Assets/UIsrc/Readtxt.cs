using UnityEngine;
using System.Collections;

public class Readtxt : MonoBehaviour {

    public TextAsset T;


	// Use this for initialization
	void Start () {
        ArrayList text = loadtxt(T);
        string[] heroname = loaddata(text, "ID");
        for(int i=0;i<heroname.Length;i++)
        {
            print(heroname[i]);
        }
	}
	


    //从text里读取内容
    ArrayList loadtxt(TextAsset x)
    {
        string y = x.text;
        string line;
        ArrayList arrlist = new ArrayList();
        while (y.Contains("\n"))
        {
            line = y.Substring(0, y.IndexOf("\n")+1);
            y = y.Substring(y.IndexOf("\n") + 1, y.Length - y.IndexOf("\n") - 1);
            //一行一行的读取
            //将每一行的内容存入数组链表容器中
            arrlist.Add(line);
        }
        arrlist.Add(y);
        return arrlist;
    }

    ArrayList loadtxt(string y)                 //配合从assbundle读数据
    {
        string line;
        ArrayList arrlist = new ArrayList();
        while (y.Contains("\n"))
        {
            line = y.Substring(0, y.IndexOf("\n") + 1);
            y = y.Substring(y.IndexOf("\n") + 1, y.Length - y.IndexOf("\n") - 1);
            //一行一行的读取
            //将每一行的内容存入数组链表容器中
            arrlist.Add(line);
        }
        arrlist.Add(y);

        return arrlist;
    }


    //根据关键字得到string数组
    static string[]  loaddata(ArrayList x,string y)
    {

        //记录关键字出现在第几个"	"符号后面
        string a=x[1].ToString();
        int times = 1;

        while (a.Length != 0 && a.Length>y.Length && a.Substring(0, y.Length) != y)
        {
            
            a = a.Substring(a.IndexOf("	")+1, a.Length - a.IndexOf("	")-1);
            times++;
        }
        if (a.Length < y.Length)
        {
            print("没有关键字");
            return null;
        }
        if (a.Length == y.Length && a != y)
        {
            print("没有关键字");
            return null;
        }
        //读出关键字所在列的值存进string数组返回
        string[] arr = new string[x.Count-2];
        for (int i = 2; i < x.Count; i++)
        {
            string b=x[i].ToString();
            for (int j = 0; j < times; j++)
            {
                if (b.Contains("	"))
                {
                    arr[i - 2] = b.Substring(0, b.IndexOf("	"));
                    b = b.Substring(b.IndexOf("	") + 1, b.Length - b.IndexOf("	") - 1);
                }
                else
                {
                    arr[i - 2] = b;
                }
            }
        }
            return arr;
    }

    //从assetBundle里读取txt
    IEnumerator readtxtassbundle(string path)
    {
        WWW bundle = WWW.LoadFromCacheOrDownload(path, 6);

        yield return bundle;

        string result = bundle.assetBundle.mainAsset.ToString();
        result = result.Substring(0, result.IndexOf("*") - 1);



    }




 
}
