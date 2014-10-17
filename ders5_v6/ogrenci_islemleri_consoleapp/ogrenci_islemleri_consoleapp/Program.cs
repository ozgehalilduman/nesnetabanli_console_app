using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ogrenci_islemleri;

namespace ogrenci_islemleri_consoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            ogrenci_islemler ogr = new ogrenci_islemler();
            //menu yapımı icin sonsuz döngü oluşturuyorun
            bool devam = true;
            while(devam)
            {//menun gorsel kısmı
                Console.WriteLine("******\tMENU\t*******");
                Console.WriteLine("-1-OGRENCİ EKLEME \t\t--");
                Console.WriteLine("-2-ÇOKLU ÖGRENCİ EKLEME\t\t--");
                Console.WriteLine("-3-OGRENCİLERİ LİSTELE\t\t--");
                Console.WriteLine("-4-BELİRLİ BİR OGRENCİYİ GOSTER\t--");
                Console.WriteLine("-5-BELİRLİ BİR OGRENCİYİ SİL\t--");
                Console.WriteLine("-6-TÜM OGRENCİLERİ SİL\t--");
                Console.WriteLine("-7-EKRANI TEMİZLE\t\t--");
                Console.WriteLine("-0-ÇIKIŞ\t--");
                Console.WriteLine("================================");
                Console.Write("SECİMİNİZ:");
                try
                {
                    char secim=Convert.ToChar(Console.ReadLine());
                    switch(secim)
                    {
                        case '1':
                            ogr.ogrenci_ekle();
                        break;
                        case '2':
                            Console.Write("KAÇ ADET OGRENCİ EKLEMEK İSTERSİNİZ :");
                            try 
                            {
                                int adet = Int32.Parse(Console.ReadLine());
                                ogr.ogrenci_ekle(adet);
                            }
                            catch
                            {
                                throw new Exception();
                            }                            
                        break;
                        case '3':
                            ogr.ogrenci_listele();
                        break;
                        case '4':
                             Console.Write("KAÇ NOLU OGRENCİYİ GÖRMEK İSTERSİNİZ:");
                            try 
                            {
                                int kisino = Int32.Parse(Console.ReadLine());
                                ogr.ogrenci_ekle(kisino);
                            }
                            catch
                            {
                                throw new Exception();
                            }            
                        break;
                        case '5':
                            Console.Write("HANGİ İSİMLİ OGRENCİYİ SİLMEK İSTERSİNİZ:");
                            try 
                            {
                                string isim= Console.ReadLine();
                                bool kontrol = isim.All(c=>char.IsLetter(c));
                                if (kontrol) { ogr.ogrenci_sil(isim); }
                                else { throw new Exception(); }
                            }
                            catch
                            {
                                throw new Exception();
                            }     
                        break;
                        case '6':
                            ogr.ogrenci_sil();
                        break;
                        case '7':
                            Console.Clear();
                        break;
                        case '0':
                            devam = false;
                        break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine("HATALI GİRİŞ");
                }
                
                
            }
        }
    }
}
