using Microsservice_Domain.Enums;
using Microsservice_Domain.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Domain.Entites
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            DataCriacao = DataUtils.GetDateTimeBrasil();
            TipoStatus = TipoStatus.Ativo;
        }

        [Column("id")]
        public Guid Id { get; set; }

        [Column("criado_por")]
        public Guid CriadoPor { get; set; }

        [Column("dt_criacao")]
        public DateTime DataCriacao { get; set; }

        [Column("modificado_por")]
        public Guid? ModificadoPor { get; set; }

        [Column("dt_modificacao")]
        public DateTime? DataModificacao { get; set; }

        [Column("tp_status")]
        public TipoStatus TipoStatus { get; set; }
    }
}
