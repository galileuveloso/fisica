﻿using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.InstituicaoFeature.Commands
{
    public class DeletarInstituicaoCommand : IRequest
    {
        public long? UsuarioId { get; set; }
        public long? InstituicaoId { get; set; }

        public void Validate()
        {
            if (InstituicaoId is null) throw new ArgumentNullException(MessageHelper.NullFor<DeletarInstituicaoCommand>(x => x.InstituicaoId));
        }
    }

    public class DeletarInstituicaoHandler : IRequestHandler<DeletarInstituicaoCommand>
    {
        private readonly IRepository<Instituicao> _repositoryInstituicao;
        private readonly IRepository<Usuario> _repositoryUsuario;

        public DeletarInstituicaoHandler(IRepository<Instituicao> repositoryInstituicao, IRepository<Usuario> repositoryUsuario)
        {
            _repositoryInstituicao = repositoryInstituicao;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Unit> Handle(DeletarInstituicaoCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<DeletarInstituicaoCommand>());

            request.Validate();

            request.UsuarioId = 1;

            Usuario? usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == request.UsuarioId!.Value, cancellationToken);

            if (usuario is null)
                throw new ObjectNotFoundException("Usuário não encontado.");

            if (usuario!.TipoUsuario != (int)TipoUsuario.Adminstrador)
                throw new InvalidOperationException("Usuário não possui permissão para excluir instituições.");

            Instituicao? instituicao = await _repositoryInstituicao.GetSingleAsync(x => x.Id == request.InstituicaoId, cancellationToken);

            if (instituicao is null)
                throw new ObjectNotFoundException("Instituição não encontrada.");

            await _repositoryInstituicao.RemoveAsync(instituicao);
            await _repositoryInstituicao.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
