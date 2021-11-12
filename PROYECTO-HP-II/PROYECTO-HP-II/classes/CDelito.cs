using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_HP_II.classes
{
    class CDelito
    {
        private string _id          ;
        private string _descripcion ;

        public CDelito()
        {
            _id = null;
            _descripcion = null;
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}
