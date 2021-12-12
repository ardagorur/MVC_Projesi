using System.Collections.Generic;

namespace Ilk_Mvc_Projesi.Models
{
    public class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
    }

    public static class UrunManager
    {
        public static List<Urun> GetUrunler()
        {
            var list = new List<Urun>();
            list.Add(new Urun()
            {
                Ad = "Kitap",
                Fiyat = 15
            });
            list.Add(new Urun()
            {
                Ad = "Defter",
                Fiyat = 7
            });
            list.Add(new Urun()
            {
                Ad = "Kalem",
                Fiyat = 5
            });
            return list;
        }
    }
}
