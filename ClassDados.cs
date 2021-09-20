using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSS_Aula06Section_1409
{
    class ClassDados
    {
        private int codigo;
        private string nome;

        public int getcod
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        public string getnome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

        public void Limparcomponentes(Control con)
        {
            foreach (Control caixatexto in con.Controls)    //  VARRER VETOR 
            {
                if(caixatexto is TextBox)
                {
                    ((TextBox)caixatexto).Clear();
                }
                else
                {
                    Limparcomponentes(caixatexto);    
                }
            }
        }
    }
}
