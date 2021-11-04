using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_HP_II.classes
{
	class CAgente
	{
		
		private string _name = "";
		private string _pass = "";
		private int _age = 0;
		private int _id = 0;
		private int _captures = 0;
		private string _urlPicture = ""; 

		public CAgente()
		{
			this._name = null;
			this._age = 0;
			this._id = 0;
			this._captures = 0;
			this._urlPicture = null;
		}

		~CAgente() {}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string Pass
		{
			get { return _pass; }
			set { _pass = value; }
		}

		public int Age
		{
			get { return _age; }
			set { _age = value; }
		}

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public int Captures
		{
			get { return _captures; }
			set { _captures = value; }
		}

		public string UrlPicture
		{
			get { return _urlPicture; }
			set { _urlPicture = value; }
		}
	}
}
