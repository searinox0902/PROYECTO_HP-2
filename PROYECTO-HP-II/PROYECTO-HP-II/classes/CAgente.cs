using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_HP_II.classes
{
	class CAgente
	{
		
		private string	_name = "";
		private string	_pass = "";
		private int		_age = 0;
		private string _rango = "";
		private string	_id = "";
		private string	_urlPicture = "";
		private int _Pin = 0;

		public CAgente()
		{
			this._name = null;
			this._age = 0;
			this._id = "";
			this._Pin = 0;
			this._urlPicture = null;
		}

		// ~CAgente() {}

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

		public string Rango
		{
			get { return _rango; }
			set { _rango = value; }
		}

		public string  Id
		{
			get { return _id; }
			set { _id = value; }
		}


		public string UrlPicture
		{
			get { return _urlPicture; }
			set { _urlPicture = value; }
		}
		public int Pin
		{
			get { return _Pin; }
			set { _Pin = value; }
		}

	}
}
