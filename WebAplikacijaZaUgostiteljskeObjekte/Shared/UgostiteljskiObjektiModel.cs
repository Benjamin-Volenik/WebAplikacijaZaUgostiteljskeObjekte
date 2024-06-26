﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacijaZaUgostiteljskeObjekte.Shared
{
    public class UgostiteljskiObjektiModel
    {
        public int UgostiteljskiObjektiId { get; set; }
        public string UgostiteljskiObjektiNaziv { get; set; }
        public string UgostiteljskiObjektiOIB { get; set; }
        public string UgostiteljskiObjektiVlasnik { get; set; }
        public string UgostiteljskiObjektiKontakt { get; set; }
        public string UgostiteljskiObjektiEmali { get; set; }
        public string UgostiteljskiObjektiLozinka { get; set; }
        public float UgostiteljskiObjektiProsjecnaOcjena { get; set; }
        public string UgostiteljskiObjektiSlika { get; set; }
        public string UgostiteljskiObjektiStanje { get; set; }
        public string UgostiteljskiObjektiTip { get; set; }
        public string UgostiteljskiObjektiGrad { get; set; }
        public string UgostiteljskiObjektiUlica { get; set; }
        public int UgostiteljskiObjektiKucniBroj { get; set; }
        public float UgostiteljskiObjektiLatituda { get; set; }
        public float UgostiteljskiObjektiLongituda { get; set; }
        public string UgostiteljskiObjektiRadnoVrijeme { get; set; }
        public string UgostiteljskiObjektiRadnoVrijemePraznici { get; set; }
        public string UgostiteljskiObjektiRadnoVrijemeSub { get; set; }
        public string UgostiteljskiObjektiRadnoVrijemeNed { get; set; }
        public string UgostiteljskiObjektiPdfPutanja { get; set; }
    }
}
