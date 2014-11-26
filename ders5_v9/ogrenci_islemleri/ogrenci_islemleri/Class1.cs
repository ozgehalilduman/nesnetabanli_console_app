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
        //şimdilik baslangıç degerleri ekliyorum...      
        /// <summary>
        /// YAPILANDIRICI METODUM
        /// </summary>
        public ogrenci_islemler()
        {
            ogr_lst.Add(new ogrenci() {ad="ali",soyad="aligiller",sinif="TL-11",okulno="1234",cinsiyet='e',boy=170,kilo=65 });
            ogr_lst.Add(new ogrenci() { ad = "veli", soyad = "aligiller", sinif = "TL-11", okulno = "1234", cinsiyet = 'e', boy = 170, kilo = 65 });
            ogr_lst.Add(new ogrenci() { ad = "ali", soyad = "veligiller", sinif = "TL-11", okulno = "1234", cinsiyet = 'e', boy = 170, kilo = 65 });
            ogr_lst.Add(new ogrenci() { ad = "deli", soyad = "aligiller", sinif = "TL-11", okulno = "1234", cinsiyet = 'e', boy = 170, kilo = 65 });
            ogr_lst.Add(new ogrenci() { ad = "ali", soyad = "deligiller", sinif = "TL-11", okulno = "1234", cinsiyet = 'e', boy = 170, kilo = 65 });
        }

        /// <summary>
        /// yeni ogrenci ekleme metodu-eylemi
        /// </summary>
        public void ogrenci_ekle()
        {
            string hata = "";
            ogrenci ogr = new ogrenci();
            Console.Write("\tAdınızı Giriniz\t\t\t: ");
            ogr.ad = Console.ReadLine();
            bool kontrol_Ad = ogr.ad.All(c => char.IsLetter(c));
            if (!kontrol_Ad) { hata += "ADI alanına HATALI Giriş\n"; }

            Console.Write("\tSoyadınızı Giriniz\t\t: ");
            ogr.soyad = Console.ReadLine();
            bool kontrol_Soyad = ogr.soyad.All(c => char.IsLetter(c));
            if (!kontrol_Soyad) { hata += "SOYADI alanına HATALI Giriş\n"; }

            Console.Write("\tSınıfınızı Giriniz\t\t: ");
            ogr.sinif = Console.ReadLine();           

            Console.Write("\tOkul Numaranızı Giriniz\t\t: ");
            ogr.okulno = Console.ReadLine();
            bool kontrol_Okulno = ogr.okulno.All(c => char.IsNumber(c));
            if (!kontrol_Okulno) { hata += "OKULNO alanına HATALI Giriş\n"; }

            try
            {
                Console.Write("\tCinsiyetinizi Giriniz(E/B)\t: ");
                ogr.cinsiyet = Convert.ToChar(Console.ReadLine().ToUpper());
                //girilen degerin sayısal olması durumunda hata urettiriyorum...
                if (ogr.cinsiyet!='E'&&ogr.cinsiyet!='B')
                {
                    throw new Exception();
                }
            }
            catch
            {
                hata += "CİNSİYET Alanına HATALI Giriş \n";
            }
            bool kontrol_Cinsiyet = char.IsLetter(ogr.cinsiyet);
            try {
                Console.Write("\tBoyunuzu Giriniz\t\t: ");
                ogr.boy = Convert.ToByte(Console.ReadLine());
            }
            catch 
            {
                 hata+="BOY Alanına HATALI Giriş \n";
            }
            try {
                Console.Write("\tKilonuzu Giriniz\t\t: ");
                ogr.kilo = Convert.ToByte(Console.ReadLine());
            }
            catch
            {
                hata += "KİLO Alanına HATALI Giriş \n";
            }
            Console.WriteLine("-----------------------------");
            //girilen ogrenciyi listeye ekliyorum..
            if (hata == "")
            {
                ogr_lst.Add(ogr);
            }
            else
            {
                Console.WriteLine("*******HATALAR*********");
                Console.WriteLine(hata);
                Console.WriteLine("***********************");            
            }
            
        }

        /// <summary>
        /// Belirtilen adet yeni ogrenci ekleme metodu-eylemi
        /// </summary>
        /// <param name="adet">KAç adet Öğrenci Ekleneceğini Belirliyorum</param>
        public void ogrenci_ekle(int adet)
        {
            for (int s = 0; s < adet; s++)
            {
                ogrenci_ekle();
            }
           //Bu metot ile hem parametre kullanıma hemde OVERLOAD a ornek vermiş olduk      
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
        /// Belirli sıradaki ogrenciyi ekrana yazan metot
        /// </summary>
        /// <param name="kacinci"></param>
        public void ogrenci_listele(int kacinci)
        {
            Console.WriteLine("{0}. ÖGRENCİ KAYDI\n---------------------", kacinci);
            try { 
                ogrenci _ogr = ogr_lst[kacinci-1];

                Console.WriteLine("AD-SOYAD\t: {0} {1}", _ogr.ad, _ogr.soyad);
                Console.WriteLine("SINIFI\t\t: {0}", _ogr.sinif);
                Console.WriteLine("OKULNO\t\t: {0}", _ogr.okulno);
                Console.WriteLine("CİNSİYETİ\t: {0}", _ogr.cinsiyet == 'e' ? "BAY" : "BAYAN");
                Console.WriteLine("BOYU\t\t: {0}", _ogr.boy);
                Console.WriteLine("KİLO\t\t: {0}", _ogr.kilo);
                Console.WriteLine("OBEZİTE DURUM\t: {0}", obezite_kontrol(_ogr.kilo, _ogr.boy));
            }
            catch
            {
                Console.WriteLine("==== KAYITLI OGRENCİ YOK ====");
            }
        }
        
        /// <summary>
        /// Girilen isme göre listeleme yapıyor
        /// </summary>
        /// <param name="ad">aranılan isim</param>
        /// <return>Geriye bulunan öğrencilerin listesini döndürür</return>
        public List<ogrenci> ogrenci_listele(string ad)
        {
            List<ogrenci> bulunan_ogrler = new List<ogrenci>();
            bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.ad == ad);
            Console.WriteLine("BULUNAN KAYITLAR\n============");
            int sayac = 0;
            foreach (ogrenci b_ogr in bulunan_ogrler)
            {
                sayac++;
                Console.WriteLine("{0}. Bulunan OGRENCİ\t:{1} sınıfından {2} nolu {3} {4}", sayac, b_ogr.sinif, b_ogr.okulno, b_ogr.ad, b_ogr.soyad);
            }
            if (sayac == 0)
            {
                Console.WriteLine("==== KAYITLI OGRENCİ YOK ====");
            }
            return bulunan_ogrler;
        }
        
        /// <summary>
        /// string bir degeri belirtilen secime göre arama yaparak bulduklarını listeler
        /// </summary>
        /// <param name="kelime">aranılan deger</param>
        /// <param name="secim">hangi kritere göre arama yapacağını ayarlar</param>
        /// <returns></returns>
        public List<ogrenci> ogrenci_listele(string kelime, string secim)
        {
            List<ogrenci> bulunan_ogrler = new List<ogrenci>();
            switch (secim)
            {
                case "ad": bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.ad == kelime);
                    break;
                case "soyad": bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.soyad == kelime);
                    break;
                case "sinif": bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.sinif == kelime);
                    break;
                case "okulno": bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.okulno == kelime);
                    break;
            }            
            Console.WriteLine("BULUNAN KAYITLAR\n============");
            int sayac = 0;
            foreach (ogrenci b_ogr in bulunan_ogrler)
            {
                sayac++;
                Console.WriteLine("{0}. Bulunan OGRENCİ\t:{1} sınıfından {2} nolu {3} {4}", sayac, b_ogr.sinif, b_ogr.okulno, b_ogr.ad, b_ogr.soyad);
            }
            if (sayac == 0)
            {
                Console.WriteLine("==== KAYITLI OGRENCİ YOK ====");
            }
            return bulunan_ogrler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cinsiyet"></param>
        /// <param name="secim"></param>
        /// <returns></returns>
        public List<ogrenci> ogrenci_listele(char cinsiyet)
        {
            List<ogrenci> bulunan_ogrler = new List<ogrenci>();
            bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.cinsiyet == cinsiyet);
            Console.WriteLine("BULUNAN KAYITLAR\n============");
            int sayac = 0;
            foreach (ogrenci b_ogr in bulunan_ogrler)
            {
                sayac++;
                Console.WriteLine("{0}. Bulunan OGRENCİ\t:{1} sınıfından {2} nolu {3} {4}", sayac, b_ogr.sinif, b_ogr.okulno, b_ogr.ad, b_ogr.soyad);
            }
            if (sayac == 0)
            {
                Console.WriteLine("==== KAYITLI OGRENCİ YOK ====");
            }
            return bulunan_ogrler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kelime"></param>
        /// <param name="secim"></param>
        /// <returns></returns>
        public List<ogrenci> ogrenci_listele(byte deger, string secim)
        {
            List<ogrenci> bulunan_ogrler = new List<ogrenci>();
            switch (secim)
            {
                case "boy": bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.boy == deger);
                    break;
                case "kilo": bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.kilo == deger);
                    break;              
            }
            Console.WriteLine("BULUNAN KAYITLAR\n============");
            int sayac = 0;
            foreach (ogrenci b_ogr in bulunan_ogrler)
            {
                sayac++;
                Console.WriteLine("{0}. Bulunan OGRENCİ\t:{1} sınıfından {2} nolu {3} {4}", sayac, b_ogr.sinif, b_ogr.okulno, b_ogr.ad, b_ogr.soyad);
            }
            if (sayac == 0)
            {
                Console.WriteLine("==== KAYITLI OGRENCİ YOK ====");
            }
            return bulunan_ogrler;
        }

        /// <summary>
        /// listeleme işleminin en son hali
        /// </summary>
        /// <param name="deger"></param>
        /// <param name="secim"></param>
        /// <returns></returns>
        public List<ogrenci> ogrenci_listele(object deger, string secim) {
            List<ogrenci> bulunan_ogrler = new List<ogrenci>();
            
            switch (secim)
            {
                case "ad"       : bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.ad == (String)deger);
                    break;
                case "soyad"    : bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.soyad == (String)deger);
                    break;
                case "sinif"    : bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.sinif == (String)deger);
                    break;
                case "okulno"   : bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.okulno == (String)deger);
                    break;
                case "cinsiyet" : bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.cinsiyet == Convert.ToChar(deger));
                    break;   
                case "boy"      : bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.boy ==Convert.ToByte(deger));
                    break;
                case "kilo": bulunan_ogrler = ogr_lst.FindAll(_ogr => _ogr.kilo == Convert.ToByte(deger));
                    break;
            }
            Console.WriteLine("BULUNAN KAYITLAR\n============");
            int sayac = 0;
            foreach (ogrenci b_ogr in bulunan_ogrler)
            {
                sayac++;
                Console.WriteLine("{0}. Bulunan OGRENCİ\t:{1} sınıfından {2} nolu {3} {4}", sayac, b_ogr.sinif, b_ogr.okulno, b_ogr.ad, b_ogr.soyad);
            }
            if (sayac == 0)
            {
                Console.WriteLine("==== KAYITLI OGRENCİ YOK ====");
            }
            return bulunan_ogrler;
        }

        /// <summary>
        /// ozbezite indeksine göre 2.5 girilen boy ve kilo değerlerine göre obezite durumunu belirler
        /// </summary>
        /// <param name="kilo">Kişinin Kilo bilgisi</param>
        /// <param name="boy">Kişinin boy bilgisi</param>
        /// <returns>"NORMAL"-"ŞİŞMAN" degerlerinden birini döndürür</returns>
        public string obezite_kontrol(byte kilo,byte boy)
        { 
            double endeks=(double)boy/(double)kilo;
            return endeks < 2.5 ? "NORMAL" : "OBEZ";
        }

        /// <summary>
        /// Tüm Öğrenci Kayıtlarını Silmeye yarayan Metot
        /// </summary>
        public void ogrenci_sil()
        {
            char karar;
            Console.Write("TÜM KAYITLARI SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ (E/H)");
            karar = Convert.ToChar(Console.ReadLine().ToUpper());
            if (karar == 'E')
            {
                ogr_lst.Clear();
            }
            else 
            {
                Console.WriteLine("İŞLEMİNİZ İPTAL EDİLDİ...");
            }
        }
        
        /// <summary>
        /// Belirtilen Ada göre ilgili kayıtları silen metot
        /// </summary>
        /// <param name="ad">Silinmesi istenen ogrenci isimleri</param>
       /* public void ogrenci_sil(string ad)
        {
            char karar;
            if (ogrenci_listele(ad) != 0)
            {
                Console.Write("BU KAYITLARI SİLMEK İSTER MİSİNİZ(E/H)");
                karar = Convert.ToChar(Console.ReadLine().ToUpper());
                if (karar == 'E')
                {
                    ogr_lst.RemoveAll(_ogr => _ogr.ad == ad);
                    Console.WriteLine("{0} KAYIT BASARIYLA SİLİNDİ");
                }
                else
                {
                    Console.WriteLine("İŞLEMİNİZ İPTAL EDİLDİ...");
                }
            }
            else
            {
                Console.WriteLine("SİLİNECEK OGRENCİ OLMADIĞINDAN...\nİŞLEMİNİZ İPTAL EDİLDİ...");
            }
            
        }*/

        /// <summary>
        /// Ad,soyad,sinif ve okulno alanlarına göre silme işlemi yapar
        /// </summary>
        /// <param name="kelime">aranılan değer</param>
        /// <param name="secim">neye göre aranacağını gelirleriz...</param>
        public void ogrenci_sil(string kelime,string secim)
        {
            char karar;
            List<ogrenci> bulunan_ogrler = ogrenci_listele(kelime, secim);
            if ( bulunan_ogrler.Count!= 0)
            {
                Console.Write("BU KAYITLARI SİLMEK İSTER MİSİNİZ(E/H)");
                karar = Convert.ToChar(Console.ReadLine().ToUpper());
                if (karar == 'E')
                {
                    ogr_lst.RemoveAll(ogr => bulunan_ogrler.Contains(ogr));
                    Console.WriteLine("{0} KAYIT BASARIYLA SİLİNDİ", bulunan_ogrler.Count);
                }
                else
                {
                    Console.WriteLine("İŞLEMİNİZ İPTAL EDİLDİ...");
                }
            }
            else
            {
                Console.WriteLine("SİLİNECEK OGRENCİ OLMADIĞINDAN...\nİŞLEMİNİZ İPTAL EDİLDİ...");
            }
        }

        /// <summary>
        /// cinsiyet alanına göre silme işlemi yapar
        /// </summary>
        /// <param name="kelime">Aranılan değer</param>
        public void ogrenci_sil(char kelime)
        {
            char karar;
            List<ogrenci> bulunan_ogrler = ogrenci_listele(kelime);
            if (bulunan_ogrler.Count != 0)
            {
                Console.Write("BU KAYITLARI SİLMEK İSTER MİSİNİZ(E/H)");
                karar = Convert.ToChar(Console.ReadLine().ToUpper());
                if (karar == 'E')
                {
                    ogr_lst.RemoveAll(_ogr => bulunan_ogrler.Contains(_ogr));
                    Console.WriteLine("{0} KAYIT BASARIYLA SİLİNDİ", bulunan_ogrler.Count);
                }
                else
                {
                    Console.WriteLine("İŞLEMİNİZ İPTAL EDİLDİ...");
                }
            }
            else
            {
                Console.WriteLine("SİLİNECEK OGRENCİ OLMADIĞINDAN...\nİŞLEMİNİZ İPTAL EDİLDİ...");
            }
        }

        /// <summary>
        /// boy ve kilo alanlarına göre silme işlemini gerçekleştirir
        /// </summary>
        /// <param name="deger">boy veya kilo değeri</param>
        /// <param name="secim">hangi alana göre secim yapılacağını belirtir</param>
        public void ogrenci_sil(byte deger,string secim)
        {
            char karar;
            List<ogrenci> bulunan_ogrler = ogrenci_listele(deger, secim);
            if (bulunan_ogrler.Count != 0)
            {
                Console.Write("BU KAYITLARI SİLMEK İSTER MİSİNİZ(E/H)");
                karar = Convert.ToChar(Console.ReadLine().ToUpper());
                if (karar == 'E')
                {
                    ogr_lst.RemoveAll(_ogr=>bulunan_ogrler.Contains(_ogr));
                    Console.WriteLine("{0} KAYIT BASARIYLA SİLİNDİ", bulunan_ogrler.Count);
                }
                else
                {
                    Console.WriteLine("İŞLEMİNİZ İPTAL EDİLDİ...");
                }
            }
            else
            {
                Console.WriteLine("SİLİNECEK OGRENCİ OLMADIĞINDAN...\nİŞLEMİNİZ İPTAL EDİLDİ...");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deger"></param>
        /// <param name="secim"></param>
        public void ogrenci_sil(object deger,string secim)
        {
            char karar;
            List<ogrenci> bulunan_ogrler = ogrenci_listele(deger, secim);
            if (bulunan_ogrler.Count != 0)
            {
                Console.Write("BU KAYITLARI SİLMEK İSTER MİSİNİZ(E/H)");
                karar = Convert.ToChar(Console.ReadLine().ToUpper());
                if (karar == 'E')
                {
                    ogr_lst.RemoveAll(_ogr => bulunan_ogrler.Contains(_ogr));
                    Console.WriteLine("{0} KAYIT BASARIYLA SİLİNDİ", bulunan_ogrler.Count);
                }
                else
                {
                    Console.WriteLine("İŞLEMİNİZ İPTAL EDİLDİ...");
                }
            }
            else
            {
                Console.WriteLine("SİLİNECEK OGRENCİ OLMADIĞINDAN...\nİŞLEMİNİZ İPTAL EDİLDİ...");
            }
        }
    }

}
