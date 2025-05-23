using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProjetoModel : BaseModel
    {
		private string _descricao;

		public string Descricao
		{
			get { return _descricao; }
			set { _descricao = value; }
		}

		private DateTime _dataInicio;

		public DateTime DataInicio
		{
			get { return _dataInicio; }
			set { _dataInicio = value; }
		}

		private DateTime _dataFim;

		public DateTime DataFim
		{
			get { return _dataFim; }
			set { _dataFim = value; }
		}

		private Guid _statusId;

		public Guid StatusId
		{
			get { return _statusId; }
			set { _statusId = value; }
		}

		private Guid _clienteId;

		public Guid ClienteId
		{
			get { return _clienteId; }
			set { _clienteId = value; }
		}

		private IEnumerable<TarefaEntity> _tarefas;

		public IEnumerable<TarefaEntity> Tarefas
		{
			get { return _tarefas; }
			set { _tarefas = value; }
		}


	}
}
