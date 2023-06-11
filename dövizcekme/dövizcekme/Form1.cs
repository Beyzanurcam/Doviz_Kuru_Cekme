using System.Xml;

namespace dövizcekme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string doviz = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(doviz);
            DateTime tarih = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

            string usd = xmlDoc.SelectSingleNode("Tarih_Date/Currency [@Kod ='USD'] /BanknoteSelling").InnerXml;
            label5.Text = string.Format("Tarih: {0}  USD: {1}", tarih.ToShortDateString(), usd);

            string euro = xmlDoc.SelectSingleNode("Tarih_Date/Currency [@Kod ='EUR'] /BanknoteSelling").InnerXml;
            label6.Text = string.Format("Tarih: {0}  EURO: {1}", tarih.ToShortDateString(), euro);

            string sterlin = xmlDoc.SelectSingleNode("Tarih_Date/Currency [@Kod ='GBP'] /BanknoteSelling").InnerXml;
            label7.Text = string.Format("Tarih: {0}  EURO: {1}", tarih.ToShortDateString(), sterlin);
        }
    }
}