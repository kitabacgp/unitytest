using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class CSVReader : MonoBehaviour {
    //敵データ格納用の配列データ(とりあえず初期値はnull値)
    public string[,] stageEnemyDatas = null;

    //読み込めたか確認の表示用の変数
    [System.NonSerialized]
    public int height = 0;
    [System.NonSerialized]
    public int width = 0;    //列数
    
    public TextAsset csvData;

    //CSVデータ読み込み関数
    //引数：データパス
    private string[,] readCSVData()
    {
        //返り値の２次元配列
        string[,] readStrData;
        
        string strStream = csvData.text;

        //StringSplitOptionを設定(要はカンマとカンマに何もなかったら格納しないことにする)
        System.StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;

        //行に分ける
        string[] lines = strStream.Split(new char[] { '\r', '\n' }, option);

        //カンマ分けの準備(区分けする文字を設定する)
        char[] spliter = new char[1] { ',' };

        //行数設定
        int heightLength = lines.Length;
        //列数設定
        int widthLength = lines[0].Split(spliter, option).Length;

        //返り値の2次元配列の要素数を設定
        readStrData = new string[heightLength, widthLength];

        //カンマ分けをしてデータを完全分割
        for (int i = 0; i < heightLength; i++)
        {
            for (int j = 0; j < widthLength; j++)
            {
                //カンマ分け
                string[] readData = lines[i].Split(spliter, option);
                readStrData[i, j] = readData[j];
            }
        }

        //確認表示用の変数(行数、列数)を格納する
        this.height = heightLength;    //行数   
        this.width = widthLength;     //列数

        //返り値
        return readStrData;
    }

    //確認表示用の関数
    //引数：2次元配列データ,行数,列数
    private void WriteMapDatas(string[,] arrays, int hgt, int wid)
    {
        for (int i = 0; i < hgt; i++)
        {

            for (int j = 0; j < wid; j++)
            {
                //行番号-列番号:データ値 と表示される
                Debug.Log(i + "-" + j + ":" + arrays[i, j]);
            }
        }
    }

    void Awake()
    {
        int a;
        //データを読み込む(引数：データパス)
        this.stageEnemyDatas = readCSVData();

        //WriteMapDatas(this.stageEnemyDatas, this.height, this.width);
    }

    void Update()
    {

    }
}
