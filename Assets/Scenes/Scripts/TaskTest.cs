using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class TaskTest : MonoBehaviour
{
    void Start()
    {
            // Task task = Task.Run(() => {
            Task.Run(() => {
            HeavyMethod1();
            //  }); 
             }).Wait(); 
            // string result = task.Result;
            
            // task.Join();
            // thread.Join();

            HeavyMethod2();
            // Debug.Log(result);
    }

    static void HeavyMethod1()
    {
        Debug.Log("すごく重い処理その1(´・ω・｀)はじまり");
        Thread.Sleep(5000);
        Debug.Log("すごく重い処理その1(´・ω・｀)おわり");
    }

    // static string HeavyMethod2()
    static void HeavyMethod2()
    {
        Debug.Log("すごく重い処理その2(´・ω・｀)はじまり");
        Thread.Sleep(3000);
        Debug.Log("すごく重い処理その2(´・ω・｀)おわり");

        // return "hoge";
    }
}
