namespace GoogleSpreadSheet
{
    // https://developers.google.com/sheets/guides/concepts?hl=ja
    public class Settings
    {
        public const string ApiKey = "AIzaSyC3r8RCSgaZkucWqHO5XXx_OhdwPt9DJuo"; // Google API Consoleで作成したAPIキーをここで指定します。
        public const string SheetId = "1kAMGGlP8GeG_WTHOs4JXraENrKPLJ69KxPq2UjB65Tg"; // GoogleスプレッドシートのsheetIDをここで指定します。
        public const string Range = "Sheet1"; // 取得範囲をここで指定します。 ("シート1"など)

        public static bool Active { get { return true; } } // これをfalseにすると変数の上書きが無効になります
    }
}