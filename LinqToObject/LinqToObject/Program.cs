using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Tanımlama

            //LINQ(Language Integrated Query)
            //Dil ile tümleşik sorgu
            //Veri KOLEKSİYONLARINI sorgulamak, verileri filtrelemek veya dönüştürmek gibi işlemleri kolaylaştıran güçlü bir teknolojidir.    .net 3.0 ile hayatımıza girmiştir.

            //LINQ kullanımının ana başlıkları
            //LINQ TO OBJECT
            //LINQ TO SQL
            //LINQ TO ENTITIES

            #endregion

            #region Lambda Expressions

            ////Lambda expressions koleksiyon üzerinde kullanılabilecek koşulları sorgu olarak ele almamızı sağlayan yapıdır. 

            //List<int> sayilar = new List<int>();
            //sayilar.AddRange(new int[] { 12, 5, 20, -3, 45, 56, 2, 4, 14, -56 });

            ////Sayılar koleksiyonu içerisindeki negatif sayıları yazdırın.
            ////for (int i = 0; i < sayilar.Count; i++)
            ////{
            ////    if (sayilar[i] < 0)
            ////    {
            ////        Console.WriteLine(sayilar[i]);
            ////    }
            ////}

            ////Lambda ile kullanım
            //List<int> negatifler = sayilar.Where(x => x < 0).ToList();
            //foreach (int item in negatifler)
            //{
            //    Console.WriteLine(item);
            //}


            #endregion

            List<int> sayilar = new List<int>();
            sayilar.AddRange(new int[] { 12, 5, 20, -3, 45, 50, 2, 4, 14, -56 });

            #region MAX - MIN - Average - SUM

            //Console.WriteLine("En büyük sayı: " + sayilar.Max());
            //Console.WriteLine("En küçük sayı: " + sayilar.Min());
            //Console.WriteLine("Ortalama: " + sayilar.Average());
            //Console.WriteLine("Toplamı: " + sayilar.Sum());

            #endregion

            #region Where

            ////Liste döndürür.
            //List<int> pozitifler = sayilar.Where(x => x>=0).ToList();
            //Console.WriteLine("0'dan büyük olan sayıların ortalaması: " + sayilar.Where(x=> x >= 0).Average());


            #endregion

            #region First - Last

            ////Tek eleman döndürür.

            //Console.WriteLine("Negatif ilk eleman: " + sayilar.First(x=> x < 0));
            //Console.WriteLine("Negatif son eleman: " + sayilar.Last(x=> x < 0));
            ////Console.WriteLine(sayilar.First(x=> x > 100));//Eğer koşula uygun değer bulunamazsa "InvalidOperationException" hatası alınır.
            //Console.WriteLine(sayilar.FirstOrDefault(x => x > 100));

            #endregion

            #region Count-Contains

            //Console.WriteLine("Eleman sayısı: " + sayilar.Count);
            //Console.WriteLine("Pozitif eleman sayısı: " + sayilar.Count(x => x >= 0));

            ////int sayi = sayilar.Count(x =>  x > 100);
            ////if (sayi > 0)
            ////{
            ////    Console.WriteLine(sayilar.First(x=> x > 100));
            ////}
            ////else
            ////{
            ////    Console.WriteLine("Sayı bulunamadı.");
            ////}

            //bool varmi = sayilar.Contains(45); //Contains elemanı yalnızca 1 eleman kabul eder. Lamda ile çoğul bir koşul kabul etmez.
            //Console.WriteLine("45 sayısı var mı? " + (varmi ? "Var" : "Yok"));

            #endregion

            #region All - Any

            ////Boolean veri döndürür.

            //Console.WriteLine("Tüm sayılar 0'dan büyük mü? " + sayilar.All(x => x > 0));
            //Console.WriteLine("Herhangi bir sayı 100'den büyük mü? " + sayilar.Any(x => x > 100));

            #endregion

            #region OrderBy - Reverse

            //foreach (int item in sayilar.OrderBy(x => x))
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (int item in sayilar.OrderByDescending(x=> x))
            //{
            //    Console.WriteLine(item);
            //}

            //sayilar.Reverse();
            //foreach (int item in sayilar)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            List<Personel> personeller = new List<Personel>();
            personeller.Add(new Personel() { No = 500, Isim = "Murtaza", Soyisim = "Şuayipoğlu", IseGirisTarihi = Convert.ToDateTime("20/10/2010"), Durum = true });
            personeller.Add(new Personel() { No = 501, Isim = "Hakkı", Soyisim = "Windowsgil", IseGirisTarihi = Convert.ToDateTime("15/05/2020"), Durum = true });
            personeller.Add(new Personel() { No = 515, Isim = "Fadime", Soyisim = "Eskuel", IseGirisTarihi = Convert.ToDateTime("20/08/2024"), Durum = true });
            personeller.Add(new Personel() { No = 547, Isim = "Şükriye", Soyisim = "datnet", IseGirisTarihi = Convert.ToDateTime("01/02/2022"), Durum = false });

            #region Çalışan personellerin listesi

            //personeller.Where(p => p.Durum == true).ToList().ForEach(x => Console.WriteLine(x.No + " " + x.Isim + " " + x.Soyisim)); 
            //foreach (Personel item in personeller.Where(p => p.Durum))
            //{
            //    Console.WriteLine(item.No + " " + item.Isim + " " + item.Soyisim);
            //}

            #endregion

            #region 5 yıl üstü çalışan personel listesi

            //DateTime tarih = DateTime.Now.AddYears(-5);

            //List<Personel> besyillik = personeller.Where(x => x.IseGirisTarihi < tarih).ToList();

            //foreach (Personel item in besyillik)
            //{
            //    Console.WriteLine(item.No + " " + item.Isim + " " + item.Soyisim); 
            //}

            #endregion

            #region select new

            var a = from x in personeller select new { pers = x.Isim + " " + x.Soyisim + " " + "-" + " " + (x.Durum ? "Aktif" : "Ayrılmış") };
            foreach (var item in a)
            {
                Console.WriteLine(item.pers);
            }


            #endregion




        }
    }
}
