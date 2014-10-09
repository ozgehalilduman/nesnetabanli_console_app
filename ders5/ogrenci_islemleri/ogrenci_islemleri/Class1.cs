using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ogrenci_islemleri
{
    /// <summary>
    /// ogrencilerin temel propertylerinin-özelliklerinin tanımlandığı kısım
    /// </summary>
    public class ogrenci
    {
        public string ad;
        public string soyad;
        public string sinif;
        public string okulno;
        public char cinsiyet;
        public byte boy;
        public byte kilo;
    }
    /// <summary>
    /// ogrencilerle ilgili işlemlerin eylemlerin tanımlandığı kısım...
    /// </summary>
    public class ogrenci_islemler
    {
        List<ogrenci> ogr_lst = new List<ogrenci>();
        /// <summary>
        /// yeni ogrenci ekleme metodu-eylemi
        /// </summary>
        public void ogrenci_ekle()
        {
            ogrenci ogr = new ogrenci();
            Console.Write("\tAdınızı Giriniz\t\t\t: ");
            ogr.ad = Console.ReadLine();
            Console.Write("\tSoyadınızı Giriniz\t\t: ");
            ogr.soyad = Console.ReadLine();
            Console.Write("\tSınıfınızı Giriniz\t\t: ");
            ogr.sinif = Console.ReadLine();
            Console.Write("\tOkul Numaranızı Giriniz\t\t: ");
            ogr.okulno = Console.ReadLine();
            Console.Write("\tCinsiyetinizi Giriniz(E/B)\t: ");
            ogr.cinsiyet =Convert.ToChar(Console.ReadLine());
            Console.Write("\tBoyunuzu Giriniz\t\t: ");
            ogr.boy = Convert.ToByte(Console.ReadLine());
            Console.Write("\tKilonuzu Giriniz\t\t: ");
            ogr.kilo = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("-----------------------------");
            //girilen ogrenciyi listeye ekliyorum..
            ogr_lst.Add(ogr);
        }
        /// <summary>
        /// Mevcut Kayıtlı Öğrencileri listeme komutu
        /// </summary>
        public void ogrenci_listele()
        {
            int sayac = 0;
            foreach(ogrenci _ogr in ogr_lst)
            {
                sayac++;
                Console.WriteLine("{0}. ÖGRENCİ KAYDI\n---------------------",sayac);
                Console.WriteLine("AD-SOYAD\t: {0} {1}",_ogr.ad,_ogr.soyad);
                Console.WriteLine("SINIFI\t\t: {0}", _ogr.sinif);
                Console.WriteLine("OKULNO\t\t: {0}", _ogr.okulno);
                Console.WriteLine("CİNSİYETİ\t: {0}", _ogr.cinsiyet=='e'?"BAY":"BAYAN");
                Console.WriteLine("BOYU\t\t: {0}",_ogr.boy);
                Console.WriteLine("KİLO\t\t: {0}", _ogr.kilo);
                Console.WriteLine("OBEZİTE DURUM\t: {0}", obezite_kontrol(_ogr.kilo,_ogr.boy));
            }
            if (sayac == 0) 
            {
                Console.WriteLine("==== KAYITLI OGRENCİ YOK ====");
            }
        }
        /// <summary>
        /// ozbezite indeksine göre 2.5 girilen boy ve kilo değerlerine göre obezite durumunu belirler
        /// </summary>
        /// <param name="kilo">Kişinin Kilo bilgisi</param>
        /// <param name="boy">Kişinin boy bilgisi</param>
        /// <returns></returns>
        public string obezite_kontrol(byte kilo,byte boy)
        { 
            double endeks=(double)boy/(double)kilo;
            return endeks < 2.5 ? "NORMAL" : "OBEZ";
        }
    }

}
