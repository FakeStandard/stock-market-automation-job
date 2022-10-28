
namespace SMAJ_Model
{
    /// <summary>
    /// 每日收盤資訊 JSON 對應欄位
    /// </summary>
    public class DailyQuotesInfo
    {
        public string stat { get; set; }

        public List<string> field9 { get; set; }

        public List<List<string>> data9 { get; set; }
    }
}
