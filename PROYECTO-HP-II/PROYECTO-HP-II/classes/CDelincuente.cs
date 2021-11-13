using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_HP_II.classes
{
    class CDelincuente
    {
        private string _id = null;
        private string _Nombre = null;
        private string _Alias = null;
        private int _Edad = 0;
        private string _Ubicacion = null;
        private string _URLPicture = null;
        private string _delito = null;


        public CDelincuente()
        {
            _id = "";
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Alias 
        {
            get { return _Alias; }
            set { _Alias = value; }
        }

        public int Edad
        {
            get { return _Edad; }
            set { _Edad = value; }
        }

        public string Ubicacion
        {
            get { return _Ubicacion; }
            set { _Ubicacion = value; }
        }

        public string url
        {
            get { return _URLPicture; }
            set { _URLPicture = value; }
        }

        public string Delito
        {
            get { return _delito; }
            set { _delito = value; }
        }

    }

}
