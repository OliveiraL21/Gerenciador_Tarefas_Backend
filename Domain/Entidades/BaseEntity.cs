using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class BaseEntity
    {
        [Key] // indica que é a primary key da tabela
        public Guid Id { get; set; }

        private DateTimeOffset? _createAt;
        public DateTimeOffset? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTimeOffset.UtcNow : value; }
        }

        public DateTimeOffset? UpdateAt { get; set; }

    }
}
