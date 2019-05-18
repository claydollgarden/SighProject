namespace GoogleSpreadSheet.Sample
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    [GetSheet]
    public class TestBehaviour : MonoBehaviour
    {
        public Text line1;
        public Text line2;
        public Text line3;
        public Text line4;
        public Text line5;
        public Text line6;
        public Text line7;
        public Text line8;
        public Text line9;
        public Text line10;
        public Text line11;
        public Text line12;
        public Text line13;
        public Text line14;
        public Text line15;
        public Text line16;
        public Text line17;
        public Text line18;
        public Text line19;
        public Text line20;
        public Text line21;
        public Text line22;

        [GetSheet("1번라인")] private string _line1;
        [GetSheet("2번라인")] private string _line2;
        [GetSheet("3번라인")] private string _line3;
        [GetSheet("4번라인")] private string _line4;
        [GetSheet("5번라인")] private string _line5;
        [GetSheet("6번라인")] private string _line6;
        [GetSheet("7번라인")] private string _line7;
        [GetSheet("8번라인")] private string _line8;
        [GetSheet("9번라인")] private string _line9;
        [GetSheet("10번라인")] private string _line10;
        [GetSheet("11번라인")] private string _line11;
        [GetSheet("12번라인")] private string _line12;
        [GetSheet("13번라인")] private string _line13;
        [GetSheet("14번라인")] private string _line14;
        [GetSheet("15번라인")] private string _line15;
        [GetSheet("16번라인")] private string _line16;
        [GetSheet("17번라인")] private string _line17;
        [GetSheet("18번라인")] private string _line18;
        [GetSheet("19번라인")] private string _line19;
        [GetSheet("20번라인")] private string _line20;
        [GetSheet("21번라인")] private string _line21;
        [GetSheet("22번라인")] private string _line22;

        IEnumerator Start()
        {
            while (SpreadSheetLoader.IsLoading)
            {
                yield return null;
            }

            line1.text = _line1;
            line2.text = _line2;
            line3.text = _line3;
            line4.text = _line4;
            line5.text = _line5;
            line6.text = _line6;
            line7.text = _line7;
            line8.text = _line8;
            line9.text = _line9;
            line10.text = _line10;
            line11.text = _line11;
            line12.text = _line12;
            line13.text = _line13;
            line14.text = _line14;
            line15.text = _line15;
            line16.text = _line16;
            line17.text = _line17;
            line18.text = _line18;
            line19.text = _line19;
            line20.text = _line20;
            line21.text = _line21;
            line22.text = _line22;

            Debug.Log(" ArrayCount : " + SpreadSheetLoader.GetArrayCount().ToString());

            Debug.LogFormat("_line1 = {0}", _line1);
            Debug.LogFormat("_line2 = {0}", _line2);
            Debug.LogFormat("_line3 = {0}", _line3);
            Debug.LogFormat("_line4 = {0}", _line4);
            Debug.LogFormat("_line5 = {0}", _line5);
            Debug.LogFormat("_line6 = {0}", _line6);
            Debug.LogFormat("_line7 = {0}", _line7);
            Debug.LogFormat("_line8 = {0}", _line8);
            Debug.LogFormat("_line9 = {0}", _line9);
            Debug.LogFormat("_line10 = {0}", _line10);
            Debug.LogFormat("_line11 = {0}", _line11);
            Debug.LogFormat("_line12 = {0}", _line12);
            Debug.LogFormat("_line13 = {0}", _line13);
            Debug.LogFormat("_line14 = {0}", _line14);
            Debug.LogFormat("_line15 = {0}", _line15);
            Debug.LogFormat("_line16 = {0}", _line16);
            Debug.LogFormat("_line17 = {0}", _line17);
            Debug.LogFormat("_line18 = {0}", _line18);
            Debug.LogFormat("_line19 = {0}", _line19);
            Debug.LogFormat("_line20 = {0}", _line20);
            Debug.LogFormat("_line21 = {0}", _line21);
            Debug.LogFormat("_line22 = {0}", _line22);
        }
    }
}