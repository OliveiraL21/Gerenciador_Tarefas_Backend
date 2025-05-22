using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ClienteModel : BaseModel
    {
		private string _razaoSocial;

		public string RazaoSocial
		{
			get { return _razaoSocial; }
			set { _razaoSocial = value; }
		}

		private string? _cnpj;

		public string? Cnpj
		{
			get { return _cnpj; }
			set { _cnpj = value; }
		}

		private string? _telefone;

		public string? Telefone
		{
			get { return _telefone; }
			set { _telefone = value; }
		}

		private string? _celular;

		public string? Celular
		{
			get { return _celular; }
			set { _celular = value; }
		}

		private string? _email;

		public string? Email
		{
			get { return _email; }
			set { _email = value; }
		}

		private IEnumerable<ProjetoEntity>? _projetos;

		public IEnumerable<ProjetoEntity>? Projetos
		{
			get { return _projetos; }
			set { _projetos = value; }
		}


	}
}
