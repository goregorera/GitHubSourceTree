using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class ThreadTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // static void Main(string[] args)
        // {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                HeavyMethod1();
            }));

            thread.Start();

            HeavyMethod2();

            // Console.ReadLine();
    }

    static void HeavyMethod1()
    {
        // Console.WriteLine("すごく重い処理その1(´・ω・｀)はじまり");
        Debug.Log("すごく重い処理その1(´・ω・｀)はじまり");
        Thread.Sleep(5000);
        Debug.Log("すごく重い処理その1(´・ω・｀)おわり");
    }

    static void HeavyMethod2()
    {
        Debug.Log("すごく重い処理その2(´・ω・｀)はじまり");
        Thread.Sleep(3000);
        Debug.Log("すごく重い処理その2(´・ω・｀)おわり");
    }
}
