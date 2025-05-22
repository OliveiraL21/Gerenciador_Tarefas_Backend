using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BaseModel
    {
		private Guid _id;

		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private DateTimeOffset _createAt;

		public DateTimeOffset CreateAt
		{
			get { return _createAt; }
			set { _createAt = value == null ? DateTimeOffset.UtcNow : value; }
		}

		private DateTimeOffset _updateAt;

		public DateTimeOffset UpdateAt
		{
			get { return _updateAt; }
			set { _updateAt = value; }
		}


	}
}
