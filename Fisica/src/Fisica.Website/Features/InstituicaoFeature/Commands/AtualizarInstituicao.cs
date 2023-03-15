using Fisica.Website.Extensions;
using Fisica.Website.Features.InstituicaoFeature.Queries;
using Fisica.Website.Helpers;
using Fisica.Classes;
using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
using MediatR;
using System.Data;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.InstituicaoFeature.Commands
{
    public class AtualizarInstituicaoCommand : IRequest<InstituicaoResponse>
    {
        public long? UsuarioId { get; set; }
        public long? InstituicaoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public int? Numero { get; set; }
        public long? CidadeId { get; set; }
        public string? UF { get; set; }

        public void Validar()
        {
            if (UsuarioId is null || UsuarioId == 0) throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>(x => x.UsuarioId));
            if (InstituicaoId is null) throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>(x => x.InstituicaoId));
            if (String.IsNullOrEmpty(Nome)) throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>(x => x.Nome));
            if (String.IsNullOrEmpty(Descricao)) throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>(x => x.Descricao));
            if (String.IsNullOrEmpty(Email)) throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>(x => x.Email));
            if (String.IsNullOrEmpty(Site)) throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>(x => x.Site));
            if (String.IsNullOrEmpty(Logradouro)) throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>(x => x.Logradouro));
            if (String.IsNullOrEmpty(Bairro)) throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>(x => x.Bairro));
            if (CidadeId is null || CidadeId == 0) throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>(x => x.CidadeId));
            if (String.IsNullOrEmpty(UF)) throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>(x => x.UF));
            if (Numero is null || Numero == 0) throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>(x => x.Numero));
        }
    }

    public class AtualizarInstituicaoHandler : IRequestHandler<AtualizarInstituicaoCommand, InstituicaoResponse>
    {
        private readonly IRepository<Instituicao> _repositoryInstituicao;
        private readonly IRepository<Cidade> _repositoryCidade;
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IRepository<Endereco> _repositoryEndereco;

        public AtualizarInstituicaoHandler(IRepository<Instituicao> repositoryInstituicao, IRepository<Cidade> repositoryCidade, IRepository<Usuario> repositoryUsuario, IRepository<Endereco> repositoryEndereco)
        {
            _repositoryInstituicao = repositoryInstituicao;
            _repositoryCidade = repositoryCidade;
            _repositoryUsuario = repositoryUsuario;
            _repositoryEndereco = repositoryEndereco;
        }

        public async Task<InstituicaoResponse> Handle(AtualizarInstituicaoCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>());

            request.Validar();

            Usuario? usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == request.UsuarioId!.Value, cancellationToken);

            if (usuario is null)
                throw new ObjectNotFoundException("Usuário não encontado.");

            if (usuario!.TipoUsuario != (int)TipoUsuario.Adminstrador)
                throw new InvalidOperationException("Usuário não possui permissão para atualizar instituições.");

            Instituicao? instituicao = await _repositoryInstituicao.GetSingleAsync(x => x.Id == request.InstituicaoId, cancellationToken, x => x.Endereco);

            if (instituicao is null)
                throw new ObjectNotFoundException("Instituição não encontrada.");

            if (!await _repositoryCidade.ExistsAsync(x => x.Id == request.CidadeId!.Value, cancellationToken))
                throw new ObjectNotFoundException("Cidade não encontrada.");

            if (await _repositoryInstituicao.ExistsAsync(x => x.Nome.Equals(request.Nome) && x.Id != request.InstituicaoId, cancellationToken))
                throw new DuplicateNameException("Já existe uma instituição com este nome.");

            if (await _repositoryInstituicao.ExistsAsync(x => x.Email.Equals(request.Email) && x.Id != request.InstituicaoId, cancellationToken))
                throw new DuplicateNameException("Já existe uma instituição com este e-mail.");

            Endereco endereco = await _repositoryEndereco.GetFirstAsync(x => x.Id == instituicao!.EnderecoId, cancellationToken, x => x.Cidade);

            instituicao.Atualizar(request);

            await _repositoryInstituicao.UpdateAsync(instituicao);
            await _repositoryInstituicao.SaveChangesAsync(cancellationToken);

            return instituicao.ToResponse();
        }
    }
}
