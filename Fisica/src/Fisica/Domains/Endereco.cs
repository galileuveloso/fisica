﻿using Fisica.Domains;

namespace Fisica.Domains
{
    public class Endereco : Entity
    {
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }

        public long CidadeId { get; set; }
        private Cidade _Cidade;
        public virtual Cidade Cidade { get { return _Cidade; } set { _Cidade = value; SetEndereco(value); } }

        public Instituicao Instituicao { get; set; }

        private void SetEndereco(Cidade value)
        {
            CidadeId = value is null ? 0 : value.Id;
        }
    }
}
