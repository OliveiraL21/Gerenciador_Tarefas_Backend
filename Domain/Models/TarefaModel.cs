using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TarefaModel : BaseModel
    {
		private DateTime _data;

		public DateTime Data
		{
			get { return _data; }
			set { _data = value; }
		}

		private DateTime _horarioInicio;

		public DateTime HorarioInicio
        {
			get { return _horarioInicio; }
			set { _horarioInicio = value; }
		}

		private DateTime _horarioFim;

		public DateTime HorarioFim
		{
			get { return _horarioFim; }
			set { _horarioFim = value; }
		}

		private DateTime _duracao;

		public DateTime Duracao
		{
			get { return _duracao; }
			set { _duracao = value; }
		}

		private string _observacao;

		public string Observacao
		{
			get { return _observacao; }
			set { _observacao = value; }
		}

		private string _descricao;

		public string Descricao
		{
			get { return _descricao; }
			set { _descricao = value; }
		}

		private Guid _projetoId;

		public Guid ProjetoId
		{
			get { return _projetoId; }
			set { _projetoId = value; }
		}


		private Guid _statusId;

		public Guid StatusId
		{
			get { return _statusId; }
			set { _statusId = value; }
		}

	}
}
