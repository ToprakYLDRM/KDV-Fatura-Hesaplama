namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal toplamFatura;
            while (true)
            {
                Console.Write("Toplam Fatura Tutarını Girin: ");

                string girilenDeger = Console.ReadLine();

                if (decimal.TryParse(girilenDeger, out toplamFatura))
                {
                    if (toplamFatura > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Fatura tutarı 0 veya negatif olamaz. Lütfen tekrar girin.");
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yaptınız. Lütfen geçerli bir sayı girin.");
                }
            }

            //Excel'den vergi oranlarını sabit bir şekilde aldım
            decimal tlLevyOran = 0.01m;
            decimal getFundOran = 0.025m;
            decimal covidLevyOran = 0.01m;
            decimal nhilOran = 0.025m;
            decimal kdvOran = 0.15m;

            decimal tutarKDVHaric = toplamFatura / (1 + kdvOran); // KDV dahil tutarı, KDV hariç tutara çevirmek için yazdım

            // KDV den önce ek vergileri hesapladım
            decimal tlLevy = tutarKDVHaric * tlLevyOran;
            decimal getFund = tutarKDVHaric * getFundOran;
            decimal covidLevy = tutarKDVHaric * covidLevyOran;
            decimal nhil = tutarKDVHaric * nhilOran;

            decimal safSatisTutari = tutarKDVHaric - (tlLevy + getFund + covidLevy + nhil); // vergisiz asıl satış tutarını bulmak için yazdım

            decimal kdvTutari = toplamFatura - tutarKDVHaric; // KDV tutarını hesaplamak için yazdım

            Console.WriteLine("\n--- Hesaplama Sonuçları ---");
            Console.WriteLine("Toplam Fatura Tutarı    : " + toplamFatura.ToString("C"));
            Console.WriteLine("Vergisiz Satış Tutarı   : " + safSatisTutari.ToString("C"));
            Console.WriteLine("KDV (%15)               : " + kdvTutari.ToString("C"));
            Console.WriteLine("TL Levy (%1)            : " + tlLevy.ToString("C"));
            Console.WriteLine("GetFund Levy (%2.5)     : " + getFund.ToString("C"));
            Console.WriteLine("Covid Levy (%1)         : " + covidLevy.ToString("C"));
            Console.WriteLine("NHIL (%2.5)             : " + nhil.ToString("C"));

            Console.WriteLine("\nProgramı kapatmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }   
}
