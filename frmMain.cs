namespace FlexyBase
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        class Basic
        {
            public virtual string Convert(int x)
            {
                string s = "";
                if (x % 3 == 0)
                    s = "-fizz";
                if (x % 5 == 0)
                    s = s + "-buzz";
                return s;
            }
        }

        class Advanced : Basic
        {
            public override string Convert(int x)
            {
                string s = base.Convert(x);
                if (x % 4 == 0)
                    s = s + "-muzz";
                if (x % 7 == 0)
                    s = s + "-guzz";
                return s;
            }
        }

        class Expert : Advanced
        {
            public override string Convert(int x)
            {
                return base.Convert(x).Replace("fizz-buzz", "good-boy").Replace("fizz", "dog").Replace("buzz", "cat");
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var c = new Basic();
            if (rb2.Checked)
            {
                c = new Advanced();
            }
            else if (rb3.Checked)
            {
                c = new Expert();
            }

            string s = "";
            foreach (var sIn in tbInput.Text.Split(","))
            {
                string sOut = "";
                if (Int32.TryParse(sIn, out int x))
                {
                    sOut = c.Convert(x);
                    if (sOut.Length > 0)
                        sOut = sOut.Substring(1);
                    else
                        sOut = x.ToString();
                }
                else
                    sOut = sIn;
                s = s + ", " + sOut;
            }
            if (s.Length > 1)
                lOutput.Text = s.Substring(2);
        }
    }
}