using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaveraSync.Model
{
    public class Produto
    {
        public int idpro { get; set; }
        public int idext_pro { get; set; }
        public string codbarra { get; set; }
        public string produto { get; set; }
        public int idgrp4 { get; set; }
        public string grupo { get; set; }
        public int idsgr4 { get; set; }
        public string subgrupo { get; set; }
        public string marca { get; set; }
        public string detalhes { get; set; }
        public double peso { get; set; }
        public int stok_off { get; set; }
        public double spotTabPrice { get; set; }
        public double promoTabPrice { get; set; }
        public double wholesaleTabPrice { get; set; }
        public double retailTabPrice { get; set; }
        public string imagem { get; set; }
    }
}
