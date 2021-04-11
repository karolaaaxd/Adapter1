using System;

namespace Adapter
{
    class Program
    {
        static void Main()
        {

            Skladnik ciastko = new Skladnik("Ciastko");
            ciastko.Wyswietlanie();


            Skladnik tort = new Zawartosc("Tort");
            tort.Wyswietlanie();

            Skladnik zebra = new Zawartosc("Zebra");
            zebra.Wyswietlanie();


            Console.ReadKey();
        }
    }

    class Skladnik

    {
        protected string _informacje;
        protected int _pieczenie;
        protected int _ilosc;
        protected string _producent;


        public Skladnik(string informacje)
        {
            this._informacje = informacje;
        }

        public virtual void Wyswietlanie()
        {
            Console.WriteLine("\nNazwa: {0} ", _informacje);
        }
    }


    class Zawartosc : Skladnik

    {
        private Ciasto _bank;

   

        public Zawartosc(string name)
          : base(name)
        {
        }

        public override void Wyswietlanie()
        { 
            _bank = new Ciasto();

            _pieczenie = _bank.GetPieczenie(_informacje, "A");
            _ilosc = _bank.GetPieczenie(_informacje, "M");
            _producent = _bank.GetProducent(_informacje);

            base.Wyswietlanie();
            Console.WriteLine(" Producent: {0}", _producent);
            Console.WriteLine(" Ilosc : {0}", _ilosc);
            Console.WriteLine(" Pieczenie : {0} (c)", _pieczenie);
        }
    }

    class Ciasto

    {
        public int GetPieczenie(string skladnik, string point)
        {
         

            if (point == "M")
            {
                switch (skladnik.ToLower())
                {
                    case "tort": return 1;
                    case "zebra": return 5;
                   
                    default: return 0;
                }
            }

            else

            {
                switch (skladnik.ToLower())
                {
                    case "tort": return 120;
                    case "zebra": return 80;
                   
                    default: return 0;
                }
            }
        }

        public string GetProducent(string skladnik)
        {
            switch (skladnik.ToLower())
            {
                case "tort": return "Wedel";
                case "zebra": return "Millano";
             
                default: return "";
            }
        }
    }
}