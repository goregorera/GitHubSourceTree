using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class RxManager : MonoBehaviour
{
    [SerializeField] Button _button;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HogeCoroutine());

        // UpdateのObservableを生成し、クリックイベントを検知する
        var mouseDown =
            this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));

        mouseDown
            // 最後にクリックされてから500msの間マウスクリックがなかったときに
            // これまでクリックした回数が２回だったらダブルクリックしたと判定する
            .Buffer(mouseDown.Throttle(TimeSpan.FromMilliseconds(500)))
            .Where(x => x.Count == 2)
            .Subscribe(_ => Debug.Log("ダブルクリックされました"));
        
        Observable.FromCoroutineValue<int>(GetLevelCoroutine, false)
        .Subscribe(
            // yield returnで返したレベルを受け取って処理する、ここではDebug.Logで出力しています
            level => Debug.Log(level)
            // すべて正常に処理し終わった後に呼ばれます
            , () => Debug.Log("OnCompleted")
        );

    }

    private IEnumerator GetLevelCoroutine()
    {
        // レベルの配列
        var levels = new[]
        {
            1,2,3,4,5
        };

        foreach (var level in levels)
        {
            yield return level;
        }
    }

    private IEnumerator HogeCoroutine()
    {
        while (true)
        {
            // Buttonが押されるまで待つ
            yield return _button
                .OnClickAsObservable()
                .Take(1)
                .ToYieldInstruction();

            // 押されたらなにか処理を行う
            Debug.Log("Do Someting");
        }
    }

}

