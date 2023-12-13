using Accessibility;

namespace c_s_5
{
    public partial class Form1 : Form
    {
        string napis = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wezel w1 = new Wezel(5);
            Wezel w2 = new Wezel(3);
            Wezel w3 = new Wezel(1);
            Wezel w4 = new Wezel(2);
            Wezel w5 = new Wezel(4);
            Wezel w6 = new Wezel(6);
            w1.dzieci.Add(w2);
            w1.dzieci.Add(w3);
            w1.dzieci.Add(w4);
            w2.dzieci.Add(w5);
            w2.dzieci.Add(w6);
            A(w1);
            void A(Wezel w)
            {
                napis += " " + w.wartosc.ToString();
                for (int i = 0; i < w.dzieci.Count; i++)
                {
                    A(w.dzieci[i]);
                }
            }


            MessageBox.Show(napis);
        }
        List<Wezel2> wezel2s;
        private void button2_Click(object sender, EventArgs e)
        {
            wezel2s = new List<Wezel2>();

            Wezel2 w1 = new Wezel2(1);
            Wezel2 w2 = new Wezel2(2);
            Wezel2 w3 = new Wezel2(3);
            Wezel2 w4 = new Wezel2(4);
            Wezel2 w5 = new Wezel2(5);
            Wezel2 w6 = new Wezel2(6);
            Wezel2 w7 = new Wezel2(7);
            w1.Add(w2);
            w1.Add(w7);
            w2.Add(w3);
            w3.Add(w4);
            w4.Add(w5);
            w5.Add(w6);
            w6.Add(w7);
            B(w4);
            MessageBox.Show(napis);
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        void B(Wezel2 w)
        {
            wezel2s.Add(w);
            napis += " " + w.wartosc.ToString();
            foreach (var sasiad in w.sasiednie)
            {
                if (!wezel2s.Contains(sasiad))
                {
                    wezel2s.Add(sasiad);
                    B(sasiad);
                }

            }
        }
    }

    public class Wezel
    {
        public int wartosc;
        public List<Wezel> dzieci = new List<Wezel>();
        
        public Wezel(int liczba)
        {
            this.wartosc = liczba;
        }
    }
    public class Wezel2
    {
        public int wartosc;
        public List<Wezel2> sasiednie = new List<Wezel2>();

        public Wezel2(int wartosc)
        {
            this.wartosc = wartosc;
        }
        public void Add(Wezel2 w)
        {
            if(this == w) return;
            if (this.sasiednie.Contains(w)) return;
            this.sasiednie.Add(w);
            w.sasiednie.Add(this);
        }
    }
    public class Wezel3
    {
        public int wartosc;
        public Wezel3 rodzic;
        public Wezel3 leweDziecko;
        public Wezel3 praweDziecko;

        public Wezel3(int liczba)
        {
            this.wartosc = liczba;
        }

        internal void Add(int number)
        {
            var dziecko = new Wezel3(number);
            dziecko.rodzic = this;
            if (number < this.wartosc)
                this.leweDziecko = dziecko;
            else
                this.praweDziecko = dziecko;
        }

        /*      public Wezel3 Znajdz(int number)
                {
                    return Wezel3;
                }
                public Wezel3 ZnajdzMin(Wezek3 w)
                {

                }
                public Wezel3 ZnajdzMax(Wezel3 w)
                {

                }
                public Wezel3 Nastepnik(Wezel3 w)
                {

                }
                a) jezeli jest prawe dziecko to uzyj
                    ZnajdzMin(w.praweDziecko)
                b) jezeli nie ma prawego dziecka
                    idz do gory, az wyjdziesz jako lewe dziecko
                    rodzica, nastepnik to rodzic
                c) jezeli nie ma prawego dziecka i idac do gory nie ma (2) to nie ma nastepnika
                public Wezel3 Poprzednik(Wezel3 w){
        }
         
         */
    }

    public class DrzewoBinarne
    {
        public Wezel3 korzen;

        public DrzewoBinarne(int liczba)
        {
            this.korzen = new Wezel3(liczba);
        }

        public void Add(int number)
        {
            Wezel3 rodzic = this.ZnjadzRodzica(number);
            rodzic.Add(number);
        }
        private Wezel3 ZnjadzRodzica(int number)
        {
            var w = this.korzen;
            while (true)
            {
                if (number < w.wartosc)
                {
                    if (w.leweDziecko == null)
                    {
                        return w;
                    }
                    else
                        w = w.leweDziecko;
                }
                else
                {
                    if (w.praweDziecko == null)
                    {
                        return w;
                    }
                    else
                        w = w.praweDziecko;
                }
            }
        }
        public Wezel3 Znajdz(int number)
        {
            var w = this.korzen;
            if (w.wartosc == number)
            {
                return w;
            }
            while (true)
            {
                if (number < w.wartosc)
                {
                    if (w.leweDziecko.wartosc == number)
                        return w;
                    else
                        w = w.leweDziecko;
                }
                if (number >= w.wartosc)
                {
                    if (number == w.praweDziecko.wartosc)
                        return w;
                    else
                        w = w.praweDziecko;
                }
            }
        }
        public Wezel3 ZnajdzMin(Wezel3 w)
        {
            var k = w;
            while (true)
            {
                if(k.leweDziecko == null)
                    return k;
                k = k.leweDziecko;
            }
        }
        public Wezel3 ZnajdzMax(Wezel3 w)
        {
            var k = w;
            while (true)
            {
                if (k.praweDziecko == null)
                    return k;
                k = k.praweDziecko;
            }
        }
        public Wezel3 Nastepnik(Wezel3 w)
        {
            if (w.praweDziecko != null)
                return ZnajdzMin(w.praweDziecko);
            Wezel3 w_temp = w.rodzic;
            while(w_temp != null && w_temp.leweDziecko != w)
            {
                w = w_temp;
                w_temp = w_temp.rodzic;
            }
            return w_temp;
        }
        public Wezel3 Poprzednik(Wezel3 w)
        {
            if(w.leweDziecko != null)
                return ZnajdzMax(w.leweDziecko);
            Wezel3 w_temp = w;
            while(w_temp != null && w_temp.praweDziecko!= w)
            {
                w = w_temp;
                w_temp = w_temp.rodzic;
            }
            return w_temp;

        }
        public Wezel3 deleteNode(Wezel3 node, DrzewoBinarne tree)
        {
            Wezel3 x;
            Wezel3 y;
            if(node.leweDziecko == null || node.praweDziecko == null)
            {
                y = node;
            }
            else
            {
                y = Nastepnik(node);
            }
            if(y.leweDziecko != null)
            {
                x = y.leweDziecko;
            }
            else
            {
                x = y.praweDziecko;
            }
            if(x != null)
            {
                x.rodzic = y.rodzic;
            }
            if(y.rodzic == null)
            {
                tree.korzen = x;
            }
            else
            {
                if(y == y.rodzic.leweDziecko)
                {
                    y.rodzic.leweDziecko = x;
                }
                else
                {
                    y.rodzic.praweDziecko = x;
                }
            }
            if(y != node)
            {
                node.wartosc = y.wartosc;
            }
            return y;
        }
    }
}