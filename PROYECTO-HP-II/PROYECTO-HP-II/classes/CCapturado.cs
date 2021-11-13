using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_HP_II.classes
{
    class CCapturado
    {
        private string _id;
        private string _fechaCaptura;
        private string _Delito;
        private string _Nombre;

        public CCapturado()
        {
            _id             = null;
            _fechaCaptura   = null;
            _Delito         = null;
            _Nombre         = null;
        }

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string fechaCaptura
        {
            get { return _fechaCaptura; }
            set { _fechaCaptura = value; }
        }

        public string delito
        {
            get { return _Delito; }
            set { _fechaCaptura = value; }
        }

        public string nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
    }
}
