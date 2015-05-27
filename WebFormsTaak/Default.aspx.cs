using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KleinOnderhoudApi.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebFormsTaak
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void btnVolgende_Click(object sender, EventArgs e)
        {
            Klant klant = new Klant(txtKlantNaam.Text);

            Wagen wagen = new Wagen()
            {
                Merk = txtMerk.Text,
                Nummerplaat = txtNummerplaat.Text,
                Km = Convert.ToInt32(txtAantalKm.Text),
                Type = txtType.Text
            };

            ControlePunt cp1 = new ControlePunt();
            ControlePunt cp2 = new ControlePunt();
            ControlePunt cp3 = new ControlePunt();

            cp1.Beschrijving = "Bandenspanning";
            cp2.Beschrijving = "Remmen";
            cp3.Beschrijving = "Olie";

            cp1.Resultaat = chkControle1.Checked;
            cp2.Resultaat = chkControle2.Checked;
            cp3.Resultaat = chkControle3.Checked;

            Controle controle = new Controle();

            controle.lstControlePunt.Add(cp1);
            controle.lstControlePunt.Add(cp2);
            controle.lstControlePunt.Add(cp3);

            controle.BandenspanningOk = chkBandenspanning.Checked;
            controle.Datum = DateTime.Now;

            if (cp1.Resultaat == true && cp2.Resultaat == true && cp3.Resultaat == true && controle.BandenspanningOk == true)
            {
                controle.Eindresultaat = true;
            }
            else
            {
                controle.Eindresultaat = false;
            }

            // TODO: Klant ophalen uit database 
            klant.lstControle.Add(controle);

            // TODO: Wagen ophalen uit database
            klant.lstWagen.Add(wagen);

            Save(klant);
            lblInfo.Text = "Done!";
        }

        private async Task Save(Klant klant)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3807/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("api/klant", klant);
            }
        }
    }
}