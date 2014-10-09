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
            ogr.ogrenci_ekle(5);
            ogr.ogrenci_listele();
            ogr.ogrenci_listele(3);
            ogr.ogrenci_listele(7);
            Console.ReadKey();            
        }
    }
}
