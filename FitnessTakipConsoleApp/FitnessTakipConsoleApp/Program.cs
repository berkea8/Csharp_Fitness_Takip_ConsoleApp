using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace Fitness_Takip_Konsol_Uygulamasi
{
    internal class Program
    {

        public class Goruntuleme // Aylik Takvim ve TDEE goruntuleme metodlarini icerir.
        {
            public static string[,] aylikTakvim = new string[4, 8]; // 4*8 String matris olusturur.

            public static void AylikTakvimGoruntule()   //Aylik takvimi goruntuleyen metoddur.
            {
                Console.WriteLine("Aylik Takvim Goruntuleniyor...\n-------------------------------");
                Console.WriteLine("\tpzt\tsal\tcrs\tprs\tcum\tcts\tpaz\n");

                for (int i = 0; i < 4; i++)
                {
                    Console.Write((i + 1) + "\t");

                    for (int j = 1; j < 8; j++)
                    {
                        Console.Write(aylikTakvim[i, j] + "\t");
                    }

                    Console.WriteLine("\n");
                }
            }


            public static void TdeeGoruntule() //TDEE Hesaplama Metodudur.
            {
                Console.WriteLine("Lutfen Yasinizi Giriniz.");
                int yas = intkontrol();
                Console.WriteLine("Lutfen Boyunuzu cm Cinsinden Giriniz.");
                double boy = doublekontrol();
                Console.WriteLine("Lutfen Kilonuzu kg Cinsinden Giriniz.");
                double kilo = doublekontrol();

                Console.Clear();
                Console.WriteLine("Lutfen Cinsiyetinizi Seciniz.\n1. Kadin\n2. Erkek");

            cinsiyet:
                int cinsiyet = intkontrol();

                if (cinsiyet == 1) //kadin
                {
                    Console.Clear();
                    double BMR = 655.1 + (9.563 * kilo) + (1.850 * boy) - (4.676 * yas); // Kadin BMR hesaplama formulu
                    Console.WriteLine($"Bazal Metabolik Hızınız: {BMR}");

                    Console.WriteLine("Lutfen Aktivite Seviyenizi Seciniz.\n------------------------------");
                    Console.WriteLine("1- Egzersiz Yok");
                    Console.WriteLine("2- Az Egzersiz (Haftada 1-2 gun)");
                    Console.WriteLine("3- Ortalama Egzersiz (Haftada 3-5 gun)");
                    Console.WriteLine("4- Agir Egzersiz (Haftada 6-7 gun)");
                    Console.WriteLine("5- Profesyonel Atlet (Gunde 2)");

                    Console.Clear();
                    string aktivite = Console.ReadLine();

                    switch (aktivite)
                    {
                        case "1":
                            Console.WriteLine($"TDEE'niz {BMR * 1.2} kalori.");
                            Console.WriteLine("------------------------------");
                            return;

                        case "2":
                            Console.WriteLine($"TDEE'niz {BMR * 1.375} kalori.");
                            Console.WriteLine("------------------------------");
                            return;

                        case "3":
                            Console.WriteLine($"TDEE'niz {BMR * 1.55} kalori.");
                            Console.WriteLine("------------------------------");
                            return;

                        case "4":
                            Console.WriteLine($"TDEE'niz {BMR * 1.725} kalori.");
                            Console.WriteLine("------------------------------");
                            return;

                        case "5":
                            Console.WriteLine($"TDEE'niz {BMR * 1.9} kalori.");
                            Console.WriteLine("------------------------------");
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("Geçersiz Seçim. Lütfen Tekrar Deneyin.");
                            break;
                    }
                }

                else if (cinsiyet == 2) //erkek

                {
                    Console.Clear();
                    double BMR = 66.5 + (13.75 * kilo) + (5.0003 * boy) - (6.75 * yas); // Erkek BMR hesaplama formulu
                    Console.WriteLine($"Bazal Metabolik Hızınız {BMR}");

                    Console.WriteLine("Lutfen Aktivite Seviyenizi Seciniz.\n------------------------------");
                    Console.WriteLine("1- Egzersiz Yok");
                    Console.WriteLine("2- Az Egzersiz (Haftada 1-2 gun)");
                    Console.WriteLine("3- Ortalama Egzersiz (Haftada 3-5 gun)");
                    Console.WriteLine("4- Agir Egzersiz (Haftada 6-7 gun)");
                    Console.WriteLine("5- Profesyonel Atlet (Gunde 2)");

                    string erkeksecim = Console.ReadLine();
                    Console.Clear();

                    switch (erkeksecim)
                    {
                        case "1":
                            Console.WriteLine($"TDEE'niz {BMR * 1.2} kalori.");
                            Console.WriteLine("------------------------------");
                            return;

                        case "2":
                            Console.WriteLine($"TDEE'niz {BMR * 1.375} kalori.");
                            Console.WriteLine("------------------------------");
                            return;

                        case "3":
                            Console.WriteLine($"TDEE'niz {BMR * 1.55} kalori.");
                            Console.WriteLine("------------------------------");
                            return;

                        case "4":
                            Console.WriteLine($"TDEE'niz {BMR * 1.725} kalori.");
                            Console.WriteLine("------------------------------");
                            return;

                        case "5":
                            Console.WriteLine($"TDEE'niz {BMR * 1.9} kalori.");
                            Console.WriteLine("------------------------------");
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("Geçersiz Seçim. Lütfen Tekrar Deneyin.");
                            break;

                    }
                }
                else Console.WriteLine("Lutfen Gecerli Deger Giriniz.");
                goto cinsiyet;
            }
        }

        public class AntremanSecenekleri //Antremanlarla Alakalı Kodları Iceren Class.

        {

            public static List<string> tamamlananAntremanlar = new List<string>();  //Tamamlanan antremanlar adında dinamik liste olusturur.

            public static void AntremanGoruntule() // Antreman seceneklerini iceren metoddur.
            {
                while (true)
                {
                    Console.WriteLine("Antrenman Secenekleri\n----------------------");
                    Console.WriteLine("1. Antreman Ekle");
                    Console.WriteLine("2. Antreman Tamamla");
                    Console.WriteLine("3. Antreman Sil");
                    Console.WriteLine("4. Tamamlanan Antremanlar");
                    Console.WriteLine("5. Ana Menuye Don");

                    string antremanSecim = Console.ReadLine();

                    switch (antremanSecim)
                    {
                        case "1":
                            int hafta;
                            Console.Clear();
                            Goruntuleme.AylikTakvimGoruntule();


                        haftaE:
                            Console.WriteLine("Lütfen haftayı girin (1-4): ");
                            int degisken = intkontrol();
                            if (degisken > 4 || degisken <= 0)
                            {
                                Console.Clear();
                                Goruntuleme.AylikTakvimGoruntule();
                                Console.WriteLine("Lütfen doğru aralıkta değer giriniz");
                                goto haftaE;
                            }
                            else hafta = degisken;


                            gunE:
                            Console.WriteLine("Lütfen günü girin (1-7): ");
                            int gun = (intkontrol());
                            if (gun > 7 || gun <= 0)
                            {
                                Console.Clear();
                                Goruntuleme.AylikTakvimGoruntule();
                                Console.WriteLine("Lütfen doğru aralıkta değer giriniz");
                                goto gunE;
                            }

                            Console.WriteLine("Lütfen antrenman bilgisini girin: ");
                            string antrenmanBilgisi = Console.ReadLine();

                            Goruntuleme.aylikTakvim[hafta - 1, gun] = antrenmanBilgisi;
                            Console.Clear();
                            Goruntuleme.AylikTakvimGoruntule();
                            break;

                        case "2":
                            int haftaTamamla;
                            int gunTamamla;
                            Console.Clear();
                            Goruntuleme.AylikTakvimGoruntule();

                        haftaT:
                            Console.WriteLine("Lütfen haftayı girin (1-4): ");
                            int degisken1 = intkontrol();
                            if (degisken1 > 4 || degisken1 <= 0)
                            {
                                Console.Clear();
                                Goruntuleme.AylikTakvimGoruntule();
                                Console.WriteLine("Lütfen doğru aralıkta değer giriniz");
                                goto haftaT;
                            }
                            else haftaTamamla = degisken1;

                            gunT:
                            Console.WriteLine("Lütfen günü girin (1-7): ");
                            int degisken2 = intkontrol();
                            if (degisken2 > 7 || degisken2 <= 0)
                            {
                                Console.Clear();
                                Goruntuleme.AylikTakvimGoruntule();
                                Console.WriteLine("Lütfen doğru aralıkta değer giriniz");
                                goto gunT;
                            }
                            else gunTamamla = degisken2;

                            string tamamlananAntrenman = Goruntuleme.aylikTakvim[haftaTamamla - 1, gunTamamla];
                            if (!string.IsNullOrEmpty(tamamlananAntrenman))
                            {
                                tamamlananAntremanlar.Add($"Hafta {haftaTamamla}, Gün {gunTamamla}: {tamamlananAntrenman}");
                                Goruntuleme.aylikTakvim[haftaTamamla - 1, gunTamamla] = "";
                                Console.Clear();
                                Goruntuleme.AylikTakvimGoruntule();
                                Console.WriteLine("Antrenman Tamamlandı ve Kaldırıldı.");
                            }
                            else
                            {
                                Console.WriteLine("Bu hücrede antrenman bulunmamaktadır.");
                            }
                            break;

                        case "3":
                            int haftaSil;
                            int gunSil;
                            Console.Clear();
                            Goruntuleme.AylikTakvimGoruntule();


                        haftaS:
                            Console.WriteLine("Lütfen haftayı girin (1-4): ");
                            int degisken3 = intkontrol();
                            if (degisken3 > 4 || degisken3 <= 0)
                            {
                                Console.Clear();
                                Goruntuleme.AylikTakvimGoruntule();
                                Console.WriteLine("Lütfen doğru aralıkta değer giriniz");
                                goto haftaS;
                            }
                            else haftaSil = degisken3;

                            gunS:
                            int degisken4;
                            Console.WriteLine("Lütfen günü girin (1-7): ");
                            degisken4 = intkontrol();
                            if (degisken4 > 7 || degisken4 <= 0)
                            {
                                Console.Clear();
                                Goruntuleme.AylikTakvimGoruntule();
                                Console.WriteLine("Lütfen doğru aralıkta değer giriniz");
                                goto gunS;
                            }
                            else gunSil = degisken4;

                            string silinenAntrenman = Goruntuleme.aylikTakvim[haftaSil - 1, gunSil] = "";
                            Console.Clear();
                            Goruntuleme.AylikTakvimGoruntule();
                            break;


                        case "4":
                            Console.Clear();
                            if (tamamlananAntremanlar.Count == 0)
                            {
                                Console.WriteLine("Tamamlanan Antreman Bulunmamaktadir.\n");
                            }
                            else
                            {
                                Console.WriteLine("Tamamlanan Antremanlar:");
                                foreach (var antreman in tamamlananAntremanlar)
                                {
                                    Console.WriteLine(antreman + "\n");
                                }
                            }
                            break;


                        case "5":
                            Console.WriteLine("Ana Menuye Don seçeneği seçildi.");
                            Console.Clear();
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("Geçersiz Seçim. Lütfen Tekrar Deneyin.");
                            break;
                    }
                }
            }
        }

        // Bagimsiz Metodlar:

        public static int intkontrol()  //Girilen deger int mi kontrol eden metoddur.
        {
            bool isValidInput2 = int.TryParse(Console.ReadLine(), out int deger);

            while (!isValidInput2)
            {
                Console.WriteLine("Geçersiz giriş! Lütfen bir sayi girin:");
                isValidInput2 = int.TryParse(Console.ReadLine(), out deger);
            }
            return deger;
        }

        public static double doublekontrol() //Girilen deger double mi kontrol eden metoddur.
        {
            bool isValidInput2 = double.TryParse(Console.ReadLine(), out double deger);

            while (!isValidInput2)
            {
                Console.WriteLine("Geçersiz giriş! Lütfen bir sayi girin:");
                isValidInput2 = double.TryParse(Console.ReadLine(), out deger);
            }
            return deger;
        }




        public static void Karsilama()  //Kullanıcı karsilama metodudur.
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("***************************\nFitness Takip Uygulamasına\n       Hoşgeldiniz!\n***************************\nDevam Etmek Icin Bir Tusa Basiniz.");
            Console.ReadKey();
            Console.Clear();
        }

        //-----------------------------------------------------------------------------

        private static string sifeliyaz()  // *'li sifre yazma metodudur.
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return pass;
        }

        //MAIN *****************************************************************

        static void Main(string[] args)
        {

            //Kullanici karsilama metodunu cagirir.
            Karsilama();

            //kullanici adi ve sifre alir ve yazdirir.
            string geciciKad, geciciSifre, kad, sifre;
        kad:
            Console.WriteLine("Kullanıcı Adınız");
            geciciKad = Console.ReadLine();
            if (geciciKad == "")
            {
                Console.Clear();
                Console.WriteLine("Lutfen Gecerli Bir Kullanici Adi Giriniz.");
                goto kad;
            }
            else kad = geciciKad;
            Console.Clear();
        sifre:
            Console.WriteLine("Şifreniz");
            geciciSifre = sifeliyaz();


            if (geciciSifre.Length < 5)
            {
                Console.Clear();
                Console.WriteLine("Sifreniz 5 haneden kucuk olamaz, lutfen tekrar deneyin.");
                goto sifre;
            }
            else sifre = geciciSifre;

            Console.Clear();
            Console.WriteLine("Adınız={0}\tŞifreniz={1}\n", kad, sifre);
            Console.WriteLine("Yonlendiriliyorsunuz...");
            Thread.Sleep(3000);
            Console.Clear();

            //ANA DONGUDUR.

            while (true)
            {
                Console.WriteLine("Lutfen seciminizi belirtin.");
                Console.WriteLine("1. Aylik Plan Goruntule");
                Console.WriteLine("2. Antreman Secenekleri");
                Console.WriteLine("3. TDEE Hesaplama");
                Console.WriteLine("4. Cikis");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.Clear();
                        Goruntuleme.AylikTakvimGoruntule();
                        break;

                    case "2":
                        Console.Clear();
                        AntremanSecenekleri.AntremanGoruntule();
                        break;

                    case "3":
                        Console.Clear();
                        Goruntuleme.TdeeGoruntule();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Uygulamadan Cikiliyor. Iyi Antrenmanlar!");
                        Thread.Sleep(2000);
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Geçersiz Seçim. Lütfen Tekrar Deneyin.\n");
                        break;
                }
            }
        }
    }
}
